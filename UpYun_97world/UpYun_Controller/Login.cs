using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace UpYun_Controller
{
    public class Login
    {
        /// <summary>
        /// 将用户输入的数据传递给业务模型层
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="operatoer"></param>
        /// <param name="pwd"></param>
        /// <param name="url"></param>
        /// <param name="ddbinternet"></param>
        /// <param name="ifremember"></param>
        /// <param name="ifauto"></param>
        /// <returns></returns>
        public UpYun_Model.UserInformation checkBeforeLogin(TextEdit bucket,TextEdit operatoer,TextEdit pwd,TextEdit url,DropDownButton ddbinternet,CheckEdit ifremember,CheckEdit ifauto)
        {
            UpYun_Model.UserInformation userinformaiton = new UpYun_Model.UserInformation(bucket.Text,operatoer.Text,pwd.Text,url.Text,ddbinternet.Text,ifremember.Checked,ifauto.Checked);
            return userinformaiton;
        }

        /// <summary>
        /// 通过配置文件获取用户信息
        /// </summary>
        /// <returns></returns>
        public UpYun_Model.UserInformation getUserInformationByIni()
        {
            return new UpYun_Model.UserInformation();
        }
    }
}
