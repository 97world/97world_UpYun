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
    public partial class UpYunMain : UpYunBase
    {
        public UpYunMain()
        {
            InitializeComponent();

            this.UrlBarLocal.CBEUrl.TextChanged += new EventHandler(UrlTextChanged);
        }

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunMain_Load(object sender, EventArgs e)
        {
            refreshLocalMain();
            refreshWebMain();
        }

        #region 按钮事件

        /// <summary>
        /// 操作员登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunLogin upYunLogin = new UpYunLogin();
            upYunLogin.Owner = this;
            upYunLogin.ShowDialog();
        }

        private void BarCheckItemAuto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            singleCheck(e.Item);
        }

        private void BarCheckItemTelecom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            singleCheck(e.Item);
        }

        private void BarCheckItemUnicom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            singleCheck(e.Item);
        }

        private void BarCheckItemMobile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            singleCheck(e.Item);
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 登录成功后刷新主界面Web相关数据
        /// </summary>
        public void refreshWebMain()
        {
            if (IfLogin == true)
            {
                BarStaticItemOperator.Caption = "操作员：" + userInformation.OperatorName;
                BarStaticItemUseSpace.Caption = "空间已使用：" + ToolsLibrary.Tools.getCommonSize( userInformation.UseSpace);
                BarStaticItemStatus.Caption = "登录成功！";
            }
        }

        /// <summary>
        /// 刷新主界面Local相关数据
        /// </summary>
        public void refreshLocalMain()
        {         
            UrlBarLocal.CBEUrl.Text = LocalPath;
            //fileInformationForListView = main.getFileInformation(path);
            //foreach (ListViewItem item in fileInformationForListView.FileInformaiton.Items)
            //    ListViewLocal.Items.Add((ListViewItem)item.Clone());
            //foreach (string key in fileInformationForListView.FileIconList.Images.Keys)
            //    ImageListLocalIcon.Images.Add(key, (Image)fileInformationForListView.FileIconList.Images[key].Clone());
            //for (int count = 0; count < ImageListLocalIcon.Images.Count; count++)
            //    ListViewLocal.Items[count].ImageKey = fileInformationForListView.FileInformaiton.Items[count].ImageKey;
        }

        /// <summary>
        /// 地址栏文本改变刷新ListViewLocal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UrlTextChanged(object sender, EventArgs e)
        {
            LocalPath = UrlBarLocal.CBEUrl.Text;
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            main.getFileInformation(ListViewLocal, ImageListLocalIcon, LocalPath);
        }

        /// <summary>
        /// 网络选择菜单单选效果
        /// </summary>
        /// <param name="sender"></param>
        private void singleCheck(object sender)
        {
            userInformation = new UpYun_Model.UserInformation();
            BarCheckItemAuto.Checked = false;
            BarCheckItemTelecom.Checked = false;
            BarCheckItemUnicom.Checked = false;
            BarCheckItemMobile.Checked = false;
            ((DevExpress.XtraBars.BarCheckItem)sender).Checked = true;
            if (BarCheckItemTelecom.Checked == true)
            {
                userInformation.Internet = "v1.api.upyun.com";
            }
            else if (BarCheckItemUnicom.Checked == true)
            {
                userInformation.Internet = "v2.api.upyun.com";
            }
            else if (BarCheckItemMobile.Checked == true)
            {
                userInformation.Internet = "v3.api.upyun.com";
            }
            else
            {
                userInformation.Internet = "v0.api.upyun.com";
            }
        }

        #endregion

    }
}