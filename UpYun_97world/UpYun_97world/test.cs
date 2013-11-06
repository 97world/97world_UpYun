using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ToolsLibrary;

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
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dropDownButton1.Text = "中国联通";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dropDownButton1.Text = "自动识别";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile();
            ini.IniWriteValue("user","name",textEdit1.Text);
            ini.IniWriteValue("user", "password", textEdit2.Text);
            ini.IniWriteValue("user","url",textEdit4.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile();
            label1.Text = ini.IniReadValue("user","name");
            label2.Text = ini.IniReadValue("user","password");
            label3.Text = ini.IniReadValue("user","url");
        }
    }
}