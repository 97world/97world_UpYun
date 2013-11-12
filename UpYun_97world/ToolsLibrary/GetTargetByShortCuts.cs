using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace ToolsLibrary
{
    public class GetTargetByShortCuts
    {
        public static string getTarget(string path)
        {
            IWshShortcut _shortcut = null;
            IWshShell_Class shell = new IWshShell_Class();
            if (System.IO.File.Exists(path) == true)
                _shortcut = shell.CreateShortcut(path) as IWshShortcut;//在vs2010中CreateShortcut返回dynamic 类型
            return _shortcut.TargetPath;
        }

        

    }
}
