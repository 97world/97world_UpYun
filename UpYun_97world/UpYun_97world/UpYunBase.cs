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

        ///// <summary>
        ///// UpYun接口
        ///// </summary>
        //public UpYunLibrary.UpYun upYun { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UpYun_Model.UserInformation userInformation { get; set; }

        #endregion
    }
}