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
    public partial class UpYunLogin : UpYunBase
    {
        public UpYunLogin()
        {
            InitializeComponent();
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
            //检查必要信息是否输入，验证操作员密码是否正确
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
                upYunMain.refreshUpYunMain();
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


    }
}