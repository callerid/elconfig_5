using System;
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


namespace EthernetLinkConfig
{
    public partial class FrmMain : Form
    {

        // Receivers
        public static UdpReceiverClass6699 UdpReceiver6699 = new UdpReceiverClass6699();
        readonly Thread _udpReceiveThread6699 = new Thread(UdpReceiver6699.UdpIdleReceive);
        public static UdpReceiverClass3520 UdpReceiver3520 = new UdpReceiverClass3520();
        readonly Thread _udpReceiveThread3520 = new Thread(UdpReceiver3520.UdpIdleReceive);
        public int LinkPort = 0;
        public int ConnectionPings = 3;
        public bool DeluxeUnitDetected = false;

        // Reception values
        public string UnitNumber;
        public string SerialNumber;
        public string MACAddress;
        public string TheIPAddress;
        public string DestPort;
        public string ListPort;
        public string DestIP;
        public string DestMAC;

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

                CallRecord record = new CallRecord(reception);

                if (record.IsValid)
                {
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
            else if (receptionBytes.Length != 57)
            {
                dgvCommData.Rows.Add();
                dgvCommData.Rows[dgvCommData.Rows.Count - 1].Cells[DGV_COMM_DATA_DISPLAY_INDEX].Value = reception;
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

        }

        private void SendUdp(string toSend, int port)
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
                    }
                    else
                    {
                        btn.Text = "Unlock";
                        tbUnitNumber.Enabled = false;
                        UpdateParameter(btn.Name);
                        btn.BackColor = Common.C_BUTTON_BACK;
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

            if (NeedsSaving)
            {
                lbNeedsSaving.Visible = !lbNeedsSaving.Visible;
            }

            if (ConnectionPings > 3)
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
            }

            if (LinkPort == 0)
            {
                SendUdp("^^IdX", 6699);
                timerRefresher.Interval = 1000;
                Common.WaitFor(250);
                SendUdp("^^IdX", 3520);

                lbDeluxeUnitDetected.Text = "Deluxe Unit NOT detected";
                SetToggleVisibility(false);

            }
            else
            {
                SendUdp("^^IdX", LinkPort);
                timerRefresher.Interval = 1000;
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
        }

        private void timerGetToggles_Tick(object sender, EventArgs e)
        {
            if (ToggleAttempts > 4) return;

            if (!GotToggles)
            {
                SendUdp("^^Id-V", LinkPort);
            }
        }
        
        // ----------------------------------------------------------------------------------
    }
}
