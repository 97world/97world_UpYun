using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UpYun_97world.Controls
{
    public partial class UrlBar : UserControl
    {
        public UrlBar()
        {
            InitializeComponent();
        }

        public SimpleButton UpButton
        {
            get { return CbbUrl; }
        }

    }
}
