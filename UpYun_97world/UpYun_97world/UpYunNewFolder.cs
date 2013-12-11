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

        /// <summary>
        /// 操作所在的当前目录路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 远程浏览器完成新建、重命名文件/文件夹操作所需要的用户信息对象
        /// </summary>
        public UpYun_Model.UserInformation userinformation { get; set; }

        /// <summary>
        /// 所进行的操作的行为状态（新建文件/文件夹，重命名文件/文件夹）
        /// </summary>
        public string newstatus { get; set; }

        /// <summary>
        /// 进行重命名的文件/文件夹的未经修改的名称
        /// </summary>
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
            else if(newstatus.Equals("newfile"))
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

        /// <summary>
        /// “取消”按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体载入事件（根据当前的操作行为更改窗体部分控件的信息）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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