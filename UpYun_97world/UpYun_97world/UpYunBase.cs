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
    public partial class UpYunBase : DevExpress.XtraEditors.XtraForm
    {
        public UpYunBase()
        {
            InitializeComponent();
        }

        #region 公共变量

        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IfLogin { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UpYun_Model.UserInformation userInformation { get; set; }

        /// <summary>
        /// 文件信息
        /// </summary>
        public UpYun_Model.FileInformationForListView fileInformationForListView { get; set; }


        private string _localpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";
        public string LocalPath
        {
            get { return _localpath; }
            set { _localpath=value; }
        }

        private string _webpath = @"/";
        public string WebPath
        {
            get { return _webpath; }
            set { _webpath = value; }
        }
        #endregion
    }
}