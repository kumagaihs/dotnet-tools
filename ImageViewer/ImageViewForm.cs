﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// 初期化処理
        /// </summary>
        public ImageView()
        {
            InitializeComponent();

            // 設定ファイルのロード
            if ( ! Settings.loadSettings()) {
                // 設定ファイルがない場合はデフォルト値を設定
                Settings.ThumbnailPanelSettings thumbnailSettings = Settings.getInstance().thumbnailPanelSettings;

                // サムネイルパネルの設定を初期化
                thumbnailSettings.width = 150;
                thumbnailSettings.height = 150;
                thumbnailSettings.margin = 1;
                thumbnailSettings.backgroundColor = Color.White;
                thumbnailSettings.maxCount = 1000;
                thumbnailSettings.subFolderSearch = false;
                thumbnailSettings.subFolderDepth = 1;
                thumbnailSettings.shuffle = false;
            }
            thumbnailPanelSettingControl.RefreshView();
            reloadThumbnail(null);

            // ドライブ一覧を走査してツリーに追加
            reloadFileTreeView(getInitialDirectories());

            // カレントディレクトリを保存先パスに初期設定
            this.saveDirTextBox.Text = Environment.CurrentDirectory;

            // XXX : Debug
            //reloadFileTreeView(new string[] { @"C:\work" });
        }

        private string[] getInitialDirectories()
        {
            List<string> ret = new List<string>();
            ret.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            ret.AddRange(Environment.GetLogicalDrives());
            return ret.ToArray();
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
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
        private void baseDirSelectButton_Click(object sender, EventArgs e)
        {
            //Folder選択ダイアログを表示
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "表示するフォルダーを選択してください/Please select folder to view";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:";
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog(this) == DialogResult.OK) {
                // 選択されたフォルダでリロードする
                baseDirTextBox.Text = fbd.SelectedPath;
                reloadFileTreeView(new String[] { baseDirTextBox.Text });
            }
        }

        /// <summary>
        /// ツリービューのベースディレクトリTextBoxのキー押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseDirTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (baseDirTextBox.Text.Trim().Length == 0) {
                    reloadFileTreeView(getInitialDirectories());
                }
                else {
                    reloadFileTreeView(new String[] { baseDirTextBox.Text });
                }
            }
        }

        private void ThumbnailSettingOpenButton_Click(object sender, EventArgs e)
        {
            if (thumbnailPanelSettingControl.Visible) {
                thumbnailPanelSettingControl.Visible = false;
                thumbnailSettingOpenButton.Text = "設定/Settings";

                // 変更された設定内容を保存し、サムネイルビューをリロード
                thumbnailPanelSettingControl.UpdateSettings();
                Settings.saveSettings();
                reloadThumbnail(nowSelectedTreeViewDir);
            }
            else {
                thumbnailPanelSettingControl.Visible = true;
                thumbnailSettingOpenButton.Text = "閉じる/Close";
            }
        }

        private void thumRefreshButton_Click(object sender, EventArgs e)
        {
            // サムネイルビューをリロード
            reloadThumbnail(nowSelectedTreeViewDir);
        }

        /// <summary>
        /// 保存先の選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveDirSelectButton_Click(object sender, EventArgs e)
        {
            //Folder選択ダイアログを表示
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "表示するフォルダーを選択してください/Please select folder to view";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = saveDirTextBox.Text;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog(this) == DialogResult.OK) {
                // 選択されたフォルダを設定する
                saveDirTextBox.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// サムネイルのリロード処理
        /// </summary>
        /// <param name="dir"></param>
        private void reloadThumbnail(String dir)
        {
            Settings.ThumbnailPanelSettings thumbnailSettings = Settings.getInstance().thumbnailPanelSettings;

            // サムネイルの背景色を設定
            this.thumbnailPanel.BackColor = thumbnailSettings.backgroundColor;

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

            if (dir == null) {
                return;
            }
            Console.WriteLine(">>>>>>>>>>>>>>> " + dir);

            // 処理中ディレクトリの更新
            this.nowSelectedTreeViewDir = dir;

            // ファイル一覧取得
            List<String> files = findFiles(
                dir,
                thumbnailSettings.subFolderSearch ? thumbnailSettings.subFolderDepth : 0);

            // ファイル一覧をシャッフル
            if (thumbnailSettings.shuffle) {
                Random rand = new Random();
                files = files.OrderBy(_ => rand.Next()).ToList();
            }

            // サムネイル表示
            Task task = Task.Run(() => {
                int thumWidth = thumbnailSettings.width;
                int thumHeight = thumbnailSettings.height;
                int marginX = thumbnailSettings.margin;
                int marginY = thumbnailSettings.margin;
                int col = 0;
                int row = 0;
                for (int i = 0; i < thumbnailSettings.maxCount; i++) {
                    string file = files[i];
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
        /// 指定フォルダのファイル一覧を取得する
        /// </summary>
        /// <param name="dir">対象フォルダ</param>
        /// <param name="maxDepth">サブフォルダを探索する階層の深さ</param>
        /// <returns>ファイル一覧</returns>
        private List<string> findFiles(string dir, int maxDepth)
        {
            List<string> files = new List<string>();
            int curDirCnt = 0;
            if ( ! findFiles(dir, 0, maxDepth, ref curDirCnt, 2000, files)) {
                MessageBox.Show(
                    "サブフォルダ数が2,000を超えたため、処理を中断しました。\r\nThe process is interrupted because the number of subfolders has exceeded 2,000.",
                    "処理中断/Break in processing");
            }
            return files;
        }

        /// <summary>
        /// 指定フォルダのファイル一覧を取得する
        /// </summary>
        /// <param name="curDir">フォルダ</param>
        /// <param name="curDepth">固定でゼロを指定する。再帰呼び出し用パラメータ。</param>
        /// <param name="maxDepth">サブフォルダを検索する深さ。-1は無制限。</param>
        /// <param name="curDirCnt">固定でゼロを指定する。再帰呼び出し用パラメータ。</param>
        /// <param name="maxDirCnt">探索する最大フォルダ数</param>
        /// <param name="files">取得したファイル一覧を格納するリスト</param>
        /// <returns>全てのフォルダを探索し終わった場合はtrue、最大フォルダ数の制限で途中で探索を中断した場合はfalse</returns>
        private bool findFiles(string curDir, int curDepth, int maxDepth, ref int curDirCnt, int maxDirCnt, List<string> files)
        {
            // サブフォルダ数がmaxDirCntを超えた場合は処理中断
            if (maxDirCnt <= curDirCnt) {
                return false;
            }

            // ファイル一覧を取得
            try {
/* ※これだとシャッフルの場合に全ての画像でシャッフルできないので無効化する。
                // 拡張子「jpg」「png」「gif」等の確実に画像と思われるファイルが最大表示数を超えたら探査終了
                int imageCount = files.FindAll(s => Regex.IsMatch(s.ToLower(), "(\\.jpg|\\.jpeg|\\.png|\\.gif|\\.bmp|\\.wmf|\\.tif|\\.tiff|\\.ico)$")).Count();
                if (imageCount > Settings.getInstance().thumbnailPanelSettings.maxCount) {
                    MessageBox.Show(
                        "file limit" + imageCount,
                        "aaa");
                    return true;
                }
*/
                files.AddRange(Directory.GetFiles(curDir).ToList<String>());
            }
            catch (Exception e) {
            }

            // サブフォルダ探索
            if (maxDepth == -1 || curDepth < maxDepth) {
                try {
                    IEnumerable<string> subDirs = Directory.EnumerateDirectories(curDir, "*", SearchOption.TopDirectoryOnly);
                    foreach (string subDir in subDirs) {
                        curDirCnt++;
                        if ( ! findFiles(subDir, curDepth + 1, maxDepth, ref curDirCnt, maxDirCnt, files)) {
                            // ディレクトリの最大数に達したため、途中で処理終了
                            return false;
                        }
                    }
                }
                catch (Exception e) {
                }
            }

            // 探索がすべて終了
            return true;
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
                cmenuItem.Text = "保存/Save";
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
            cmenuItem.Text = "保存/Save";
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

    }
}
