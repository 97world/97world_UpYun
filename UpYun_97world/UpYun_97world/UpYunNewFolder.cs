using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UpYun_97world
{
    public partial class UpYunNewFolder : DevExpress.XtraEditors.XtraForm
    {
        public UpYunNewFolder()
        {
            InitializeComponent();
        }

        #region 公共变量

        public string Path { get; set; }

        public UpYun_Model.UserInformation userinformation { get; set; }

        #endregion

        private void BtnOK_Click(object sender, EventArgs e)
        {
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            if (Path.Substring(0, 1).Equals("/"))
                main.newFolder(TextBoxFolderName.Text, Path, userinformation);
            else
                main.newFolder(TextBoxFolderName.Text, Path);
            this.Close();
        }

        private void BtnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}