using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EthernetLinkConfig.Classes;

namespace EthernetLinkConfig
{
    static class Program
    {

        public static FrmMain FMain = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var numberOfELConfigInstances = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length;
            if (numberOfELConfigInstances > 1)
            {
                Common.MessageBox("ELConfig 5 already running.", "ELConf 5 Already Opened", true, 1000);
                Common.WaitFor(1000);
                Application.Exit();
                return;
            }


            FMain = new FrmMain();
            Application.Run(FMain);

        }
    }
}
