using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UpYun_Model
{
    public class FileInformationForListView
    {

        #region FileInformation

        /// <summary>
        /// 存放文件信息的ListView
        /// </summary>
        public ListView FileInformaiton { get; set; }

        /// <summary>
        /// 存放文件Icon的ImageList
        /// </summary>
        public ImageList FileIconList { get; set; }

        #endregion

        public FileInformationForListView()
        { }

        /// <summary>
        /// FileInformation:文件信息实体类
        /// </summary>
        public FileInformationForListView(string path,bool islocal)
        {
            setControl();
            setListViewForLocal(path);
        }

        public void getFileInformationForListView(ListView listview,ImageList imagelist,string path)
        {
            listview.SmallImageList = imagelist;
            string[] dirs, files;
            try
            {
                dirs = Directory.GetDirectories(path);//获取指定目录中子目录的名称
                files = Directory.GetFiles(path);//获取目录中文件的名称
            }
            catch (Exception ex)
            {
                return;
            }
            listview.Items.Clear();
            imagelist.Images.Clear();
            int index = 0;
            for (int i = 0; i < dirs.Length; i++)//遍历子文件夹
            {
                string[] info = new string[3];//定义一个数组
                DirectoryInfo dir = new DirectoryInfo(dirs[i]);//根据文件夹的路径实例化DirectoryInfo类
                if (!(dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information") && (dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    info[0] = dir.Name;
                    info[1] = "      ";
                    info[2] = dir.LastWriteTime.ToString();
                    ListViewItem item = new ListViewItem(info, index);//实例化ListViewItem类
                    listview.Items.Add(item);//添加当前文件夹的基本信息
                    imagelist.Images.Add(dir.Name, ToolsLibrary.GetIcon.GetDirectoryIcon(dir.FullName));
                    index++;
                }
            }
            for (int i = 0; i < files.Length; i++)//遍历文件
            {
                string[] info = new string[3];//定义一个数组
                FileInfo fi = new FileInfo(files[i]);//根据文件的路径实例化FileInfo类
                string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".")).ToLower();//获取文件的类型
                if (!(Filetype == "sys" || Filetype == "ini" || Filetype == "bin" || Filetype == "log" || Filetype == "com" || Filetype == "bat" || Filetype == "db") && (fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    info[0] = fi.Name;
                    info[1] = ToolsLibrary.Tools.getCommonSize(fi.Length);
                    info[2] = fi.LastWriteTime.ToString();
                    ListViewItem item = new ListViewItem(info, index);//实例化ListViewItem类
                    listview.Items.Add(item);//添加当前文件的基本信息
                    imagelist.Images.Add(fi.Name, ToolsLibrary.GetIcon.GetFileIcon(Filetype, false));
                    index++;
                }
            }
        }

        public void setListViewForLocal(string path)
        {
            string[] dirs = Directory.GetDirectories(path);//获取指定目录中子目录的名称
            string[] files = Directory.GetFiles(path);//获取目录中文件的名称
            for (int i = 0; i < dirs.Length; i++)//遍历子文件夹
            {
                string[] info = new string[3];//定义一个数组
                DirectoryInfo dir = new DirectoryInfo(dirs[i]);//根据文件夹的路径实例化DirectoryInfo类
                if (!(dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information") && (dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    info[0] = dir.Name;
                    info[1] = "      ";
                    info[2] = dir.LastWriteTime.ToString();
                    ListViewItem item = new ListViewItem(info, dir.Name);//实例化ListViewItem类
                    FileInformaiton.Items.Add(item);//添加当前文件夹的基本信息
                    FileIconList.Images.Add(dir.Name,ToolsLibrary.GetIcon.GetDirectoryIcon(dir.FullName));
                }
            }
            for (int i = 0; i < files.Length; i++)//遍历文件
            {
                string[] info = new string[3];//定义一个数组
                FileInfo fi = new FileInfo(files[i]);//根据文件的路径实例化FileInfo类
                string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".") ).ToLower();//获取文件的类型
                if (!(Filetype == "sys" || Filetype == "ini" || Filetype == "bin" || Filetype == "log" || Filetype == "com" || Filetype == "bat" || Filetype == "db") && (fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    info[0] = fi.Name;
                    info[1] = ToolsLibrary.Tools.getCommonSize(fi.Length);
                    info[2] = fi.LastWriteTime.ToString();
                    ListViewItem item = new ListViewItem(info, fi.Name);//实例化ListViewItem类
                    FileInformaiton.Items.Add(item);//添加当前文件的基本信息
                    FileIconList.Images.Add(fi.Name, ToolsLibrary.GetIcon.GetFileIcon(Filetype,false));
                }
            }
        }

        public void setControl()
        {
            FileInformaiton = new ListView();
            FileInformaiton.View = View.Details;
            FileInformaiton.Columns.Add("名称", 160);
            FileInformaiton.Columns.Add("大小", 100);
            FileInformaiton.Columns.Add("修改时间", 100);
            FileInformaiton.FullRowSelect = true;
            

            FileIconList = new ImageList();
            FileIconList.ColorDepth = ColorDepth.Depth32Bit;

            FileInformaiton.SmallImageList = FileIconList;
        }
    }
}
