
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
            this.baseDirSelectButton = new System.Windows.Forms.Button();
            this.thumbnailSettingOpenButton = new System.Windows.Forms.Button();
            this.saveDirTextBox = new System.Windows.Forms.TextBox();
            this.saveDirLabel = new System.Windows.Forms.Label();
            this.thumbnailPanel = new System.Windows.Forms.Panel();
            this.saveDirSelectButton = new System.Windows.Forms.Button();
            this.thumRefreshButton = new System.Windows.Forms.Button();
            this.thumbnailPanelSettingControl = new ImageViewer.ThumbnailPanelSettingControl();
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
            this.mainSplitContainer.Panel1.Controls.Add(this.baseDirSelectButton);
            this.mainSplitContainer.Panel1.Controls.Add(this.fileTreeView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.thumRefreshButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.thumbnailSettingOpenButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.saveDirSelectButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.thumbnailPanelSettingControl);
            this.mainSplitContainer.Panel2.Controls.Add(this.saveDirTextBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.saveDirLabel);
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
            this.baseDirTextBox.Size = new System.Drawing.Size(113, 19);
            this.baseDirTextBox.TabIndex = 1;
            this.baseDirTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.baseDirTextBox_KeyDown);
            // 
            // baseDirSelectButton
            // 
            this.baseDirSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseDirSelectButton.Location = new System.Drawing.Point(117, 1);
            this.baseDirSelectButton.Name = "baseDirSelectButton";
            this.baseDirSelectButton.Size = new System.Drawing.Size(85, 21);
            this.baseDirSelectButton.TabIndex = 2;
            this.baseDirSelectButton.Text = "参照/Select";
            this.baseDirSelectButton.UseVisualStyleBackColor = true;
            this.baseDirSelectButton.Click += new System.EventHandler(this.baseDirSelectButton_Click);
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
            // saveDirTextBox
            // 
            this.saveDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDirTextBox.Location = new System.Drawing.Point(326, 2);
            this.saveDirTextBox.MinimumSize = new System.Drawing.Size(4, 19);
            this.saveDirTextBox.Name = "saveDirTextBox";
            this.saveDirTextBox.Size = new System.Drawing.Size(216, 19);
            this.saveDirTextBox.TabIndex = 5;
            // 
            // saveDirLabel
            // 
            this.saveDirLabel.AutoSize = true;
            this.saveDirLabel.Location = new System.Drawing.Point(234, 5);
            this.saveDirLabel.Name = "saveDirLabel";
            this.saveDirLabel.Size = new System.Drawing.Size(86, 12);
            this.saveDirLabel.TabIndex = 3;
            this.saveDirLabel.Text = "保存先/Save to";
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
            // saveDirSelectButton
            // 
            this.saveDirSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDirSelectButton.Location = new System.Drawing.Point(544, 1);
            this.saveDirSelectButton.Name = "saveDirSelectButton";
            this.saveDirSelectButton.Size = new System.Drawing.Size(85, 21);
            this.saveDirSelectButton.TabIndex = 2;
            this.saveDirSelectButton.Text = "参照/Select";
            this.saveDirSelectButton.UseVisualStyleBackColor = true;
            this.saveDirSelectButton.Click += new System.EventHandler(this.saveDirSelectButton_Click);
            // 
            // thumRefreshButton
            // 
            this.thumRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("thumRefreshButton.Image")));
            this.thumRefreshButton.Location = new System.Drawing.Point(115, 1);
            this.thumRefreshButton.Name = "thumRefreshButton";
            this.thumRefreshButton.Size = new System.Drawing.Size(24, 23);
            this.thumRefreshButton.TabIndex = 13;
            this.thumRefreshButton.UseVisualStyleBackColor = true;
            this.thumRefreshButton.Click += new System.EventHandler(this.thumRefreshButton_Click);
            // 
            // thumbnailPanelSettingControl
            // 
            this.thumbnailPanelSettingControl.Location = new System.Drawing.Point(0, 24);
            this.thumbnailPanelSettingControl.Name = "thumbnailPanelSettingControl";
            this.thumbnailPanelSettingControl.Size = new System.Drawing.Size(400, 400);
            this.thumbnailPanelSettingControl.TabIndex = 10;
            this.thumbnailPanelSettingControl.Visible = false;
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
        private System.Windows.Forms.Button baseDirSelectButton;
        private System.Windows.Forms.TextBox baseDirTextBox;
        private System.Windows.Forms.Panel thumbnailPanel;
        private System.Windows.Forms.TextBox saveDirTextBox;
        private System.Windows.Forms.Label saveDirLabel;
        private ThumbnailPanelSettingControl thumbnailPanelSettingControl;
        private System.Windows.Forms.Button thumbnailSettingOpenButton;
        private System.Windows.Forms.Button saveDirSelectButton;
        private System.Windows.Forms.Button thumRefreshButton;
    }
}

