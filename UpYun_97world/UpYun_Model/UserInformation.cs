using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace UpYun_Model
{
    /// <summary>
    /// UserInformation:用户信息实体类
    /// </summary>
    public class UserInformation
    {
        /// <summary>
        /// 检查必要信息是否输入，验证操作员密码是否正确，验证通过实例化一个UserInformation的对象
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="operatorname"></param>
        /// <param name="pwd"></param>
        /// <param name="url"></param>
        /// <param name="internet"></param>
        /// <param name="ifremember"></param>
        /// <param name="ifauto"></param>
        public UserInformation(string bucket, string operatorname, string pwd, string url, string internet, bool ifremember, bool ifauto)
        {
            if (bucket == "")
            {
                XtraMessageBox.Show("空间名称不能为空！");
                upYun = null;
            }
            else if (operatorname == "")
            {
                XtraMessageBox.Show("操作员用户名不能为空！");
                upYun = null;
            }
            else if (pwd == "")
            {
                XtraMessageBox.Show("操作员密码不能为空！");
                upYun = null;
            }
            else
            {
                switch (internet)
                {
                    case "中国电信网络": internet = "v1.api.upyun.com";
                        break;
                    case "中国联通网络": internet = "v2.api.upyun.com";
                        break;
                    case "中国移动网络": internet = "v3.api.upyun.com";
                        break;
                    default: internet = "v0.api.upyun.com";
                        break;
                }
                BucketName = bucket;
                OperatorName = operatorname;
                OperatorPwd = pwd;
                Url = url;
                IfAutoLogin = ifauto;
                IfRemember = ifremember;
                Internet = internet;
                upYun = new UpYunLibrary.UpYun(BucketName, OperatorName, OperatorPwd, Internet);
                try
                {
                    UseSpace = getUseSpace();
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    upYun = null;
                }
            }

        }

        #region UserInformation
        private string _operatorname;
        private string _operatorpwd;
        private string _bucketname;
        private string _url;
        private bool _ifremember;
        private bool _ifautologin;
        private double _usespace;
        private string _internet;

        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OperatorName
        {
            set { _operatorname = value; }
            get { return _operatorname; }
        }

        /// <summary>
        /// 操作员密码
        /// </summary>
        public string OperatorPwd
        {
            set { _operatorpwd = value; }
            get { return _operatorpwd; }
        }

        /// <summary>
        /// 空间名称
        /// </summary>
        public string BucketName
        {
            set { _bucketname = value; }
            get { return _bucketname; }
        }

        /// <summary>
        /// 域名
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }

        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool IfRemember
        {
            set { _ifremember = value; }
            get { return _ifremember; }
        }

        /// <summary>
        /// 是否自动登录
        /// </summary>
        public bool IfAutoLogin
        {
            set { _ifautologin = value; }
            get { return _ifautologin; }
        }

        /// <summary>
        /// 已占用的空间
        /// </summary>
        public double UseSpace
        {
            set { _usespace = value; }
            get { return _usespace; }
        }

        /// <summary>
        /// 网络路线
        /// </summary>
        public string Internet
        {
            set { _internet = value; }
            get { return _internet; }
        }

        /// <summary>
        /// UpYun对象
        /// </summary>
        public UpYunLibrary.UpYun upYun { get; set; }
        #endregion

        #region 辅助方法（信息的导入）

        public double getUseSpace()
        {
            return upYun.getBucketUsage();
        }

        #endregion
    }
}
