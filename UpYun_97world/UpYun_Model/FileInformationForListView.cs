using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Collections;
using System.Threading;
using System.Net;

namespace UpYun_Model
{
    public class FileInformationForListView
    {

        public FileInformationForListView()
        { }

        public delegate void RefreshListViewWeb(ListView dglistview, ImageList dgimagelist, string dgpath);
        public delegate void RefreshListViewLocal(ListView dglistview, ImageList dgimagelist);
        public delegate void RefreshListViewSuccess(bool isuploadsuccess);
        public double TransSpeed;
        public int TempDataSize;
        

        /// <summary>
        ///  本地浏览器ListView填充数据
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="imagelist"></param>
        /// <param name="path"></param>
        public void getFileInformationForListView(ListView listview,ImageList imagelist,string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] dirs, files;
            try
            {
                dirs = Directory.GetDirectories(path);//获取指定目录中子目录的名称
                files = Directory.GetFiles(path);//获取目录中文件的名称
            }
            catch
            {
                XtraMessageBox.Show("不存在该目录或文件！");
                return;
            }

            RefreshListViewLocal rlv = new RefreshListViewLocal(delegate(ListView dglistview, ImageList dgimagelist)
            {
                dglistview.SmallImageList = dgimagelist;
                dglistview.Items.Clear();
                dgimagelist.Images.Clear();
                dglistview.Items.Add("上级目录");
                int index = 0;
                dglistview.BeginUpdate();
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
                        dglistview.Items.Add(item);//添加当前文件夹的基本信息
                        dgimagelist.Images.Add(dir.Name, ToolsLibrary.GetIcon.GetDirectoryIcon(dir.FullName));
                        index++;
                    }
                }
                dglistview.EndUpdate();
                dglistview.BeginUpdate();
                for (int i = 0; i < files.Length; i++)//遍历文件
                {
                    string[] info = new string[3];//定义一个数组
                    FileInfo fi = new FileInfo(files[i]);//根据文件的路径实例化FileInfo类
                    string Filetype = "unknown";
                    if (fi.Name.Contains("."))
                        Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".")).ToLower();//获取文件的类型              
                    if (!(Filetype == "sys" || Filetype == "ini" || Filetype == "bin" || Filetype == "log" || Filetype == "com" || Filetype == "bat" || Filetype == "db") && (fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        info[0] = fi.Name;
                        info[1] = ToolsLibrary.Tools.getCommonSize(fi.Length);
                        info[2] = fi.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, index);//实例化ListViewItem类
                        dglistview.Items.Add(item);//添加当前文件的基本信息
                        dgimagelist.Images.Add(fi.Name, ToolsLibrary.GetIcon.GetFileIcon(Filetype, false));
                        index++;
                    }
                }
                dglistview.EndUpdate();
            });
            listview.Invoke(rlv, listview, imagelist);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 本地浏览器ListView填充数据（我的电脑）
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="imagelist"></param>
        /// <param name="path"></param>
        public void getFileInformationForListViewMyPc(ListView listview, ImageList imagelist, string path)
        {
            listview.Items.Clear();
            imagelist.Images.Clear();
            listview.SmallImageList = imagelist;
            try
            {
                DriveInfo[] sysdir = System.IO.Directory.GetLogicalDrives().Select(q => new System.IO.DriveInfo(q)).ToArray();
                foreach (var sd in sysdir)
                {
                    string drivepath = sd.Name.Substring(0, sd.Name.LastIndexOf(@"\"));
                    imagelist.Images.Add(sd.Name, ToolsLibrary.GetIcon.GetDirectoryIcon(drivepath));//添加图标
                    ListViewItem item = new ListViewItem(sd.VolumeLabel + " (" + sd.Name + ")");
                    item.ImageKey = sd.Name;
                    item.SubItems.Add(ToolsLibrary.Tools.getCommonSize(sd.TotalFreeSpace));
                    item.SubItems.Add("本地磁盘");
                    listview.Items.Add(item);
                }
            }
            catch { }
        }

        /// <summary>
        /// 选中文件批量删除
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="path"></param>
        public void delFileByListView(ListView listview,string path)
        {
            if (XtraMessageBox.Show("确定删除选中文件(文件夹)？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                for (int i = 0; i < listview.SelectedItems.Count; i++)
                {
                    if (listview.SelectedItems[i].SubItems[1].Text == "      ")
                    {
                        DirectoryInfo di = new DirectoryInfo(path + listview.SelectedItems[i].Text);
                        di.Delete(true);
                    }
                    else
                        File.Delete(path + listview.SelectedItems[i].Text);
                }
            }
        }

        /// <summary>
        /// Local新建文件夹
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="path"></param>
        public void newFolderForLocal(string foldername,string path)
        {
            string fullfoldername = path + foldername;
            System.IO.Directory.CreateDirectory(fullfoldername);
        }

        /// <summary>
        /// Web新建文件夹
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="path"></param>
        /// <param name="userinformation"></param>
        public void newFolderForWeb(string foldername,string path,UserInformation userinformation)
        {
            string fullfoldername = path + foldername;
            userinformation.upYun.mkDir(fullfoldername,true);
        }

        /// <summary>
        /// Web删除文件
        /// </summary>
        /// <param name="fullfoldername"></param>
        /// <param name="userinformation"></param>
        public void rmFile(string webpath, UserInformation userinformation,ListView listview)
        {
            for (int i = 0; i < listview.SelectedItems.Count;i++ )
            {
                userinformation.upYun.deleteFile(webpath+listview.SelectedItems[i].Text);
            }
        }

        /// <summary>
        /// 远程浏览器ListView填充数据
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="imagelist"></param>
        /// <param name="path"></param>
        /// <param name="userInformation"></param>
        public void getFileInformationForListViewWeb(ListView listview, ImageList imagelist, string path, UserInformation userInformation)
        {
            ArrayList str = new ArrayList();
            try
            {
                str = userInformation.upYun.readDir(path);
            }catch{ }
            RefreshListViewWeb rlv = new RefreshListViewWeb(delegate(ListView dglistview, ImageList dgimagelist, string dgpath)
                {
                    dglistview.Items.Clear();
                    dgimagelist.Images.Clear();
                    if (dgpath != @"/")
                        dglistview.Items.Add("上级目录");
                    ListViewItem lvi = new ListViewItem();
                    int index = 1;
                    string filetypename = "unknown";
                    dgimagelist.Images.Add("folder", ToolsLibrary.GetIcon.GetDirectoryIcon(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\"));
                    foreach (var item in str)
                    {
                        UpYunLibrary.FolderItem a = (UpYunLibrary.FolderItem)item;
                        lvi = new ListViewItem(a.filename);
                        if (a.filetype == "F")
                            lvi.ImageIndex = 0;
                        else if (a.filetype == "N")
                        {
                            lvi.ImageIndex = index;
                            if (a.filename.Contains("."))
                                filetypename = a.filename.Substring(a.filename.LastIndexOf(".")).ToLower();//获取文件的类型
                            dgimagelist.Images.Add(a.filename, ToolsLibrary.GetIcon.GetFileIcon(filetypename, false));
                            index++;
                        }
                        lvi.SubItems.Add(ToolsLibrary.Tools.getCommonSize(a.size));
                        lvi.SubItems.Add(ToolsLibrary.Tools.getCommonTime(Convert.ToDouble(a.number)).ToString());
                        dglistview.Items.Add(lvi);
                    }
                });
            listview.Invoke(rlv,listview,imagelist,path);
        }

        public void upFile(string webpath, string localpath, ListView locallistview, UserInformation userinformation, RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            string[] SelectText = new string[locallistview.SelectedItems.Count];
            for (int i = 0; i < SelectText.Length; i++)
            {
                SelectText[i] = locallistview.SelectedItems[i].Text;
            }
            Thread thread = new Thread(() => upFileByUpYun(localpath, webpath, SelectText, userinformation, refresh, setprogressbar));
            thread.Start();
        }

        public void upFileByUpYun(string localpath, string webpath, string[] selectedtext, UserInformation userinformation, RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            int SelectNum = selectedtext.Length;
            try
            {
                for (int i = 0; i < SelectNum; i++)
                {
                    string localpath_up = localpath + selectedtext[i];
                    FileStream fs = new FileStream(localpath_up, FileMode.Open, FileAccess.Read);
                    BinaryReader r = new BinaryReader(fs);
                    byte[] postArray = r.ReadBytes((int)fs.Length);
                    string webpath_up = webpath + selectedtext[i];
                    userinformation.upYun.writeFile(webpath_up, postArray, true, setprogressbar);
                }
            }
            catch
            {
                XtraMessageBox.Show("上传出错：文件只能是图像文件！");
                refresh(false);
                return;
            }
            refresh(true);
        }

        public void downloadFile(string localpath, string webpath, ListView weblistview, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            string[] SelectText = new string[weblistview.SelectedItems.Count];
            for (int i = 0; i < SelectText.Length; i++)
            {
                SelectText[i] = weblistview.SelectedItems[i].Text;
            }
            Thread thread = new Thread(() => downloadFileByUpYun(localpath, webpath, SelectText, userinformation, refresh, setprogressbar));
            thread.Start();
        }

        public void downloadFileByUpYun(string localpath, string webpath, string[] selecttext, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            int SelectNum = selecttext.Length, count;
            FileStream Fs = null;
            for (int i = 0; i < SelectNum; i++ )
            {
                Fs = new FileStream(localpath + selecttext[i], FileMode.Create);
                //byte[] contents = userinformation.upYun.readFile(webpath + selecttext[i], setprogressbar);
                string CopyLink = "";
                if (userinformation.Url.Substring(userinformation.Url.Length - 1).Equals("/"))
                    CopyLink = userinformation.Url + webpath.Substring(1) + selecttext[i];
                else
                    CopyLink = userinformation.Url + "/" + webpath.Substring(1) + selecttext[i];
                HttpWebRequest Hwr = (HttpWebRequest)WebRequest.Create(CopyLink);
                HttpWebResponse rps = (HttpWebResponse)Hwr.GetResponse();
                Stream stream = rps.GetResponseStream();
                byte[] byts = new byte[rps.ContentLength];
                System.Threading.Timer FileTm = new System.Threading.Timer(CalculateSpeedTime, null, 0, 1000);
                while ((count = stream.Read(byts, 0, 5000)) != 0)
                {
                    TempDataSize += count;
                    Fs.Write(byts, 0, count);
                    setprogressbar(false, selecttext[i], (Fs.Length / Convert.ToDouble(byts.Length))* 100.0, TransSpeed);
                }
            }
            Fs.Close();
            refresh(true);
        }

        public void CalculateSpeedTime(object state)
        {
            TransSpeed = TempDataSize / 1.0;
            TempDataSize = 0;
        }
    }
}
