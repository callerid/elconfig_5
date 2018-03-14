using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace EthernetLinkConfig.Classes
{
    class Common
    {

        public static Color C_BUTTON_BACK = Color.WhiteSmoke;
        public static Color C_BUTTON_FORE = Color.Black;
        public static Color C_BUTTON_HOVER = Color.Blue;
        public static Color C_BACK = Color.WhiteSmoke;
        public static Color C_FORE = Color.Black;
        public static Color C_ATTENTION = Color.LightGoldenrodYellow;
        public static Color C_NEEDS_SAVING = Color.LightPink;

        public static void DrawColors(Form frm)
        {
            frm.BackColor = Color.WhiteSmoke;
            frm.ForeColor = Color.Black;

            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is Panel)
                {
                    if (ctrl.Name == "panChangers")
                    {
                        foreach (Control pan_control in ctrl.Controls)
                        {
                            if (pan_control is Button)
                            {
                                pan_control.BackColor = C_BUTTON_BACK;
                                pan_control.ForeColor = C_BUTTON_FORE;
                            }
                        }
                    }
                }

                if (ctrl is Button)
                {
                    ctrl.BackColor = C_BUTTON_BACK;
                    ctrl.ForeColor = C_BUTTON_FORE;
                }
            }
        }

        public static void SetTitle(Form frm, string title)
        {
            frm.Text = "ELConfig v." + Application.ProductVersion.ToString() + " :: " + title;
        }

        public static void WaitFor(int milliSeconds)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < milliSeconds)
            {
                Application.DoEvents();
            }
            sw.Stop();
        }

        public static string HexFromIP(string ip)
        {
            string[] parts = ip.Split('.');

            string fullHex = "";
            foreach (string part in parts)
            {
                fullHex += int.Parse(part).ToString("X").PadLeft(2, '0');
            }

            return fullHex;
        }

    }
}
