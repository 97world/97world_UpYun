namespace UpYun_97world.Controls
{
    partial class UrlBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CbbUrl = new System.Windows.Forms.ComboBox();
            this.BtnUpFolder = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // CbbUrl
            // 
            this.CbbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbbUrl.FormattingEnabled = true;
            this.CbbUrl.Location = new System.Drawing.Point(21, 2);
            this.CbbUrl.Name = "CbbUrl";
            this.CbbUrl.Size = new System.Drawing.Size(214, 20);
            this.CbbUrl.TabIndex = 4;
            // 
            // BtnUpFolder
            // 
            this.BtnUpFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUpFolder.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.BtnUpFolder.Image = global::UpYun_97world.Properties.Resources.Ribbon_Close_16x16;
            this.BtnUpFolder.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopLeft;
            this.BtnUpFolder.Location = new System.Drawing.Point(2, 2);
            this.BtnUpFolder.Name = "BtnUpFolder";
            this.BtnUpFolder.Size = new System.Drawing.Size(19, 19);
            this.BtnUpFolder.TabIndex = 43;
            // 
            // UrlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.BtnUpFolder);
            this.Controls.Add(this.CbbUrl);
            this.Name = "UrlBar";
            this.Size = new System.Drawing.Size(287, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbbUrl;
        private DevExpress.XtraEditors.SimpleButton BtnUpFolder;



    }
}
