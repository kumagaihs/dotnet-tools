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
        /// ピクチャーBOXの右クリックメニュー
        /// </summary>
        private ContextMenuStrip picMenu;

        public ImageView()
        {
            InitializeComponent();

            // サムネイルサイズを設定
            picWidthTextBox.Text = "200";
            picHeightTextBox.Text = "200";

            // ドライブ一覧を走査してツリーに追加
            reloadFileTreeView(Environment.GetLogicalDrives());

            // カレントディレクトリを保存先パスに初期設定
            this.saveDirTextBox.Text = Environment.CurrentDirectory;

            // XXX : Debug
            //reloadFileTreeView(new string[] { @"C:\work" });

            // ピクチャーBOXの右クリックメニュー
            this.picMenu = new ContextMenuStrip();
            ToolStripMenuItem cmenuItem = new ToolStripMenuItem();
            cmenuItem.Text = "保存";
            cmenuItem.Click += fullPictureBox_Menu_Save;
            picMenu.Items.Add(cmenuItem);
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

        private void fileTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            reloadThumbnail(e.Node.FullPath);
        }

        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void baseDirResetButton_Click(object sender, EventArgs e)
        {
            reloadFileTreeView(new String[] { baseDirTextBox.Text });
        }

        private void reloadThumbnail(String dir)
        {
            // サムネイルペインをクリア
            thumbnailPanel.Controls.Clear();

            // ファイル一覧取得
            List<String> files = Directory.GetFiles(dir).ToList<String>();

            // サムネイル表示
            Task task = Task.Run(() => {
                int thumWidth = int.Parse(picWidthTextBox.Text);
                int thumHeight = int.Parse(picHeightTextBox.Text);
                int marginX = 1;
                int marginY = 1;
                int col = 0;
                int row = 0;
                foreach (String file in files) {
                    try {
                        PictureBox pic = createPictureBox(file, col * (thumWidth + marginX), row * (thumHeight + marginY), thumWidth, thumHeight);
                        Invoke(new Action(() =>
                        {
                            thumbnailPanel.Controls.Add(pic);
                        }));
                    }
                    catch (Exception e)
                    {
                        // Do nothing.
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

        private Object lockObject = new Object();

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
                // 縦長の画像
                if (img.Width < img.Height)
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
                // 横長の画像
                else if (img.Height < img.Width)
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
                pic.ContextMenuStrip = this.picMenu;

                return pic;
            }
        }

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
            pic.ContextMenuStrip = this.picMenu;

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
    }
}
