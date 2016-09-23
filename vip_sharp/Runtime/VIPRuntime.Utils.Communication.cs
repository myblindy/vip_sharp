using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace vip_sharp
{
    public partial class VIPRuntime
    {
        internal void InitCommunications()
        {
            if (!VIPSystemClass.CommunicationEnabled)
                return;

            new Thread(CommunicationThread).Start(0);		// vip thread
            new Thread(CommunicationThread).Start(1);		// vhp thread
        }

        internal void CommunicationThread(object _idx)
        {
            var idx = (int)_idx;
            IPEndPoint ep = null;

            using (var client = new UdpClient(VIPSystemClass.CommunicationPort + idx))
                while (true)
                {
                    var data = client.Receive(ref ep);

                    if (data?.Length > 0)
                    {

                    }
                }
        }
    }
}
