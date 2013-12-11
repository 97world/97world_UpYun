using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Runtime.InteropServices;

namespace UpYun_97world
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Seven Classic");

            Application.Run(new UpYunMain());
        }
    }
}