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
    public partial class UpYunPreview : DevExpress.XtraEditors.XtraForm
    {
        public UpYunPreview()
        {
            InitializeComponent();
        }

        private Point offset;
        private Point oldlocation;

        /// <summary>
        /// 窗体载入事件（设置窗体的长和高与背景图片一致）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunPreview_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void UpYunPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return; 

            Point cur = this.PointToScreen(e.Location);
            oldlocation = cur;
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void UpYunPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void UpYunPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (oldlocation.Equals(this.PointToScreen(e.Location)))
                this.Close();
        }
    }
}