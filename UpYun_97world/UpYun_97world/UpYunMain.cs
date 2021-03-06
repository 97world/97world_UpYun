﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ToolsLibrary;

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
            UrlBarLocal.CBEUrl.SelectedIndexChanged += new EventHandler(LocalUrlBarSelectedItemsChanged);

            //本地浏览器工具栏相关控件事件的绑定和实现
            LocalToolsBarMain.BtnMyPc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnMyPcLocal_click);
            LocalToolsBarMain.BtnDesktop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDesktopLocal_click);
            LocalToolsBarMain.BtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnRefreshLocal_click);
            LocalToolsBarMain.BtnTrans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnTransLocal_click);
            LocalToolsBarMain.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDelLocal_click);
            LocalToolsBarMain.BtnNewFloder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnNewFolderLocal_click);
            LocalToolsBarMain.BtnMyFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnMyFolderLocal_click);
            LocalToolsBarMain.BtnNewFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnNewFileLocal_click);

            //远程浏览器地址栏相关控件事件的绑定和实现
            UrlBarWeb.CBEUrl.KeyDown += new KeyEventHandler(WebUrlEnter);
            UrlBarWeb.UpButton.Click += new EventHandler(BtnUpWeb);
            UrlBarWeb.CBEUrl.SelectedIndexChanged += new EventHandler(WebUrlBarSelectedItemChanged);

            //远程浏览器工具栏相关控件时间的绑定和实现
            WebToolsBarMain.BtnOperator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnOperatorWeb_click);
            WebToolsBarMain.BtnHome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnHomeWeb_click);
            WebToolsBarMain.BtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnRefreshWeb_click);
            WebToolsBarMain.BtnTrans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnTransWeb_click);
            WebToolsBarMain.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnDelWeb_click);
            WebToolsBarMain.BtnNewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnNewFolderWeb_click);
            WebToolsBarMain.BtnLink.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnLinkWeb_click);
            WebToolsBarMain.BtnPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(BtnPreviewWeb_click);
        }

        #region 变量
        public delegate void setUrlBar(string webpath);
        public delegate void setProgressBarDelegate(double num);

        /// <summary>
        /// 本地浏览器、远程浏览器复制文件的源路径
        /// </summary>
        public string localcopyoldurl = "", webcopyoldurl = "";

        /// <summary>
        /// 本地浏览器、远程浏览器复制文件的文件名/文件夹名（数组）
        /// </summary>
        public string[] localcopyoldname, webcopyoldname;

        /// <summary>
        /// 本地浏览器、远程浏览器右键菜单弹出坐标
        /// </summary>
        public Point menutrippoint = new Point();

        /// <summary>
        /// 为实现单选菜单而设置的临时变量，传递上一次选中的item
        /// </summary>
        public DevExpress.XtraBars.BarCheckItem tempItem = new DevExpress.XtraBars.BarCheckItem();
        #endregion

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunMain_Load(object sender, EventArgs e)
        {
            //ListView标题栏点击事件的绑定
            ListViewLocal.ListViewItemSorter = new ListViewColumnSorter();
            ListViewLocal.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);
            ListViewWeb.ListViewItemSorter = new ListViewColumnSorter();
            ListViewWeb.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);

            IniFile iniFile = new IniFile();
            if (String.Compare(iniFile.IniReadValue("ifconfig", "auto"), "true", true) == 0)
            {
                IfLogin = true;
                UpYun_Controller.Login CtrGetUserIfm = new UpYun_Controller.Login();
                userInformation = CtrGetUserIfm.getUserInformationByIni();
            }
            refreshLocalMain();
            refreshWebMain();

            //添加主题样式
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                DevExpress.XtraBars.BarCheckItem subMenu = new DevExpress.XtraBars.BarCheckItem(xafBarManagerMain);
                subMenu.Caption = cnt.SkinName;
                subMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SubItemTheme_ItemClick);
                SubItemTheme.AddItem(subMenu);
            }
        }

        #region 菜单事件

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

        /// <summary>
        /// 菜单点击有惊喜事件
        /// </summary>
        /// <param name="sender"></param>`
        /// <param name="e"></param>
        private void BarButtonItemSuper_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/97world/UpYun_97world");
        }

        /// <summary>
        /// 菜单“访问我的BLOG”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemMyblog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.97world.com/");
        }

        /// <summary>
        /// 设置主题事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SubItemTheme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tempItem.Caption != null)
                tempItem.Checked = false;
            tempItem = (DevExpress.XtraBars.BarCheckItem)e.Item;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = e.Item.Caption;
        }

        #region 菜单“网络”单选功能的实现

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
            if (BarCheckItemTelecom.Checked == true && userInformation != null)
                userInformation.upYun.setApiDomain("v1.api.upyun.com");
            else if (BarCheckItemUnicom.Checked == true && userInformation != null)
                userInformation.upYun.setApiDomain("v2.api.upyun.com");
            else if (BarCheckItemMobile.Checked == true && userInformation != null)
                userInformation.upYun.setApiDomain("v3.api.upyun.com");
            else if (BarCheckItemAuto.Checked == true && userInformation != null)
                userInformation.upYun.setApiDomain("v0.api.upyun.com");
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

        #endregion

        #region 辅助方法

        public void LocalUrlBarSelectedItemsChanged(object sender, EventArgs e)
        {
            LocalPath = UrlBarLocal.CBEUrl.SelectedItem.ToString();
            LocalUrlTextChanged();
        }

        public void WebUrlBarSelectedItemChanged(object sender, EventArgs e)
        {
            WebPath = UrlBarWeb.CBEUrl.SelectedItem.ToString();
            WebUrlTextChanged();
        }

        /// <summary>
        /// 登录成功后刷新主界面Web相关数据
        /// </summary>
        public void refreshWebMain()
        {
            if (IfLogin == true)
            {
                BarStaticItemOperator.Caption = "操作员：" + userInformation.OperatorName;
                BarStaticItemUseSpace.Caption = "空间已使用：" + Tools.getCommonSize(userInformation.UseSpace);
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
            WebToolsBarMain.BtnPreview.Enabled = true;
            WebToolsBarMain.BtnPreview.Enabled = true;
            BarButtonItemLogout.Enabled = true;
            UrlBarWeb.Enabled = true;
        }

        /// <summary>
        /// 操作员登出后设置控件状态
        /// </summary>
        public void setControlsWhenLogout()
        {
            WebToolsBarMain.BtnHome.Enabled = false; ;
            WebToolsBarMain.BtnRefresh.Enabled = false;
            WebToolsBarMain.BtnTrans.Enabled = false;
            WebToolsBarMain.BtnNewFolder.Enabled = false;
            WebToolsBarMain.BtnDel.Enabled = false;
            WebToolsBarMain.BtnLink.Enabled = false;
            WebToolsBarMain.BtnPreview.Enabled = false;
            BarButtonItemLogout.Enabled = false;
            ListViewWeb.Items.Clear();
            UrlBarWeb.CBEUrl.Text = "/";
            WebPath = "/";
            UrlBarWeb.Enabled = false;
            IfLogin = false;
        }

        /// <summary>
        /// 控制进度条和相关信息的显示
        /// </summary>
        /// <param name="isupload"></param>
        /// <param name="uploadinformation"></param>
        /// <param name="num"></param>
        /// <param name="speed"></param>
        public void setProgressBar(bool isupload, string uploadinformation, double num, double speed)
        {
            if (isupload == true)
                //BarStaticItemStatus.Caption = "正在上传" + uploadinformation + "上传速度：" + ToolsLibrary.Tools.getCommonSize(speed) + "/s";
                BarStaticItemStatus.Caption = "上传速度：" + ToolsLibrary.Tools.getCommonSize(speed) + "/S";
            else
                BarStaticItemStatus.Caption = "下载速度：" + ToolsLibrary.Tools.getCommonSize(speed) + "/S";
            setProgressBarValue(num);
        }

        /// <summary>
        /// 设置进度条的当前值
        /// </summary>
        /// <param name="num"></param>
        public void setProgressBarValue(double num)
        {
            if (InvokeRequired)
            {
                setProgressBarDelegate spb = new setProgressBarDelegate(delegate(double numprogressbar)
                {
                    barEditItemUploadBar.EditValue = numprogressbar;
                });
                Invoke(spb, new object[] { num });
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
                if (ListViewLocal.SelectedItems[0].Text.Equals(".") && ListViewLocal.SelectedItems[0].Text.Substring(ListViewLocal.SelectedItems[0].Text.LastIndexOf(".")).ToLower() == ".lnk")
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
        /// 地址栏文本改变(刷新ListView)
        /// </summary>
        public void LocalUrlTextChanged()
        {
            if (UrlBarLocal.CBEUrl.InvokeRequired)
            {
                setUrlBar sub = new setUrlBar(delegate(string localpath)
                {
                    UrlBarLocal.CBEUrl.Text = localpath;
                    UrlBarLocal.CBEUrl.Items.Add(localpath);
                });
                UrlBarLocal.CBEUrl.Invoke(sub, LocalPath);
            }
            else
            {
                UrlBarLocal.CBEUrl.Text = LocalPath;
                UrlBarLocal.CBEUrl.Items.Add(LocalPath);
            }
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            if (LocalPath == Environment.SpecialFolder.MyComputer.ToString())
                main.getFileInformationMyPc(ListViewLocal, ImageListLocalIcon, LocalPath);
            else
                main.getFileInformation(ListViewLocal, ImageListLocalIcon, LocalPath);
        }

        /// <summary>
        /// 上传成功后刷新ListView并初始化其他控件信息
        /// </summary>
        /// <param name="issuccess"></param>
        public void LocalUrlTextChanged(bool issuccess)
        {
            LocalUrlTextChanged();
            if (issuccess == true)
                BarStaticItemStatus.Caption = "下载成功！";
            else
                BarStaticItemStatus.Caption = "下载失败！";
            setProgressBarValue(0);
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
                LocalPath = LocalPath.Substring(0, LocalPath.LastIndexOf(@"\") + 1);
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
            main.upFileOrFolder(WebPath, LocalPath, ListViewLocal, userInformation, WebUrlTextChanged, setProgressBar);
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
            if (XtraMessageBox.Show("确定删除选中文件(文件夹)？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                main.delFileByListView(ListViewLocal, LocalPath);
                BarStaticItemStatus.Caption = "删除成功！";
            }
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
            newfolder.newstatus = "folder";
            newfolder.Path = LocalPath;
            newfolder.ShowDialog();
            LocalUrlTextChanged();
        }

        /// <summary>
        /// LOCAL工具栏按钮“新建文件”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnNewFileLocal_click(object sender, EventArgs e)
        {
            LocalPopupMenuNewFile_ItemClick(sender, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
        }

        /// <summary>
        /// 本地浏览器弹出右键菜单并判断显示可用菜单条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewLocal_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = this.ListViewLocal.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                LocalPopupMenuCopy.Enabled = true;
                LocalPopupMenuDefault.Enabled = true;
                LocalPopupMenuDel.Enabled = true;
                LocalPopupMenuNewFile.Enabled = true;
                LocalPopupMenuNewFolder.Enabled = true;
                LocalPopupMenuOpen.Enabled = true;
                LocalPopupMenuProperty.Enabled = true;
                LocalPopupMenuRefresh.Enabled = true;
                LocalPopupMenuRename.Enabled = true;
                LocalPopupMenuStick.Enabled = false;
                LocalPopupMenuTrans.Enabled = true;
                //判断是否有选中条目或者选中条目是否为“上级目录”
                if (ListViewLocal.GetItemAt(p.X, p.Y) != null && ListViewLocal.GetItemAt(p.X, p.Y).SubItems.Count > 1)
                {
                    //判断选中的条目是否是文件夹，选中条目为文件夹禁止传输
                    if (ListViewLocal.GetItemAt(p.X, p.Y).SubItems[1].Text.Equals("      ") || IfLogin == false)
                        LocalPopupMenuTrans.Enabled = false;
                }
                else
                {
                    LocalPopupMenuCopy.Enabled = false;
                    LocalPopupMenuDefault.Enabled = false;
                    LocalPopupMenuDel.Enabled = false;
                    LocalPopupMenuOpen.Enabled = false;
                    LocalPopupMenuProperty.Enabled = false;
                    LocalPopupMenuRename.Enabled = false;
                    LocalPopupMenuTrans.Enabled = false;
                }
                //判断是否进行了“复制”的操作
                if (localcopyoldurl.Length > 0)
                    LocalPopupMenuStick.Enabled = true;
                //弹出右键菜单并记录弹出坐标
                p = new Point(Cursor.Position.X, Cursor.Position.Y);
                PopupMenuLocal.ShowPopup(p);
                menutrippoint = p;
            }

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
            if (userInformation != null)
            {
                if (UrlBarWeb.CBEUrl.InvokeRequired)
                {
                    setUrlBar sub = new setUrlBar(delegate(string webpath)
                        {
                            UrlBarWeb.CBEUrl.Text = webpath;
                            UrlBarWeb.CBEUrl.Items.Add(WebPath);
                        });
                    UrlBarWeb.CBEUrl.Invoke(sub, WebPath);
                }
                else
                {
                    UrlBarWeb.CBEUrl.Text = WebPath;
                    UrlBarWeb.CBEUrl.Items.Add(WebPath);
                }
                UpYun_Controller.Main main = new UpYun_Controller.Main();
                main.getFileInformationWeb(ListViewWeb, ImageListWebIcon, WebPath, userInformation);
            }
        }

        /// <summary>
        /// 数据传输状态的显示并初始化其他控件信息
        /// </summary>
        /// <param name="isuploadsuccess"></param>
        public void WebUrlTextChanged(bool isuploadsuccess)
        {
            WebUrlTextChanged();
            if (isuploadsuccess == true)
                BarStaticItemStatus.Caption = "上传成功！";
            else
                BarStaticItemStatus.Caption = "上传失败！";
            setProgressBarValue(0);
        }

        /// <summary>
        /// 远程浏览器ListView双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewWeb_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ListViewWeb.SelectedItems[0].Text == "上级目录")
            {
                WebPath = WebPath.Substring(0, WebPath.Length - 1);
                WebPath = WebPath.Substring(0, WebPath.LastIndexOf(@"/") + 1);
            }
            else if (!(ListViewWeb.SelectedItems[0].Text.Contains(".") && ListViewWeb.SelectedItems[0].Text.Substring(ListViewWeb.SelectedItems[0].Text.LastIndexOf(".")).Length == 4))
                WebPath = WebPath + ListViewWeb.SelectedItems[0].Text + "/";
            else
            {
                UpYunPreview upYunPreview = new UpYunPreview();
                UpYun_Controller.Main main = new UpYun_Controller.Main();
                Image i = main.previewFile(userInformation.Url, WebPath, ListViewWeb.SelectedItems[0].Text);
                upYunPreview.Width = i.Width;
                upYunPreview.Height = i.Height;
                upYunPreview.BackgroundImage = i;
                upYunPreview.Show();
                return;
            }
            WebUrlTextChanged();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// WEB地址栏上级目录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnUpWeb(object sender, EventArgs e)
        {
            if (WebPath.Equals("/"))
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
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            main.downloadFile(LocalPath, WebPath, ListViewWeb, userInformation, LocalUrlTextChanged, setProgressBar);
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
                main.rmFileForWeb(WebPath, userInformation, ListViewWeb);
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
            newfolder.newstatus = "folder";
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

        /// <summary>
        /// WEB工具栏按钮：预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnPreviewWeb_click(object sender, EventArgs e)
        {
            UpYunPreview upYunPreview = new UpYunPreview();
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            Image i = main.previewFile(userInformation.Url, WebPath, ListViewWeb.SelectedItems[0].Text);
            upYunPreview.Width = i.Width;
            upYunPreview.Height = i.Height;
            upYunPreview.BackgroundImage = i;
            upYunPreview.Show();
        }

        /// <summary>
        /// 远程浏览器弹出右键菜单并判断显示可用的菜单条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewWeb_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = this.ListViewWeb.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                WebPopupMenuLink.Enabled = false;
                WebPopupMenuTrans.Enabled = false;
                WebPopupMenuDel.Enabled = false;
                WebPopupMenuNewFolder.Enabled = false;
                WebPopupMenuRefresh.Enabled = false;
                WebPopupMenuPreview.Enabled = false;
                //判断操作员是否登录
                if (IfLogin == true)
                {
                    WebPopupMenuRefresh.Enabled = true;
                    WebPopupMenuNewFolder.Enabled = true;
                    if (ListViewWeb.GetItemAt(p.X, p.Y) != null)
                    {
                        WebPopupMenuDel.Enabled = true;
                        if (!ListViewWeb.GetItemAt(p.X, p.Y).SubItems[1].Text.Equals("0 B"))
                        {
                            WebPopupMenuLink.Enabled = true;
                            WebPopupMenuTrans.Enabled = true;
                            WebPopupMenuPreview.Enabled = true;
                        }
                    }
                }
                p = new Point(Cursor.Position.X, Cursor.Position.Y);
                PopupMenuWeb.ShowPopup(p);
                menutrippoint = p;
            }
        }

        #endregion

        #region 本地浏览器右键菜单事件

        /// <summary>
        /// 本地浏览器右键菜单“传输”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuTrans_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnTransLocal_click(sender, new EventArgs());
        }

        /// <summary>
        /// 本地浏览器右键菜单“打开”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListViewLocal_DoubleClick(sender, new EventArgs());
        }

        /// <summary>
        /// 本地浏览器右键菜单“资源管理器菜单”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShellContextMenu scm = new ShellContextMenu();
            FileInfo[] files = new FileInfo[1];
            Point p = this.ListViewLocal.PointToClient(new Point(menutrippoint.X, menutrippoint.Y));
            files[0] = new FileInfo(LocalPath + ListViewLocal.GetItemAt(p.X, p.Y).Text);
            scm.ShowContextMenu(files, menutrippoint);
        }

        /// <summary>
        /// 本地浏览器右键菜单“复制”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            localcopyoldurl = "";
            localcopyoldname = null;
            localcopyoldname = new string[ListViewLocal.SelectedItems.Count];
            for (int i = 0; i < ListViewLocal.SelectedItems.Count; i++)
                localcopyoldname[i] = ListViewLocal.SelectedItems[i].Text;
            localcopyoldurl = LocalPath;
        }

        /// <summary>
        /// 本地浏览器右键菜单“粘贴”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuStick_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (localcopyoldurl.Length == 0)
                return;
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            main.copyFileLocal(localcopyoldurl, localcopyoldname, LocalPath);
            LocalUrlTextChanged();
            localcopyoldurl = "";
            localcopyoldname = null;
        }

        /// <summary>
        /// 本地浏览器右键菜单“删除”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnDelLocal_click(sender, new EventArgs());
        }

        /// <summary>
        /// 本地浏览器右键菜单“重命名”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuRename_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunNewFolder newfolder = new UpYunNewFolder();
            newfolder.Owner = this;
            newfolder.Path = LocalPath;
            Point p = this.ListViewLocal.PointToClient(new Point(menutrippoint.X, menutrippoint.Y));
            if (ListViewLocal.GetItemAt(p.X, p.Y).SubItems[1].Text.Equals("      "))
                newfolder.newstatus = "renamefolder";
            else
                newfolder.newstatus = "renamefile";
            newfolder.oldname = ListViewLocal.GetItemAt(p.X, p.Y).Text;
            newfolder.ShowDialog();
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 本地浏览器右键菜单“属性”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuProperty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            const string discVerb = "属性(&R)";
            Point p = this.ListViewLocal.PointToClient(new Point(menutrippoint.X, menutrippoint.Y));
            string sourceFile = LocalPath + ListViewLocal.GetItemAt(p.X, p.Y).Text;
            FileInfo file = new FileInfo(sourceFile);
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(file.DirectoryName);
            Shell32.FolderItem folderItem = folder.ParseName(file.Name);
            foreach (Shell32.FolderItemVerb Fib in folderItem.Verbs())
            {
                if (Fib.Name == discVerb)
                {
                    Fib.DoIt();
                    break;
                }
            }
        }

        /// <summary>
        /// 本地浏览器右键菜单“建立文件夹”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuNewFloder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnNewFolderLocal_click(sender, new EventArgs());
        }

        /// <summary>
        /// 本地浏览器右键菜单“新建文件”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuNewFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunNewFolder newfolder = new UpYunNewFolder();
            newfolder.Owner = this;
            newfolder.Path = LocalPath;
            newfolder.newstatus = "newfile";
            newfolder.ShowDialog();
            LocalUrlTextChanged();
        }

        /// <summary>
        /// 本地浏览器右键菜单“刷新”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalPopupMenuRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LocalUrlTextChanged();
        }

        #endregion

        #region 远程浏览器右键菜单事件

        /// <summary>
        /// 远程浏览器右键菜单“传输”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPoPupMenuTrans_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnTransWeb_click(sender, new EventArgs());
        }

        /// <summary>
        /// 远程浏览器右键菜单“打开”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPoPupMenuOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListViewWeb_DoubleClick(sender, new EventArgs());
        }

        /// <summary>
        /// 远程浏览器右键菜单“复制”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPoPupMenuCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 远程浏览器右键菜单“粘贴”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuStick_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 远程浏览器右键菜单“删除”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnDelWeb_click(sender, new EventArgs());
        }

        /// <summary>
        /// 远程浏览器右键菜单“重命名”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuRename_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 远程浏览器右键菜单“属性”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuProperty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 远程浏览器右键菜单“建立文件夹”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuNewFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnNewFolderWeb_click(sender, new EventArgs());
        }

        private void WebPopupMenuNewFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 远程浏览器右键菜单“刷新”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WebUrlTextChanged();
        }

        /// <summary>
        /// 远程浏览器右键菜单“复制链接”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuLink_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnLinkWeb_click(sender, new EventArgs());
        }

        /// <summary>
        /// 远程浏览器右键菜单“预览”条目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebPopupMenuPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunPreview upYunPreview = new UpYunPreview();
            UpYun_Controller.Main main = new UpYun_Controller.Main();
            Point p = this.ListViewWeb.PointToClient(new Point(menutrippoint.X, menutrippoint.Y));
            Image i = main.previewFile(userInformation.Url, WebPath, ListViewWeb.GetItemAt(p.X, p.Y).Text);
            upYunPreview.Width = i.Width;
            upYunPreview.Height = i.Height;
            upYunPreview.BackgroundImage = i;
            upYunPreview.Show();
        }

        #endregion

        /// <summary>
        /// 设置窗体快捷键执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunMain_KeyDown(object sender, KeyEventArgs e)
        {
            Control con = this.ActiveControl;
            if (e.KeyCode == Keys.F8)
                BarButtonItemLogin_ItemClick(sender, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
            else if (e.Alt && e.KeyCode == Keys.X)
                this.Close();
            if (con.Name.Equals("ListViewLocal"))
            {
                if (e.Control && e.KeyCode == Keys.O)
                    ListViewLocal_DoubleClick(sender, new EventArgs());
                else if (e.Control && e.KeyCode == Keys.T && IfLogin == true)
                    BtnTransWeb_click(sender, new EventArgs());
                else if (e.Control && e.KeyCode == Keys.C)
                    LocalPopupMenuCopy_ItemClick(sender, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
                else if (e.Control && e.KeyCode == Keys.V)
                    LocalPopupMenuStick_ItemClick(sender, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
                else if (e.KeyCode == Keys.Delete)
                    BtnDelLocal_click(sender, new EventArgs());
                else if (e.KeyCode == Keys.F2)
                    LocalPopupMenuRename_ItemClick(sender, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
                else if (e.KeyCode == Keys.Insert)
                    BtnNewFolderLocal_click(sender, new EventArgs());
                else if (e.Control && e.Shift && e.KeyCode == Keys.Insert)
                    LocalPopupMenuNewFile_ItemClick(sender, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
                else if (e.KeyCode == Keys.F5)
                    LocalUrlTextChanged();
            }
            else if (con.Name.Equals("ListViewWeb"))
            {
                if (e.Control && e.KeyCode == Keys.O)
                    ListViewWeb_DoubleClick(sender, new EventArgs());
                else if (e.Control && e.KeyCode == Keys.T)
                    BtnTransWeb_click(sender, new EventArgs());
                else if (e.Control && e.Shift && e.KeyCode == Keys.C)
                    BtnLinkWeb_click(sender, new EventArgs());
                else if (e.KeyCode == Keys.Delete)
                    BtnDelWeb_click(sender, new EventArgs());
                else if (e.KeyCode == Keys.Insert)
                    BtnNewFolderWeb_click(sender, new EventArgs());
                else if (e.KeyCode == Keys.F5)
                    BtnRefreshWeb_click(sender, new EventArgs());
            }
        }

        private void barButtonItemAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunAbout upYunAbout = new UpYunAbout();
            upYunAbout.Owner = this;
            upYunAbout.ShowDialog();
        }


    }
}