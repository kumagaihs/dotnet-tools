
namespace ImageViewer
{
    partial class ImageView
    {
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageView));
            this.fileTreeView = new System.Windows.Forms.TreeView();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.baseDirTextBox = new System.Windows.Forms.TextBox();
            this.baseDirResetButton = new System.Windows.Forms.Button();
            this.thumbnailSettingOpenButton = new System.Windows.Forms.Button();
            this.thumbnailPanelSettingControl = new ImageViewer.ThumbnailPanelSettingControl();
            this.saveDirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.thumbnailPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTreeView
            // 
            this.fileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTreeView.Location = new System.Drawing.Point(0, 24);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.Size = new System.Drawing.Size(203, 437);
            this.fileTreeView.TabIndex = 0;
            this.fileTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileTreeBiew_BeforeExpand);
            this.fileTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileTreeView_AfterSelect);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.baseDirTextBox);
            this.mainSplitContainer.Panel1.Controls.Add(this.baseDirResetButton);
            this.mainSplitContainer.Panel1.Controls.Add(this.fileTreeView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.thumbnailSettingOpenButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.thumbnailPanelSettingControl);
            this.mainSplitContainer.Panel2.Controls.Add(this.saveDirTextBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.label1);
            this.mainSplitContainer.Panel2.Controls.Add(this.thumbnailPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(842, 460);
            this.mainSplitContainer.SplitterDistance = 205;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // baseDirTextBox
            // 
            this.baseDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseDirTextBox.Location = new System.Drawing.Point(2, 2);
            this.baseDirTextBox.MinimumSize = new System.Drawing.Size(4, 19);
            this.baseDirTextBox.Name = "baseDirTextBox";
            this.baseDirTextBox.Size = new System.Drawing.Size(146, 19);
            this.baseDirTextBox.TabIndex = 1;
            // 
            // baseDirResetButton
            // 
            this.baseDirResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseDirResetButton.Location = new System.Drawing.Point(149, 1);
            this.baseDirResetButton.Name = "baseDirResetButton";
            this.baseDirResetButton.Size = new System.Drawing.Size(53, 21);
            this.baseDirResetButton.TabIndex = 2;
            this.baseDirResetButton.Text = "reload";
            this.baseDirResetButton.UseVisualStyleBackColor = true;
            this.baseDirResetButton.Click += new System.EventHandler(this.baseDirResetButton_Click);
            // 
            // thumbnailSettingOpenButton
            // 
            this.thumbnailSettingOpenButton.Location = new System.Drawing.Point(1, 1);
            this.thumbnailSettingOpenButton.Name = "thumbnailSettingOpenButton";
            this.thumbnailSettingOpenButton.Size = new System.Drawing.Size(107, 23);
            this.thumbnailSettingOpenButton.TabIndex = 11;
            this.thumbnailSettingOpenButton.Text = "設定/Settings";
            this.thumbnailSettingOpenButton.UseVisualStyleBackColor = true;
            this.thumbnailSettingOpenButton.Click += new System.EventHandler(this.ThumbnailSettingOpenButton_Click);
            // 
            // thumbnailPanelSettingControl
            // 
            this.thumbnailPanelSettingControl.Location = new System.Drawing.Point(0, 24);
            this.thumbnailPanelSettingControl.Name = "thumbnailPanelSettingControl";
            this.thumbnailPanelSettingControl.Size = new System.Drawing.Size(360, 400);
            this.thumbnailPanelSettingControl.TabIndex = 10;
            this.thumbnailPanelSettingControl.Visible = false;
            // 
            // saveDirTextBox
            // 
            this.saveDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDirTextBox.Location = new System.Drawing.Point(325, 2);
            this.saveDirTextBox.MinimumSize = new System.Drawing.Size(4, 19);
            this.saveDirTextBox.Name = "saveDirTextBox";
            this.saveDirTextBox.Size = new System.Drawing.Size(304, 19);
            this.saveDirTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "保存先";
            // 
            // thumbnailPanel
            // 
            this.thumbnailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailPanel.AutoScroll = true;
            this.thumbnailPanel.BackColor = System.Drawing.Color.White;
            this.thumbnailPanel.Location = new System.Drawing.Point(0, 24);
            this.thumbnailPanel.Name = "thumbnailPanel";
            this.thumbnailPanel.Size = new System.Drawing.Size(631, 437);
            this.thumbnailPanel.TabIndex = 0;
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 461);
            this.Controls.Add(this.mainSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageView";
            this.Text = "ImageView";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Button baseDirResetButton;
        private System.Windows.Forms.TextBox baseDirTextBox;
        private System.Windows.Forms.Panel thumbnailPanel;
        private System.Windows.Forms.TextBox saveDirTextBox;
        private System.Windows.Forms.Label label1;
        private ThumbnailPanelSettingControl thumbnailPanelSettingControl;
        private System.Windows.Forms.Button thumbnailSettingOpenButton;
    }
}

