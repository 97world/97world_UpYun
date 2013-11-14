using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpYun_Model;

namespace UpYun_Controller
{
    public class Main
    {
        //public UpYun_Model.FileInformationForListView getFileInformation(string path)
        //{
        //    return new UpYun_Model.FileInformationForListView(path, true);
        //}

        public void getFileInformation(ListView listview,ImageList imagelist,string path)
        {
            FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.getFileInformationForListView(listview,imagelist,path);
        }

        public void getFileInformationMyPc(ListView listview, ImageList imagelist, string path)
        {
            FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.getFileInformationForListViewMyPc(listview, imagelist, path);
        }

        public void delFileByListView(ListView listview,string path)
        {
            FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.delFileByListView(listview,path);
        }

        public void newFolder(string foldername, string path)
        {
            FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.newFolderForLocal(foldername, path);
        }

        public void getFileInformationWeb(ListView listview, ImageList imagelist, string path, UserInformation userInformation)
        {
            FileInformationForListView fileinformationforlistview = new FileInformationForListView();
            fileinformationforlistview.getFileInformationForListViewWeb(listview, imagelist, path, userInformation);
        }

    }
}
