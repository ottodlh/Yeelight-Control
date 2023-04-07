using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YControl.classes
{
    internal class DeviceControl
    {
        private TcpClient m_TcpClient;

        private Device m_ConnectedBulb;

        private byte[] receive(TcpClient socket)
        {
            byte[] array = new byte[256];
            socket.Client.Receive(array);
            return array;
        }

        public bool Connect(Device device)
        {
            if (m_TcpClient != null)
            {
                m_TcpClient.Close();
            }
            m_TcpClient = new TcpClient();
            try
            {
                m_TcpClient.Connect(device.getEndPoint());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!m_TcpClient.Connected)
            {
                m_ConnectedBulb = null;
                return false;
            }
            m_ConnectedBulb = device;
            return true;
        }

        public void Toggle()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"toggle\",\"params\":[]}\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
            byte[] bytes2 = receive(m_TcpClient);
            string @string = Encoding.Default.GetString(bytes2);
            if (@string != null && !@string.Contains("error") && !string.IsNullOrEmpty(@string))
            {
                m_ConnectedBulb.State = !m_ConnectedBulb.State;
            }
        }

        public void SetPower(bool power, int smooth)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("{\"id\":");
                stringBuilder.Append(m_ConnectedBulb.Id);
                stringBuilder.Append(",\"method\":\"set_power\",\"params\":[\"");
                if (power)
                {
                    stringBuilder.Append("on");
                }
                else
                {
                    stringBuilder.Append("off");
                }
                if (smooth >= 30)
                {
                    stringBuilder.Append("\", \"smooth\", " + smooth + "]}\r\n");
                }
                else
                {
                    stringBuilder.Append("\", \"sudden\", " + smooth + "]}\r\n");
                }
                byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                m_TcpClient.Client.Send(bytes);
                byte[] bytes2 = receive(m_TcpClient);
                string @string = Encoding.Default.GetString(bytes2);
                if (@string != null && !@string.Contains("error") && !string.IsNullOrEmpty(@string))
                {
                    m_ConnectedBulb.State = !m_ConnectedBulb.State;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yeelight Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetBrightness(int value, int smooth)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_bright\",\"params\":[");
            stringBuilder.Append(value);
            if (smooth >= 30)
            {
                stringBuilder.Append(", \"smooth\", " + smooth + "]}\r\n");
            }
            else
            {
                stringBuilder.Append(", \"sudden\", " + smooth + "]}\r\n");
            }
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
            m_ConnectedBulb.Brightness = value;
        }

        public void SetColor(int r, int g, int b, int smooth)
        {
            int value = (r << 16) | (g << 8) | b;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_rgb\",\"params\":[");
            stringBuilder.Append(value);
            if (smooth >= 30)
            {
                stringBuilder.Append(", \"smooth\", " + smooth + "]}\r\n");
            }
            else
            {
                stringBuilder.Append(", \"sudden\", " + smooth + "]}\r\n");
            }
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void SetTemperature(int value, int smooth)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_ct_abx\",\"params\":[");
            stringBuilder.Append(value);
            if (smooth >= 30)
            {
                stringBuilder.Append(", \"smooth\", " + smooth + "]}\r\n");
            }
            else
            {
                stringBuilder.Append(", \"sudden\", " + smooth + "]}\r\n");
            }
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void SetName(string name)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_name\",\"params\":[\"");
            stringBuilder.Append(name);
            stringBuilder.Append("\"]}\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void SetDefault()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_default\",\"params\":[]}\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void SetMusic()
        {
            string value = Utils.GetLocalIPAddress().ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_music\",\"params\":[1,\"");
            stringBuilder.Append(value);
            stringBuilder.Append("\",54321]}\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void StopMusic()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"set_music\",\"params\":[0]}\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void ExecCommand(string method, string param, int smooth)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{\"id\":");
            stringBuilder.Append(m_ConnectedBulb.Id);
            stringBuilder.Append(",\"method\":\"" + method + "\",\"params\":[");
            stringBuilder.Append(param);
            if (smooth >= 30)
            {
                stringBuilder.Append(", \"smooth\", " + smooth + "]}\r\n");
            }
            else
            {
                stringBuilder.Append(", \"sudden\", " + smooth + "]}\r\n");
            }
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            m_TcpClient.Client.Send(bytes);
        }

        public void send(IPEndPoint ipEndpoint, string json)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(json);
            stringBuilder.Append("\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ipEndpoint);
            tcpClient.Client.Send(bytes);
            tcpClient.Close();
        }
    }
}
