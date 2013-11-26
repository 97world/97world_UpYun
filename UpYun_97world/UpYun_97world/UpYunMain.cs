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
            UrlBarLocal.CBEUrl.KeyDown += new KeyEventHandler(LocalUrlEnter);
            UrlBarLocal.UpButton.Click += new EventHandler(BtnUpLocal);

            //本地浏览器工具栏相关控件事件的绑定和实现
            LocalToolsBarMain.BtnMyPc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnMyPcLocal_click);
            LocalToolsBarMain.BtnDesktop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDesktopLocal_click);
            LocalToolsBarMain.BtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnRefreshLocal_click);
            LocalToolsBarMain.BtnTrans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnTransLocal_click);
            LocalToolsBarMain.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDelLocal_click);
            LocalToolsBarMain.BtnNewFloder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnNewFolderLocal_click);
            LocalToolsBarMain.BtnMyFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnMyFolderLocal_click);

            //远程浏览器地址栏相关控件事件的绑定和实现
            UrlBarWeb.CBEUrl.KeyDown += new KeyEventHandler(WebUrlEnter);
            UrlBarWeb.UpButton.Click += new EventHandler(BtnUpWeb);

            //远程浏览器工具栏相关控件时间的绑定和实现
            WebToolsBarMain.BtnOperator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnOperatorWeb_click);
            WebToolsBarMain.BtnHome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnHomeWeb_click);
            WebToolsBarMain.BtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnRefreshWeb_click);
            WebToolsBarMain.BtnTrans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnTransWeb_click);
            WebToolsBarMain.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDelWeb_click);
            WebToolsBarMain.BtnNewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnNewFolderWeb_click);
            WebToolsBarMain.BtnLink.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnLinkWeb_click);
        }

        public delegate void setUrlBar(string webpath);

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunMain_Load(object sender, EventArgs e)
        {
            ToolsLibrary.IniFile iniFile=new ToolsLibrary.IniFile();
            if (String.Compare(iniFile.IniReadValue("ifconfig", "auto"), "true", true) == 0)
            {
                IfLogin = true;
                UpYun_Controller.Login CtrGetUserIfm = new UpYun_Controller.Login();
                userInformation = CtrGetUserIfm.getUserInformationByIni();
            }
            refreshLocalMain();
            refreshWebMain();
        }

        #region 控件事件

        /// <summary>
        /// 菜单操作员登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunLogin upYunLogin = new UpYunLogin();
            upYunLogin.Owner = this;
            upYunLogin.ShowDialog();
        }


        /// <summary>
        /// 菜单操作员注销事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setControlsWhenLogout();
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
                setControlsWhenLoginSuccess();
                UrlBarWeb.CBEUrl.Text = WebPath;
                WebUrlTextChanged();
            }
        }

        /// <summary>
        /// 刷新主界面Local相关数据
        /// </summary>
        public void refreshLocalMain()
        {
            UrlBarLocal.CBEUrl.Text = LocalPath;
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 网络选择菜单单选效果
        /// </summary>
        /// <param name="sender"></param>
        private void singleCheck(object sender)
        {
            BarCheckItemAuto.Checked = false;
            BarCheckItemTelecom.Checked = false;
            BarCheckItemUnicom.Checked = false;
            BarCheckItemMobile.Checked = false;
            ((DevExpress.XtraBars.BarCheckItem)sender).Checked = true;
            if (BarCheckItemTelecom.Checked == true && userInformation!=null)
            {
                userInformation.upYun.setApiDomain("v1.api.upyun.com");
            }
            else if (BarCheckItemUnicom.Checked == true && userInformation != null)
            {
                userInformation.upYun.setApiDomain("v2.api.upyun.com");
            }
            else if (BarCheckItemMobile.Checked == true && userInformation != null)
            {
                userInformation.upYun.setApiDomain("v3.api.upyun.com");
            }
            else if (BarCheckItemAuto.Checked==true&&userInformation!=null)
            {
                userInformation.upYun.setApiDomain("v0.api.upyun.com");
            }
        }

        /// <summary>
        /// 操作员登录成功后设置控件状态
        /// </summary>
        public void setControlsWhenLoginSuccess()
        {
            WebToolsBarMain.BtnHome.Enabled = true;
            WebToolsBarMain.BtnRefresh.Enabled = true;
            WebToolsBarMain.BtnTrans.Enabled = true;
            WebToolsBarMain.BtnNewFolder.Enabled = true;
            WebToolsBarMain.BtnDel.Enabled = true;
            WebToolsBarMain.BtnLink.Enabled = true;
            BarButtonItemLogout.Enabled = true;
            UrlBarWeb.Enabled = true;
        }

        /// <summary>
        /// 操作员登出后设置控件状态
        /// </summary>
        public void setControlsWhenLogout()
        {
            WebToolsBarMain.BtnHome.Enabled = false;;
            WebToolsBarMain.BtnRefresh.Enabled = false;
            WebToolsBarMain.BtnTrans.Enabled = false;
            WebToolsBarMain.BtnNewFolder.Enabled = false;
            WebToolsBarMain.BtnDel.Enabled = false;
            WebToolsBarMain.BtnLink.Enabled = false;
            BarButtonItemLogout.Enabled = false;
            ListViewWeb.Items.Clear();
            UrlBarWeb.CBEUrl.Text = "/";
            WebPath = "/";
            UrlBarWeb.Enabled = false;
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
                    LocalPath = Environment.SpecialFolder.MyComputer.ToString();
                }
                else
                {
                    LocalPath = LocalPath.Substring(0, LocalPath.Length - 1);
                    LocalPath = LocalPath.Substring(0, LocalPath.LastIndexOf(@"\") + 1);
                }
            }
            else if (ListViewLocal.SelectedItems[0].SubItems[1].Text == "      ")
            {
                LocalPath = LocalPath + ListViewLocal.SelectedItems[0].Text + @"\";
            }
            else if (ListViewLocal.SelectedItems[0].SubItems[2].Text == "本地磁盘")
            {
                LocalPath = ListViewLocal.SelectedItems[0].ImageKey.ToString();
            }
            else
            {
                if (ListViewLocal.SelectedItems[0].Text.Substring(ListViewLocal.SelectedItems[0].Text.LastIndexOf(".")).ToLower() == ".lnk")
                {
                    string target = ToolsLibrary.GetTargetByShortCuts.getTarget(LocalPath + ListViewLocal.SelectedItems[0].Text);
                    if (System.IO.File.Exists(target) == false)
                        LocalPath = target + @"\";
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
                    LocalPath = UrlBarLocal.CBEUrl.Text.Trim() + @"\";
                else
                    LocalPath = UrlBarLocal.CBEUrl.Text.Trim();
                LocalUrlTextChanged();
            }
        }

        /// <summary>
        /// 地址栏文本改变
        /// </summary>
        public void LocalUrlTextChanged()
        {
            UrlBarLocal.CBEUrl.Text = LocalPath;
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
        public void BtnUpLocal(object sender, EventArgs e)
        {
            if (UrlBarLocal.CBEUrl.Text == Environment.SpecialFolder.MyComputer.ToString())
                return;
            else if (UrlBarLocal.CBEUrl.Text.Length == 3)
                LocalPath = Environment.SpecialFolder.MyComputer.ToString();
            else
            {
                LocalPath = LocalPath.Substring(0, UrlBarLocal.CBEUrl.Text.Length - 1);
                LocalPath = LocalPath.Substring(0, UrlBarLocal.CBEUrl.Text.LastIndexOf(@"\") + 1);
            }
            LocalUrlTextChanged();

        }

        /// <summary>
        /// LOCAL工具栏按钮“我的电脑”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMyPcLocal_click(object sender, EventArgs e)
        {
            LocalPath = Environment.SpecialFolder.MyComputer.ToString();
            LocalUrlTextChanged();
        }

        /// <summary>
        /// LOCAL工具栏按钮“桌面”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnDesktopLocal_click(object sender, EventArgs e)
        {
            LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
            LocalUrlTextChanged();
        }

        /// <summary>
        /// LOCAL工具栏按钮“我的文档”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnMyFolderLocal_click(object sender, EventArgs e)
        {
            LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
            LocalUrlTextChanged();
        }

        /// <summary>
        /// LOCAL工具栏按钮“刷新”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnRefreshLocal_click(object sender, EventArgs e)
        {
            LocalUrlTextChanged();
        }

        /// <summary>
        /// LOCAL工具栏按钮“传输”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnTransLocal_click(object sender, EventArgs e)
        {
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            main.upFile(WebPath, LocalPath, ListViewLocal, userInformation, WebUrlTextChanged);
        }

        /// <summary>
        /// LOCAL工具栏按钮“删除”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public void BtnDelLocal_click(object sender, EventArgs e)
        {
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            main.delFileByListView(ListViewLocal,LocalPath);
            BarStaticItemStatus.Caption = "删除成功！";
            LocalUrlTextChanged();
        }

        /// <summary>
        /// LOCAL工具栏按钮“新建文件夹”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNewFolderLocal_click(object sender, EventArgs e)
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
        /// WEB地址栏回车键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WebUrlEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //验证路径是否以“/”结尾，如果不是添加字符“/”               
                if (!UrlBarWeb.CBEUrl.Text.Substring(UrlBarWeb.CBEUrl.Text.Length - 1, 1).Equals(@"/"))
                    WebPath = UrlBarWeb.CBEUrl.Text.Trim() + @"/";
                else
                    WebPath = UrlBarWeb.CBEUrl.Text.Trim();
                WebUrlTextChanged();
            }
        }

        /// <summary>
        /// 远程浏览器地址栏文本改变刷新listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WebUrlTextChanged()
        {
            if(userInformation!=null)
            {
                if (UrlBarWeb.CBEUrl.InvokeRequired)
                {
                    setUrlBar sub = new setUrlBar(delegate(string webpath)
                        {
                            UrlBarWeb.CBEUrl.Text = webpath;
                        });
                    UrlBarWeb.CBEUrl.Invoke(sub, WebPath);
                }
                else
                {
                    UrlBarWeb.CBEUrl.Text = WebPath;
                }
                UpYun_Controller.Main main = new UpYun_Controller.Main();
                main.getFileInformationWeb(ListViewWeb, ImageListWebIcon, WebPath, userInformation);
            }
        }

        public void WebUrlTextChanged(bool isuploadsuccess)
        {
            WebUrlTextChanged();
            if (isuploadsuccess==true)
                BarStaticItemStatus.Caption = "上传成功！";
            else
                BarStaticItemStatus.Caption = "上传失败！";
        }

        private void ListViewWeb_DoubleClick(object sender, EventArgs e)
        {
            if(ListViewWeb.SelectedItems[0].Text=="上级目录")
            {
                WebPath = WebPath.Substring(0, WebPath.Length - 1);
                WebPath = WebPath.Substring(0, WebPath.LastIndexOf(@"/") + 1);
            }
            else if (!(ListViewWeb.SelectedItems[0].Text.Contains(".") && ListViewWeb.SelectedItems[0].Text.Substring(ListViewWeb.SelectedItems[0].Text.LastIndexOf(".")).Length==4))
            {
                WebPath = WebPath + ListViewWeb.SelectedItems[0].Text + "/";
            }
            WebUrlTextChanged();
        }

        /// <summary>
        /// WEB地址栏上级目录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnUpWeb(object sender, EventArgs e)
        { 
            if(WebPath.Equals("/"))
                return;
            WebPath = WebPath.Substring(0, WebPath.Length - 1);
            WebPath = WebPath.Substring(0, WebPath.LastIndexOf(@"/") + 1);
            WebUrlTextChanged();
        }

        /// <summary>
        /// WEB工具栏按钮：操作员登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnOperatorWeb_click(object sender, EventArgs e)
        {
            UpYunLogin upYunLogin = new UpYunLogin();
            upYunLogin.Owner = this;
            upYunLogin.ShowDialog();
        }
        /// <summary>
        /// WEB工具栏按钮：返回主目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnHomeWeb_click(object sender, EventArgs e)
        {
            WebPath = "/";
            WebUrlTextChanged();
        }

        /// <summary>
        /// WEB工具栏按钮：刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnRefreshWeb_click(object sender, EventArgs e)
        {
            WebUrlTextChanged();
        }
        /// <summary>
        /// WEB工具栏按钮：传输
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnTransWeb_click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// WEB工具栏按钮：删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnDelWeb_click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("确定删除选中文件(文件夹)？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                UpYun_Controller.Main main = new UpYun_Controller.Main();
                main.rmFileForWeb(WebPath, userInformation,ListViewWeb);
                WebUrlTextChanged();
            }
        }

        /// <summary>
        /// WEB工具栏按钮：新建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNewFolderWeb_click(object sender, EventArgs e)
        {
            UpYunNewFolder newfolder = new UpYunNewFolder();
            newfolder.Owner = this;
            newfolder.Path = WebPath;
            newfolder.userinformation = userInformation;
            newfolder.ShowDialog();
            WebUrlTextChanged();
        }

        /// <summary>
        /// WEB工具栏按钮：一键复制外链
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnLinkWeb_click(object sender, EventArgs e)
        {
            if (ListViewWeb.SelectedItems[0].Text.Contains(".") && ListViewWeb.SelectedItems[0].Text.Substring(ListViewWeb.SelectedItems[0].Text.LastIndexOf(".")).Length == 4)
            {
                string CopyLink = "";
                if (userInformation.Url.Substring(userInformation.Url.Length - 1).Equals("/"))
                    CopyLink = userInformation.Url + WebPath.Substring(1) + ListViewWeb.SelectedItems[0].Text;
                else
                    CopyLink = userInformation.Url + "/" + WebPath.Substring(1) + ListViewWeb.SelectedItems[0].Text;
                Clipboard.SetDataObject(CopyLink);
            }
        }

        #endregion

    }
}