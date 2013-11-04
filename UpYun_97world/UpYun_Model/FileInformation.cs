using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace UpYun_Model
{
    public class FileInformation
    {
        /// <summary>
        /// FileInformation:文件信息实体类
        /// </summary>
        public FileInformation()
        { }
        #region FileInformation
        private string _filename;
        private string _filetype;
        private double _filesize;
        private DateTime _filetime;

        /// <summary>
        /// 文件名称（目录名称）
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }

        /// <summary>
        /// 文件占用大小（目录大小）
        /// </summary>
        public double FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }

        /// <summary>
        /// 文件（目录）创建时间
        /// </summary>
        public DateTime FileTime
        {
            set { _filetime = value; }
            get { return _filetime; }
        }
        #endregion
    }
}
