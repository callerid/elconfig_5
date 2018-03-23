using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            
            FMain = new FrmMain();
            Application.Run(FMain);

        }
    }
}
