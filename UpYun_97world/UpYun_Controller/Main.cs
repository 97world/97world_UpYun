using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UpYun_Model;

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

        public void newFile(string filename, string path)
        {
            fileinformationforlistview.newFileForLocal(filename, path);
        }

        public void rmFileForWeb(string webpath, UserInformation userinformation,ListView listview)
        {
            fileinformationforlistview.rmFile(webpath, userinformation, listview);
        }

        public void getFileInformationWeb(ListView listview, ImageList imagelist, string path, UserInformation userInformation)
        {
            fileinformationforlistview.getFileInformationForListViewWeb(listview, imagelist, path, userInformation);
        }

        public void upFile(string webpath, string localpath, ListView locallistview, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            fileinformationforlistview.upFile(webpath, localpath, locallistview, userinformation, refresh, setprogressbar);
        }

        public void downloadFile(string localpath, string webpath, ListView weblistview, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            fileinformationforlistview.downloadFile(localpath, webpath, weblistview, userinformation, refresh, setprogressbar);
        }

        public void copyFileLocal(string oldpath, string[] name, string localpath)
        {
            StringBuilder frompath = new StringBuilder(), topath = new StringBuilder();
            int count = name.Length;
            for (int i = 0; i < count; i++)
            {
                frompath.Append(oldpath + name[i] + "\0");
                topath.Append(localpath + "\0");
            }
            fileinformationforlistview.copyFileLocal(frompath, topath);
        }
    }
}
