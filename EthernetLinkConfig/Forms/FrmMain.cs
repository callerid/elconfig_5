﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EthernetLinkConfig.Classes;
using System.Threading;
using System.Text.RegularExpressions;
using EthernetLinkConfig.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace EthernetLinkConfig
{
    public partial class FrmMain : Form
    {
        public bool Loading = true;
        public bool AlwaysShowToggles = false;
        public bool FoundAndSwitchedToUnicast = false;
        public bool HaveHadAConnection = false;
        public bool HaveShownMultipleUnitMessage = false;
        public static bool AskedToChangeLineCount = false;
        public bool HaveShownDupResetWindow = false;
        public bool WaitingForNewIP = false;
        public string ChangingIPTo = "";
        public bool LoggingCallRecords = false;
        public string LogPath = "";

        // Forms
        FrmSetLineCount FSetLineCount = new FrmSetLineCount(0);
        FrmDuplicateTracking FDupsTracking = new FrmDuplicateTracking();
        FrmLog FLog = new FrmLog();
        FrmOldFirmwareSettingLineCount FSetLineCountOldFirmware = new FrmOldFirmwareSettingLineCount();
        FrmSetLineCountWithDipSwitches FSetLineCountDipSwitches = null;
        
        // Receivers
        public static UdpReceiverClass6699 UdpReceiver6699 = new UdpReceiverClass6699();
        readonly Thread _udpReceiveThread6699 = new Thread(UdpReceiver6699.UdpIdleReceive);
        public static UdpReceiverClass3520 UdpReceiver3520 = new UdpReceiverClass3520();
        readonly Thread _udpReceiveThread3520 = new Thread(UdpReceiver3520.UdpIdleReceive);
        
        // Custom receiver
        public static UdpReceiverClassCustom UdpReceiverCustom = new UdpReceiverClassCustom();
        public static Thread _udpReceiveThreadCustom = new Thread(UdpReceiverCustom.UdpIdleReceive);
        
        // Receive vitals
        public static LinkPortsClass LinkPorts;
        public int ConnectionPings = 3;
        public bool DeluxeUnitDetected = false;

        // Required sending IP data
        //public static List<string> FoundSerials = new List<string>();
        public static List<string> FoundUnitIPs = new List<string>();
        public static string SendToIP = "255.255.255.255";

        // Call Record reception <reception_string, seconds_since_it_came_in>
        Dictionary<string, int> previousReceptions = new Dictionary<string, int>();

        // Reception values
        public string UnitNumber;
        public string SerialNumber;
        public string MACAddress;
        public string TheIPAddress;
        public string DestPort;
        public string ListPort;
        public string DestIP;
        public string DestMAC;
        public int LineCount = 1;
        public static int Dups = 1;
        public double FirmwareVersion;

        public string PreviousUnitNumber;
        public string PreviousSerialNumber;
        public string PreviousMACAddress;
        public string PreviousTheIPAddress;
        public string PreviousDestPort;
        public string PreviousListPort;
        public string PreviousDestIP;
        public string PreviousDestMAC;

        // Phone data
        private const int DGV_PHONE_DATA_LINE_INDEX = 0;
        private const int DGV_PHONE_DATA_IO_INDEX = 1;
        private const int DGV_PHONE_DATA_SE_INDEX = 2;
        private const int DGV_PHONE_DATA_DUR_INDEX = 3;
        private const int DGV_PHONE_DATA_CS_INDEX = 4;
        private const int DGV_PHONE_DATA_RING_INDEX = 5;
        private const int DGV_PHONE_DATA_DATE_INDEX = 6;
        private const int DGV_PHONE_DATA_TIME_INDEX = 7;
        private const int DGV_PHONE_DATA_NUMBER_INDEX = 8;
        private const int DGV_PHONE_DATA_NAME_INDEX = 9;

        // Comm data
        private const int DGV_COMM_DATA_DISPLAY_INDEX = 0;

        // Toggles
        public Dictionary<string, bool> Toggles;
        public bool GotToggles = false;
        public int ToggleAttempts = 0;

        // Others
        public bool NeedsSaving = false;

        public FrmMain()
        {
            Loading = true;

            InitializeComponent();

            string filepath = Application.StartupPath + @"/log.txt";
            if (!File.Exists(filepath))
            {
                using (FileStream fs = File.Create(filepath))
                {
                    // writing data in string
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                }
            }

            FSetLineCount = new FrmSetLineCount(0);
            FSetLineCountOldFirmware = new FrmOldFirmwareSettingLineCount();
            MinimumSize = Size;

            LinkPorts = new LinkPortsClass();

            // Setup Toggles
            Toggles = new Dictionary<string, bool>();
            Toggles.Add("C", false);
            Toggles.Add("U", false);
            Toggles.Add("D", false);
            Toggles.Add("A", false);
            Toggles.Add("S", false);
            Toggles.Add("O", false);
            Toggles.Add("B", false);
            Toggles.Add("K", false);

            Common.DrawColors(this);
            Common.SetTitle(this, "Editing Unit");

            // Boot up Receiver Threads
            _udpReceiveThread6699.IsBackground = true;
            _udpReceiveThread6699.Start();
            _udpReceiveThread3520.IsBackground = true;
            _udpReceiveThread3520.Start();

            // Start Listeners
            Subscribe(UdpReceiver6699);
            Subscribe(UdpReceiver3520);

            if(!Common.IsRunningOnMono())
            {
                rtbHint.Text = @"This configuration and test tool is normally for:" + (char)13 + "     - Setting the static IP of the device" + (char)13 + "     - Testing for call records arriving from the Caller ID unit" + (char)13 + "" + (char)13 + "Advanced users can set a number of other parameters including:" + (char)13 + "     - Toggles for output options on Deluxe units" + (char)13 + "     - Destination IP and MAC unicasts" + (char)13 + "     - Duplicate call record delivery to increase throughput." + (char)13 + "     - Starting Line count when connecting multiple units" + (char)13 + "	 " + (char)13 + "Unit Number:" + (char)13 + "	Some applications use unit numbers to match data arriving from multiple units." + (char)13 + "" + (char)13 + "Unit IP Address:" + (char)13 + "	Set a static IP address within the IP scheme either outside the DHCP range or a value that would not create an IP conflict with another device on the network." + (char)13 + "	Based on this computer’s IP address of: [computer_ip] the suggested IP of the unit should be: [suggested_ip]." + (char)13 + "	" + (char)13 + "Unit Destination Port:" + (char)13 + "	The default Network communication port is 3520. Do not change unless your application absolutely requires it. A value other than 3520 or 6699 will require you change the listening port on this application." + (char)13 + "	" + (char)13 + "Destination IP Address:" + (char)13 + "	The IP to where the call records will be sent. The default is 255.255.255.255 (broadcast) which most applications use, even if only one PC is listening for data. Change only if necessary." + (char)13 + "	" + (char)13 + "Unit MAC Address:" + (char)13 + "	The MAC address to where call records will be sent. The default is FF-FF-FF-FF-FF-FF (Broadcast) which most applications use. Change to specific MAC only if the Destination IP is specified as a unicast.";

                string computerIP = GetComputerIP();

                string[] computerIPParts = computerIP.Split('.');
                int lastInt = int.Parse(computerIPParts[3]);

                string suggestedIP = "192.168.0.90";
                if (lastInt > 50 && lastInt < 100)
                {
                    suggestedIP = computerIPParts[0] + "." + computerIPParts[1] + "." + computerIPParts[2] + ".190";
                }
                else
                {
                    suggestedIP = computerIPParts[0] + "." + computerIPParts[1] + "." + computerIPParts[2] + ".90";
                }

                rtbHint.Text = rtbHint.Text.Replace("[computer_ip]", computerIP);
                rtbHint.Text = rtbHint.Text.Replace("[suggested_ip]", suggestedIP);


            }
            else
            {
                
            }

            Loading = false;
        }

        // Custom receiver
        public void StartCustomReceiver(int port)
        {
            UdpReceiverClassCustom.ListenOn = port;

            UdpReceiverCustom = new UdpReceiverClassCustom();
            _udpReceiveThreadCustom = new Thread(UdpReceiverCustom.UdpIdleReceive);

            _udpReceiveThreadCustom.IsBackground = true;
            _udpReceiveThreadCustom.Start();

            Subscribe(UdpReceiverCustom);
            LinkPorts.AddPort(UdpReceiverClassCustom.ListenOn, UdpReceiverClassCustom.LastIncomingIPAddress);
        }

        // UDP Port --------------------------------------------------------------------------
        public void Subscribe(UdpReceiverClass6699 u)
        {
            // If UDP event occurs run HeardIt method
            u.DataReceived += HeardIt6699;
        }

        private void HeardIt6699(UdpReceiverClass6699 u, EventArgs e)
        {
            // HELP : example how to call method
            // Invoke((MethodInvoker)(() => methodName()));
            Invoke((MethodInvoker)(HandleReception6699));

        }

        public void Subscribe(UdpReceiverClass3520 u)
        {
            // If UDP event occurs run HeardIt method
            u.DataReceived += HeardIt3520;
        }

        private void HeardIt3520(UdpReceiverClass3520 u, EventArgs e)
        {
            // HELP : example how to call method
            // Invoke((MethodInvoker)(() => methodName()));
            Invoke((MethodInvoker)(HandleReception3520));

        }

        public void Subscribe(UdpReceiverClassCustom u)
        {
            // If UDP event occurs run HeardIt method
            u.DataReceived += HeardItCustom;
        }

        private void HeardItCustom(UdpReceiverClassCustom u, EventArgs e)
        {
            // HELP : example how to call method
            // Invoke((MethodInvoker)(() => methodName()));
            Invoke((MethodInvoker)(HandleReceptionCustom));

        }

        private void HandleReceptionCustom()
        {
            HandleAllReception(UdpReceiverClassCustom.ListenOn);
        }

        private void HandleReception6699()
        {
            HandleAllReception(6699);
        }

        private void HandleReception3520()
        {
            HandleAllReception(3520);
        }

        private void HandleAllReception(int port)
        {

            // Handle UDP Reception
            string reception;
            byte[] receptionBytes;

            if (port == 6699)
            {
                // 6699
                reception = UdpReceiverClass6699.ReceivedMessage;
                receptionBytes = UdpReceiverClass6699.ReceviedMessageByte;

            }
            else if (port == 3520)
            {
                // 3520
                reception = UdpReceiverClass3520.ReceivedMessage;
                receptionBytes = UdpReceiverClass3520.ReceviedMessageByte;
            }
            else
            {
                // Other
                reception = UdpReceiverClassCustom.ReceivedMessage;
                receptionBytes = UdpReceiverClassCustom.ReceviedMessageByte;
            }

            if (receptionBytes.Length == 5 || receptionBytes.Length == 6) return;

            string ip = "";
            switch (port)
            {
                case 3520:
                    ip = UdpReceiverClass3520.LastIncomingIPAddress;
                    break;

                case 6699:
                    ip = UdpReceiverClass6699.LastIncomingIPAddress;
                    break;

                default:
                    ip = UdpReceiverClassCustom.LastIncomingIPAddress;
                    break;
            }

            // Set main repsonse port (first response only)
            if (receptionBytes.Length == 90)
            {
                LinkPorts.SetMainPort(port);

                // Add Serials
                // -- Get Serial/Ethernet ID 
                SerialNumber = "";
                for (int i = 84; i <= 89; i++)
                {
                    int intValue = receptionBytes[i];
                    string sn_piece = intValue.ToString("X");
                    if (sn_piece.Length == 1) sn_piece = "0" + sn_piece;
                    SerialNumber += sn_piece;
                }
            }

            //LinkPorts.AddPort(port, ip);

            if (receptionBytes.Length == 31)
            {
                string number = reception.Substring(reception.Length - 10);
                AddToCommData("Blocked Number: " + number);

                if (Program.FBlockingConfig != null)
                {
                    if (Program.FBlockingConfig.Visible)
                    {
                        Program.FBlockingConfig.AddRowToList(number);
                    }
                }
            }

            if (receptionBytes.Length == 22)
            {

                bool is_private = reception.Substring(reception.Length - 1, 1) == "P";

                if (is_private)
                {
                    AddToCommData("Private Blocked");

                    if (Program.FBlockingConfig != null)
                    {
                        if (Program.FBlockingConfig.Visible)
                        {
                            Program.FBlockingConfig.AddRowToList("Private Calls");
                        }
                    }

                }
                else if (reception.Substring(reception.Length - 1, 1) == "O")
                {
                    AddToCommData("Out-Of-Area Blocked");

                    if (Program.FBlockingConfig != null)
                    {
                        if (Program.FBlockingConfig.Visible)
                        {
                            Program.FBlockingConfig.AddRowToList("Out-Of-Area Calls");
                        }
                    }
                }

            }

            if (receptionBytes.Length < 57 && reception.Contains("ok"))
            {
                NeedsSaving = false;
                lbNeedsSaving.Visible = false;
                AddToCommData("Unit Updated");
                ReEnableAllUnlocks();
            }

            if (receptionBytes.Length == 28 || receptionBytes.Length == 29 || receptionBytes.Length == 52 || receptionBytes.Length == 53)
            {

                Match fVersionBoot = Regex.Match(reception, @"V(\d(\.)?\d)");

                if (fVersionBoot.Success)
                {
                    FirmwareVersion = double.Parse(fVersionBoot.Groups[1].Value.ToString());
                }

                Match lineCountBoot = Regex.Match(reception, @"((\d{1,2}) V)");

                if (lineCountBoot.Success)
                {
                    LineCount = int.Parse(lineCountBoot.Groups[2].Value.ToString());
                }

                if(fVersionBoot.Success || lineCountBoot.Success)
                {
                    LinkPorts.SetMainPort(port, true);

                    // On seen boot, ping back broadcast
                    // to search for that unit X command
                    // to make sure no IP conflicts (keep
                    // Link Ports updated)
                    string ip_temp = SendToIP;
                    SendToIP = "255.255.255.255";
                    SendUdp("^^IdX", port);
                    SendToIP = ip_temp;
                }

                if (LineCount > 8)
                {
                    if (!AskedToChangeLineCount)
                    {
                        if (FSetLineCountDipSwitches == null)
                        {
                            FSetLineCountDipSwitches = new FrmSetLineCountWithDipSwitches();
                            FSetLineCountDipSwitches.Show();
                        }
                        else if (FSetLineCountDipSwitches.Visible)
                        {
                            FSetLineCountDipSwitches.WindowState = FormWindowState.Normal;
                            FSetLineCountDipSwitches.Focus();
                        }
                    }
                }

                int startAt = 21;

                string comm_reception = reception.Substring(startAt, reception.Length - startAt);

                if (dgvCommData.Rows.Count > 0)
                {
                    if (dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value.ToString() != comm_reception)
                    {
                        AddToCommData(comm_reception);
                    }
                }
                else
                {
                    AddToCommData(comm_reception);
                }

            }

            if (receptionBytes.Length != 90 && receptionBytes.Length != 57 && receptionBytes.Length != 83 && receptionBytes.Length != 84 && receptionBytes.Length != 52 && receptionBytes.Length != 53 && receptionBytes.Length != 15) return;

            ConnectionPings = 0;
            lbConnected.Visible = true;
            imgConnected.Visible = true;
            lbListeningOn.Visible = true;

            // ------------------------------------------------------------------------
            // If Call Record
            // ------------------------------------------------------------------------
            if (receptionBytes.Length == 83 || receptionBytes.Length == 84 || receptionBytes.Length == 52 || receptionBytes.Length == 53)
            {
                // DUPLICATES CODING START
                if (ckbIgnoreDups.Checked)
                {
                    if (previousReceptions.ContainsKey(reception))
                    {
                        if (previousReceptions[reception] < 60) return;
                    }
                    else
                    {

                        if (previousReceptions.Count > 30)
                        {
                            previousReceptions.Add(reception, 0);

                            string removeKey = "";
                            foreach (string key in previousReceptions.Keys)
                            {
                                removeKey = key;
                                break;
                            }

                            if (!string.IsNullOrEmpty(removeKey))
                            {
                                previousReceptions.Remove(removeKey);
                            }

                        }
                        else
                        {
                            previousReceptions.Add(reception, 0);
                        }
                    }
                }
                // DUPLICATES CODING END
                
                CallRecord record = new CallRecord(reception);

                if (record.IsValid)
                {

                    if (record.Line > 8)
                    {
                        if (!AskedToChangeLineCount)
                        {
                            FSetLineCountDipSwitches = new FrmSetLineCountWithDipSwitches();
                            FSetLineCountDipSwitches.Show();
                        }
                    }

                    bool blocked = record.InternalBlock;
                    string start_end = blocked ? "B" : record.StartOrEnd;

                    if (record.Detailed)
                    {
                        AddCallRecordToPhoneData(record.Line.ToString(), record.DetailedType.ToString(), "", "", "", "", record.DateTime.ToShortDateString(), record.DateTime.ToShortTimeString(), "", "");
                    }
                    else
                    {
                        AddCallRecordToPhoneData(record.Line.ToString(), record.InboundOrOutboundOrBlock.ToString(), start_end, record.Duration.ToString(),
                            record.CheckSum.ToString(), record.RingType + record.RingNumber, record.DateTime.ToShortDateString(), record.DateTime.ToShortTimeString(),
                            record.PhoneNumber, record.Name);
                    }
                }

                return;
            }
            else if(receptionBytes.Length == 15)
            {
                int isDigit = -1;
                int.TryParse(Encoding.ASCII.GetString(receptionBytes).Trim().Replace("^^IdVV", ""), out isDigit);

                if (isDigit >= 35) lbDupsPossible.Visible = true;

                return;
            }
            else if (receptionBytes.Length != 90 && receptionBytes.Length != 83)
            {

                int startAt = 21;

                string comm_reception = reception.Substring(startAt, reception.Length - startAt);

                if (dgvCommData.Rows.Count > 0)
                {
                    if (dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value.ToString() != comm_reception)
                    {
                        AddToCommData(comm_reception);
                    }
                }
                else
                {
                    AddToCommData(comm_reception);
                }
            }

            // -------------------------------------------------------------------------
            // If Toggles
            // -------------------------------------------------------------------------

            if (receptionBytes.Length == 57)
            {
                
                Match fVersion = Regex.Match(reception, @"V(\d\.\d)");

                if (fVersion.Success)
                {
                    FirmwareVersion = double.Parse(fVersion.Groups[1].Value.ToString());
                }
                
                int start_at = 1;
                Match m = Regex.Match(reception, @"([Ee])([Cc])([Xx])([Uu])([Dd])([Aa])([Ss])([Oo])([Bb])([Kk])([Tt]) L=(\d{1,2}) (\d{1,2}/\d{1,2}) (\d{1,2}:\d{1,2}:\d{1,2})");

                if (m.Success)
                {

                    Toggles["E"] = m.Groups[start_at].Value.ToString() == "e";
                    Toggles["C"] = m.Groups[start_at + 1].Value.ToString() == "c";
                    Toggles["U"] = m.Groups[start_at + 3].Value.ToString() == "u";
                    Toggles["D"] = m.Groups[start_at + 4].Value.ToString() == "d";
                    Toggles["A"] = m.Groups[start_at + 5].Value.ToString() == "a";
                    Toggles["S"] = m.Groups[start_at + 6].Value.ToString() == "s";
                    Toggles["O"] = m.Groups[start_at + 7].Value.ToString() == "o";
                    Toggles["B"] = m.Groups[start_at + 8].Value.ToString() == "b";
                    Toggles["K"] = m.Groups[start_at + 9].Value.ToString() == "k";

                    if(Program.FBlockingConfig != null)
                    {
                        if (Program.FBlockingConfig.Visible)
                        {
                            Program.FBlockingConfig.SetEnabledDisabled(Toggles["U"]);
                        }
                    }                    

                    LineCount = int.Parse(m.Groups[start_at + 11].Value.ToString());

                    if (LineCount > 1)
                    {
                        if (!AskedToChangeLineCount)
                        {
                            if (FirmwareVersion >= 5.0 && FirmwareVersion <= 9.6)
                            {
                                FSetLineCount = new FrmSetLineCount(LineCount, true);
                                FSetLineCount.Show();
                                AskedToChangeLineCount = true;
                            }
                            else
                            {
                                FSetLineCount = new FrmSetLineCount(LineCount, true);
                                FSetLineCount.Show();
                                AskedToChangeLineCount = true;
                            }
                        }
                    }

                    lbLineCount.Text = LineCount.ToString().PadLeft(2,'0');

                    if (FSetLineCount.Visible)
                    {
                        FSetLineCount.lbLineCount.Text = LineCount.ToString().PadLeft(2, '0');
                        FrmSetLineCount.Loading = true;
                        FSetLineCount.DisplayNewLineCount(LineCount);
                        FSetLineCount.cbLineCount.Text = LineCount.ToString();
                        FrmSetLineCount.Loading = false;
                    }

                    DeluxeUnitDetected = true;
                    UpdateToggles();
                    lbDeluxeUnitDetected.Text = "Deluxe Unit\nDETECTED";
                    unlockTogglesToolStripMenuItem.Visible = false;
                    GotToggles = true;

                }

                return;
            }

            // -------------------------------------------------------------------------
            //           X COMMAND

            // Handle and Parse

            // UNIT NUMBER-----------------------
            UnitNumber = "";
            int unitStartPos = 57;

            for (int i = unitStartPos; i <= unitStartPos + 5; i++)
            {
                string un_piece = ((int)receptionBytes[i]).ToString("X").PadLeft(2,'0');
                UnitNumber += un_piece;
            }

            if (!tbUnitNumber.Enabled)
            {
                tbUnitNumber.Text = UnitNumber;
            }

            // ----------------------------------

            // Ethernet ID 
            SerialNumber = "";
            for (int i = 84; i <= 89; i++)
            {
                int intValue = receptionBytes[i];
                string sn_piece = intValue.ToString("X");
                if (sn_piece.Length == 1) sn_piece = "0" + sn_piece;
                SerialNumber += sn_piece;
            }

            // ----------------------------------

            // MAC Address -----------------------
            MACAddress = "";
            for (int i = 24; i <= 29; i++)
            {
                int intValue = receptionBytes[i];
                string mac_piece = intValue.ToString("X");
                if (mac_piece.Length == 1) mac_piece = "0" + mac_piece;
                MACAddress += mac_piece + ":";
            }
            MACAddress = MACAddress.Substring(0, MACAddress.Length - 1);
            
            if(MACAddress.Substring(0,2) != "06")
            {
                ResetUnitMAC();
            }
            
            if (!tbMAC.Enabled)
            {
                tbMAC.Text = MACAddress;
            }

            // ----------------------------------

            // IP Address -----------------------
            TheIPAddress = "";
            for (int i = 33; i <= 36; i++)
            {
                int intValue = receptionBytes[i];
                string ip_piece = intValue.ToString();
                TheIPAddress += ip_piece + ".";
            }
            TheIPAddress = TheIPAddress.Substring(0, TheIPAddress.Length - 1);
            
            if (!tbIP.Enabled)
            {
                tbIP.Text = TheIPAddress;
            }

            // Add IP to list if needed
            LinkPorts.AddEthernetIDAndIP(SerialNumber, TheIPAddress);

            // ----------------------------------

            // Dest Port -----------------------
            DestPort = "";
            for (int i = 52; i <= 53; i++)
            {
                int intValue = receptionBytes[i];
                string destPort_piece = intValue.ToString("X");
                if (destPort_piece.Length == 1) destPort_piece = "0" + destPort_piece;
                DestPort += destPort_piece;
            }
            DestPort = Convert.ToInt32(DestPort, 16).ToString();

            int dest_port = int.Parse(DestPort);
            LinkPorts.AddPort(dest_port, TheIPAddress);
            LinkPorts.SetMainPort(dest_port, true);

            if(dest_port != 3520 && dest_port != 6699)
            {
                // Use custom receiver
                UdpReceiverClassCustom.Done = true;

                StartCustomReceiver(dest_port);

            }

            if (!tbDestPort.Enabled)
            {
                tbDestPort.Text = DestPort;
            }

            // ----------------------------------

            // Dest IP Address -----------------------
            DestIP = "";
            for (int i = 40; i <= 43; i++)
            {
                int intValue = receptionBytes[i];
                string ip_piece = intValue.ToString();
                DestIP += ip_piece + ".";
            }
            DestIP = DestIP.Substring(0, DestIP.Length - 1);
            
            if (!tbDestIP.Enabled)
            {
                tbDestIP.Text = DestIP;
            }

            // ----------------------------------

            // Dest MAC Address -----------------------
            DestMAC = "";
            for (int i = 66; i <= 71; i++)
            {
                int intValue = receptionBytes[i];
                string mac_piece = intValue.ToString("X");
                if (mac_piece.Length == 1) mac_piece = "0" + mac_piece;
                DestMAC += mac_piece + ":";
            }
            DestMAC = DestMAC.Substring(0, DestMAC.Length - 1);
            
            if (!tbDestMAC.Enabled)
            {
                tbDestMAC.Text = DestMAC;
            }

            // ----------------------------------

            Dups = receptionBytes[75];
            lbDups.Text = "# Of Dups: " + Dups.ToString();

            if (Dups >= 254)
            {
                lbDups.Visible = false;
                ckbIgnoreDups.Visible = false;
                sendDuplicateCallRecordsToolStripMenuItem.Visible = false;
            }
            else
            {
                lbDups.Visible = true;
                ckbIgnoreDups.Visible = true;
                sendDuplicateCallRecordsToolStripMenuItem.Visible = true;

                if (Dups > 1 && !HaveShownDupResetWindow)
                {
                    HaveShownDupResetWindow = true;

                    if (!Common.IsRunningOnMono())
                    {
                        FrmDupsOverOne fDupsOverOne = new FrmDupsOverOne(Dups);
                        fDupsOverOne.ShowDialog();
                    }
                }
            }
        }

        public void ResetUnitMAC()
        {
            Common.WaitFor(150);

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string day = DateTime.Now.Day.ToString().PadLeft(2, '0');
            string secs = DateTime.Now.Second.ToString().PadLeft(2, '0');

            string mac = "06" + year + month + day + secs;

            byte[] to_send = ASCIIEncoding.ASCII.GetBytes("^^IdM" + mac);
            UdpReceiver3520.SendUDP(to_send);

        }

        public static void SendUdp(string toSend, int port)
        {
            var s = Encoding.ASCII.GetBytes(toSend.ToCharArray(), 0, toSend.Length);
            if (port == 6699)
            {
                UdpReceiver6699.SendUDP(s);
            }
            else if (port == 3520)
            {
                UdpReceiver3520.SendUDP(s);
            }
            else
            {
                UdpReceiverCustom.SendUDP(s);
            }
        }

        // -----------------------------------------------------------------

        private void CommandButtonSend(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btn = (Button)sender;

            string toSend = btn.Text.ToString().ToUpper();
            
            SendUdp("^^Id-" + toSend, LinkPorts.MainPort);
            Common.WaitFor(250);
            Common.AddToLogFile("Command: " + btn.Text.ToUpper(), "", "");

        }

        private void SetToggle(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            
            Button btn = (Button)sender;

            string toSend = btn.Text.ToString();
            string previous_toggle = toSend;

            if (toSend == toSend.ToUpper())
            {
                toSend = toSend.ToLower();
            }
            else
            {
                toSend = toSend.ToUpper();
            }

            SendUdp("^^Id-" + toSend, LinkPorts.MainPort);
            Common.WaitFor(250);
            btnRetrieveToggles_Click(new object(), new EventArgs());
            Common.AddToLogFile("Toggle: " + toSend.ToUpper(), previous_toggle, toSend);

            if (Common.IsRunningOnMono())
            {
                Common.WaitFor(250);
                btnRetrieveToggles_Click(new object(), new EventArgs());
            }
        }

        private void UpdateToggles()
        {
            SetToggleVisibility(true);
            foreach (string toggle in Toggles.Keys)
            {
                UpdateToggleButton(toggle, Toggles[toggle]);
            }
        }

        private void UpdateToggleButton(string toggle, bool set)
        {
            string btnName = "btnToggle" + toggle;

            foreach (Control ctrl in Controls)
            {
                if (!(ctrl is Button)) continue;

                if (!(ctrl.Name == btnName)) continue;

                if (set)
                {
                    ctrl.Text = toggle.ToLower();
                    ctrl.BackColor = Common.C_GREENISH;
                }
                else
                {
                    ctrl.Text = toggle.ToUpper();
                    ctrl.BackColor = Common.C_BUTTON_BACK;
                }
            }

        }

        private void SetToggleVisibility(bool visible)
        {
            if (btnRetrieveToggles.Visible) return;

            if (LinkPorts.MainPort == 0) visible = false;

            foreach (Control ctrl in Controls)
            {
                if (!(ctrl is Button)) continue;

                if(ctrl.Name.Contains("btnToggle"))
                {
                    ctrl.Visible = visible;
                }
            }
            btnRetrieveToggles.Visible = visible;
        }

        private void UpdateParameter(string button_name)
        {
            switch (button_name)
            {
                case "btnUnlockUnitNumber":

                    SendUdp("^^IdU" + tbUnitNumber.Text.PadLeft(12, '0'), LinkPorts.MainPort);
                    Common.AddToLogFile("Unit Number", PreviousUnitNumber, tbUnitNumber.Text);

                    break;

                case "btnUnlockIPAddress":

                    SendUdp("^^IdI" + Common.HexFromIP(tbIP.Text), LinkPorts.MainPort);
                    Common.AddToLogFile("Unit IP", PreviousTheIPAddress, tbIP.Text);

                    break;

                case "btnUnlockMACAddress":

                    SendUdp("^^IdM" + tbMAC.Text.Replace(":", ""), LinkPorts.MainPort);
                    Common.AddToLogFile("Unit MAC", PreviousMACAddress, tbMAC.Text.Replace(":", "-"));

                    break;

                case "btnUnlockDestPort":

                    SendUdp("^^IdT" + (int.Parse(tbDestPort.Text).ToString("X")).PadLeft(4, '0'), LinkPorts.MainPort);

                    if (string.IsNullOrEmpty(tbDestPort.Text)) break;
                    Program.FMain.StartCustomReceiver(int.Parse(tbDestPort.Text));
                    FrmMain.LinkPorts.AddPort(int.Parse(tbDestPort.Text), tbIP.Text);

                    Common.AddToLogFile("Destination Port", PreviousDestPort, tbDestPort.Text);

                    break;

                case "btnUnlockDestIP":

                    SendUdp("^^IdD" + Common.HexFromIP(tbDestIP.Text), LinkPorts.MainPort);
                    Common.AddToLogFile("Destination IP", PreviousDestIP, tbDestIP.Text);

                    break;

                case "btnUnlockDestMAC":

                    string mac = tbDestMAC.Text.Replace(":", "").Replace("-","");
                    SendUdp("^^IdC" + mac, LinkPorts.MainPort);
                    Common.AddToLogFile("Destination MAC", PreviousDestMAC.Replace(":","-"), tbDestMAC.Text.Replace(":", "-"));

                    break;

                default:
                    return;
            }
        }

        private void Unlocks(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btnUnlockUnitNumber":

                    if (LinkPorts.AnyDuplicateIPs(SendToIP))
                    {
                        FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                        fMultiUnits.Show();
                        return;
                    }

                    if (btn.Text == "Change")
                    {
                        PreviousUnitNumber = tbUnitNumber.Text;
                        btn.Text = "Save";
                        tbUnitNumber.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        lbNeedsSaving.Visible = true;
                        lbNeedsSaving.ForeColor = Color.Red;
                    }
                    else
                    {
                        UpdateParameter(btn.Name);
                    }

                    break;

                case "btnUnlockIPAddress":

                    if (LinkPorts.AnyDuplicateIPs(SendToIP))
                    {
                        FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                        fMultiUnits.Show();
                        return;
                    }
                    
                    if (btn.Text.Contains("Set"))
                    {
                        PreviousTheIPAddress = tbIP.Text;
                        tbIP.Text = GetComputerIP().Substring(0, GetComputerIP().LastIndexOf(".")) + ".90";
                        btn.Text = "Save";
                        tbIP.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        lbNeedsSaving.Visible = true;
                        lbNeedsSaving.ForeColor = Color.Red;
                    }
                    else
                    {

                        if (!(Common.IsValidIP(tbIP.Text)))
                        {
                            Common.MessageBox("Invalid IP Address.", "Invalid", true);
                            return;
                        }

                        btn.Text = "Set Unit IP to Suggested";
                        tbIP.Enabled = false;
                        WaitingForNewIP = true;
                        ChangingIPTo = tbIP.Text;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockMACAddress":

                    if (LinkPorts.AnyDuplicateIPs(SendToIP))
                    {
                        FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                        fMultiUnits.Show();
                        return;
                    }

                    if (btn.Text == "Change")
                    {
                        PreviousMACAddress = tbMAC.Text.Replace(":", "-");
                        btn.Text = "Save";
                        tbMAC.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        lbNeedsSaving.Visible = true;
                        lbNeedsSaving.ForeColor = Color.Red;
                    }
                    else
                    {
                        btn.Text = "Change";
                        tbMAC.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockDestPort":

                    if (LinkPorts.AnyDuplicateIPs(SendToIP))
                    {
                        FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                        fMultiUnits.Show();
                        return;
                    }

                    if (btn.Text == "Change")
                    {
                        string message = "The 2 default Network Ports suported by ELConfig are 3520 and 6699." + Environment.NewLine + Environment.NewLine + "Changing the port number that the unit sends to other than these 2 default ports is not reccomended." + Environment.NewLine + Environment.NewLine + "Do so only if absolutely neccesary for your application." + Environment.NewLine + Environment.NewLine + "Are you sure you wish to change the Destination Port now?";

                        if (MessageBox.Show(new Form() { TopMost = true }, message, "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) return;

                        PreviousDestPort = tbDestPort.Text;
                        btn.Text = "Save";
                        tbDestPort.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        lbNeedsSaving.Visible = true;
                        lbNeedsSaving.ForeColor = Color.Red;
                    }
                    else
                    {
                        btn.Text = "Change";
                        tbDestPort.Enabled = false;
                        UpdateParameter(btn.Name);
                        LinkPorts.SetMainPort(int.Parse(tbDestPort.Text), true);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockDestIP":

                    if (LinkPorts.AnyDuplicateIPs(SendToIP))
                    {
                        FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                        fMultiUnits.Show();
                        return;
                    }

                    if (btn.Text == "Change")
                    {
                        PreviousDestIP = tbDestIP.Text;
                        btn.Text = "Save";
                        tbDestIP.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        lbNeedsSaving.Visible = true;
                        lbNeedsSaving.ForeColor = Color.Red;
                    }
                    else
                    {

                        if (!(Common.IsValidIP(tbDestIP.Text)))
                        {
                            Common.MessageBox("Invalid IP Address.", "Invalid", true);
                            return;
                        }

                        btn.Text = "Change";
                        tbDestIP.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockDestMAC":

                    if (LinkPorts.AnyDuplicateIPs(SendToIP))
                    {
                        FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                        fMultiUnits.Show();
                        return;
                    }

                    if (btn.Text == "Change")
                    {
                        PreviousDestMAC = tbDestMAC.Text;
                        btn.Text = "Save";
                        tbDestMAC.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        lbNeedsSaving.Visible = true;
                        lbNeedsSaving.ForeColor = Color.Red;
                    }
                    else
                    {
                        btn.Text = "Change";
                        tbDestMAC.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;


                default:
                    return;
            }

            Common.WaitFor(250);

        }
        
        private void ReEnableAllUnlocks()
        {
            foreach (Control ctrl in Controls)
            {
                if (!(ctrl is Panel)) continue;

                if (ctrl.Name != "panChangers") continue;

                foreach (Control pan_ctrl in ctrl.Controls)
                {
                    if (pan_ctrl is Button)
                    {
                        if (pan_ctrl.Name.Contains("btnUnlock"))
                        {
                            if(pan_ctrl.Name == "btnUnlockIPAddress")
                            {
                                pan_ctrl.Enabled = true;
                                pan_ctrl.Text = "Set IP to Suggested";
                                pan_ctrl.BackColor = Common.C_BUTTON_BACK;
                                continue;
                            }
                            pan_ctrl.Enabled = true;
                            pan_ctrl.Text = "Change";
                            pan_ctrl.BackColor = Common.C_BUTTON_BACK;
                        }
                    }
                    if (pan_ctrl is TextBox)
                    {
                        pan_ctrl.Enabled = false;
                    }
                }
            }
        }
        
        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btn = (Button)sender;

            if (btn.Text == "Save") return;

            btn.BackColor = Common.C_ATTENTION;

            switch (btn.Name)
            {
                case "btnUnlockUnitNumber":
                case "tbUnitNumber":

                    lbHintHeader.Text = "Unit Number";
                    rtbHint.Text = "Some applications use unit numbers to match data arriving from multiple units.";

                    break;

                case "btnUnlockIPAddress":
                case "tbIP":

                    lbHintHeader.Text = "Unit IP Address:";
                    string computerIP = GetComputerIP();

                    string[] computerIPParts = computerIP.Split('.');
                    int lastInt = int.Parse(computerIPParts[3]);

                    string suggestedIP = "192.168.0.90";
                    if (lastInt > 50 && lastInt < 100)
                    {
                        suggestedIP = computerIPParts[0] + "." + computerIPParts[1] + "." + computerIPParts[2] + ".190";
                    }
                    else
                    {
                        suggestedIP = computerIPParts[0] + "." + computerIPParts[1] + "." + computerIPParts[2] + ".90";
                    }

                    string message = "Set a static IP address within the IP scheme either outside the DHCP range or a value that would not create an IP conflict with another device on the network." + Environment.NewLine+Environment.NewLine+
                        "Based on this computer’s IP address of: [computer_ip] the suggested IP of the unit should be: [suggested_ip].";

                    message = message.Replace("[computer_ip]", computerIP);
                    message = message.Replace("[suggested_ip]", suggestedIP);

                    rtbHint.Text = message;


                    break;

                case "btnUnlockMACAddress":
                case "tbMAC":



                    break;

                case "btnUnlockDestPort":
                case "tbDestPort":

                    lbHintHeader.Text = "Unit Destination Port:";
                    rtbHint.Text = "The default Network communication port is 3520. Do not change unless your application absolutely requires it. A value other than 3520 or 6699 will require you change the listening port on this application.";

                    break;

                case "btnUnlockDestIP":
                case "tbDestIP":

                    lbHintHeader.Text = "Destination IP Address:";
                    rtbHint.Text = "The IP to where the call records will be sent. The default is 255.255.255.255 (broadcast) which most applications use, even if only one PC is listening for data. Change only if necessary.";

                    break;

                case "btnUnlockDestMAC":
                case "tbDestMAC":

                    lbHintHeader.Text = "Unit MAC Address:";
                    rtbHint.Text = "The MAC address to where call records will be sent. The default is FF-FF-FF-FF-FF-FF (Broadcast) which most applications use. Change to specific MAC only if the Destination IP is specified as a unicast.";

                    break;


                default:
                    return;
            }       
        }

        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btn = (Button)sender;

            if (btn.Text == "Save") return;

            btn.BackColor = Common.C_BUTTON_BACK;

            lbHintHeader.Text = "ELConfig 5";
            rtbHint.Text = "This configuration and test tool is normally for:\n     - Setting the static IP of the device\n     - Testing for call records arriving from the Caller ID unit\n\n" +
                "Advanced users can set a number of other parameters including:\n     - Toggles for output options on Deluxe units\n     - Destination IP and MAC unicasts\n     - Duplicate call record delivery to increase throughput.\n" +
                "     - Starting Line count when connecting multiple units";
        }

        private void ToggleMouseEnter(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btnToggleC":

                    lbHintHeader.Text = "Toggle 'C'";
                    rtbHint.Text = "Lowercase c prepends “$” to records & removes dashes in phone numbers";

                    break;

                case "btnToggleU":

                    lbHintHeader.Text = "Toggle 'U'";
                    rtbHint.Text = "Used for Call Blocking using relayed-enabled hardware";

                    break;

                case "btnToggleD":

                    lbHintHeader.Text = "Toggle 'D'";
                    rtbHint.Text = "Lowercase 'd' sends On Hook, Off Hook, and Ring call records";

                    break;

                case "btnToggleA":

                    lbHintHeader.Text = "Toggle 'A'";
                    rtbHint.Text = "Uppercase 'A' sends both Start and End of Call records";

                    break;

                case "btnToggleS":

                    lbHintHeader.Text = "Toggle 'S'";
                    rtbHint.Text = "Uppercase 'S' sends only Start of Call records when lowercase 'a' is set";

                    break;

                case "btnToggleO":

                    lbHintHeader.Text = "Toggle 'O'";
                    rtbHint.Text = "Lowercase 'o' sends Outbound Call records";

                    break;

                case "btnToggleB":

                    lbHintHeader.Text = "Toggle 'B'";
                    rtbHint.Text = "Uppercase 'B' blocks first ring of Inbound calls using relayed-enabled hardware";

                    break;

                case "btnToggleK":

                    lbHintHeader.Text = "Toggle 'K'";
                    rtbHint.Text = "Used for Call Blocking using relayed-enabled hardware";

                    break;

            }
        }

        private void ToggleMouseLeave(object sender, EventArgs e)
        {
            lbHintHeader.Text = "ELConfig 5";
            rtbHint.Text = "This configuration and test tool is normally for:\n     - Setting the static IP of the device\n     - Testing for call records arriving from the Caller ID unit\n\n" +
                "Advanced users can set a number of other parameters including:\n     - Toggles for output options on Deluxe units\n     - Destination IP and MAC unicasts\n     - Duplicate call record delivery to increase throughput.\n" +
                "     - Starting Line count when connecting multiple units";
        }

        // -----------------------------------------------------------------
        private bool CheckingToggles = false;
        private void AddToCommData(string message)
        {
            
            if(dgvCommData.Rows.Count > 0)
            {
                string previous = dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value.ToString();

                Match m = Regex.Match(previous, @"([Ee])([Cc])([Xx])([Uu])([Dd])([Aa])([Ss])([Oo])([Bb])([Kk])([Tt]) L=(\d{1,2}) (\d{1,2}/\d{1,2}) (\d{1,2}:\d{1,2}:\d{1,2})");
                Match msg = Regex.Match(message, @"([Ee])([Cc])([Xx])([Uu])([Dd])([Aa])([Ss])([Oo])([Bb])([Kk])([Tt]) L=(\d{1,2}) (\d{1,2}/\d{1,2}) (\d{1,2}:\d{1,2}:\d{1,2})");

                if ((m.Success && msg.Success) && !CheckingToggles)
                { 
                    return;
                }
            }

            CheckingToggles = false;

            dgvCommData.Rows.Add();
            dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value = message;
            dgvCommData.FirstDisplayedScrollingRowIndex = dgvCommData.Rows.Count - 1;
        }

        private void AddCallRecordToPhoneData(string ln, string io, string se, string dur, string cs, string ring, string date, string time, string number, string name)
        {
            dgvPhoneData.Rows.Add();
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_LINE_INDEX].Value = ln.PadLeft(2, '0');
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_IO_INDEX].Value = io;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_SE_INDEX].Value = se;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_DUR_INDEX].Value = dur == "" ? "" : dur.PadLeft(4, '0');
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_CS_INDEX].Value = cs;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_RING_INDEX].Value = ring;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_DATE_INDEX].Value = date;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_TIME_INDEX].Value = time;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_NUMBER_INDEX].Value = number;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_NAME_INDEX].Value = name;
            dgvPhoneData.FirstDisplayedScrollingRowIndex = dgvPhoneData.Rows.Count - 1;

            if (LoggingCallRecords)
            {
                if(!(string.IsNullOrEmpty(sfdLogCallLog.FileName)))
                {
                    string export_line = ln.PadLeft(2, '0') + "  " + io + "  " + se + "  " + dur + "  " + cs + "  " + ring + "  " + date + "  " + time + "  " + number + "  " + name;
                    Common.AddToCallLogFile(sfdLogCallLog.FileName, export_line);
                }
            }
        }

        // -----------------------------------------------------------------
        public void timerRefresher_Tick(object sender, EventArgs e)
        {
            timerRefresher.Interval = 1000;

            if(fComputerMsg != null)
            {
                if (fComputerMsg.Visible) fComputerMsg.timerRefresher_Tick(null, null);
            }

            bool bound = false;
            switch (LinkPorts.MainPort)
            {
                case 3520:

                    bound = UdpReceiverClass3520.IsBound;

                    break;

                case 6699:

                    bound = UdpReceiverClass6699.IsBound;

                    break;

                default:

                    bound = UdpReceiverClassCustom.IsBound;

                    break;
            }
            
            if (bound)
            {
                lbListeningOn.Text = "Listening on: " + LinkPorts.MainPort;
            }
            else
            {
                lbListeningOn.Text = "Failed to bind";
                ConnectionPings = 5;
            }

            ConnectionPings += 1;
            
            if (ConnectionPings > 4)
            {
                imgConnected.Visible = false;
                imgConnected.BackColor = Color.Pink;
                panStatus.BackColor = Color.Pink;
                lbConnected.BackColor = Color.Pink;
                lbDeluxeUnitDetected.BackColor = Color.Pink;
                lbListeningOn.BackColor = Color.Pink;
                lbNeedsSaving.BackColor = Color.Pink;
                lbConnected.Text = "NOT Connected";
                lbUnitFoundIP.Visible = false;

                ResetDisplay();

                if (!FoundAndSwitchedToUnicast)
                {
                    if (LinkPorts.AnyDuplicateIPs())
                    {
                        if (!HaveHadAConnection)
                        {
                            // If ELC found an IP that works
                            // but has not connected then
                            // Switch to Uni-cast and attempt
                            // tries via Uni-cast.
                            FoundAndSwitchedToUnicast = true;
                            SendToIP = FoundUnitIPs[0];
                        }
                    }
                }
                
                // Reset for fast poling unit
                timerRefresher.Interval = 1000;

            }
            else
            {

                if(lbUnlock.Text == "U")
                {
                    if (DeluxeUnitDetected)
                    {
                        btnBlockingConfig.Visible = true;
                        btnQ.Visible = true;
                        btnR.Visible = true;
                        btnJ.Visible = true;
                    }
                }

                imgConnected.Visible = true;
                imgConnected.BackColor = Common.C_GREENISH;
                lbListeningOn.Visible = true;
                panStatus.BackColor = Common.C_GREENISH;
                lbConnected.BackColor = Common.C_GREENISH;
                lbDeluxeUnitDetected.BackColor = Common.C_GREENISH;
                lbNeedsSaving.BackColor = Common.C_GREENISH;
                lbListeningOn.BackColor = Common.C_GREENISH;
                lbConnected.Text = "Connected";
                lbUnitFoundIP.Visible = true;
            }

            if (LinkPorts.MainPort == 0)
            {
                SendUdp("^^IdX", 6699);
                Common.WaitFor(250);
                SendUdp("^^IdX", 3520);
                Common.WaitFor(250);
                SendUdp("^^Id-V", 6699);
                Common.WaitFor(250);
                SendUdp("^^Id-V", 3520);

                if (!AlwaysShowToggles)
                {
                    lbDeluxeUnitDetected.Text = "Deluxe Unit\nNOT detected";
                    SetToggleVisibility(false);
                }

            }
            else
            {
                HaveHadAConnection = true;

                List<int> l_ports = LinkPorts.GetAllPorts();
                foreach (int linkedPort in l_ports)
                {
                    SendUdp("^^IdX", linkedPort);
                    Common.WaitFor(100);
                    SendUdp("^^Id-V", linkedPort);
                    Common.WaitFor(100);
                    SendUdp("^^IdV", linkedPort);
                    Common.WaitFor(100);
                }

                timerRefresher.Interval = 4000;

                if (LinkPorts.ContainsPort(6699))
                {
                    
                    if(!(FoundUnitIPs.Contains(UdpReceiverClass6699.LastIncomingIPAddress)))
                    {
                        if (UdpReceiverClass6699.LastIncomingIPAddress != null)
                        {
                            if (UdpReceiverClass6699.LastIncomingIPAddress == ChangingIPTo)
                            {
                                WaitingForNewIP = false;
                                FoundUnitIPs.Clear();
                                ChangingIPTo = "";
                                FoundUnitIPs.Add(UdpReceiverClass6699.LastIncomingIPAddress);
                            }
                            else
                            {
                                FoundUnitIPs.Add(UdpReceiverClass6699.LastIncomingIPAddress);
                            }
                        }
                    }

                    if (LinkPorts.AnyDuplicateIPs())
                    {
                        lbUnitFoundIP.Text = "Multiple Units Found";
                        lbSendingTo.Text = "Sending Commands to: " + SendToIP;
                    }
                    else
                    {
                        lbUnitFoundIP.Text = "Unit Found on IP: " + UdpReceiverClass6699.LastIncomingIPAddress;
                        lbSendingTo.Text = "Sending Commands to: " + SendToIP;
                    }
                    
                }
                
                if(LinkPorts.ContainsPort(3520))
                {

                    if (!(FoundUnitIPs.Contains(UdpReceiverClass3520.LastIncomingIPAddress)))
                    {
                        if (UdpReceiverClass3520.LastIncomingIPAddress != null)
                        {
                            if (UdpReceiverClass3520.LastIncomingIPAddress == ChangingIPTo)
                            {
                                WaitingForNewIP = false;
                                FoundUnitIPs.Clear();
                                ChangingIPTo = "";
                                FoundUnitIPs.Add(UdpReceiverClass3520.LastIncomingIPAddress);
                            }
                            else
                            {
                                FoundUnitIPs.Add(UdpReceiverClass3520.LastIncomingIPAddress);
                            }
                        }
                    }

                    if (LinkPorts.AnyDuplicateIPs())
                    {
                        lbUnitFoundIP.Text = "Multiple Units Found";
                        lbSendingTo.Text = "Sending Commands to: " + SendToIP;
                    }
                    else
                    {
                        lbUnitFoundIP.Text = "Unit Found on IP: " + UdpReceiverClass3520.LastIncomingIPAddress;
                        lbSendingTo.Text = "Sending Commands to: " + SendToIP;
                    }
                }
                
                if(LinkPorts.ContainsPort(UdpReceiverClassCustom.ListenOn))
                {

                    if (!(FoundUnitIPs.Contains(UdpReceiverClassCustom.LastIncomingIPAddress)))
                    {
                        if (UdpReceiverClassCustom.LastIncomingIPAddress != null)
                        {
                            if (UdpReceiverClassCustom.LastIncomingIPAddress == ChangingIPTo)
                            {
                                WaitingForNewIP = false;
                                FoundUnitIPs.Clear();
                                ChangingIPTo = "";
                                FoundUnitIPs.Add(UdpReceiverClassCustom.LastIncomingIPAddress);
                            }
                            else
                            {
                                FoundUnitIPs.Add(UdpReceiverClassCustom.LastIncomingIPAddress);
                            }
                        }
                    }

                    if (LinkPorts.AnyDuplicateIPs())
                    {
                        lbUnitFoundIP.Text = "Multiple Units Found";
                        lbSendingTo.Text = "Sending Commands to: " + SendToIP;
                    }
                    else
                    {
                        lbUnitFoundIP.Text = "Unit Found on IP: " + UdpReceiverClassCustom.LastIncomingIPAddress;
                        lbSendingTo.Text = "Sending Commands to: " + SendToIP;
                    }
                }
            }

            if (LinkPorts.AnyDuplicateIPs()) timerRefresher.Interval = 4000;



        }

        private void btnClearPhoneData_Click(object sender, EventArgs e)
        {
            dgvPhoneData.Rows.Clear();
        }

        private void btnClearCommData_Click(object sender, EventArgs e)
        {
            dgvCommData.Rows.Clear();
        }

        public void btnRetrieveToggles_Click(object sender, EventArgs e)
        {
            CheckingToggles = true;
            SendUdp("^^Id-V", LinkPorts.MainPort);
            Common.WaitFor(250);
            SendUdp("^^Id-V", LinkPorts.MainPort);
            Common.WaitFor(250);
            SendUdp("^^Id-V", LinkPorts.MainPort);
            Common.WaitFor(250);
            SendUdp("^^Id-V", LinkPorts.MainPort);

            if (Common.IsRunningOnMono())
            {
                btnRetrieveToggles.BackColor = SystemColors.Control;
            }
        }

        private void timerGetToggles_Tick(object sender, EventArgs e)
        {
            if (ToggleAttempts > 4) return;

            if (!GotToggles)
            {
                SendUdp("^^Id-V", LinkPorts.MainPort);
            }
        }

        private void resetEthernetDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SendUdp("^^IdDFFFFFFFF", LinkPorts.MainPort); //External IP
            Common.WaitFor(250);
            SendUdp("^^IdU000000000001", LinkPorts.MainPort); //Unit ID
            Common.WaitFor(250);
            SendUdp("^^IdIC0A8005A", LinkPorts.MainPort); //Internal IP
            Common.WaitFor(250);
            SendUdp("^^IdCFFFFFFFFFFFF", LinkPorts.MainPort); //Destination MAC address
            Common.WaitFor(250);
            SendUdp("^^IdT0DC0", LinkPorts.MainPort); //Port Number
            Common.WaitFor(250);

            int intVal = 1;
            string hexStr = intVal.ToString("X").PadLeft(2, '0');
            int previous_dups = Dups;
            SendUdp("^^IdO" + hexStr, LinkPorts.MainPort);
            Common.AddToLogFile("Duplicates", previous_dups.ToString(), intVal.ToString());

            Common.MessageBox("Command Sent.", "Finished");

        }

        private void setDeluxeUnitOutputDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-N0000007701", LinkPorts.MainPort);
            Common.WaitFor(250);
            SendUdp("^^Id-R", LinkPorts.MainPort);

            Common.MessageBox("Command Sent.", "Finished");
            Program.FMain.dgvCommData.Rows.Clear();
            Common.WaitFor(100);
            btnRetrieveToggles_Click(null, null);
        }

        public FrmComputerIP fComputerMsg = null;
        private void displayComputerIPAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fComputerMsg = new FrmComputerIP(GetComputerIP(), GetComputerMAC(), tbDestIP.Text, tbDestMAC.Text);
            fComputerMsg.Show();
        }

        private string GetComputerIP()
        {

            if (Program.IsMono)
            {

                //Create process
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

                //strCommand is path and file name of command to run
                pProcess.StartInfo.FileName = "ifconfig";
                
                pProcess.StartInfo.UseShellExecute = false;

                //Set output of program to be written to process output stream
                pProcess.StartInfo.RedirectStandardOutput = true;

                //Start the process
                pProcess.Start();

                //Get program output
                string strOutput = pProcess.StandardOutput.ReadToEnd();

                //Wait for process to finish
                pProcess.WaitForExit();

                Match matcher = Regex.Match(strOutput, @"inet (\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})");

                List<string> ips = new List<string>();
                while (matcher.Success)
                {
                    string ip = matcher.Groups[1].Value.ToString();

                    if(ip != "127.0.0.1")
                    {
                        ips.Add(ip);
                    }

                    matcher = matcher.NextMatch();
                }

                if (ips.Count > 0)
                {
                    return ips[0];
                }
                else
                {
                    return "127.0.0.1";
                }

            }

            string strHostName = System.Net.Dns.GetHostName();
            string strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList[0].ToString();
        
            return strIPAddress;

        }

        private string GetComputerMAC(string ip = "")
        {

            if (Program.IsMono)
            {

                //Create process
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

                //strCommand is path and file name of command to run
                pProcess.StartInfo.FileName = "ifconfig";

                pProcess.StartInfo.UseShellExecute = false;

                //Set output of program to be written to process output stream
                pProcess.StartInfo.RedirectStandardOutput = true;

                //Start the process
                pProcess.Start();

                //Get program output
                string strOutput = pProcess.StandardOutput.ReadToEnd();

                //Wait for process to finish
                pProcess.WaitForExit();

                Match matcher = Regex.Match(strOutput, @"ether ([0-9A-Za-z]{2}\:[0-9A-Za-z]{2}\:[0-9A-Za-z]{2}\:[0-9A-Za-z]{2}\:[0-9A-Za-z]{2}\:[0-9A-Za-z]{2})");

                List<string> macs = new List<string>();
                while (matcher.Success)
                {
                    string mac = matcher.Groups[1].Value.ToString();

                    macs.Add(mac.Replace(":", "-").ToUpper());
                    matcher = matcher.NextMatch();

                }

                if (macs.Count > 0)
                {
                    return macs[0];
                }
                else
                {
                    return "00-00-00-00-00-00";
                }

            }

            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault();

            return macAddr.Substring(0, 2) + "-" + macAddr.Substring(2, 2) + "-" + macAddr.Substring(4, 2) + "-" + macAddr.Substring(6, 2) + "-" + macAddr.Substring(8, 2) + "-" + macAddr.Substring(10, 2);
        }

        private void setUnitToCurrentTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-N0000007701\r\n", LinkPorts.MainPort);
            Common.WaitFor(250);
            DateTime t = DateTime.Now;
            string timeString = t.Month.ToString().PadLeft(2, '0') + t.Day.ToString().PadLeft(2, '0') + t.Hour.ToString().PadLeft(2, '0') + t.Minute.ToString().PadLeft(2, '0');
            timeString = "^^Id-Z" + timeString + "\r";
            SendUdp(timeString, LinkPorts.MainPort);
            Common.WaitFor(800);
            SendUdp("^^Id-V", LinkPorts.MainPort);

            Common.MessageBox("Command Sent.", "Finished");
        }

        private void setDeluxeUnitToBasicUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-a", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-E", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-C", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-X", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-U", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-K", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-S", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-B", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-D", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-O", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-T", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-a", LinkPorts.MainPort);
            Common.WaitFor(100);
            SendUdp("^^Id-V", LinkPorts.MainPort);

            Common.MessageBox("Commands to Reset Sent.", "Finished");
        }

        private void sendDuplicateCallRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSendDups fDups = new FrmSendDups();
            fDups.ShowDialog();
        }

        private void unlockTogglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlwaysShowToggles = true;
                        
            SetToggleVisibility(true);

        }

        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPing fPing = new FrmPing();
            fPing.ShowDialog();
        }

        private void setupUnicastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUniCast fUniCast = new FrmUniCast();
            fUniCast.ShowDialog();
        }

        private void setLineCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSetLineCount = new FrmSetLineCount(LineCount);
            FSetLineCount.ShowDialog();
        }

        private void timerPreviousReceptionHandliing_Tick(object sender, EventArgs e)
        {
            // DUPLICATES CODING START
            // This timer is used to increment all seconds
            // of the previous receptions and remove them 
            // after 4 seconds have passed.

            // If there is nothing in the reception buffer then simply exit function
            if (previousReceptions.Count < 1) return;

            // Create needed lists
            List<string> keysToRemove = new List<string>();
            List<string> keysToIncrement = new List<string>();

            // Loop through previously received call records
            // and mark the ones which need to be removed and
            // mark the ones to increment the seconds on
            foreach (string key in previousReceptions.Keys)
            {
                if (previousReceptions[key] > 4) // remove after 4 seconds
                {
                    // This reception will be removed
                    keysToRemove.Add(key);
                }
                else
                {
                    // This reception has no waited another second
                    keysToIncrement.Add(key);
                }
            }

            // Increment the second of all needed receptions in buffer
            foreach (string key in keysToIncrement)
            {
                previousReceptions[key]++;
            }

            // Remove all receptions in buffer that are past the time limit (2 seconds)
            foreach (string key in keysToRemove)
            {
                previousReceptions.Remove(key);
            }

            // If we are debugging/developer/unlocked mode then refresh the presentation of buffer
            if (FDupsTracking.Visible)
            {
                FDupsTracking.RefreshDups(previousReceptions);
            }

            // DUPLICATES CODING END
        }

        private void duplicateTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDupsTracking = new FrmDuplicateTracking();
            FDupsTracking.Show();
        }

        private void lbUnlock_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbUnlock.Text == "L")
            {
                duplicateTrackingToolStripMenuItem.Visible = true;

                if (DeluxeUnitDetected)
                {
                    btnBlockingConfig.Visible = true;
                    btnQ.Visible = true;
                    btnR.Visible = true;
                    btnJ.Visible = true;
                }

                SetToggleVisibility(true);
                AlwaysShowToggles = true;
                btnRetrieveToggles.Visible = true;
                lbUnlock.Text = "U";
            }
            else
            {
                duplicateTrackingToolStripMenuItem.Visible = false;
                lbUnlock.Text = "L";

                btnBlockingConfig.Visible = false;
                btnQ.Visible = false;
                btnR.Visible = false;
                btnJ.Visible = false;

            }
        }

        private void timerFoundIPChecker_Tick(object sender, EventArgs e)
        {
            
            if (HaveShownMultipleUnitMessage || WaitingForNewIP) return;

            if (LinkPorts.AnyDuplicateIPs())
            {
                HaveShownMultipleUnitMessage = true;
                FrmMultipleUnits fMultiUnits = new FrmMultipleUnits();
                fMultiUnits.ShowDialog();
            }
        }

        private void listeningPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangeListeningPort fChangeListeningPort = new FrmChangeListeningPort();
            fChangeListeningPort.ShowDialog();
        }

        private void PreventAlphaCharacters(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FLog = new FrmLog();
            FLog.Show();
        }

        private void btnDestMAC_MouseDown(object sender, MouseEventArgs e)
        {
            if (btnUnlockDestMAC.Text == "Change") return;

            if (!(e.Button == System.Windows.Forms.MouseButtons.Right)) return;

            if (MessageBox.Show("Change to this computer's MAC Address?", "Use Computer MAC?", MessageBoxButtons.YesNo) == DialogResult.No) return;

            tbDestMAC.Text = GetComputerMAC().Replace("-", ":");

        }

        private void msiLogCallRecords_Click(object sender, EventArgs e)
        {
            if (msiLogCallRecords.Text == "Start Logging Call Records")
            {
                sfdLogCallLog.Filter = "Text File | *.txt";

                DialogResult result = sfdLogCallLog.ShowDialog();

                if (result != System.Windows.Forms.DialogResult.OK) return;

                if (string.IsNullOrEmpty(sfdLogCallLog.FileName))
                {
                    Common.MessageBox("Invalid file path.", "Invalid");
                    return;
                }

                msiLogCallRecords.Text = "Stop Logging Call Records";
                LoggingCallRecords = true;
            }
            else
            {
                msiLogCallRecords.Text = "Start Logging Call Records";
                LoggingCallRecords = false;
            }
        }

        private void btnBlockingConfig_Click(object sender, EventArgs e)
        {
            if (Program.FBlockingConfig == null)
            {
                Program.FBlockingConfig = new FrmBlockingConfig(Toggles["U"]);
                Program.FBlockingConfig.Show();
                Program.FBlockingConfig.Focus();
                return;
            }
            if (Program.FBlockingConfig.Visible)
            {
                Program.FBlockingConfig.WindowState = FormWindowState.Normal;
                Program.FBlockingConfig.Focus();
                return;
            }
            else
            {
                Program.FBlockingConfig = new FrmBlockingConfig(Toggles["U"]);
                Program.FBlockingConfig.Show();
                Program.FBlockingConfig.Focus();
                return;
            }
        }
        
        // ----------------------------------------------------------------------------------

        private void ResetDisplay()
        {
            
            if (!tbUnitNumber.Focused) tbUnitNumber.Text = "NO UNIT";
            if (!tbIP.Focused) tbIP.Text = "0.0.0.0";
            if (!tbMAC.Focused) tbMAC.Text = "00:00:00:00:00:00";
            if (!tbDestIP.Focused) tbDestIP.Text = "0.0.0.0";
            if (!tbDestMAC.Focused) tbDestMAC.Text = "00:00:00:00:00:00";

            Toggles = new Dictionary<string, bool>();
            Toggles.Add("C", false);
            Toggles.Add("U", false);
            Toggles.Add("D", false);
            Toggles.Add("A", false);
            Toggles.Add("S", false);
            Toggles.Add("O", false);
            Toggles.Add("B", false);
            Toggles.Add("K", false);

            UpdateToggles();


        }

        private void boundStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoundStatus fBound = new BoundStatus();
            fBound.ShowDialog();
        }

        private void btnUnlockUnitNumber_MouseEnter(object sender, EventArgs e)
        {
            ButtonMouseEnter(sender, e);
        }

        private void btnUnlockDestPort_MouseEnter(object sender, EventArgs e)
        {
            ButtonMouseEnter(sender, e);
        }
    }
}
