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

        private Settings.ThumbnailPanelSettings thumbnailSettings;

        public ThumbnailPanelSettingControl()
        {
            InitializeComponent();
        }

        private void ThumbnailPanelSettingControl_Load(object sender, EventArgs e)
        {
            this.thumbnailSettings = Settings.getInstance().thumbnailPanelSettings;
            RefreshView();
        }

        /// <summary>
        /// Settings.ThumbnailPanelSettingsの設定内容に合わせて画面表示をリフレッシュする
        /// </summary>
        public void RefreshView()
        {
            thumWidthTextBox.Text = this.thumbnailSettings.width.ToString();
            thumHeightTextBox.Text = this.thumbnailSettings.height.ToString();
            thumMarginTextBox.Text = this.thumbnailSettings.margin.ToString();
            thumBgColorButton.BackColor = this.thumbnailSettings.backgroundColor;
            thumSubFolderCheckBox.Checked = this.thumbnailSettings.subFolderSearch;
            thumSubFolderDepthTextBox.Text = this.thumbnailSettings.subFolderDepth.ToString();
            thumShuffleCheckBox.Checked = this.thumbnailSettings.shuffle;
        }

        /// <summary>
        /// 画面設定内容をSettings.ThumbnailPanelSettingsに反映する。
        /// </summary>
        public void UpdateSettings()
        {
            this.thumbnailSettings.width = int.Parse(thumWidthTextBox.Text);
            this.thumbnailSettings.height = int.Parse(thumHeightTextBox.Text);
            this.thumbnailSettings.margin = int.Parse(thumMarginTextBox.Text);
            this.thumbnailSettings.backgroundColor = thumBgColorButton.BackColor;
            this.thumbnailSettings.subFolderSearch = thumSubFolderCheckBox.Checked;
            this.thumbnailSettings.subFolderDepth = int.Parse(thumSubFolderDepthTextBox.Text);
            this.thumbnailSettings.shuffle = thumShuffleCheckBox.Checked;
        }

        /// <summary>
        /// BG Colorボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thumBgColorButton_Click(object sender, EventArgs e)
        {
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
