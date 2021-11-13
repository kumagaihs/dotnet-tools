
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
            this.picHeightLabel = new System.Windows.Forms.Label();
            this.picWidthLabel = new System.Windows.Forms.Label();
            this.picHeightTextBox = new System.Windows.Forms.TextBox();
            this.picWidthTextBox = new System.Windows.Forms.TextBox();
            this.thumbnailPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.saveDirTextBox = new System.Windows.Forms.TextBox();
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
            this.fileTreeView.Location = new System.Drawing.Point(0, 30);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.Size = new System.Drawing.Size(203, 428);
            this.fileTreeView.TabIndex = 0;
            this.fileTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileTreeBiew_BeforeExpand);
            this.fileTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileTreeView_AfterSelect);
            this.fileTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fileTreeView1_NodeMouseClick);
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
            this.mainSplitContainer.Panel2.Controls.Add(this.saveDirTextBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.label1);
            this.mainSplitContainer.Panel2.Controls.Add(this.picHeightLabel);
            this.mainSplitContainer.Panel2.Controls.Add(this.picWidthLabel);
            this.mainSplitContainer.Panel2.Controls.Add(this.picHeightTextBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.picWidthTextBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.thumbnailPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(842, 460);
            this.mainSplitContainer.SplitterDistance = 205;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // baseDirTextBox
            // 
            this.baseDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseDirTextBox.Location = new System.Drawing.Point(0, 0);
            this.baseDirTextBox.MinimumSize = new System.Drawing.Size(4, 30);
            this.baseDirTextBox.Name = "baseDirTextBox";
            this.baseDirTextBox.Size = new System.Drawing.Size(148, 30);
            this.baseDirTextBox.TabIndex = 2;
            // 
            // baseDirResetButton
            // 
            this.baseDirResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseDirResetButton.Location = new System.Drawing.Point(149, 0);
            this.baseDirResetButton.Name = "baseDirResetButton";
            this.baseDirResetButton.Size = new System.Drawing.Size(53, 30);
            this.baseDirResetButton.TabIndex = 1;
            this.baseDirResetButton.Text = "reload";
            this.baseDirResetButton.UseVisualStyleBackColor = true;
            this.baseDirResetButton.Click += new System.EventHandler(this.baseDirResetButton_Click);
            // 
            // picHeightLabel
            // 
            this.picHeightLabel.AutoSize = true;
            this.picHeightLabel.Location = new System.Drawing.Point(105, 9);
            this.picHeightLabel.Name = "picHeightLabel";
            this.picHeightLabel.Size = new System.Drawing.Size(38, 12);
            this.picHeightLabel.TabIndex = 3;
            this.picHeightLabel.Text = "Height";
            // 
            // picWidthLabel
            // 
            this.picWidthLabel.AutoSize = true;
            this.picWidthLabel.Location = new System.Drawing.Point(3, 9);
            this.picWidthLabel.Name = "picWidthLabel";
            this.picWidthLabel.Size = new System.Drawing.Size(33, 12);
            this.picWidthLabel.TabIndex = 3;
            this.picWidthLabel.Text = "Width";
            // 
            // picHeightTextBox
            // 
            this.picHeightTextBox.Location = new System.Drawing.Point(149, 0);
            this.picHeightTextBox.MinimumSize = new System.Drawing.Size(4, 30);
            this.picHeightTextBox.Name = "picHeightTextBox";
            this.picHeightTextBox.Size = new System.Drawing.Size(49, 19);
            this.picHeightTextBox.TabIndex = 2;
            // 
            // picWidthTextBox
            // 
            this.picWidthTextBox.Location = new System.Drawing.Point(41, 0);
            this.picWidthTextBox.MinimumSize = new System.Drawing.Size(4, 30);
            this.picWidthTextBox.Name = "picWidthTextBox";
            this.picWidthTextBox.Size = new System.Drawing.Size(49, 19);
            this.picWidthTextBox.TabIndex = 2;
            // 
            // thumbnailPanel
            // 
            this.thumbnailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailPanel.AutoScroll = true;
            this.thumbnailPanel.BackColor = System.Drawing.Color.White;
            this.thumbnailPanel.Location = new System.Drawing.Point(0, 30);
            this.thumbnailPanel.Name = "thumbnailPanel";
            this.thumbnailPanel.Size = new System.Drawing.Size(631, 428);
            this.thumbnailPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "保存先";
            // 
            // saveDirTextBox
            // 
            this.saveDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDirTextBox.Location = new System.Drawing.Point(267, 0);
            this.saveDirTextBox.MinimumSize = new System.Drawing.Size(4, 30);
            this.saveDirTextBox.Name = "saveDirTextBox";
            this.saveDirTextBox.Size = new System.Drawing.Size(364, 30);
            this.saveDirTextBox.TabIndex = 2;
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
        private System.Windows.Forms.Label picHeightLabel;
        private System.Windows.Forms.Label picWidthLabel;
        private System.Windows.Forms.TextBox picHeightTextBox;
        private System.Windows.Forms.TextBox picWidthTextBox;
        private System.Windows.Forms.TextBox saveDirTextBox;
        private System.Windows.Forms.Label label1;
    }
}

