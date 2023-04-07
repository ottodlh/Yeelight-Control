using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YControl.classes
{
    internal class LocalDiscovery
    {
        private const int SsdpUdpPort = 1982;

        private const string SsdpMessage = "M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1982\r\nMAN: \"ssdp:discover\"\r\nST: wifi_bulb";

        private static readonly byte[] ssdpDiagram = Encoding.ASCII.GetBytes("M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1982\r\nMAN: \"ssdp:discover\"\r\nST: wifi_bulb");

        private static readonly IPEndPoint LocalEndPoint = new IPEndPoint(Utils.GetLocalIPAddress(), 0);

        private static readonly IPEndPoint MulticastEndPoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 1982);

        private static readonly IPEndPoint AnyEndPoint = new IPEndPoint(IPAddress.Any, 0);

        private Socket ssdpSocket;

        private byte[] ssdpReceiveBuffer;

        public IList<Device> DiscoveredDevices { get; }

        public LocalDiscovery()
        {
            DiscoveredDevices = new List<Device>();
        }

        public void SendDiscoveryMessage()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i > 0)
                {
                    Thread.Sleep(50);
                }
                IAsyncResult asyncResult = ssdpSocket.BeginSendTo(ssdpDiagram, 0, ssdpDiagram.Length, SocketFlags.None, MulticastEndPoint, delegate (IAsyncResult o)
                {
                    int num = ssdpSocket.EndSendTo(o);
                }, null);
                asyncResult.AsyncWaitHandle.WaitOne();
            }
        }

        private void ReceiveResponseRecursive(IAsyncResult response = null)
        {
            if (response != null)
            {
                EndPoint senderEndPoint = AnyEndPoint;
                int read = ssdpSocket.EndReceiveFrom(response, ref senderEndPoint);
                byte[] resBuf = ssdpReceiveBuffer;
                new Task(delegate
                {
                    HandleResponse(senderEndPoint, Encoding.ASCII.GetString(resBuf, 0, read));
                }).Start();
            }
            EndPoint remoteEP = LocalEndPoint;
            ssdpReceiveBuffer = new byte[4096];
            ssdpSocket.BeginReceiveFrom(ssdpReceiveBuffer, 0, ssdpReceiveBuffer.Length, SocketFlags.None, ref remoteEP, ReceiveResponseRecursive, null);
        }

        public void StartListening()
        {
            ssdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                Blocking = false,
                Ttl = 1,
                UseOnlyOverlappedIO = true,
                MulticastLoopback = false
            };
            IPAddress localIPAddress = Utils.GetLocalIPAddress();
            try
            {
                ssdpSocket.Bind(new IPEndPoint(localIPAddress, 0));
                ssdpSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(MulticastEndPoint.Address));
                ReceiveResponseRecursive();
            }
            catch (Exception)
            {
                if (MessageBox.Show("No active LAN connections found. Please, check your network settings and try again.", "Yeelight Toolbox", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void HandleResponse(EndPoint sender, string response)
        {
            string ip = "";
            Utils.GetSubString(response, "Location: yeelight://", ":", ref ip);
            lock (DiscoveredDevices)
            {
                if (!DiscoveredDevices.Any((Device item) => item.Ip == ip))
                {
                    string ret = "";
                    Utils.GetSubString(response, "id: ", "\r\n", ref ret);
                    string ret2 = "";
                    Utils.GetSubString(response, "bright: ", "\r\n", ref ret2);
                    string ret3 = "";
                    Utils.GetSubString(response, "power: ", "\r\n", ref ret3);
                    bool state = ret3.Contains("on");
                    string ret4 = "";
                    Utils.GetSubString(response, "model: ", "\r\n", ref ret4);
                    string ret5 = "";
                    Utils.GetSubString(response, "name: ", "\r\n", ref ret5);
                    try
                    {
                        ret5 = Utils.base64Decode(ret5);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ret5);
                        ret5 = ip;
                    }
                    string ret6 = "";
                    Utils.GetSubString(response, "fw_ver: ", "\r\n", ref ret6);
                    string ret7 = "";
                    Utils.GetSubString(response, "rgb: ", "\r\n", ref ret7);
                    string ret8 = "";
                    Utils.GetSubString(response, "ct: ", "\r\n", ref ret8);
                    DiscoveredDevices.Add(new Device(ip, ret, state, Convert.ToInt32(ret2), ret4, ret5, ret6, Convert.ToInt32(ret7), Convert.ToInt32(ret8)));
                }
            }
        }
    }
}
