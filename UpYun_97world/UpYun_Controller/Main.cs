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
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            Thread thread = new Thread(() => fileinformationforlistview.getFileInformationForListView(listview, imagelist, path));
            thread.Start();
            //fileinformationforlistview.getFileInformationForListView(listview,imagelist,path);
        }

        /// <summary>
        /// 数据填充本地浏览器ListView（我的电脑）
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="imagelist"></param>
        /// <param name="path"></param>
        public void getFileInformationMyPc(ListView listview, ImageList imagelist, string path)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.getFileInformationForListViewMyPc(listview, imagelist, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="path"></param>
        public void delFileByListView(ListView listview,string path)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.delFileByListView(listview,path);
        }

        public void newFolder(string foldername, string path, UserInformation userInformation)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.newFolderForWeb(foldername, path, userInformation);
        }

        public void newFolder(string foldername, string path)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.newFolderForLocal(foldername, path);
        }

        public void rmFileForWeb(string webpath, UserInformation userinformation,ListView listview)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.rmFile(webpath, userinformation,listview);
        }

        public void getFileInformationWeb(ListView listview, ImageList imagelist, string path, UserInformation userInformation)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.getFileInformationForListViewWeb(listview, imagelist, path, userInformation);
        }

        public void upFile(string webpath, string localpath, ListView locallistview, UserInformation userinformation)
        {
            //FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.upFile(webpath,localpath,locallistview,userinformation);
        }

    }
}
