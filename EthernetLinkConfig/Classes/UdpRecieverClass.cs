using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EthernetLinkConfig.Classes
{

    public class UdpReceiverClass6699
    {
        // Declare variables
        public static Boolean Done;
        public static string ReceivedMessage;
        public static byte[] ReceviedMessageByte;
        public static string LastIncomingIPAddress;
        public static int[] NListenPorts = new int[] { 6699 };
        public static string BoundTo;

        // Define event
        public delegate void UdpEventHandler(UdpReceiverClass6699 u, EventArgs e);
        public event UdpEventHandler DataReceived;

        // Idle listening
        UdpClient listener = null;
        IPEndPoint groupEp = null;
        UdpClient sendClient = new UdpClient();
        public void UdpIdleReceive()
        {

            // Set done to false so loop will begin
            Done = false;

            // Setup filter for too small messages
            const int filterMessageSmallerThan = 4;

            // Setup socket for listening
            bool bound = false;
            try
            {
                listener = new UdpClient();
                listener.ExclusiveAddressUse = false;
                listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                groupEp = new IPEndPoint(IPAddress.Any, 6699);
                listener.Client.Bind(groupEp);

                sendClient.ExclusiveAddressUse = false;
                sendClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                sendClient.Client.Bind(groupEp);
                
                bound = true;
                BoundTo = "6699";
            }
            catch (Exception ex)
            {
                bound = false;
                Console.Write("Failed to bind: " + ex.ToString());
            }

            if (!bound)
            {
                string programName = Common.GetProgramBoundToUDPPort(6699);
                string message = "The Ethernet Link Configuration Tool cannot bind to UDP Port 6699. Another program [possible_program]is already bound to this port. Close any other application that uses Caller ID and relaunch ELConfig.";
                if (programName != "none")
                {
                    message = message.Replace("[possible_program]", "(" + programName + ") ");
                }
                else
                {
                    message.Replace("[possible_program]", "");
                }

                MessageBox.Show(new Form() { TopMost = true }, message, "Failed To Bind", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Wait for broadcast
            try
            {
                while (!Done)
                {
                    // Receive broadcast
                    ReceviedMessageByte = listener.Receive(ref groupEp);
                    ReceivedMessage = Encoding.UTF7.GetString(ReceviedMessageByte, 0, ReceviedMessageByte.Length);

                    // Use for getting incoming IP Address ------------------------
                    if (ReceviedMessageByte.Length == 90 || ReceviedMessageByte.Length == 83 || ReceviedMessageByte.Length == 52)
                    {
                        LastIncomingIPAddress = groupEp.Address.ToString();
                    }

                    //  ----------------------------------------------------------

                    // Filter smaller messages););
                    if (ReceviedMessageByte.Length > filterMessageSmallerThan)
                    {
                        DataReceived(this, EventArgs.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            listener.Close();
        }

        public void SendUDP(byte[] toSend)
        {
            IPEndPoint sendEndPoint = new IPEndPoint(IPAddress.Parse(FrmMain.SendToIP), 6699);
            sendClient.Send(toSend, toSend.Length, sendEndPoint);
        }

    }

    public class UdpReceiverClass3520
    {
        // Declare variables
        public static Boolean Done;
        public static string ReceivedMessage;
        public static byte[] ReceviedMessageByte;
        public static string LastIncomingIPAddress;
        public static int[] NListenPorts = new int[] { 3520 };
        public static string BoundTo;

        // Define event
        public delegate void UdpEventHandler(UdpReceiverClass3520 u, EventArgs e);
        public event UdpEventHandler DataReceived;

        // Idle listening
        UdpClient listener = null;
        IPEndPoint groupEp = null;
        UdpClient sendClient = new UdpClient();
        public void UdpIdleReceive()
        {

            // Set done to false so loop will begin
            Done = false;

            // Setup filter for too small messages
            const int filterMessageSmallerThan = 4;

            // Setup socket for listening
            bool bound = false;
            try
            {
                listener = new UdpClient();
                listener.ExclusiveAddressUse = false;
                listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                groupEp = new IPEndPoint(IPAddress.Any, 3520);
                listener.Client.Bind(groupEp);

                sendClient.ExclusiveAddressUse = false;
                sendClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                sendClient.Client.Bind(groupEp);

                bound = true;
                BoundTo = "3520";
            }
            catch (Exception ex)
            {
                bound = false;
                Console.Write("Failed to bind: " + ex.ToString());
            }

            if (!bound)
            {
                string programName = Common.GetProgramBoundToUDPPort(3520);
                string message = "The Ethernet Link Configuration Tool cannot bind to UDP Port 3520. Another program [possible_program]is already bound to this port. Close any other application that uses Caller ID and relaunch ELConfig.";
                if (programName != "none")
                {
                    message = message.Replace("[possible_program]", "(" + programName + ") ");
                }
                else
                {
                    message.Replace("[possible_program]", "");
                }

                MessageBox.Show(new Form() { TopMost = true }, message, "Failed To Bind", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Wait for broadcast
            try
            {
                while (!Done)
                {
                    // Receive broadcast
                    ReceviedMessageByte = listener.Receive(ref groupEp);
                    ReceivedMessage = Encoding.UTF7.GetString(ReceviedMessageByte, 0, ReceviedMessageByte.Length);

                    // Use for getting incoming IP Address ------------------------
                    if (ReceviedMessageByte.Length == 90 || ReceviedMessageByte.Length == 83 || ReceviedMessageByte.Length == 52)
                    {
                        LastIncomingIPAddress = groupEp.Address.ToString();
                    }

                    // Filter smaller messages););
                    if (ReceviedMessageByte.Length > filterMessageSmallerThan)
                    {
                        DataReceived(this, EventArgs.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            listener.Close();
        }

        public void SendUDP(byte[] toSend)
        {
            IPEndPoint sendEndPoint = new IPEndPoint(IPAddress.Parse(FrmMain.SendToIP), 3520);
            sendClient.Send(toSend, toSend.Length, sendEndPoint);
        }

    }

    public class UdpReceiverClassCustom
    {
        // Declare variables
        public static Boolean Done;
        public static string ReceivedMessage;
        public static byte[] ReceviedMessageByte;
        public static string LastIncomingIPAddress;
        public static int ListenOn;
        public static string BoundTo;

        // Define event
        public delegate void UdpEventHandler(UdpReceiverClassCustom u, EventArgs e);
        public event UdpEventHandler DataReceived;

        // Idle listening
        UdpClient listener = null;
        IPEndPoint groupEp = null;
        UdpClient sendClient = new UdpClient();
        public void UdpIdleReceive()
        {
            // Set done to false so loop will begin
            Done = false;

            // Setup filter for too small messages
            const int filterMessageSmallerThan = 4;

            // Setup socket for listening
            bool bound = false;
            try
            {
                listener = new UdpClient();
                listener.ExclusiveAddressUse = false;
                listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                groupEp = new IPEndPoint(IPAddress.Any, ListenOn);
                listener.Client.Bind(groupEp);

                sendClient.ExclusiveAddressUse = false;
                sendClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                sendClient.Client.Bind(groupEp);

                bound = true;
                BoundTo = ListenOn.ToString();
            }
            catch (Exception ex)
            {
                bound = false;
                Console.Write("Failed to bind: " + ex.ToString());
            }

            if (!bound)
            {
                string programName = Common.GetProgramBoundToUDPPort(ListenOn);
                string message = "The Ethernet Link Configuration Tool cannot bind to UDP Port " + ListenOn.ToString() + ". Another program [possible_program]is already bound to this port. Close any other application that uses Caller ID and relaunch ELConfig.\n\n";
                if (programName != "none")
                {
                    message = message.Replace("[possible_program]", "(" + programName + ") ");
                }
                else
                {
                    message.Replace("[possible_program]", "");
                }

                MessageBox.Show(new Form() { TopMost = true }, message, "Failed To Bind", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Wait for broadcast
            try
            {
                while (!Done)
                {
                    // Receive broadcast
                    ReceviedMessageByte = listener.Receive(ref groupEp);
                    ReceivedMessage = Encoding.UTF7.GetString(ReceviedMessageByte, 0, ReceviedMessageByte.Length);

                    // Use for getting incoming IP Address ------------------------
                    if (ReceviedMessageByte.Length == 90 || ReceviedMessageByte.Length == 83 || ReceviedMessageByte.Length == 52)
                    {
                        LastIncomingIPAddress = groupEp.Address.ToString();
                    }

                    //  ----------------------------------------------------------

                    // Filter smaller messages););
                    if (ReceviedMessageByte.Length > filterMessageSmallerThan)
                    {
                        DataReceived(this, EventArgs.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            listener.Close();
        }

        public void SendUDP(byte[] toSend)
        {
            IPEndPoint sendEndPoint = new IPEndPoint(IPAddress.Parse(FrmMain.SendToIP), ListenOn);
            sendClient.Send(toSend, toSend.Length, sendEndPoint);
        }

    }
}
