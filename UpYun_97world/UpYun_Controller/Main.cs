using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            UpYun_Model.FileInformationForListView fileinformationforlistview = new UpYun_Model.FileInformationForListView();
            fileinformationforlistview.getFileInformationForListView(listview,imagelist,path);
        }

        public void getFileInformationMyPc(ListView listview, ImageList imagelist, string path)
        {
            UpYun_Model.FileInformationForListView fileinformationforlistview = new UpYun_Model.FileInformationForListView();
            fileinformationforlistview.getFileInformationForListViewMyPc(listview, imagelist, path);
        }

        public void delFileByListView(ListView listview,string path)
        {
            UpYun_Model.FileInformationForListView fileinformationforlistview = new UpYun_Model.FileInformationForListView();
            fileinformationforlistview.delFileByListView(listview,path);
        }

        public void newFolder(string foldername, string path)
        {
            UpYun_Model.FileInformationForListView fileinformationforlistview = new UpYun_Model.FileInformationForListView();
            fileinformationforlistview.newFolderForLocal(foldername, path);
        }

    }
}
