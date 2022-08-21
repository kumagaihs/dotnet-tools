namespace ImageViewer {
    partial class ThumbnailPanelSettingControl {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.thumShuffleCheckBox = new System.Windows.Forms.CheckBox();
            this.thumMarginTextBox = new System.Windows.Forms.TextBox();
            this.thumMarginLabel = new System.Windows.Forms.Label();
            this.thumBgColorButton = new System.Windows.Forms.Button();
            this.thumHeightLabel = new System.Windows.Forms.Label();
            this.thumWidthLabel = new System.Windows.Forms.Label();
            this.thumHeightTextBox = new System.Windows.Forms.TextBox();
            this.thumWidthTextBox = new System.Windows.Forms.TextBox();
            this.TitleShum = new System.Windows.Forms.Label();
            this.thumBgColorLabel = new System.Windows.Forms.Label();
            this.thumShuffleLabel = new System.Windows.Forms.Label();
            this.thumMaxCountLabel = new System.Windows.Forms.Label();
            this.thumMaxCountLabelTextBox = new System.Windows.Forms.TextBox();
            this.thumSubFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.thumSubFolderLabel = new System.Windows.Forms.Label();
            this.thumSubFolderDepthLabel = new System.Windows.Forms.Label();
            this.thumSubFolderDepthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thumShuffleCheckBox
            // 
            this.thumShuffleCheckBox.AutoSize = true;
            this.thumShuffleCheckBox.Location = new System.Drawing.Point(197, 178);
            this.thumShuffleCheckBox.Name = "thumShuffleCheckBox";
            this.thumShuffleCheckBox.Size = new System.Drawing.Size(15, 14);
            this.thumShuffleCheckBox.TabIndex = 10;
            this.thumShuffleCheckBox.UseVisualStyleBackColor = true;
            // 
            // thumMarginTextBox
            // 
            this.thumMarginTextBox.Location = new System.Drawing.Point(197, 79);
            this.thumMarginTextBox.Name = "thumMarginTextBox";
            this.thumMarginTextBox.Size = new System.Drawing.Size(48, 19);
            this.thumMarginTextBox.TabIndex = 17;
            // 
            // thumMarginLabel
            // 
            this.thumMarginLabel.Location = new System.Drawing.Point(9, 79);
            this.thumMarginLabel.Name = "thumMarginLabel";
            this.thumMarginLabel.Size = new System.Drawing.Size(182, 19);
            this.thumMarginLabel.TabIndex = 16;
            this.thumMarginLabel.Text = "画像間の余白/Margin";
            this.thumMarginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumBgColorButton
            // 
            this.thumBgColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.thumBgColorButton.Location = new System.Drawing.Point(197, 104);
            this.thumBgColorButton.Name = "thumBgColorButton";
            this.thumBgColorButton.Size = new System.Drawing.Size(123, 21);
            this.thumBgColorButton.TabIndex = 15;
            this.thumBgColorButton.Text = "変更/change";
            this.thumBgColorButton.UseVisualStyleBackColor = false;
            this.thumBgColorButton.Click += new System.EventHandler(this.thumBgColorButton_Click);
            // 
            // thumHeightLabel
            // 
            this.thumHeightLabel.Location = new System.Drawing.Point(9, 54);
            this.thumHeightLabel.Name = "thumHeightLabel";
            this.thumHeightLabel.Size = new System.Drawing.Size(182, 19);
            this.thumHeightLabel.TabIndex = 11;
            this.thumHeightLabel.Text = "画像高さ/Height";
            this.thumHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumWidthLabel
            // 
            this.thumWidthLabel.Location = new System.Drawing.Point(9, 29);
            this.thumWidthLabel.Name = "thumWidthLabel";
            this.thumWidthLabel.Size = new System.Drawing.Size(182, 19);
            this.thumWidthLabel.TabIndex = 12;
            this.thumWidthLabel.Text = "画像横幅/Width";
            this.thumWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumHeightTextBox
            // 
            this.thumHeightTextBox.Location = new System.Drawing.Point(197, 54);
            this.thumHeightTextBox.MinimumSize = new System.Drawing.Size(4, 19);
            this.thumHeightTextBox.Name = "thumHeightTextBox";
            this.thumHeightTextBox.Size = new System.Drawing.Size(48, 19);
            this.thumHeightTextBox.TabIndex = 14;
            // 
            // thumWidthTextBox
            // 
            this.thumWidthTextBox.Location = new System.Drawing.Point(197, 29);
            this.thumWidthTextBox.MinimumSize = new System.Drawing.Size(4, 19);
            this.thumWidthTextBox.Name = "thumWidthTextBox";
            this.thumWidthTextBox.Size = new System.Drawing.Size(48, 19);
            this.thumWidthTextBox.TabIndex = 1;
            // 
            // TitleShum
            // 
            this.TitleShum.AutoSize = true;
            this.TitleShum.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TitleShum.Location = new System.Drawing.Point(7, 4);
            this.TitleShum.Name = "TitleShum";
            this.TitleShum.Size = new System.Drawing.Size(244, 12);
            this.TitleShum.TabIndex = 18;
            this.TitleShum.Text = "サムネイル表示設定 / Thumbnail Settings";
            // 
            // thumBgColorLabel
            // 
            this.thumBgColorLabel.Location = new System.Drawing.Point(9, 106);
            this.thumBgColorLabel.Name = "thumBgColorLabel";
            this.thumBgColorLabel.Size = new System.Drawing.Size(182, 19);
            this.thumBgColorLabel.TabIndex = 16;
            this.thumBgColorLabel.Text = "背景色/Background color";
            this.thumBgColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumShuffleLabel
            // 
            this.thumShuffleLabel.Location = new System.Drawing.Point(9, 176);
            this.thumShuffleLabel.Name = "thumShuffleLabel";
            this.thumShuffleLabel.Size = new System.Drawing.Size(182, 19);
            this.thumShuffleLabel.TabIndex = 16;
            this.thumShuffleLabel.Text = "画像をシャッフル/Shuffle";
            this.thumShuffleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumMaxCountLabel
            // 
            this.thumMaxCountLabel.Location = new System.Drawing.Point(9, 131);
            this.thumMaxCountLabel.Name = "thumMaxCountLabel";
            this.thumMaxCountLabel.Size = new System.Drawing.Size(182, 19);
            this.thumMaxCountLabel.TabIndex = 16;
            this.thumMaxCountLabel.Text = "画像の最大表示数/Max count";
            this.thumMaxCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumMaxCountLabelTextBox
            // 
            this.thumMaxCountLabelTextBox.Location = new System.Drawing.Point(197, 131);
            this.thumMaxCountLabelTextBox.Name = "thumMaxCountLabelTextBox";
            this.thumMaxCountLabelTextBox.Size = new System.Drawing.Size(48, 19);
            this.thumMaxCountLabelTextBox.TabIndex = 17;
            // 
            // thumSubFolderCheckBox
            // 
            this.thumSubFolderCheckBox.AutoSize = true;
            this.thumSubFolderCheckBox.Location = new System.Drawing.Point(197, 156);
            this.thumSubFolderCheckBox.Name = "thumSubFolderCheckBox";
            this.thumSubFolderCheckBox.Size = new System.Drawing.Size(15, 14);
            this.thumSubFolderCheckBox.TabIndex = 10;
            this.thumSubFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // thumSubFolderLabel
            // 
            this.thumSubFolderLabel.Location = new System.Drawing.Point(9, 154);
            this.thumSubFolderLabel.Name = "thumSubFolderLabel";
            this.thumSubFolderLabel.Size = new System.Drawing.Size(182, 19);
            this.thumSubFolderLabel.TabIndex = 16;
            this.thumSubFolderLabel.Text = "サブフォルダも表示/View sub folder";
            this.thumSubFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumSubFolderDepthLabel
            // 
            this.thumSubFolderDepthLabel.Location = new System.Drawing.Point(218, 154);
            this.thumSubFolderDepthLabel.Name = "thumSubFolderDepthLabel";
            this.thumSubFolderDepthLabel.Size = new System.Drawing.Size(73, 19);
            this.thumSubFolderDepthLabel.TabIndex = 16;
            this.thumSubFolderDepthLabel.Text = "階層/Depth";
            this.thumSubFolderDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thumSubFolderDepthTextBox
            // 
            this.thumSubFolderDepthTextBox.Location = new System.Drawing.Point(297, 154);
            this.thumSubFolderDepthTextBox.Name = "thumSubFolderDepthTextBox";
            this.thumSubFolderDepthTextBox.Size = new System.Drawing.Size(48, 19);
            this.thumSubFolderDepthTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(251, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "※未実装";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(218, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "※未実装";
            // 
            // ThumbnailPanelSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleShum);
            this.Controls.Add(this.thumSubFolderDepthTextBox);
            this.Controls.Add(this.thumMaxCountLabelTextBox);
            this.Controls.Add(this.thumMarginTextBox);
            this.Controls.Add(this.thumSubFolderDepthLabel);
            this.Controls.Add(this.thumSubFolderLabel);
            this.Controls.Add(this.thumShuffleLabel);
            this.Controls.Add(this.thumMaxCountLabel);
            this.Controls.Add(this.thumBgColorLabel);
            this.Controls.Add(this.thumMarginLabel);
            this.Controls.Add(this.thumBgColorButton);
            this.Controls.Add(this.thumHeightLabel);
            this.Controls.Add(this.thumWidthLabel);
            this.Controls.Add(this.thumHeightTextBox);
            this.Controls.Add(this.thumWidthTextBox);
            this.Controls.Add(this.thumSubFolderCheckBox);
            this.Controls.Add(this.thumShuffleCheckBox);
            this.Name = "ThumbnailPanelSettingControl";
            this.Size = new System.Drawing.Size(360, 400);
            this.Load += new System.EventHandler(this.ThumbnailPanelSettingControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox thumShuffleCheckBox;
        private System.Windows.Forms.TextBox thumMarginTextBox;
        private System.Windows.Forms.Label thumMarginLabel;
        private System.Windows.Forms.Button thumBgColorButton;
        private System.Windows.Forms.Label thumHeightLabel;
        private System.Windows.Forms.Label thumWidthLabel;
        private System.Windows.Forms.TextBox thumHeightTextBox;
        private System.Windows.Forms.TextBox thumWidthTextBox;
        private System.Windows.Forms.Label TitleShum;
        private System.Windows.Forms.Label thumBgColorLabel;
        private System.Windows.Forms.Label thumShuffleLabel;
        private System.Windows.Forms.Label thumMaxCountLabel;
        private System.Windows.Forms.TextBox thumMaxCountLabelTextBox;
        private System.Windows.Forms.CheckBox thumSubFolderCheckBox;
        private System.Windows.Forms.Label thumSubFolderLabel;
        private System.Windows.Forms.Label thumSubFolderDepthLabel;
        private System.Windows.Forms.TextBox thumSubFolderDepthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
