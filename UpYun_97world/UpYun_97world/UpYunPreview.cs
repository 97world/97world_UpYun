using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UpYun_97world
{
    public partial class UpYunPreview : DevExpress.XtraEditors.XtraForm
    {
        public UpYunPreview()
        {
            InitializeComponent();
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
        }

        private Point offset;
        private Point oldlocation;
        private Size oldsize;
        private int sizenum = 0;

        /// <summary>
        /// 窗体载入事件（设置窗体的长和高与背景图片一致）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunPreview_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            oldsize.Height = this.Height;
            oldsize.Width = this.Width;
        }

        /// <summary>
        /// 点击鼠标记录鼠标位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return; 

            Point cur = this.PointToScreen(e.Location);
            oldlocation = cur;
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        /// <summary>
        /// 根据记录的鼠标坐标和鼠标光标当前位置移动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        /// <summary>
        /// 判断鼠标单击后是否有移动位置，如果没有移动位置在释放鼠标的时候关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpYunPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (oldlocation.Equals(this.PointToScreen(e.Location)))
                this.Close();
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                sizenum++;
                this.Height = Convert.ToInt32(oldsize.Height + (oldsize.Height * (0.1 * sizenum)));
                this.Width = Convert.ToInt32(oldsize.Width + (oldsize.Width * (0.1 * sizenum)));
            }
            else
            {
                if (sizenum == -5)
                    return;
                sizenum--;
                this.Height = Convert.ToInt32(oldsize.Height + (oldsize.Height * (0.1 * sizenum)));
                this.Width = Convert.ToInt32(oldsize.Width + (oldsize.Width * (0.1 * sizenum)));
            }
        }
    }
}