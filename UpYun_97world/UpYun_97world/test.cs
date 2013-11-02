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
    public partial class test : DevExpress.XtraEditors.XtraForm
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            DataTable DataTableInternet = new DataTable();
            DataColumn DCName = new DataColumn("Name",typeof(string));
            DataColumn DCText = new DataColumn("Text",typeof(string));
            DataTableInternet.Columns.Add(DCName);
            DataTableInternet.Columns.Add(DCText);
            DataRow DRInternet = DataTableInternet.NewRow();
            DRInternet["Name"] = "AutoInternet";
            DRInternet["Text"] = "自动识别";
            DataTableInternet.Rows.Add(DRInternet);
            
            //dropDownButton1.DataBindings.Add();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dropDownButton1.Text = "中国联通";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dropDownButton1.Text = "自动识别";
        }
    }
}