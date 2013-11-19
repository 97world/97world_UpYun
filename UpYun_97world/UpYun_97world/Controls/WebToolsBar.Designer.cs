namespace UpYun_97world.Controls
{
    partial class WebToolsBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebToolsBar));
            this.BarManagerWeb = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BtnItemOperator = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemHome = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemTrans = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemLink = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ImageListToolIcon = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerWeb)).BeginInit();
            this.SuspendLayout();
            // 
            // BarManagerWeb
            // 
            this.BarManagerWeb.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.BarManagerWeb.DockControls.Add(this.barDockControlTop);
            this.BarManagerWeb.DockControls.Add(this.barDockControlBottom);
            this.BarManagerWeb.DockControls.Add(this.barDockControlLeft);
            this.BarManagerWeb.DockControls.Add(this.barDockControlRight);
            this.BarManagerWeb.Form = this;
            this.BarManagerWeb.Images = this.ImageListToolIcon;
            this.BarManagerWeb.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnItemOperator,
            this.BtnItemHome,
            this.BtnItemRefresh,
            this.BtnItemTrans,
            this.BtnItemNewFolder,
            this.BtnItemLink,
            this.BtnItemDel});
            this.BarManagerWeb.MaxItemId = 10;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.FloatLocation = new System.Drawing.Point(285, 166);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemOperator),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemHome),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemTrans),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemNewFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemLink)});
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // BtnItemOperator
            // 
            this.BtnItemOperator.Caption = "操作员登录";
            this.BtnItemOperator.Id = 0;
            this.BtnItemOperator.ImageIndex = 10;
            this.BtnItemOperator.Name = "BtnItemOperator";
            // 
            // BtnItemHome
            // 
            this.BtnItemHome.Caption = "返回主目录";
            this.BtnItemHome.Enabled = false;
            this.BtnItemHome.Id = 1;
            this.BtnItemHome.ImageIndex = 11;
            this.BtnItemHome.Name = "BtnItemHome";
            // 
            // BtnItemRefresh
            // 
            this.BtnItemRefresh.Caption = "重新载入";
            this.BtnItemRefresh.Enabled = false;
            this.BtnItemRefresh.Id = 2;
            this.BtnItemRefresh.ImageIndex = 9;
            this.BtnItemRefresh.Name = "BtnItemRefresh";
            // 
            // BtnItemTrans
            // 
            this.BtnItemTrans.Caption = "开始传输";
            this.BtnItemTrans.Enabled = false;
            this.BtnItemTrans.Id = 3;
            this.BtnItemTrans.ImageIndex = 0;
            this.BtnItemTrans.Name = "BtnItemTrans";
            // 
            // BtnItemDel
            // 
            this.BtnItemDel.Caption = "删除";
            this.BtnItemDel.Enabled = false;
            this.BtnItemDel.Id = 9;
            this.BtnItemDel.ImageIndex = 8;
            this.BtnItemDel.Name = "BtnItemDel";
            // 
            // BtnItemNewFolder
            // 
            this.BtnItemNewFolder.Caption = "新建文件夹";
            this.BtnItemNewFolder.Enabled = false;
            this.BtnItemNewFolder.Id = 4;
            this.BtnItemNewFolder.ImageIndex = 4;
            this.BtnItemNewFolder.Name = "BtnItemNewFolder";
            // 
            // BtnItemLink
            // 
            this.BtnItemLink.Caption = "一键获取链接";
            this.BtnItemLink.Enabled = false;
            this.BtnItemLink.Id = 8;
            this.BtnItemLink.ImageIndex = 5;
            this.BtnItemLink.Name = "BtnItemLink";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(393, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 0);
            this.barDockControlBottom.Size = new System.Drawing.Size(393, 47);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(393, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
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
            // WebToolsBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "WebToolsBar";
            this.Size = new System.Drawing.Size(393, 47);
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerWeb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManagerWeb;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BtnItemOperator;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList ImageListToolIcon;
        private DevExpress.XtraBars.BarButtonItem BtnItemHome;
        private DevExpress.XtraBars.BarButtonItem BtnItemRefresh;
        private DevExpress.XtraBars.BarButtonItem BtnItemTrans;
        private DevExpress.XtraBars.BarButtonItem BtnItemNewFolder;
        private DevExpress.XtraBars.BarButtonItem BtnItemLink;
        private DevExpress.XtraBars.BarButtonItem BtnItemDel;
    }
}
