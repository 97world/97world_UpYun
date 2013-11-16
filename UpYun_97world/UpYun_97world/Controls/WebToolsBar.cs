using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UpYun_97world.Controls
{
    public partial class WebToolsBar : UserControl
    {
        public WebToolsBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按钮：操作员登录
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnOperator { get { return BtnItemOperator; } }


        /// <summary>
        /// 按钮：返回主目录
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnHome { get { return BtnItemHome; } }


        /// <summary>
        /// 按钮：刷新
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnRefresh { get { return BtnItemRefresh; } }

        /// <summary>
        /// 按钮：传输
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnTrans { get { return BtnItemTrans; } }

        /// <summary>
        /// 按钮：删除
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnDel { get { return BtnItemDel; } }

        /// <summary>
        /// 按钮：新建文件夹
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnNewFolder { get { return BtnItemNewFolder; } }

        /// <summary>
        /// 按钮：一键复制外链
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnLink { get { return BtnItemLink; } }
    }
}
