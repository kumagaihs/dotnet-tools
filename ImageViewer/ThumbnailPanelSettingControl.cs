using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer {
    public partial class ThumbnailPanelSettingControl : UserControl {

        public ThumbnailPanelSettingControl()
        {
            InitializeComponent();
        }

        private void ThumbnailPanelSettingControl_Load(object sender, EventArgs e)
        {
            RefreshView();
        }

        /// <summary>
        /// Settings.ThumbnailPanelSettingsの設定内容に合わせて画面表示をリフレッシュする
        /// </summary>
        public void RefreshView()
        {
            Settings.ThumbnailPanelSettings thumbnailSettings = Settings.getInstance().thumbnailPanelSettings;
            thumWidthTextBox.Text = thumbnailSettings.width.ToString();
            thumHeightTextBox.Text = thumbnailSettings.height.ToString();
            thumMarginTextBox.Text = thumbnailSettings.margin.ToString();
            thumBgColorButton.BackColor = thumbnailSettings.backgroundColor;
            thumMaxCountTextBox.Text = thumbnailSettings.maxCount.ToString();
            thumSubFolderCheckBox.Checked = thumbnailSettings.subFolderSearch;
            thumSubFolderDepthTextBox.Text = thumbnailSettings.subFolderDepth.ToString();
            thumShuffleCheckBox.Checked = thumbnailSettings.shuffle;
        }

        /// <summary>
        /// 画面設定内容をSettings.ThumbnailPanelSettingsに反映する。
        /// </summary>
        public void UpdateSettings()
        {
            Settings.ThumbnailPanelSettings thumbnailSettings = Settings.getInstance().thumbnailPanelSettings;
            thumbnailSettings.width = int.Parse(thumWidthTextBox.Text);
            thumbnailSettings.height = int.Parse(thumHeightTextBox.Text);
            thumbnailSettings.margin = int.Parse(thumMarginTextBox.Text);
            thumbnailSettings.backgroundColor = thumBgColorButton.BackColor;
            thumbnailSettings.maxCount = int.Parse(thumMaxCountTextBox.Text);
            thumbnailSettings.subFolderSearch = thumSubFolderCheckBox.Checked;
            thumbnailSettings.subFolderDepth = int.Parse(thumSubFolderDepthTextBox.Text);
            thumbnailSettings.shuffle = thumShuffleCheckBox.Checked;
        }

        /// <summary>
        /// BG Colorボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thumBgColorButton_Click(object sender, EventArgs e)
        {
            Settings.ThumbnailPanelSettings thumbnailSettings = Settings.getInstance().thumbnailPanelSettings;

            //ColorDialogクラスのインスタンスを作成
            ColorDialog cd = new ColorDialog();

            //はじめに選択されている色を設定
            cd.Color = thumbnailSettings.backgroundColor;
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
                //選択された色を取得
                thumbnailSettings.backgroundColor = cd.Color;

                // 色設定ボタンの背景色設定
                this.thumBgColorButton.BackColor = thumbnailSettings.backgroundColor;

                // 色設定ボタンの文字色を反転色にする
                this.thumBgColorButton.ForeColor = Color.FromArgb(thumbnailSettings.backgroundColor.ToArgb() ^ 0xFFFFFF);
            }
        }
    }
}
