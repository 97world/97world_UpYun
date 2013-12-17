using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Collections;
using System.Threading;
using System.Net;
using System.Drawing;
using System.Collections;

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
                    //string Filetype = "unknown";
                    //if (fi.Name.Contains("."))
                    //    Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".")).ToLower();//获取文件的类型  
                    //!(Filetype == "sys" || Filetype == "ini" || Filetype == "bin" || Filetype == "log" || Filetype == "com" || Filetype == "bat" || Filetype == "db") && 
                    if ((fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        info[0] = fi.Name;
                        info[1] = ToolsLibrary.Tools.getCommonSize(fi.Length);
                        info[2] = fi.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, index);//实例化ListViewItem类
                        dglistview.Items.Add(item);//添加当前文件的基本信息
                        dgimagelist.Images.Add(fi.Name, ToolsLibrary.GetIcon.GetFileIcon(fi.Name, false));
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
            catch { }   //如果不使用try catch抓取错误并以此跳过错误，在添加没有放入光盘的光驱Items时会提示错误
        }

        /// <summary>
        /// 选中文件批量删除
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="path"></param>
        public void delFileByListView(ListView listview,string path)
        {
            for (int i = 0; i < listview.SelectedItems.Count; i++)
            {
                if (listview.SelectedItems[i].SubItems.Count>1 && listview.SelectedItems[i].SubItems[1].Text == "      ")
                {
                    DirectoryInfo di = new DirectoryInfo(path + listview.SelectedItems[i].Text);
                    di.Delete(true);
                }
                else if (listview.SelectedItems[i].Text == "上级目录")
                    return;
                else
                    File.Delete(path + listview.SelectedItems[i].Text);
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

        public void newFileForLocal(string filename, string path)
        {
            using (System.IO.File.CreateText(path + filename)){}
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
                    dglistview.BeginUpdate();
                    dglistview.Items.Clear();
                    dgimagelist.Images.Clear();
                    if (dgpath != @"/")
                        dglistview.Items.Add("上级目录");
                    ListViewItem lvi = new ListViewItem();
                    int index = 1;
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
                            dgimagelist.Images.Add(a.filename, ToolsLibrary.GetIcon.GetFileIcon(a.filename, false));
                            index++;
                        }
                        lvi.SubItems.Add(ToolsLibrary.Tools.getCommonSize(a.size));
                        lvi.SubItems.Add(ToolsLibrary.Tools.getCommonTime(Convert.ToDouble(a.number)).ToString());
                        dglistview.Items.Add(lvi);
                    }
                    dglistview.EndUpdate();
                });
            listview.Invoke(rlv,listview,imagelist,path);
        }

        public void upFile(string webpath, string localpath, ArrayList filenamelist, UserInformation userinformation, RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            Thread thread = new Thread(() => upFileByUpYun(localpath, webpath, filenamelist, userinformation, refresh, setprogressbar));
            thread.IsBackground = true;
            thread.Start();
        }

        //public void upFolder(string webpath, string localpath, ArrayList foldername, UserInformation userinformation, RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        //{ 
            
        //}

        public void upFileByUpYun(string localpath, string webpath, ArrayList filenamelist, UserInformation userinformation, RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            int SelectNum = filenamelist.Count;
            try
            {
                for (int i = 0; i < SelectNum; i++)
                {
                    string localpath_up = localpath + filenamelist[i];
                    FileStream fs = new FileStream(localpath_up, FileMode.Open, FileAccess.Read);
                    BinaryReader r = new BinaryReader(fs);
                    byte[] postArray = r.ReadBytes((int)fs.Length);
                    string webpath_up = webpath + filenamelist[i];
                    userinformation.upYun.writeFile(webpath_up, postArray, true, setprogressbar);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                refresh(false);
                XtraMessageBox.Show(ex.ToString(), "错误信息");
            }
            refresh(true);
        }

        public void downloadFile(string localpath, string webpath, ArrayList filenamelist, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            Thread thread = new Thread(() => downloadFileByUpYun(localpath, webpath, filenamelist, userinformation, refresh, setprogressbar));
            thread.IsBackground = true;
            thread.Start();
        }

        public void downloadFileByUpYun(string localpath, string webpath, ArrayList filenamelist, UserInformation userinformation, FileInformationForListView.RefreshListViewSuccess refresh, UpYunLibrary.UpYun.SetProgressBar setprogressbar)
        {
            int SelectNum = filenamelist.Count, count;
            FileStream Fs = null;
            try
            {
                for (int i = 0; i < SelectNum; i++)
                {
                    Fs = new FileStream(localpath + filenamelist[i], FileMode.Create);
                    string CopyLink = "";
                    if (userinformation.Url.Substring(userinformation.Url.Length - 1).Equals("/"))
                        CopyLink = userinformation.Url + webpath.Substring(1) + filenamelist[i];
                    else
                        CopyLink = userinformation.Url + "/" + webpath.Substring(1) + filenamelist[i];
                    HttpWebRequest Hwr = (HttpWebRequest)WebRequest.Create(CopyLink);
                    HttpWebResponse rps = (HttpWebResponse)Hwr.GetResponse();
                    Stream stream = rps.GetResponseStream();
                    byte[] byts = new byte[rps.ContentLength];
                    System.Threading.Timer FileTm = new System.Threading.Timer(CalculateSpeedTime, null, 0, 1000);
                    while ((count = stream.Read(byts, 0, 5000)) != 0)
                    {
                        TempDataSize += count;
                        Fs.Write(byts, 0, count);
                        setprogressbar(false, filenamelist[i].ToString(), (Fs.Length / Convert.ToDouble(byts.Length)) * 100.0, TransSpeed);
                    }
                }
            }
            catch (Exception ex)
            {
                refresh(false);
                XtraMessageBox.Show(ex.ToString());
            }
            finally
            {
                refresh(true);
                Fs.Close();
            }
        }

        public void CalculateSpeedTime(object state)
        {
            TransSpeed = TempDataSize / 1.0;
            TempDataSize = 0;
        }

        public int copyFileLocal(StringBuilder frompath, StringBuilder topath)
        {
            ToolsLibrary.CopyFile.SHFILEOPSTRUCT op = new ToolsLibrary.CopyFile.SHFILEOPSTRUCT();
            op.hwnd = IntPtr.Zero;
            op.wFunc = ToolsLibrary.CopyFile.FileFuncFlags.FO_COPY;
            op.pFrom = frompath.ToString();// 需要注意，最后需要加入"\0"表示字符串结束，如果需要拷贝多个文件，则 file1 + "\0" + file2 + "\0"...
            op.pTo = topath.ToString();// 需要注意，最后需要加入"\0"表示字符串结束
            op.hNameMappings = IntPtr.Zero;
            op.fFlags = ToolsLibrary.CopyFile.FILEOP_FLAGS.FOF_NOCONFIRMMKDIR;
            op.fAnyOperationsAborted = false;
            int ret = ToolsLibrary.CopyFile.SHFileOperation(ref op);
            return ret;
        }

        /// <summary>
        /// 根据url预览图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Image previewFile(string url)
        {
            HttpWebRequest Hwr = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse rps = (HttpWebResponse)Hwr.GetResponse();
            Stream stream = rps.GetResponseStream();
            Image i = Bitmap.FromStream(stream);
            return i;
        }
    }
}
