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
    public partial class UpYunMain : DevExpress.XtraEditors.XtraForm
    {
        public UpYunMain()
        {
            InitializeComponent();
        }

        private void UpYunMain_Load(object sender, EventArgs e)
        {
            
        }

        private void BarButtonItemLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpYunLogin upYunLogin = new UpYunLogin();
            upYunLogin.ShowDialog();
        }
    }
}