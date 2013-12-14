using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace UpYun_97world.Controls
{
    public partial class UrlBar : UserControl
    {
        public UrlBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取按钮对象
        /// </summary>
        public SimpleButton UpButton
        {
            get { return BtnUpFolder; }
        }

        /// <summary>
        /// 获取地址栏对象
        /// </summary>
        public System.Windows.Forms.ComboBox CBEUrl
        {
            get { return CbbUrl; }
        }

        private void CbbUrl_DropDown(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < CbbUrl.Items.Count; i++)
            {
                if (!ht.ContainsValue(CbbUrl.Items[i].ToString()))
                {
                    ht.Add(i, CbbUrl.Items[i].ToString());
                }
            }
            this.CbbUrl.Items.Clear();
            foreach (DictionaryEntry de in ht)
            {
                CbbUrl.Items.Add(de.Value);
            }
        }

        private void CbbUrl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
