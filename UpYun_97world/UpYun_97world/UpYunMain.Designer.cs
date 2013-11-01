namespace UpYun_97world
{
    partial class UpYunMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpYunMain));
            this.xafBarManagerMain = new DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(this.components);
            this.MenuBar = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.SubItemOperator = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.SubItemInternet = new DevExpress.XtraBars.BarSubItem();
            this.SubItemHelp = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.BottomBar = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GroupControlLocal = new DevExpress.XtraEditors.GroupControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.UrlBarLocal = new UpYun_97world.Controls.UrlBar();
            this.localToolsBar1 = new UpYun_97world.Controls.LocalToolsBar();
            this.GroupControlWeb = new DevExpress.XtraEditors.GroupControl();
            this.listView2 = new System.Windows.Forms.ListView();
            this.UrlBarWeb = new UpYun_97world.Controls.UrlBar();
            this.webToolsBar1 = new UpYun_97world.Controls.WebToolsBar();
            this.ImageListToolIcon = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlLocal)).BeginInit();
            this.GroupControlLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlWeb)).BeginInit();
            this.GroupControlWeb.SuspendLayout();
            this.SuspendLayout();
            // 
            // xafBarManagerMain
            // 
            this.xafBarManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.MenuBar,
            this.BottomBar});
            this.xafBarManagerMain.DockControls.Add(this.barDockControlTop);
            this.xafBarManagerMain.DockControls.Add(this.barDockControlBottom);
            this.xafBarManagerMain.DockControls.Add(this.barDockControlLeft);
            this.xafBarManagerMain.DockControls.Add(this.barDockControlRight);
            this.xafBarManagerMain.Form = this;
            this.xafBarManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.SubItemOperator,
            this.SubItemInternet,
            this.SubItemHelp,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4});
            this.xafBarManagerMain.MainMenu = this.MenuBar;
            this.xafBarManagerMain.MaxItemId = 7;
            this.xafBarManagerMain.StatusBar = this.BottomBar;
            // 
            // MenuBar
            // 
            this.MenuBar.BarName = "Main Menu";
            this.MenuBar.DockCol = 0;
            this.MenuBar.DockRow = 0;
            this.MenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.MenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.SubItemOperator),
            new DevExpress.XtraBars.LinkPersistInfo(this.SubItemInternet),
            new DevExpress.XtraBars.LinkPersistInfo(this.SubItemHelp)});
            this.MenuBar.OptionsBar.DrawDragBorder = false;
            this.MenuBar.OptionsBar.MultiLine = true;
            this.MenuBar.OptionsBar.UseWholeRow = true;
            this.MenuBar.TargetPageCategoryColor = System.Drawing.Color.Empty;
            this.MenuBar.Text = "Main Menu";
            // 
            // SubItemOperator
            // 
            this.SubItemOperator.Caption = "操作员(&U)";
            this.SubItemOperator.Id = 0;
            this.SubItemOperator.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.SubItemOperator.Name = "SubItemOperator";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "登录(&L)";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "注销(&C)";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // SubItemInternet
            // 
            this.SubItemInternet.Caption = "网络选择(&I)";
            this.SubItemInternet.Id = 1;
            this.SubItemInternet.Name = "SubItemInternet";
            // 
            // SubItemHelp
            // 
            this.SubItemHelp.Caption = "帮助(&H)";
            this.SubItemHelp.Id = 2;
            this.SubItemHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.SubItemHelp.Name = "SubItemHelp";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "访问我的BLOG";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "关于(&A)";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // BottomBar
            // 
            this.BottomBar.BarName = "StatusBar";
            this.BottomBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.BottomBar.DockCol = 0;
            this.BottomBar.DockRow = 0;
            this.BottomBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.BottomBar.OptionsBar.AllowQuickCustomization = false;
            this.BottomBar.OptionsBar.DrawDragBorder = false;
            this.BottomBar.OptionsBar.UseWholeRow = true;
            this.BottomBar.TargetPageCategoryColor = System.Drawing.Color.Empty;
            this.BottomBar.Text = "StatusBar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(774, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 536);
            this.barDockControlBottom.Size = new System.Drawing.Size(774, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 512);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(774, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 512);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 28);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.GroupControlLocal);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GroupControlWeb);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(770, 500);
            this.splitContainerControl1.SplitterPosition = 383;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // GroupControlLocal
            // 
            this.GroupControlLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControlLocal.Controls.Add(this.listView1);
            this.GroupControlLocal.Controls.Add(this.UrlBarLocal);
            this.GroupControlLocal.Controls.Add(this.localToolsBar1);
            this.GroupControlLocal.Location = new System.Drawing.Point(4, 3);
            this.GroupControlLocal.Name = "GroupControlLocal";
            this.GroupControlLocal.Size = new System.Drawing.Size(377, 494);
            this.GroupControlLocal.TabIndex = 0;
            this.GroupControlLocal.Text = "本地浏览器";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(5, 94);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(366, 395);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // UrlBarLocal
            // 
            this.UrlBarLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlBarLocal.Location = new System.Drawing.Point(3, 67);
            this.UrlBarLocal.Name = "UrlBarLocal";
            this.UrlBarLocal.Size = new System.Drawing.Size(369, 26);
            this.UrlBarLocal.TabIndex = 2;
            // 
            // localToolsBar1
            // 
            this.localToolsBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localToolsBar1.Location = new System.Drawing.Point(1, 21);
            this.localToolsBar1.Name = "localToolsBar1";
            this.localToolsBar1.Size = new System.Drawing.Size(314, 46);
            this.localToolsBar1.TabIndex = 1;
            // 
            // GroupControlWeb
            // 
            this.GroupControlWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControlWeb.Controls.Add(this.listView2);
            this.GroupControlWeb.Controls.Add(this.UrlBarWeb);
            this.GroupControlWeb.Controls.Add(this.webToolsBar1);
            this.GroupControlWeb.Location = new System.Drawing.Point(2, 3);
            this.GroupControlWeb.Name = "GroupControlWeb";
            this.GroupControlWeb.Size = new System.Drawing.Size(375, 494);
            this.GroupControlWeb.TabIndex = 0;
            this.GroupControlWeb.Text = "远程浏览器";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Location = new System.Drawing.Point(5, 94);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(365, 395);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // UrlBarWeb
            // 
            this.UrlBarWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlBarWeb.Location = new System.Drawing.Point(3, 67);
            this.UrlBarWeb.Name = "UrlBarWeb";
            this.UrlBarWeb.Size = new System.Drawing.Size(365, 26);
            this.UrlBarWeb.TabIndex = 3;
            // 
            // webToolsBar1
            // 
            this.webToolsBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webToolsBar1.Location = new System.Drawing.Point(1, 21);
            this.webToolsBar1.Name = "webToolsBar1";
            this.webToolsBar1.Size = new System.Drawing.Size(345, 46);
            this.webToolsBar1.TabIndex = 1;
            // 
            // ImageListToolIcon
            // 
            this.ImageListToolIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListToolIcon.ImageStream")));
            this.ImageListToolIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListToolIcon.Images.SetKeyName(0, "Accept.png");
            this.ImageListToolIcon.Images.SetKeyName(1, "Computer.png");
            this.ImageListToolIcon.Images.SetKeyName(2, "Desktop.png");
            this.ImageListToolIcon.Images.SetKeyName(3, "Down.png");
            this.ImageListToolIcon.Images.SetKeyName(4, "Folder add.png");
            this.ImageListToolIcon.Images.SetKeyName(5, "Globe.png");
            this.ImageListToolIcon.Images.SetKeyName(6, "Image.png");
            this.ImageListToolIcon.Images.SetKeyName(7, "Refresh.png");
            this.ImageListToolIcon.Images.SetKeyName(8, "Remove.png");
            this.ImageListToolIcon.Images.SetKeyName(9, "Repeat.png");
            this.ImageListToolIcon.Images.SetKeyName(10, "User.png");
            this.ImageListToolIcon.Images.SetKeyName(11, "Home.png");
            // 
            // UpYunMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 559);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UpYunMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "又拍云客户端 v1.0";
            this.Load += new System.EventHandler(this.UpYunMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlLocal)).EndInit();
            this.GroupControlLocal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControlWeb)).EndInit();
            this.GroupControlWeb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager xafBarManagerMain;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar MenuBar;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar BottomBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarSubItem SubItemOperator;
        private DevExpress.XtraBars.BarSubItem SubItemInternet;
        private DevExpress.XtraBars.BarSubItem SubItemHelp;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraEditors.GroupControl GroupControlLocal;
        private Controls.LocalToolsBar localToolsBar1;
        private Controls.UrlBar UrlBarLocal;
        private DevExpress.XtraEditors.GroupControl GroupControlWeb;
        private Controls.UrlBar UrlBarWeb;
        private Controls.WebToolsBar webToolsBar1;
        private System.Windows.Forms.ImageList ImageListToolIcon;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
    }
}