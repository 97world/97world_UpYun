using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// UserInformation:用户信息实体类
    /// </summary>
    public class UserInformation
    {
        public UserInformation()
        { }

        #region UserInformation
        private string _operatorname;
        private string _operatorpwd;
        private string _bucketname;
        private string _url;
        private bool _ifremember;
        private bool _ifautologin;
        private double _usespace;

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
        #endregion
    }
}
