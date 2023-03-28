using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace YControl
{
    internal class YeelightControl
    {
        private TcpClient client;

        public YeelightControl(string ipAddress, int port = 55443)
        {
            client = new TcpClient(ipAddress, port);
        }

        public void SendCommand(string command)
        {
            byte[] data = Encoding.UTF8.GetBytes(command + "\r\n");
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }

        public void TurnOn()
        {
            SendCommand("{\"id\":1,\"method\":\"set_power\",\"params\":[\"on\",\"smooth\",500]}\r\n");
        }

        public void TurnOff()
        {
            SendCommand("{\"id\":1,\"method\":\"set_power\",\"params\":[\"off\",\"smooth\",500]}\r\n");
        }

        public void SetBrightness(int brightness)
        {
            SendCommand($"{{\"id\":1,\"method\":\"set_bright\",\"params\":[{brightness},\"smooth\",500]}}\r\n");
        }

        public void SetColorTemperature(int temperature)
        {
            SendCommand($"{{\"id\":1,\"method\":\"set_ct_abx\",\"params\":[{temperature},\"smooth\",500]}}\r\n");
        }

        public void SetRGBColor(int r, int g, int b)
        {
            int rgb = (r << 16) | (g << 8) | b;
            SendCommand($"{{\"id\":1,\"method\":\"set_rgb\",\"params\":[{rgb},\"smooth\",500]}}\r\n");
        }

        public void Dispose()
        {
            client.Close();
        }
    }
}
