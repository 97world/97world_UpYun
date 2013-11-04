using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsLibrary
{
    public class Tools
    {
        /// <summary>
        /// 字节容量单位转换为易读的容量单位
        /// </summary>
        /// <param name="bytes">字节</param>
        /// <returns></returns>
        public static string getCommonSize(double bytes)
        {
            int unit = 1024;
            if (bytes < unit) return bytes + " B";
            int exp = (int)(Math.Log(bytes) / Math.Log(unit));
            return String.Format("{0:F1} {1}B", bytes / Math.Pow(unit, exp), "KMGTPE"[exp - 1]);
        }

        /// <summary>
        /// 时间戳转换
        /// </summary>
        /// <param name="num">时间戳</param>
        /// <returns></returns>
        public static DateTime getCommonTime(double num)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(num);
            return time;
        }
    }
}
