using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using EthernetLinkConfig.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

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
        public static Color C_NEEDS_SAVING = Color.FromArgb(251, 215, 218);
        public static Color C_GREENISH = Color.FromArgb(189, 221, 189);

        public static void DrawColors(Form frm)
        {
            frm.BackColor = Color.WhiteSmoke;
            frm.ForeColor = Color.Black;

            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is RichTextBox)
                {
                    ctrl.BackColor = C_BACK;
                    continue;
                }

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

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
                return false;
            }
            return pingable;
        }

        public static bool IsValidIP(string ip)
        {
            Match m = Regex.Match(ip, @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

            return m.Success;
        }

        public static void AddToLogFile(string field, string changed_from, string changed_to)
        {
            string my_docs_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if(!(Directory.Exists(my_docs_path + @"\CallerID.com\ELConfig5")))
            {
                Directory.CreateDirectory(my_docs_path + @"\CallerID.com\ELConfig5");
            }

            string current_log = "";
            if(File.Exists(my_docs_path + @"\CallerID.com\ELConfig5\log.txt"))
            {
                current_log = File.ReadAllText(my_docs_path + @"\CallerID.com\ELConfig5\log.txt");
            }

            string write_line = "Field Changed: " + field + Environment.NewLine + "On: " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToShortTimeString() + Environment.NewLine +
                "Changed To: " + changed_to + Environment.NewLine + "Changed From: " + changed_from;

            File.WriteAllText(my_docs_path + @"\CallerID.com\ELConfig5\log.txt", write_line + Environment.NewLine + Environment.NewLine + current_log);
        }

        public static void AddToCallLogFile(string filename, string log)
        {
            string current_log = "";
            if (File.Exists(filename))
            {
                current_log = File.ReadAllText(filename);
            }

            string write_line = log;
            string divider = "---------------------------------------------------------------------------";

            File.WriteAllText(filename, write_line + Environment.NewLine + divider + Environment.NewLine + current_log);
        }

        public static string ReadLog()
        {

            string my_docs_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string current_log = "";
            if (File.Exists(my_docs_path + @"\CallerID.com\ELConfig5\log.txt"))
            {
                current_log = File.ReadAllText(my_docs_path + @"\CallerID.com\ELConfig5\log.txt");
            }
            else
            {
                current_log = "No changes have been made on this computer. You may have made changes on a different computer.";
            }

            return current_log;
        }

        // -----------------------------------------
        public static DialogResult MessageBox(string mText, string mTitle, bool ok_only = true, int auto_close_ms = 1500)
        {
            DialogResult result;
            using (var fMsgBox = new FrmMessageBox(mText, mTitle, ok_only, auto_close_ms))
            {
                result = fMsgBox.ShowDialog();

            }
            return result;
        }

        // -----------------------------------------

        public static string GetProgramBoundToUDPPort(int port)
        {

            List<UdpProcessRecord> programs = GetAllUdpConnections();

            foreach (UdpProcessRecord program in programs)
            {
                if (program.LocalPort == port)
                {
                    return program.ProcessName;
                }
            }

            return "none";
        }

        private static List<UdpProcessRecord> GetAllUdpConnections()
        {
            int bufferSize = 0;
            List<UdpProcessRecord> udpTableRecords = new List<UdpProcessRecord>();

            // Getting the size of UDP table, that is returned in 'bufferSize' variable. 
            uint result = GetExtendedUdpTable(IntPtr.Zero, ref bufferSize, true,
                AF_INET, UdpTableClass.UDP_TABLE_OWNER_PID);

            // Allocating memory from the unmanaged memory of the process by using the 
            // specified number of bytes in 'bufferSize' variable. 
            IntPtr udpTableRecordPtr = Marshal.AllocHGlobal(bufferSize);

            try
            {
                // The size of the table returned in 'bufferSize' variable in previous 
                // call must be used in this subsequent call to 'GetExtendedUdpTable' 
                // function in order to successfully retrieve the table. 
                result = GetExtendedUdpTable(udpTableRecordPtr, ref bufferSize, true,
                    AF_INET, UdpTableClass.UDP_TABLE_OWNER_PID);

                // Non-zero value represent the function 'GetExtendedUdpTable' failed, 
                // hence empty list is returned to the caller function. 
                if (result != 0)
                    return new List<UdpProcessRecord>();

                // Marshals data from an unmanaged block of memory to a newly allocated 
                // managed object 'udpRecordsTable' of type 'MIB_UDPTABLE_OWNER_PID' 
                // to get number of entries of the specified TCP table structure. 
                MIB_UDPTABLE_OWNER_PID udpRecordsTable = (MIB_UDPTABLE_OWNER_PID)
                    Marshal.PtrToStructure(udpTableRecordPtr, typeof(MIB_UDPTABLE_OWNER_PID));
                IntPtr tableRowPtr = (IntPtr)((long)udpTableRecordPtr +
                    Marshal.SizeOf(udpRecordsTable.dwNumEntries));

                // Reading and parsing the UDP records one by one from the table and 
                // storing them in a list of 'UdpProcessRecord' structure type objects. 
                for (int i = 0; i < udpRecordsTable.dwNumEntries; i++)
                {
                    MIB_UDPROW_OWNER_PID udpRow = (MIB_UDPROW_OWNER_PID)
                        Marshal.PtrToStructure(tableRowPtr, typeof(MIB_UDPROW_OWNER_PID));
                    udpTableRecords.Add(new UdpProcessRecord(new IPAddress(udpRow.localAddr),
                        BitConverter.ToUInt16(new byte[2] { udpRow.localPort[1], 
                            udpRow.localPort[0] }, 0), udpRow.owningPid));
                    tableRowPtr = (IntPtr)((long)tableRowPtr + Marshal.SizeOf(udpRow));
                }
            }
            catch (OutOfMemoryException outOfMemoryException)
            {
                MessageBox(outOfMemoryException.Message.ToString(), "Out Of Memory");
            }
            catch (Exception exception)
            {
                MessageBox(exception.Message, "Exception");
            }
            finally
            {
                Marshal.FreeHGlobal(udpTableRecordPtr);
            }
            return udpTableRecords != null ? udpTableRecords.Distinct()
                .ToList<UdpProcessRecord>() : new List<UdpProcessRecord>();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_UDPROW_OWNER_PID
        {
            public uint localAddr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] localPort;
            public int owningPid;
        }

        /// <summary> 
        /// The structure contains the User Datagram Protocol (UDP) listener table for IPv4 
        /// on the local computer. The table also includes the process ID (PID) that issued 
        /// the call to the bind function for each UDP endpoint. 
        /// </summary> 
        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_UDPTABLE_OWNER_PID
        {
            public uint dwNumEntries;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct,
                SizeConst = 1)]
            public UdpProcessRecord[] table;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class UdpProcessRecord
        {
            [DisplayName("Local Address")]
            public IPAddress LocalAddress { get; set; }
            [DisplayName("Local Port")]
            public uint LocalPort { get; set; }
            [DisplayName("Process ID")]
            public int ProcessId { get; set; }
            [DisplayName("Process Name")]
            public string ProcessName { get; set; }

            public UdpProcessRecord(IPAddress localAddress, uint localPort, int pId)
            {
                LocalAddress = localAddress;
                LocalPort = localPort;
                ProcessId = pId;
                if (Process.GetProcesses().Any(process => process.Id == pId))
                    ProcessName = Process.GetProcessById(ProcessId).ProcessName;
            }
        }

        public enum UdpTableClass
        {
            UDP_TABLE_BASIC,
            UDP_TABLE_OWNER_PID,
            UDP_TABLE_OWNER_MODULE
        }

        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedUdpTable(IntPtr pUdpTable, ref int pdwSize,
            bool bOrder, int ulAf, UdpTableClass tableClass, uint reserved = 0);

        private const int AF_INET = 2;

    }
}
