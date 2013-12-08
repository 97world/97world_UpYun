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

        public string newstatus { get; set; }

        public string oldname { get; set; }

        #endregion

        private void BtnOK_Click(object sender, EventArgs e)
        {
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            if (newstatus.Equals("folder"))
            {
                if (Path.Substring(0, 1).Equals("/"))
                    main.newFolder(TextBoxFolderName.Text, Path, userinformation);
                else
                    main.newFolder(TextBoxFolderName.Text, Path);
            }
            else if(newstatus.Equals("file"))
            {
                main.newFile(TextBoxFolderName.Text, Path);
                System.Diagnostics.Process.Start("notepad.exe", Path + TextBoxFolderName.Text);
            }
            else if (newstatus.Equals("renamefile"))
            {
                if (!System.IO.File.Exists(Path + TextBoxFolderName.Text))
                    System.IO.File.Move(Path + oldname, Path + TextBoxFolderName.Text);
                else
                    XtraMessageBox.Show("存在同名文件，是否覆盖？");
            }
            else if (newstatus.Equals("renamefolder"))
            {
                if(!System.IO.Directory.Exists(Path + TextBoxFolderName.Text))
                    System.IO.Directory.Move(Path + oldname, Path + TextBoxFolderName.Text);
                else
                    XtraMessageBox.Show("存在同名文件夹，是否覆盖？");
            }
            this.Close();
        }

        private void BtnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpYunNewFolder_Load(object sender, EventArgs e)
        {
            if (newstatus.Equals("newfile"))
            {
                this.Text = "新建文件";
                LabelControlFolderName.Text = "文件名称：";
            }
            else if(newstatus.Equals("renamefile"))
            {
                this.Text = "重命名";
                LabelControlFolderName.Text = "文件名称：";
                TextBoxFolderName.Text = oldname;
            }
            else if (newstatus.Equals("renamefolder"))
            {
                this.Text = "重命名";
                LabelControlFolderName.Text = "文件夹名称：";
                TextBoxFolderName.Text = oldname;
            }
        }
    }
}