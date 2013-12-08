namespace UpYun_97world
{
    partial class UpYunNewFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelControlFolderName = new DevExpress.XtraEditors.LabelControl();
            this.TextBoxFolderName = new System.Windows.Forms.TextBox();
            this.BtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.BtnEsc = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // LabelControlFolderName
            // 
            this.LabelControlFolderName.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControlFolderName.Location = new System.Drawing.Point(12, 18);
            this.LabelControlFolderName.Name = "LabelControlFolderName";
            this.LabelControlFolderName.Size = new System.Drawing.Size(72, 17);
            this.LabelControlFolderName.TabIndex = 0;
            this.LabelControlFolderName.Text = "文件夹名称：";
            // 
            // TextBoxFolderName
            // 
            this.TextBoxFolderName.Location = new System.Drawing.Point(12, 41);
            this.TextBoxFolderName.Name = "TextBoxFolderName";
            this.TextBoxFolderName.Size = new System.Drawing.Size(260, 22);
            this.TextBoxFolderName.TabIndex = 1;
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnOK.Location = new System.Drawing.Point(55, 83);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "确认";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnEsc
            // 
            this.BtnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnEsc.Location = new System.Drawing.Point(155, 83);
            this.BtnEsc.Name = "BtnEsc";
            this.BtnEsc.Size = new System.Drawing.Size(75, 23);
            this.BtnEsc.TabIndex = 3;
            this.BtnEsc.Text = "取消";
            this.BtnEsc.Click += new System.EventHandler(this.BtnEsc_Click);
            // 
            // UpYunNewFolder
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnEsc;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.Controls.Add(this.BtnEsc);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TextBoxFolderName);
            this.Controls.Add(this.LabelControlFolderName);
            this.Name = "UpYunNewFolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "建立文件夹";
            this.Load += new System.EventHandler(this.UpYunNewFolder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl LabelControlFolderName;
        private System.Windows.Forms.TextBox TextBoxFolderName;
        private DevExpress.XtraEditors.SimpleButton BtnOK;
        private DevExpress.XtraEditors.SimpleButton BtnEsc;
    }
}