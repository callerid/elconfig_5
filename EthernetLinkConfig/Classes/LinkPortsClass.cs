using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EthernetLinkConfig.Classes
{
    public class LinkPortsClass
    {
        private List<int> LinkPorts;
        public int MainPort;

        public LinkPortsClass()
        {
            LinkPorts = new List<int>();
            MainPort = 0;
        }

        public void AddPort(int port)
        {
            if (LinkPorts.Contains(port)) return;
            LinkPorts.Add(port);
        }

        public void RemovePort(int port)
        {
            LinkPorts.Remove(port);
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
            List<int> temp = LinkPorts;
            return temp;
        }
    }
}
