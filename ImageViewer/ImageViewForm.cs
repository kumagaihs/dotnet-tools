using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class ImageView : Form
    {
        /// <summary>
        /// 現在ツリービューで選択されているディレクトリ
        /// </summary>
        private string nowSelectedTreeViewDir;

        private Color thumbnailBgColor;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public ImageView()
        {
            InitializeComponent();

            // サムネイルサイズを設定
            picWidthTextBox.Text = "150";
            picHeightTextBox.Text = "150";
            picMarginTextBox.Text = "1";
            // サムネイルの背景色を設定
            setThumbnailBgColor(Color.White);

            // ドライブ一覧を走査してツリーに追加
            reloadFileTreeView(Environment.GetLogicalDrives());

            // カレントディレクトリを保存先パスに初期設定
            this.saveDirTextBox.Text = Environment.CurrentDirectory;

            // XXX : Debug
            //reloadFileTreeView(new string[] { @"C:\work" });

        }

        /// <summary>
        /// ツリービューを指定されたパスをベースに更新する。
        /// </summary>
        /// <param name="paths">ツリービューのベースにするパス（複数指定可能）</param>
        private void reloadFileTreeView(String[] paths)
        {
            // ツリーをクリア
            fileTreeView.Nodes.Clear();

            // パスをツリーに追加
            foreach (String path in paths)
            {
                // 新規ノード作成
                // プラスボタンを表示するため空のノードを追加しておく
                TreeNode node = new TreeNode(path);
                node.Nodes.Add(new TreeNode());
                fileTreeView.Nodes.Add(node);
            }
        }

        /// <summary>
        /// ツリービュー項目展開時（前）のイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileTreeBiew_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            String path = node.FullPath;
            node.Nodes.Clear();

            try
            {
                DirectoryInfo dirList = new DirectoryInfo(path);
                foreach (DirectoryInfo di in dirList.GetDirectories())
                {
                    TreeNode child = new TreeNode(di.Name);
                    child.Nodes.Add(new TreeNode());
                    node.Nodes.Add(child);
                }
            }
            catch (IOException ie)
            {
                MessageBox.Show(ie.Message, "選択エラー");
            }

        }

        /// <summary>
        /// ツリービューでディレクトリが選択された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            reloadThumbnail(e.Node.FullPath);
        }

        /// <summary>
        /// ツリービューのベースディレクトリreloadボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseDirResetButton_Click(object sender, EventArgs e)
        {
            reloadFileTreeView(new String[] { baseDirTextBox.Text });
        }

        /// <summary>
        /// サムネイルのリロード処理
        /// </summary>
        /// <param name="dir"></param>
        private void reloadThumbnail(String dir)
        {
            // サムネイルペインをクリア
            for (int i = 0; i < thumbnailPanel.Controls.Count; i++) {
                PictureBox pic = (PictureBox)thumbnailPanel.Controls[i];
                if (pic.Image != null) {
                    pic.Image.Dispose();
                }
                pic.MouseClick -= thumbnalePictureBox_MouseClick;
                pic.Dispose();
                thumbnailPanel.Controls.Remove(pic);
            }
            thumbnailPanel.Controls.Clear();

            // 処理中ディレクトリの更新
            this.nowSelectedTreeViewDir = dir;

            // ファイル一覧取得
            List<String> files = Directory.GetFiles(dir).ToList<String>();
            if (picShuffleCheckBox.Checked) {
                // ファイル一覧をシャッフル
                Random rand = new Random();
                files = files.OrderBy(_ => rand.Next()).ToList();
            }

            // サムネイル表示
            Task task = Task.Run(() => {
                int thumWidth = int.Parse(picWidthTextBox.Text);
                int thumHeight = int.Parse(picHeightTextBox.Text);
                int marginX = int.Parse(picMarginTextBox.Text);
                int marginY = int.Parse(picMarginTextBox.Text);
                int col = 0;
                int row = 0;
                foreach (String file in files) {
                    try {
                        if (nowSelectedTreeViewDir != dir)
                        {
                            // ツリービューで別のディレクトリが選択された場合は処理を中断
                            break;
                        }

                        PictureBox pic = createPictureBox(file, col * (thumWidth + marginX), row * (thumHeight + marginY), thumWidth, thumHeight);
                        Invoke(new Action(() =>
                        {
                            // スクロール分ずれてパネルに配置されてしまうので、スクロール分の位置補正を行う。
                            Point adjust = pic.Location;
                            adjust.Offset(-thumbnailPanel.HorizontalScroll.Value, -thumbnailPanel.VerticalScroll.Value);
                            pic.Location = adjust;

                            thumbnailPanel.Controls.Add(pic);
                        }));
                    }
                    catch (Exception e)
                    {
                        continue;
                    }

                    if (((col + 2) * (thumWidth + marginX)) > thumbnailPanel.Width) {
                        col = 0;
                        row++;
                    }
                    else {
                        col++;
                    }
                }
            });
        }

        /// <summary>
        /// サムネイル画像の生成処理がバッティングしない様に制御するロックオブジェクト
        /// </summary>
        private Object lockObject = new Object();

        /// <summary>
        /// サムネイル画像を１つ作成する
        /// </summary>
        /// <param name="file">サムネイルを作る画像ファイルのパス</param>
        /// <param name="x">サムネイル画像を表示する位置（横）</param>
        /// <param name="y">サムネイル画像を表示する位置（横）</param>
        /// <param name="width">サムネイル画像の幅</param>
        /// <param name="height">サムネイル画像の高さ</param>
        /// <returns>サムネイル画像のPictureBoxオブジェクト</returns>
        private PictureBox createPictureBox(String file, int x, int y, int width, int height)
        {
            lock (lockObject)
            {
                // PictureBoxの生成
                PictureBox pic = new PictureBox();
                pic.Text = file;
                pic.Location = new Point(x, y);
                pic.Size = new System.Drawing.Size(width, height);
                pic.MouseClick += thumbnalePictureBox_MouseClick;

                // 画像ファイルの読み込み
                Bitmap canvas = new Bitmap(pic.Width, pic.Height);
                Graphics g = Graphics.FromImage(canvas);
                Image img = Image.FromFile(file);

                // 補間方法として高品質双三次補間を指定する
                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // サムネイル画像サイズに合わせて縮小する
                Rectangle srcRect = new Rectangle(0, 0, pic.Width, pic.Height);

                // 縦長の画像 もしくは 正方形の画像でサムネイルが横長の場合
                if ((img.Width < img.Height) || (img.Width == img.Height && pic.Height < pic.Width))
                {
                    // 横幅を基準にサイズ合わせした場合の高さを算出
                    int resizeHeight = (int)(img.Height * ((double)pic.Width / (double)img.Width));

                    // 表示領域をオーバーする高さを算出
                    int over = resizeHeight - pic.Height;
                    over = (int)(over * ((double)img.Width / (double)pic.Width));

                    // 横幅はそのままで、高さは中央を表示するように上下をトリミング
                    srcRect = new Rectangle(
                        0,
                        over / 2,
                        img.Width,
                        img.Height - (over)
                    );
                }
                // 横長の画像 もしくは 正方形の画像でサムネイルが縦長か正方形の場合
                else
                {
                    // 高さを基準にサイズ合わせした場合の横幅を算出
                    int resizeWidth = (int)(img.Width * ((double)pic.Height / (double)img.Height));

                    // 表示領域をオーバーする横幅を算出
                    int over = resizeWidth - pic.Width;
                    over = (int)(over * ((double)img.Height / (double)pic.Height));

                    // 高さはそのままで、横幅は中央を表示するように左右をトリミング
                    srcRect = new Rectangle(
                        over / 2,
                        0,
                        img.Width - (over),
                        img.Height
                    );
                }

                // 画像のサイズを縮小・トリミングしてcanvasに描画する
                g.DrawImage(img, new Rectangle(0, 0, pic.Width, pic.Height), srcRect, GraphicsUnit.Pixel);

                // リソースを解放する
                img.Dispose();
                g.Dispose();

                // pic.Image = new System.Drawing.Bitmap(file);
                pic.Image = canvas;

                // ピクチャーBOXに右クリックメニューを設定
                ContextMenuStrip picMenu = new ContextMenuStrip();
                ToolStripMenuItem cmenuItem = new ToolStripMenuItem();
                cmenuItem.Text = "保存";
                cmenuItem.Click += fullPictureBox_Menu_Save;
                picMenu.Items.Add(cmenuItem);
                pic.ContextMenuStrip = picMenu;

                return pic;
            }
        }

        /// <summary>
        /// サムネイル画像クリック時の処理。拡大画像を表示する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thumbnalePictureBox_MouseClick(Object sender, MouseEventArgs e)
        {
            // PictureBoxの生成
            PictureBox pic = new PictureBox();
            // pic.BackColor = Color.Transparent;
            pic.Location = new Point(0, 0);
            pic.Text = ((PictureBox)sender).Text;
            pic.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height);
            pic.MouseClick += fullPictureBox_MouseClick;

            // 画像ファイルの読み込み
            Bitmap canvas = new Bitmap(pic.Width, pic.Height);
            Graphics g = Graphics.FromImage(canvas);
            Image img = Image.FromFile(pic.Text);

            // 補間方法として高品質双三次補間を指定する
            g.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // 画像サイズを拡大 or 縮小
            int width = 0;
            int height = 0;
            if ((double)img.Width / img.Height < (double)pic.Width / pic.Height) {
                // 表示領域の方が横長なら、縦方向はいっぱいに表示
                width = (int)(pic.Height * ((double)img.Width / (double)img.Height));
                height = pic.Height;
            }
            else if (img.Height < img.Width) {
                // 画像の方が横長なら、横方向はいっぱいに表示
                width = pic.Width;
                height = (int)(pic.Width * ((double)img.Height / (double)img.Width));
            }

            // 画像表示
            g.DrawImage(img, 0, 0, width, height);

            // PictureBoxを画像サイズぴったりにリサイズ
            pic.Width = width;
            pic.Height = height;

            // リソースを解放する
            img.Dispose();
            g.Dispose();

            // 表示
            pic.Image = canvas;
            this.Controls.Add(pic);

            // 画像を最前面に表示
            pic.BringToFront();

            // ピクチャーBOXに右クリックメニューを設定
            ContextMenuStrip picMenu = new ContextMenuStrip();
            ToolStripMenuItem cmenuItem = new ToolStripMenuItem();
            cmenuItem.Text = "保存";
            cmenuItem.Click += fullPictureBox_Menu_Save;
            picMenu.Items.Add(cmenuItem);
            pic.ContextMenuStrip = picMenu;

        }

        private void fullPictureBox_MouseClick(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Controls.Remove(((PictureBox)sender));
            }
        }

        private void fullPictureBox_Menu_Save(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip menu = (ContextMenuStrip)menuItem.Owner;
            PictureBox pic = (PictureBox)menu.SourceControl;

            DateTime dt = DateTime.Now;
            String ext = Path.GetExtension(pic.Text);
            File.Copy(pic.Text, this.saveDirTextBox.Text + "\\" + dt.ToString("yyyyMMddHHmmssfff") + ext);
        }

        /// <summary>
        /// BG Colorボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thumbnailBgColorButton_Click(object sender, EventArgs e)
        {
            //ColorDialogクラスのインスタンスを作成
            ColorDialog cd = new ColorDialog();

            //はじめに選択されている色を設定
            cd.Color = this.thumbnailBgColor;
            //色の作成部分を表示可能にする
            //デフォルトがTrueのため必要はない
            cd.AllowFullOpen = true;
            //純色だけに制限しない
            //デフォルトがFalseのため必要はない
            cd.SolidColorOnly = false;
            //[作成した色]に指定した色（RGB値）を表示する
            cd.CustomColors = new int[] {
                0x33, 0x66, 0x99, 0xCC, 0x3300, 0x3333,
                0x3366, 0x3399, 0x33CC, 0x6600, 0x6633,
                0x6666, 0x6699, 0x66CC, 0x9900, 0x9933
            };

            //ダイアログを表示する
            if (cd.ShowDialog() == DialogResult.OK) {
                //選択された色に設定する
                setThumbnailBgColor(cd.Color);
            }
        }

        /// <summary>
        /// サムネイルペインの背景色を変更する
        /// </summary>
        /// <param name="newColor"></param>
        private void setThumbnailBgColor(Color newColor)
        {
            this.thumbnailBgColor = newColor;

            // 色設定ボタンの背景色設定
            this.thumbnailBgColorButton.BackColor = this.thumbnailBgColor;
            // 色設定ボタンの文字色を反転色にする
            this.thumbnailBgColorButton.ForeColor = Color.FromArgb(this.thumbnailBgColor.ToArgb() ^ 0xFFFFFF);

            // サムネイルエリアの背景色を設定
            this.thumbnailPanel.BackColor = this.thumbnailBgColor;
        }
    }
}
