using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace UpYun_97world
{
    public partial class UpYunLogin : UpYunBase
    {
        public UpYunLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunLogin_Load(object sender, EventArgs e)
        {
            setControl();
        }


        #region 按钮事件

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 默认按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClean_Click(object sender, EventArgs e)
        {
            TextEditBucket.Text = "";
            TextEditOperator.Text = "";
            TextEditPwd.Text = "";
            TextEditUrl.Text = "";
            DropDownButtonInternet.Text = "自动识别网络";
            CheEditAutoLogin.Checked = false;
            CheEditRemember.Checked = false;
        }

        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            UpYun_Controller.Login CtrLogin = new UpYun_Controller.Login();
            userInformation = CtrLogin.checkBeforeLogin(
                    TextEditBucket,
                    TextEditOperator,
                    TextEditPwd,
                    TextEditUrl,
                    DropDownButtonInternet,
                    CheEditRemember,
                    CheEditAutoLogin                               
                );
            if (userInformation.upYun != null)
            {
                UpYunMain upYunMain = (UpYunMain) this.Owner;
                upYunMain.IfLogin = true;
                upYunMain.userInformation = userInformation;
                upYunMain.refreshWebMain();
                this.Close();
            }
            else
                return;          
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DropDownButtonInternet.Text = "自动识别网络";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DropDownButtonInternet.Text = "中国电信网络";
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DropDownButtonInternet.Text = "中国联通网络";
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DropDownButtonInternet.Text = "中国移动网络";
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 根据窗体的userInformation对象设置各个控件的信息
        /// </summary>
        public void setControl()
        {
            ToolsLibrary.IniFile ini = new ToolsLibrary.IniFile();
            if (ini.IniReadValue("ifconfig", "remember") != "" && !Convert.ToBoolean(string.Compare(ini.IniReadValue("ifconfig", "remember"), "true", true)))
            {
                TextEditBucket.Text = ini.IniReadValue("operatorinformation", "bucket");
                TextEditOperator.Text = ini.IniReadValue("operatorinformation", "operatorname");
                TextEditPwd.Text = ToolsLibrary.Tools.DecryptDES(ini.IniReadValue("operatorinformation", "operatorpwd"), "WORLDCOM");
                TextEditUrl.Text = ini.IniReadValue("operatorinformation", "url");
                DropDownButtonInternet.Text = ini.IniReadValue("operatorinformation", "internet");
                CheEditRemember.Checked = Convert.ToBoolean(ini.IniReadValue("operatorinformation", "ifremember"));
                CheEditAutoLogin.Checked = Convert.ToBoolean(ini.IniReadValue("operatorinformation", "ifauto"));
            }
        }

        /// <summary>
        /// 为部分控件设置快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Modifiers == Keys.Alt)
                TextEditBucket.Focus();
            if (e.KeyCode == Keys.U && e.Modifiers == Keys.Alt)
                TextEditOperator.Focus();
            if (e.KeyCode == Keys.W && e.Modifiers == Keys.Alt)
                TextEditPwd.Focus();
            if (e.KeyCode == Keys.L && e.Modifiers == Keys.Alt)
                TextEditUrl.Focus();
            if (e.KeyCode == Keys.I && e.Modifiers == Keys.Alt)
                DropDownButtonInternet.Focus();
        }

        /// <summary>
        /// 自动登录必须记住密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheEditAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (CheEditAutoLogin.Checked == true)
                CheEditRemember.Checked = true;
        }

        /// <summary>
        /// 取消记住密码则不可设置自动登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheEditRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (CheEditRemember.Checked == false)
                CheEditAutoLogin.Checked = false;
        }

        #endregion


    }
}