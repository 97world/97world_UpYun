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
    public partial class LocalToolsBar : UserControl
    {
        public LocalToolsBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按钮：我的电脑
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnMyPc { get { return BtnItemMyPC; } }

        /// <summary>
        /// 按钮：桌面
        /// </summary>
        public DevExpress.XtraBars.BarButtonItem BtnDesktop { get { return BtnItemDesktop; } }

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
        public DevExpress.XtraBars.BarButtonItem BtnNewFloder { get { return BtnItemNewFloder; } }
    }
}
