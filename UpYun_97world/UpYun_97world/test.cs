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
            
            //string path = @"D:\android";
            //UpYun_Controller.Main main = new UpYun_Controller.Main();
            //UpYun_Model.FileInformationForListView fileInformationForListView = main.getFileInformation(path);
            //ListView listviewtest = new ListView();
            //listviewtest.View = View.Details;
            //string[] info = new string[3];
            //info[0] = "test";
            //info[1] = "test";
            //info[2] = "test";
            //ListViewItem lvi = new ListViewItem(info,"test");
            //listviewtest.Items.Add(lvi);
            ////listView1.Items.Add(lvi);
            //System.Windows.Forms.ListView.ListViewItemCollection coll = new System.Windows.Forms.ListView.ListViewItemCollection(listviewtest);
            //listView1.Items.AddRange(coll);
            ////listviewtest.Columns.Add("test", 100);
            ////listviewtest.Columns.Add("test", 100);
            ////listviewtest.Columns.Add("test", 100);
            ////listView1 = listviewtest;
            ////listView1 = fileInformationForListView.FileInformaiton;
            ////ImageListLocalIcon = fileInformationForListView.FileIconList;
            
            ////ListViewLocal.SmallImageList = ImageListLocalIcon;
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
            progressBarControl1.Position = progressBarControl1.Position + 20;
        }

        private void BtnUpFolder_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}