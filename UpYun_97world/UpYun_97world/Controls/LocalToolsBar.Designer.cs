namespace UpYun_97world.Controls
{
    partial class LocalToolsBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalToolsBar));
            this.BarManagerLocal = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BtnItemMyPC = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemDesktop = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemMyFolder = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemTrans = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnItemNewFloder = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ImageListToolIcon = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BtnItemNewFile = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarManagerLocal
            // 
            this.BarManagerLocal.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.BarManagerLocal.DockControls.Add(this.barDockControlTop);
            this.BarManagerLocal.DockControls.Add(this.barDockControlBottom);
            this.BarManagerLocal.DockControls.Add(this.barDockControlLeft);
            this.BarManagerLocal.DockControls.Add(this.barDockControlRight);
            this.BarManagerLocal.Form = this;
            this.BarManagerLocal.Images = this.ImageListToolIcon;
            this.BarManagerLocal.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnItemMyPC,
            this.barButtonItem2,
            this.BtnItemRefresh,
            this.BtnItemTrans,
            this.BtnItemNewFloder,
            this.BtnItemDel,
            this.barButtonItem7,
            this.BtnItemDesktop,
            this.BtnItemMyFolder,
            this.BtnItemNewFile});
            this.BarManagerLocal.MaxItemId = 20;
            this.BarManagerLocal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemMyPC),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemDesktop),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemMyFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemTrans),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemNewFloder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnItemNewFile)});
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // BtnItemMyPC
            // 
            this.BtnItemMyPC.Caption = "我的电脑";
            this.BtnItemMyPC.Id = 0;
            this.BtnItemMyPC.ImageIndex = 1;
            this.BtnItemMyPC.Name = "BtnItemMyPC";
            // 
            // BtnItemDesktop
            // 
            this.BtnItemDesktop.Caption = "桌面";
            this.BtnItemDesktop.Id = 13;
            this.BtnItemDesktop.ImageIndex = 2;
            this.BtnItemDesktop.Name = "BtnItemDesktop";
            // 
            // BtnItemMyFolder
            // 
            this.BtnItemMyFolder.Caption = "我的文档";
            this.BtnItemMyFolder.Id = 18;
            this.BtnItemMyFolder.ImageIndex = 9;
            this.BtnItemMyFolder.Name = "BtnItemMyFolder";
            // 
            // BtnItemRefresh
            // 
            this.BtnItemRefresh.Caption = "重新载入";
            this.BtnItemRefresh.Id = 2;
            this.BtnItemRefresh.ImageIndex = 6;
            this.BtnItemRefresh.Name = "BtnItemRefresh";
            // 
            // BtnItemTrans
            // 
            this.BtnItemTrans.Caption = "开始传输";
            this.BtnItemTrans.Id = 3;
            this.BtnItemTrans.ImageIndex = 0;
            this.BtnItemTrans.Name = "BtnItemTrans";
            // 
            // BtnItemDel
            // 
            this.BtnItemDel.Caption = "删除";
            this.BtnItemDel.Id = 5;
            this.BtnItemDel.ImageIndex = 7;
            this.BtnItemDel.Name = "BtnItemDel";
            // 
            // BtnItemNewFloder
            // 
            this.BtnItemNewFloder.Caption = "新建文件夹";
            this.BtnItemNewFloder.Id = 4;
            this.BtnItemNewFloder.ImageIndex = 3;
            this.BtnItemNewFloder.Name = "BtnItemNewFloder";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(356, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 47);
            this.barDockControlBottom.Size = new System.Drawing.Size(356, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(356, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // ImageListToolIcon
            // 
            this.ImageListToolIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListToolIcon.ImageStream")));
            this.ImageListToolIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListToolIcon.Images.SetKeyName(0, "import-picture-document.png");
            this.ImageListToolIcon.Images.SetKeyName(1, "terminal.png");
            this.ImageListToolIcon.Images.SetKeyName(2, "desktop.png");
            this.ImageListToolIcon.Images.SetKeyName(3, "add.png");
            this.ImageListToolIcon.Images.SetKeyName(4, "web-browser.png");
            this.ImageListToolIcon.Images.SetKeyName(5, "spotlight-blue-button.png");
            this.ImageListToolIcon.Images.SetKeyName(6, "backup-green-button.png");
            this.ImageListToolIcon.Images.SetKeyName(7, "remove.png");
            this.ImageListToolIcon.Images.SetKeyName(8, "user.png");
            this.ImageListToolIcon.Images.SetKeyName(9, "document.png");
            this.ImageListToolIcon.Images.SetKeyName(10, "new-document.png");
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "返回桌面";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageIndex = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "返回上一目录";
            this.barButtonItem7.Id = 7;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // BtnItemNewFile
            // 
            this.BtnItemNewFile.Caption = "新建文件";
            this.BtnItemNewFile.Id = 19;
            this.BtnItemNewFile.ImageIndex = 10;
            this.BtnItemNewFile.Name = "BtnItemNewFile";
            // 
            // LocalToolsBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "LocalToolsBar";
            this.Size = new System.Drawing.Size(356, 47);
            ((System.ComponentModel.ISupportInitialize)(this.BarManagerLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManagerLocal;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BtnItemMyPC;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem BtnItemRefresh;
        private DevExpress.XtraBars.BarButtonItem BtnItemTrans;
        private DevExpress.XtraBars.BarButtonItem BtnItemNewFloder;
        private DevExpress.XtraBars.BarButtonItem BtnItemDel;
        private System.Windows.Forms.ImageList ImageListToolIcon;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem BtnItemDesktop;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem BtnItemNewFile;
        private DevExpress.XtraBars.BarButtonItem BtnItemMyFolder;

    }
}
