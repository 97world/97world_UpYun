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

            //本地浏览器地址栏相关控件事件的绑定和实现
            this.UrlBarLocal.CBEUrl.KeyDown += new KeyEventHandler(LocalUrlEnter);
            this.UrlBarLocal.UpButton.Click += new EventHandler(BtnUp);

            //本地浏览器工具栏相关控件事件的绑定和实现
            this.LocalToolsBarMain.BtnMyPc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnMyPc_click);
            this.LocalToolsBarMain.BtnDesktop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDesktop_click);
            this.LocalToolsBarMain.BtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnRefresh_click);
            this.LocalToolsBarMain.BtnTrans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnTrans_click);
            this.LocalToolsBarMain.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDel_click);
            this.LocalToolsBarMain.BtnNewFloder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnNewFolder_click);

            //远程浏览器地址栏相关控件事件的绑定和实现
            this.UrlBarWeb.CBEUrl.KeyDown += new KeyEventHandler(WebUrlTextChanged);

            //远程浏览器工具栏相关控件时间的绑定和实现

        }

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunMain_Load(object sender, EventArgs e)
        {
            UrlBarLocal.CBEUrl.Text = LocalPath;
            refreshLocalMain();
            refreshWebMain();
        }

        #region 控件事件

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
                UrlBarWeb.CBEUrl.Text = WebPath;
            }
        }

        /// <summary>
        /// 刷新主界面Local相关数据
        /// </summary>
        public void refreshLocalMain()
        {
            LocalUrlTextChanged();
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

        #region 本地浏览器控件方法

        /// <summary>
        /// 本地listview控件双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewLocal_DoubleClick(object sender, EventArgs e)
        {
            if (ListViewLocal.SelectedItems[0].Text == "上级目录")
            {
                if (UrlBarLocal.CBEUrl.Text.Length == 3)
                {
                    UrlBarLocal.CBEUrl.Text = Environment.SpecialFolder.MyComputer.ToString();
                }
                else
                {
                    UrlBarLocal.CBEUrl.Text = UrlBarLocal.CBEUrl.Text.Trim().Substring(0, UrlBarLocal.CBEUrl.Text.Length-1);
                    UrlBarLocal.CBEUrl.Text = UrlBarLocal.CBEUrl.Text.Trim().Substring(0, UrlBarLocal.CBEUrl.Text.LastIndexOf(@"\")+1);
                }
            }
            else if (ListViewLocal.SelectedItems[0].SubItems[1].Text == "      ")
            {
                UrlBarLocal.CBEUrl.Text = LocalPath + ListViewLocal.SelectedItems[0].Text + @"\";
            }
            else if (ListViewLocal.SelectedItems[0].SubItems[2].Text == "本地磁盘")
            {
                UrlBarLocal.CBEUrl.Text = ListViewLocal.SelectedItems[0].ImageKey.ToString();
            }
            else
            {
                if (ListViewLocal.SelectedItems[0].Text.Substring(ListViewLocal.SelectedItems[0].Text.LastIndexOf(".")).ToLower() == ".lnk")
                {
                    string target = ToolsLibrary.GetTargetByShortCuts.getTarget(LocalPath + ListViewLocal.SelectedItems[0].Text);
                    if (System.IO.File.Exists(target) == false)
                        UrlBarLocal.CBEUrl.Text = target + @"\";
                    else
                    {
                        System.Diagnostics.Process.Start(target);
                        return;
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start(LocalPath + ListViewLocal.SelectedItems[0].Text);
                    return;
                }
            }
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 地址栏文本改变刷新ListViewLocal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LocalUrlEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //验证路径是否以“\”结尾，如果不是添加字符“\”
                if (UrlBarLocal.CBEUrl.Text.Trim() != Environment.SpecialFolder.MyComputer.ToString() && !UrlBarLocal.CBEUrl.Text.Substring(UrlBarLocal.CBEUrl.Text.Length - 1, 1).Equals(@"\"))
                    UrlBarLocal.CBEUrl.Text = UrlBarLocal.CBEUrl.Text.Trim() + @"\";
                LocalUrlTextChanged();
            }
        }

        public void LocalUrlTextChanged()
        {
            LocalPath = UrlBarLocal.CBEUrl.Text.Trim();
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            if (LocalPath == Environment.SpecialFolder.MyComputer.ToString())
                main.getFileInformationMyPc(ListViewLocal, ImageListLocalIcon, LocalPath);
            else
                main.getFileInformation(ListViewLocal, ImageListLocalIcon, LocalPath);
        }

        /// <summary>
        /// 地址栏上一级按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnUp(object sender, EventArgs e)
        {
            if (UrlBarLocal.CBEUrl.Text == Environment.SpecialFolder.MyComputer.ToString())
                return;
            else if (UrlBarLocal.CBEUrl.Text.Length == 3)
                UrlBarLocal.CBEUrl.Text = Environment.SpecialFolder.MyComputer.ToString();
            else
            {
                UrlBarLocal.CBEUrl.Text = UrlBarLocal.CBEUrl.Text.Trim().Substring(0, UrlBarLocal.CBEUrl.Text.Length - 1);
                UrlBarLocal.CBEUrl.Text = UrlBarLocal.CBEUrl.Text.Trim().Substring(0, UrlBarLocal.CBEUrl.Text.LastIndexOf(@"\") + 1);
            }
            LocalUrlTextChanged();

        }

        /// <summary>
        /// 工具栏按钮“我的电脑”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMyPc_click(object sender, EventArgs e)
        {
            UrlBarLocal.CBEUrl.Text = Environment.SpecialFolder.MyComputer.ToString();
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 工具栏按钮“桌面”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnDesktop_click(object sender, EventArgs e)
        {
            UrlBarLocal.CBEUrl.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\";
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 工具栏按钮“刷新”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnRefresh_click(object sender, EventArgs e)
        {
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 工具栏按钮“传输”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnTrans_click(object sender, EventArgs e)
        { 
            
        }

        /// <summary>
        /// 工具栏按钮“删除”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public void BtnDel_click(object sender, EventArgs e)
        {
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            main.delFileByListView(ListViewLocal,LocalPath);
            BarStaticItemStatus.Caption = "删除成功！";
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 工具栏按钮“新建文件夹”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNewFolder_click(object sender, EventArgs e)
        {
            UpYunNewFolder newfolder = new UpYunNewFolder();
            newfolder.Owner = this;
            newfolder.Path = LocalPath;
            newfolder.ShowDialog();
            LocalUrlTextChanged();
        }

        #endregion

        #region 远程浏览器控件方法

        /// <summary>
        /// 远程浏览器地址栏文本改变刷新listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WebUrlTextChanged(object sender, KeyEventArgs e)
        {
            if(userInformation!=null)
            {
                WebPath = UrlBarWeb.CBEUrl.Text.Trim();
                UpYun_Controller.Main main = new UpYun_Controller.Main();
                main.getFileInformationWeb(ListViewWeb, ImageListWebIcon, WebPath, userInformation);
            }
        }

        private void ListViewWeb_DoubleClick(object sender, EventArgs e)
        {
            if(ListViewWeb.SelectedItems[0].Text=="上级目录")
            {
                WebPath = WebPath.Substring(0, WebPath.Length - 1);
                WebPath = WebPath.Substring(0, WebPath.LastIndexOf(@"\") + 1);
                UrlBarWeb.CBEUrl.Text = WebPath;
            }
        }

        #endregion

    }
}