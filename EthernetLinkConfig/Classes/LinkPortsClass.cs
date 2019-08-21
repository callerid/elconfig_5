using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EthernetLinkConfig.Classes
{
    public class LinkPortsClass
    {
        private List<int> LinkPorts;
        private List<string> LinkPortIPs;

        private Dictionary<string, List<string>> Units;

        public int MainPort;

        public LinkPortsClass()
        {
            LinkPorts = new List<int>();
            LinkPortIPs = new List<string>();
            Units = new Dictionary<string, List<string>>();
            MainPort = 0;
        }

        public void ResetPorts()
        {
            LinkPorts.Clear();
            LinkPortIPs.Clear();
            Units.Clear();
            MainPort = 0;
        }

        public void AddEthernetIDAndIP(string ethernet_id, string ip)
        {
            if (!Units.ContainsKey(ethernet_id))
            {
                Units.Add(ethernet_id, new List<string> { ip });
            }
            else
            {
                if (!Units[ethernet_id].Contains(ip))
                {
                    Units[ethernet_id].Add(ip);
                }
            }
        }

        public void AddPort(int port, string ip)
        {
            if (LinkPorts.Contains(port)) return;
            LinkPorts.Add(port);
            LinkPortIPs.Add(ip);
        }

        public void RemovePort(int port)
        {
            int index = GetIndexOfPort(port);

            if (index == -1) return;

            LinkPorts.RemoveAt(index);
            LinkPortIPs.RemoveAt(index);
        }

        public bool MultipleIPsExists(string ip)
        {
            int cnt = 0;
            foreach(string ethernet_id in Units.Keys)
            {
                foreach(string _ip in Units[ethernet_id])
                {
                    if (ip == _ip)
                    {
                        cnt++;
                    }
                }
            }

            return cnt > 1;
        }

        public bool AnyDuplicateIPs(string check_this_ip = "none")
        {
            // Check any possible duplicates
            if(check_this_ip == "none")
            {
                List<string> ips = new List<string>();

                foreach (string _ethernet_id in Units.Keys)
                {
                    foreach (string _ip in Units[_ethernet_id])
                    {
                        if (ips.Contains(_ip))
                        {
                            return true;
                        }

                        ips.Add(_ip);
                    }
                }

                return false;
            }
            else
            {
                // If broadcast then just check for any 
                // duplicates
                if(check_this_ip == "255.255.255.255")
                {
                    return AnyDuplicateIPs("none");
                }

                // Check for any duplicates of "check_this_ip"'s value
                List<string> ips = new List<string>();

                foreach (string _ethernet_id in Units.Keys)
                {
                    foreach (string _ip in Units[_ethernet_id])
                    {
                        if (_ip != check_this_ip) continue;
                        ips.Add(_ip);
                    }
                }

                return ips.Count > 1;
            }
            
        }
        
        public string GetIPOfPort(int port)
        {
            int index = GetIndexOfPort(port);

            if (index == -1) return "NaN";

            return LinkPortIPs[index];
        }

        public int GetPortOfIP(string ip)
        {
            int index = GetIndexOfIP(ip);

            if (index == -1) return -1;

            return LinkPorts[index];
        }

        public bool ContainsPort(int port)
        {
            return LinkPorts.Contains(port);
        }

        public void SetMainPort(int port, bool force = false)
        {
            if (MainPort != 0 && !force) return;
            MainPort = port;
        }

        public List<int> GetAllPorts()
        {
            int[] temp = new int[LinkPorts.Count];
            LinkPorts.CopyTo(temp, 0);

            return temp.ToList<int>();
        }

        private int GetIndexOfPort(int port)
        {
            int index = -1;

            for (int i = 0; i < LinkPorts.Count; i++)
            {
                if (LinkPorts[i] == port)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private int GetIndexOfIP(string ip)
        {
            int index = -1;

            for (int i = 0; i < LinkPortIPs.Count; i++)
            {
                if (LinkPortIPs[i] == ip)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
