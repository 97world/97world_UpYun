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

        #region 构造方法
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
                BucketName = bucket;
                OperatorName = operatorname;
                OperatorPwd = pwd;
                Url = url;
                IfAutoLogin = ifauto;
                IfRemember = ifremember;
                Internet = internet;
                upYun = new UpYunLibrary.UpYun(BucketName, OperatorName, OperatorPwd);
                setNetWork();
                writeConfig();
                try
                {
                    UseSpace = getUseSpace();
                }
                catch(Exception ex)
                {
                    upYun = null;
                    XtraMessageBox.Show(ex.Message,"错误提示");
                }
            }

        }

        /// <summary>
        /// 默认通过配置文件获取信息实例化UserInformation
        /// </summary>
        public UserInformation()
        {
            ToolsLibrary.IniFile ini = new ToolsLibrary.IniFile();
            if (ini.IniReadValue("ifconfig","remember")!="" && !Convert.ToBoolean(string.Compare(ini.IniReadValue("ifconfig", "remember"), "true", true)))
            {
                BucketName = ini.IniReadValue("operatorinformation","bucket");
                OperatorName = ini.IniReadValue("operatorinformation", "operatorname");
                OperatorPwd = ToolsLibrary.Tools.DecryptDES( ini.IniReadValue("operatorinformation", "operatorpwd"), "WORLDCOM");
                Url = ini.IniReadValue("operatorinformation", "url");
                Internet = ini.IniReadValue("operatorinformation", "internet");
                IfRemember = Convert.ToBoolean(ini.IniReadValue("operatorinformation", "ifremember"));
                IfAutoLogin = Convert.ToBoolean(ini.IniReadValue("operatorinformation", "ifauto"));
                upYun = new UpYunLibrary.UpYun(BucketName, OperatorName, OperatorPwd);
                UseSpace = upYun.getBucketUsage();
                setNetWork();
            }
        }

        #endregion

        #region 辅助方法（信息的获取）

        /// <summary>
        /// 使用upYun接口获取操作员的空间占用信息
        /// </summary>
        /// <returns></returns>
        public double getUseSpace()
        {
            return upYun.getBucketUsage();
        }

        /// <summary>
        /// 设置网络线路
        /// </summary>
        /// <param name="network"></param>
        public void setNetWork()
        {
            switch (Internet)
            {
                case "中国电信网络": upYun.setApiDomain("v1.api.upyun.com");
                    break;
                case "中国联通网络": upYun.setApiDomain("v2.api.upyun.com");
                    break;
                case "中国移动网络": upYun.setApiDomain("v3.api.upyun.com");
                    break;
                case "自动识别网络": upYun.setApiDomain("v0.api.upyun.com");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 将操作员信息写入INI配置文件
        /// </summary>
        public void writeConfig()
        {
            ToolsLibrary.IniFile ini = new ToolsLibrary.IniFile();
            if (IfRemember || IfAutoLogin)
            {
                ini.IniWriteValue("operatorinformation", "bucket", BucketName);
                ini.IniWriteValue("operatorinformation", "operatorname", OperatorName);
                ini.IniWriteValue("operatorinformation", "operatorpwd", ToolsLibrary.Tools.EncryptDES(OperatorPwd, "WORLDCOM"));
                ini.IniWriteValue("operatorinformation", "url", Url);
                ini.IniWriteValue("operatorinformation", "internet", Internet);
                ini.IniWriteValue("operatorinformation", "ifremember", IfRemember.ToString());
                ini.IniWriteValue("operatorinformation", "ifauto", IfAutoLogin.ToString());
                ini.IniWriteValue("ifconfig", "remember", IfRemember.ToString());
                ini.IniWriteValue("ifconfig", "auto", IfAutoLogin.ToString());
            }
            else
            {
                ini.IniWriteValue("operatorinformation", "bucket", "");
                ini.IniWriteValue("operatorinformation", "operatorname", "");
                ini.IniWriteValue("operatorinformation", "operatorpwd", "");
                ini.IniWriteValue("operatorinformation", "url", "");
                ini.IniWriteValue("operatorinformation", "internet", "自动识别网络");
                ini.IniWriteValue("operatorinformation", "ifremember", "false");
                ini.IniWriteValue("operatorinformation", "ifauto", "false");
                ini.IniWriteValue("ifconfig", "remember", "false");
                ini.IniWriteValue("ifconfig", "auto", "false");
            }
        }

        #endregion
    }
}
