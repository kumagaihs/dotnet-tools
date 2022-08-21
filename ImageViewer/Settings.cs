using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageViewer {
    public class Settings {

        public const string SETTING_FILE_NAME = "Settings.xml";

        public class ThumbnailPanelSettings {
            public int height { set; get; }
            public int width { set; get; }
            public int margin { set; get; }
            public Color backgroundColor { set; get; }
            public int _backgroundColor_ARGB { set; get; }
            public int maxCount { set; get; }
            public Boolean subFolderSearch { set; get; }
            public int subFolderDepth { set; get; }
            public Boolean shuffle { set; get; }
        }

        private static Settings self;

        // getオンリーにしたいが、XMLシリアライズ用にsetも必要。
        public ThumbnailPanelSettings thumbnailPanelSettings { get; set; }

        // デフォルトコンストラクターはXMLシリアライズ用にpublic。
        public Settings()
        {
            this.thumbnailPanelSettings = new ThumbnailPanelSettings();
        }

        /// <summary>
        /// アプリケーションの設定を取得する。
        /// </summary>
        /// <returns></returns>
        public static Settings getInstance()
        {
            if (self == null) {
                self = new Settings();
            }
            return self;
        }

        /// <summary>
        /// アプリケーションの設定を保存する。
        /// </summary>
        public static void saveSettings()
        {
            // ColorはXMLシリアライズできないため、ARGB値を設定
            self.thumbnailPanelSettings._backgroundColor_ARGB = self.thumbnailPanelSettings.backgroundColor.ToArgb();

            // 実行ファイル格納ディレクトリパス
            string baseDir = Application.StartupPath;
            string filePath = baseDir + "\\" + SETTING_FILE_NAME;

            //ファイルを開く（UTF-8 BOM無し）
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            StreamWriter sw = new StreamWriter(
                filePath,
                false,
                new System.Text.UTF8Encoding(false));

            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, getInstance());
            sw.Close();
        }

        /// <summary>
        /// アプリケーションの設定を読み込む。
        /// </summary>
        /// <returns></returns>
        public static bool loadSettings()
        {
            // 実行ファイル格納ディレクトリパス
            string baseDir = Application.StartupPath;
            string filePath = baseDir + "\\" + SETTING_FILE_NAME;

            try {
                if (File.Exists(filePath)) {
                    //ファイルを開く
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    StreamReader sr = new StreamReader(
                        filePath,
                        new System.Text.UTF8Encoding(false));

                    //XMLファイルから読み込み、逆シリアル化する
                    Settings settings = (Settings)serializer.Deserialize(sr);
                    sr.Close();
                    self = settings;

                    // ColorはXMLシリアライズできないため、ARGB値から復元
                    self.thumbnailPanelSettings.backgroundColor = Color.FromArgb(self.thumbnailPanelSettings._backgroundColor_ARGB);

                    return true;
                }
            }
            catch (Exception e) {
                MessageBox.Show(
                    "設定ファイルが不正なため、デフォルト設定で起動します。\r\nThe configuration file is invalid and will start with default settings.",
                    "Error");
            }
            return false;
        }

    }
}
