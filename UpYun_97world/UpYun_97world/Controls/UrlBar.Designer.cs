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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlBar));
            this.BtnUpFolder = new DevExpress.XtraEditors.SimpleButton();
            this.CbbUrl = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CbbUrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnUpFolder
            // 
            this.BtnUpFolder.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.BtnUpFolder.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpFolder.Image")));
            this.BtnUpFolder.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopLeft;
            this.BtnUpFolder.Location = new System.Drawing.Point(-1, -1);
            this.BtnUpFolder.Name = "BtnUpFolder";
            this.BtnUpFolder.Size = new System.Drawing.Size(24, 24);
            this.BtnUpFolder.TabIndex = 3;
            // 
            // CbbUrl
            // 
            this.CbbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbbUrl.EditValue = "";
            this.CbbUrl.Location = new System.Drawing.Point(24, 3);
            this.CbbUrl.Name = "CbbUrl";
            this.CbbUrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CbbUrl.Size = new System.Drawing.Size(156, 20);
            this.CbbUrl.TabIndex = 4;
            // 
            // UrlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnUpFolder);
            this.Controls.Add(this.CbbUrl);
            this.Name = "UrlBar";
            this.Size = new System.Drawing.Size(183, 26);
            ((System.ComponentModel.ISupportInitialize)(this.CbbUrl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnUpFolder;
        private DevExpress.XtraEditors.ComboBoxEdit CbbUrl;



    }
}
