using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpYun_Model;
using System.Threading;

namespace UpYun_Controller
{
    public class Main
    {
        public Main()
        { }

        FileInformationForListView fileinformationforlistview = new FileInformationForListView();
        

        /// <summary>
        /// 数据填充本地浏览器ListView
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="imagelist"></param>
        /// <param name="path"></param>
        public void getFileInformation(ListView listview,ImageList imagelist,string path)
        {
            fileinformationforlistview.getFileInformationForListView(listview,imagelist,path);
        }

        /// <summary>
        /// 数据填充本地浏览器ListView（我的电脑）
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="imagelist"></param>
        /// <param name="path"></param>
        public void getFileInformationMyPc(ListView listview, ImageList imagelist, string path)
        {
            fileinformationforlistview.getFileInformationForListViewMyPc(listview, imagelist, path);
        }

        public void delFileByListView(ListView listview,string path)
        {
            fileinformationforlistview.delFileByListView(listview,path);
        }

        public void newFolder(string foldername, string path, UserInformation userInformation)
        {
            fileinformationforlistview.newFolderForWeb(foldername, path, userInformation);
        }

        public void newFolder(string foldername, string path)
        {
            fileinformationforlistview.newFolderForLocal(foldername, path);
        }

        public void rmFileForWeb(string webpath, UserInformation userinformation,ListView listview)
        {
            fileinformationforlistview.rmFile(webpath, userinformation,listview);
        }

        public void getFileInformationWeb(ListView listview, ImageList imagelist, string path, UserInformation userInformation)
        {
            fileinformationforlistview.getFileInformationForListViewWeb(listview, imagelist, path, userInformation);
        }

        public void upFile(string webpath, string localpath, ListView locallistview, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh)
        {
            fileinformationforlistview.upFile(webpath, localpath, locallistview, userinformation, refresh);
        }

    }
}
