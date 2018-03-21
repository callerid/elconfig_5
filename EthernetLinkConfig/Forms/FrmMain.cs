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


namespace EthernetLinkConfig
{
    public partial class FrmMain : Form
    {
        public bool Loading = true;
        public bool AlwaysShowToggles = false;
        public bool FoundAndSwitchedToUnicast = false;
        public bool HasHadAConnection = false;
        
        // Receivers
        public static UdpReceiverClass6699 UdpReceiver6699 = new UdpReceiverClass6699();
        readonly Thread _udpReceiveThread6699 = new Thread(UdpReceiver6699.UdpIdleReceive);
        public static UdpReceiverClass3520 UdpReceiver3520 = new UdpReceiverClass3520();
        readonly Thread _udpReceiveThread3520 = new Thread(UdpReceiver3520.UdpIdleReceive);
        public static int LinkPort = 0;
        public int ConnectionPings = 3;
        public bool DeluxeUnitDetected = false;

        // Required sending IP data
        public static string FoundIP = "";
        public static string SendToIP = "255.255.255.255";

        // Call Record reception
        List<string> previousReceptions = new List<string>();

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
            MinimumSize = Size;

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

            cbLineCount.SelectedIndex = 0;

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

            Loading = false;
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

        private void HandleReception6699()
        {
            HandleAllReception(6699);
        }

        private void HandleReception3520()
        {
            HandleAllReception(3520);
        }

        private void RemovePreviousReceptionFromBuffer(string reception)
        {
            List<int> indexes = new List<int>();
            int cnt = 0;
            foreach (string rec in previousReceptions)
            {
                if (rec.Contains(reception.Substring(reception.Length - 20)))
                {
                    indexes.Add(cnt);
                }

                cnt++;

            }

            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                previousReceptions.RemoveAt(indexes[i]);
            }

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
            else
            {
                // 3520
                reception = UdpReceiverClass3520.ReceivedMessage;
                receptionBytes = UdpReceiverClass3520.ReceviedMessageByte;
            }

            if (receptionBytes.Length == 5) return;

            LinkPort = port;

            if (receptionBytes.Length < 57 && reception.Contains("ok"))
            {
                NeedsSaving = false;
                lbNeedsSaving.Visible = false;
                AddToCommData("Unit Updated");
                ReEnableAllUnlocks();
            }

            if (receptionBytes.Length != 90 && receptionBytes.Length != 57 && receptionBytes.Length != 83 && receptionBytes.Length != 52) return;

            ConnectionPings = 0;
            lbConnected.Visible = true;
            imgConnected.Visible = true;
            lbListeningOn.Visible = true;
            lbListeningOn.Text = "Listening On: " + LinkPort;

            // ------------------------------------------------------------------------
            // If Call Record
            // ------------------------------------------------------------------------
            if (receptionBytes.Length == 83 || receptionBytes.Length == 52)
            {
                // Duplicate handling
                if (ckbIgnoreDups.Checked)
                {
                    if (previousReceptions.Contains(reception))
                    {
                        return;
                    }
                    else
                    {

                        if (previousReceptions.Count > 30)
                        {
                            previousReceptions.Add(reception);
                            previousReceptions.RemoveAt(0);
                        }
                        else
                        {
                            previousReceptions.Add(reception);
                        }
                    }
                }
                
                CallRecord record = new CallRecord(reception);

                if (record.IsValid)
                {
                    // If end record then remove entries form previousReceptions buffer
                    if (record.IsEndRecord() && ckbIgnoreDups.Checked)
                    {
                        RemovePreviousReceptionFromBuffer(reception);
                    }

                    if (record.Detailed)
                    {
                        AddCallRecordToPhoneData(record.Line.ToString(), record.DetailedType.ToString(), "", "", "", "", record.DateTime.ToShortDateString(), record.DateTime.ToShortTimeString(), "", "");
                    }
                    else
                    {
                        AddCallRecordToPhoneData(record.Line.ToString(), record.InboundOrOutboundOrBlock.ToString(), record.StartOrEnd, record.Duration.ToString(),
                            record.CheckSum.ToString(), record.RingType + record.RingNumber, record.DateTime.ToShortDateString(), record.DateTime.ToShortTimeString(),
                            record.PhoneNumber, record.Name);
                    }
                }

                return;
            }
            else if (receptionBytes.Length != 90 && receptionBytes.Length != 83)
            {
                if (dgvCommData.Rows.Count > 0)
                {
                    if (dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value.ToString() != reception)
                    {
                        AddToCommData(reception);
                    }
                }
                else
                {
                    AddToCommData(reception);
                }
            }

            // -------------------------------------------------------------------------
            // If Toggles
            // -------------------------------------------------------------------------

            if (receptionBytes.Length == 57)
            {
                int start_at = 1;
                Match m = Regex.Match(reception, @"([Ee])([Cc])([Xx])([Uu])([Dd])([Aa])([Ss])([Oo])([Bb])([Kk])([Tt]) L=(\d{1,2}) (\d{1,2}/\d{1,2}) (\d{1,2}:\d{1,2}:\d{1,2})");

                if (m.Success)
                {

                    Toggles["E"] = m.Groups[start_at].Value.ToString() == "e";
                    Toggles["U"] = m.Groups[start_at + 3].Value.ToString() == "u";
                    Toggles["D"] = m.Groups[start_at + 4].Value.ToString() == "d";
                    Toggles["A"] = m.Groups[start_at + 5].Value.ToString() == "a";
                    Toggles["S"] = m.Groups[start_at + 6].Value.ToString() == "s";
                    Toggles["O"] = m.Groups[start_at + 7].Value.ToString() == "o";
                    Toggles["B"] = m.Groups[start_at + 8].Value.ToString() == "b";
                    Toggles["K"] = m.Groups[start_at + 9].Value.ToString() == "k";

                    LineCount = int.Parse(m.Groups[start_at + 11].Value.ToString());
                    lbLineCount.Text = LineCount.ToString().PadLeft(2,'0');

                    DeluxeUnitDetected = true;
                    UpdateToggles();
                    lbDeluxeUnitDetected.Text = "Deluxe Unit DETECTED";
                    GotToggles = true;

                }

                return;
            }

            // -------------------------------------------------------------------------

            // Handle and Parse

            // UNIT NUMBER-----------------------
            UnitNumber = "";
            int unitStartPos = 4;
            
            /* IF NIC CARD -----
            if (ckbNIC.Checked)
            {
                unitStartPos = 5;
            }
             ------------------- */

            for (int i = unitStartPos; i <= unitStartPos + 5; i++)
            {
                string un_piece = ((int)receptionBytes[i]).ToString("X").PadLeft(2, '0');
                UnitNumber += un_piece;
            }

            if (!tbUnitNumber.Enabled)
            {
                tbUnitNumber.Text = UnitNumber;
            }

            // ----------------------------------

            // SERIAL NUMBER-----------------------
            SerialNumber = "";
            for (int i = 84; i <= 89; i++)
            {
                int intValue = receptionBytes[i];
                string sn_piece = intValue.ToString("X");
                if (sn_piece.Length == 1) sn_piece = "0" + sn_piece;
                SerialNumber += sn_piece;
            }
            lbEthernetID.Text = SerialNumber;

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

        }

        public static void SendUdp(string toSend, int port)
        {
            var s = Encoding.ASCII.GetBytes(toSend.ToCharArray(), 0, toSend.Length);
            if (port == 6699)
            {
                UdpReceiver6699.SendUDP(s);
            }
            else
            {
                UdpReceiver3520.SendUDP(s);
            }
        }

        // -----------------------------------------------------------------

        private void SetToggle(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            
            Button btn = (Button)sender;

            string toSend = btn.Text.ToString();

            if (toSend == toSend.ToUpper())
            {
                toSend = toSend.ToLower();
            }
            else
            {
                toSend = toSend.ToUpper();
            }

            SendUdp("^^Id-" + toSend, LinkPort);
            Common.WaitFor(250);
            btnRetrieveToggles_Click(new object(), new EventArgs());

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
                    ctrl.BackColor = Color.LightGreen;
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

                    SendUdp("^^IdU" + tbUnitNumber.Text.PadLeft(12, '0'), LinkPort);

                    break;

                case "btnUnlockIPAddress":

                    SendUdp("^^IdI" + Common.HexFromIP(tbIP.Text), LinkPort);

                    break;

                case "btnUnlockMACAddress":

                    SendUdp("^^IdM" + tbMAC.Text.Replace(":", ""), LinkPort);

                    break;

                case "btnUnlockDestPort":

                    SendUdp("^^IdT" + tbDestPort.Text.PadLeft(4, '0'), LinkPort);

                    break;

                case "btnUnlockDestIP":

                    SendUdp("^^IdD" + Common.HexFromIP(tbDestIP.Text), LinkPort);

                    break;

                case "btnUnlockDestMAC":

                    SendUdp("^^IdC" + tbDestMAC.Text.Replace(":", ""), LinkPort);

                    break;

                default:
                    return;
            }
        }

        private void Unlocks(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            lbNeedsSaving.Visible = true;

            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btnUnlockUnitNumber":

                    if (btn.Text == "Unlock")
                    {
                        btn.Text = "Save";
                        tbUnitNumber.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                        DisableAllUnlocksExcept(btn.Name);
                    }
                    else
                    {
                        UpdateParameter(btn.Name);
                    }

                    break;

                case "btnUnlockIPAddress":

                    if (btn.Text == "Unlock")
                    {
                        btn.Text = "Save";
                        tbIP.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                    }
                    else
                    {
                        btn.Text = "Unlock";
                        tbIP.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockMACAddress":

                    if (btn.Text == "Unlock")
                    {
                        btn.Text = "Save";
                        tbMAC.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                    }
                    else
                    {
                        btn.Text = "Unlock";
                        tbMAC.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockDestPort":

                    if (btn.Text == "Unlock")
                    {
                        btn.Text = "Save";
                        tbDestPort.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                    }
                    else
                    {
                        btn.Text = "Unlock";
                        tbDestPort.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockDestIP":
                    
                    if (btn.Text == "Unlock")
                    {
                        btn.Text = "Save";
                        tbDestIP.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                    }
                    else
                    {
                        btn.Text = "Unlock";
                        tbDestIP.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;

                case "btnUnlockDestMAC":
                    
                    if (btn.Text == "Unlock")
                    {
                        btn.Text = "Save";
                        tbDestMAC.Enabled = true;
                        btn.BackColor = Common.C_NEEDS_SAVING;
                        NeedsSaving = true;
                    }
                    else
                    {
                        btn.Text = "Unlock";
                        tbDestMAC.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
                    }

                    break;


                default:
                    return;
            }            
        }

        private void DisableAllUnlocksExcept(string btnName)
        {
            foreach (Control ctrl in Controls)
            {
                if (!(ctrl is Panel)) continue;

                if (ctrl.Name != "panChangers") continue;

                foreach (Control pan_ctrl in ctrl.Controls)
                {
                    if (!(pan_ctrl is Button)) continue;

                    if (pan_ctrl.Name.Contains("btnUnlock"))
                    {
                        if (pan_ctrl.Name != btnName) pan_ctrl.Enabled = false;
                    }
                }                
            }
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
                            pan_ctrl.Enabled = true;
                            pan_ctrl.Text = "Unlock";
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
        }

        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btn = (Button)sender;

            if (btn.Text == "Save") return;

            btn.BackColor = Common.C_BUTTON_BACK;
        }

        // -----------------------------------------------------------------

        private void AddToCommData(string message)
        {
            dgvCommData.Rows.Add();
            dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value = message;
        }

        private void AddCallRecordToPhoneData(string ln, string io, string se, string dur, string cs, string ring, string date, string time, string number, string name)
        {
            dgvPhoneData.Rows.Add();
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_LINE_INDEX].Value = ln.PadLeft(2, '0');
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_IO_INDEX].Value = io;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_SE_INDEX].Value = se;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_DUR_INDEX].Value = dur;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_CS_INDEX].Value = cs;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_RING_INDEX].Value = ring;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_DATE_INDEX].Value = date;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_TIME_INDEX].Value = time;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_NUMBER_INDEX].Value = number;
            dgvPhoneData.Rows[dgvPhoneData.Rows.Count - 1].Cells[DGV_PHONE_DATA_NAME_INDEX].Value = name;
        }
        // -----------------------------------------------------------------

        private void timerRefresher_Tick(object sender, EventArgs e)
        {
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
                lbListeningOn.Text = "Listening...";
                lbUnitFoundIP.Visible = false;

                if (!FoundAndSwitchedToUnicast)
                {
                    if (!string.IsNullOrEmpty(FoundIP))
                    {
                        if (!HasHadAConnection)
                        {
                            // If ELC found an IP that works
                            // but has not connected then
                            // Switch to Uni-cast and attempt
                            // tries via Uni-cast.
                            FoundAndSwitchedToUnicast = true;
                            SendToIP = FoundIP;
                        }
                    }
                }

                // Reset for fast poling unit
                timerRefresher.Interval = 750;

            }
            else
            {
                imgConnected.Visible = true;
                imgConnected.BackColor = Color.LightGreen;
                lbListeningOn.Visible = true;
                lbListeningOn.Text = "Listening On: " + LinkPort;
                panStatus.BackColor = Color.LightGreen;
                lbConnected.BackColor = Color.LightGreen;
                lbDeluxeUnitDetected.BackColor = Color.LightGreen;
                lbNeedsSaving.BackColor = Color.LightGreen;
                lbListeningOn.BackColor = Color.LightGreen;
                lbConnected.Text = "Connected";
                lbUnitFoundIP.Visible = true;
            }

            if (LinkPort == 0)
            {
                SendUdp("^^IdX", 6699);
                Common.WaitFor(250);
                SendUdp("^^IdX", 3520);

                if (!AlwaysShowToggles)
                {
                    lbDeluxeUnitDetected.Text = "Deluxe Unit NOT detected";
                    SetToggleVisibility(false);
                }

            }
            else
            {
                HasHadAConnection = true;

                SendUdp("^^IdX", LinkPort);

                // Reset to slow poling
                if (ConnectionPings < 4)
                {
                    timerRefresher.Interval = 3000;
                }
                else
                {
                    timerRefresher.Interval = 750;
                }

                if (LinkPort == 6699)
                {
                    FoundIP = UdpReceiverClass6699.LastIncomingIPAddress;
                    lbUnitFoundIP.Text = "Unit Found on IP Address: " + UdpReceiverClass6699.LastIncomingIPAddress;
                    lbSendingTo.Text = "Currently Sending Commands To: " + SendToIP;
                }
                else
                {
                    FoundIP = UdpReceiverClass3520.LastIncomingIPAddress;
                    lbUnitFoundIP.Text = "Unit Found on IP Address: " + UdpReceiverClass3520.LastIncomingIPAddress;
                    lbSendingTo.Text = "Currently Sending Commands To: " + SendToIP;
                }
            }
        }

        private void btnClearPhoneData_Click(object sender, EventArgs e)
        {
            dgvPhoneData.Rows.Clear();
        }

        private void btnClearCommData_Click(object sender, EventArgs e)
        {
            dgvCommData.Rows.Clear();
        }

        private void btnRetrieveToggles_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-V", LinkPort);
            Common.WaitFor(250);
            SendUdp("^^Id-V", LinkPort);
            Common.WaitFor(250);
            SendUdp("^^Id-V", LinkPort);
            Common.WaitFor(250);
            SendUdp("^^Id-V", LinkPort);
            Common.WaitFor(250);
        }

        private void timerGetToggles_Tick(object sender, EventArgs e)
        {
            if (ToggleAttempts > 4) return;

            if (!GotToggles)
            {
                SendUdp("^^Id-V", LinkPort);
            }
        }

        private void resetEthernetDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^IdDFFFFFFFF", LinkPort); //External IP
            Common.WaitFor(250);
            SendUdp("^^IdU000000000001", LinkPort); //Unit ID
            Common.WaitFor(250);
            SendUdp("^^IdIC0A8005A", LinkPort); //Internal IP
            Common.WaitFor(250);
            SendUdp("^^IdCFFFFFFFFFFFF", LinkPort); //Destination MAC address
            Common.WaitFor(250);
            SendUdp("^^IdT0DC0", LinkPort); //Port Number
            Common.WaitFor(250);

            Common.MessageBox("Command Sent.", "Finished");

        }

        private void setDeluxeUnitOutputDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-N0000007701", LinkPort);
            Common.WaitFor(250);
            SendUdp("^^Id-R", LinkPort);

            Common.MessageBox("Command Sent.", "Finished");
        }

        private void displayComputerIPAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.MessageBox(Environment.NewLine + "Your IP: " + GetComputerIP(), "Computer IP Address", true, -1);
        }

        private string GetComputerIP()
        {

            string strHostName = System.Net.Dns.GetHostName();
            string strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList[0].ToString();
        
            return strIPAddress;

        }

        private void setUnitToCurrentTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-N0000007701\r\n",LinkPort);
            Common.WaitFor(250);
            DateTime t = DateTime.Now;
            string timeString = t.Month.ToString().PadLeft(2, '0') + t.Day.ToString().PadLeft(2, '0') + t.Hour.ToString().PadLeft(2, '0') + t.Minute.ToString().PadLeft(2, '0');
            timeString = "^^Id-Z" + timeString + "\r";
            SendUdp(timeString, LinkPort);
            Common.WaitFor(800);
            SendUdp("^^Id-V",LinkPort);

            Common.MessageBox("Command Sent.", "Finished");
        }

        private void SetLineCount(int line)
        {
            string sendString = "";
            switch (line)
            {

                case 1:
                    sendString = "^^Id-N0000007701\r\n";
                    break;

                case 5:
                    sendString = "^^Id-N0000007705\r\n";
                    break;

                case 9:
                    sendString = "^^Id-N0000007709\r\n";
                    break;

                case 17:
                    sendString = "^^Id-N0000007711\r\n";
                    break;

                case 21:
                    sendString = "^^Id-N0000007715\r\n";
                    break;

                case 25:
                    sendString = "^^Id-N0000007719\r\n";
                    break;

                case 33:
                    sendString = "^^Id-N0000007721\r\n";
                    break;
            }

            SendUdp(sendString, LinkPort);

            Common.MessageBox("Command Sent.", "Finished");

        }

        private void cbLineCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading) return;
            SetLineCount(int.Parse(cbLineCount.Text.ToString()));
            Common.WaitFor(250);
            btnRetrieveToggles_Click(new object(), new EventArgs());
        }

        private void setDeluxeUnitToBasicUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendUdp("^^Id-a", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-E", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-C", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-X", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-U", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-K", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-S", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-B", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-D", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-O", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-T", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-a", LinkPort);
            Common.WaitFor(100);
            SendUdp("^^Id-V", LinkPort);

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
        
        // ----------------------------------------------------------------------------------
    }
}
