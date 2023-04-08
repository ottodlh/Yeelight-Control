using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YControl.Properties;

namespace YControl.classes
{
    
    internal static class Utils
    {

        public static void saveLog(string log)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\YeelightToolbox_log.txt";
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
            streamWriter.WriteLine(log);
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static bool isBase64String(this string s)
        {
            s = s.Trim();
            return s.Length % 4 == 0 && Regex.IsMatch(s, "^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None);
        }

        public static string base64Decode(string base64EncodedData)
        {
            if (base64EncodedData.isBase64String() && base64EncodedData != null && !base64EncodedData.Trim().Equals(""))
            {
                int num = base64EncodedData.Length % 4;
                if (num != 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        base64EncodedData += "=";
                    }
                }
                byte[] bytes = Convert.FromBase64String(base64EncodedData);
                base64EncodedData = Encoding.UTF8.GetString(bytes);
            }
            return base64EncodedData;
        }

        public static string Base64Encode(string plainText)
        {
            string result = "";
            if (plainText != null && !plainText.Trim().Equals(""))
            {
                result = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
            }
            return result;
        }

        public static IPAddress GetAdapterLocalIPAddress()
        {
            FormSettings formSettings = new FormSettings();
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in allNetworkInterfaces)
            {
                GatewayIPAddressInformation gatewayIPAddressInformation = networkInterface.GetIPProperties().GatewayAddresses.FirstOrDefault();
                if (gatewayIPAddressInformation == null || gatewayIPAddressInformation.Address.ToString().Equals("0.0.0.0") || gatewayIPAddressInformation.Address.ToString().Equals("127.0.0.1") || (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Wireless80211 && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Ethernet))
                {
                    continue;
                }
                
                foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork && unicastAddress.IsDnsEligible)
                    {
                        formSettings.LocalIpAddress = unicastAddress.Address.ToString();
                        formSettings.Save();
                        return unicastAddress.Address;
                    }
                }
            }
            return IPAddress.Parse(formSettings.LocalIpAddress);
        }

        public static IPAddress GetLocalIPAddress()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint iPEndPoint = socket.LocalEndPoint as IPEndPoint;
                    string text = iPEndPoint.Address.ToString();
                    FormSettings formSettings = new FormSettings();
                    formSettings.LocalIpAddress = text;
                    formSettings.Save();
                    return IPAddress.Parse(text);
                }
            }
            catch
            {
                return GetAdapterLocalIPAddress();
            }
        }

        public static Color getAverageColor(IEnumerable<Color> colors)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            foreach (Color color in colors)
            {
                num += color.R;
                num2 += color.G;
                num3 += color.B;
                num4++;
            }
            return Color.FromArgb(num / num4, num2 / num4, num3 / num4);
        }

        public static Color getDominantColor(IEnumerable<Color> colors)
        {
            Dictionary<Color, int?> dictionary = new Dictionary<Color, int?>();
            foreach (Color color in colors)
            {
                if (!dictionary.ContainsKey(color))
                {
                    dictionary[color] = 0;
                }
                dictionary[color]++;
            }
            return dictionary.OrderByDescending((KeyValuePair<Color, int?> p) => p.Value).First().Key;
        }

        public static byte[] Map(Color color)
        {
            return new byte[3] { color.R, color.G, color.B };
        }

        public static bool GetSubString(string str, string begin, string end, ref string ret)
        {
            int num = -1;
            int num2 = -1;
            num = str.IndexOf(begin);
            if (num != -1)
            {
                ret = str.Substring(num + begin.Length);
                num2 = ret.IndexOf(end);
                ret = ret.Substring(0, num2);
                return true;
            }
            return false;
        }

        public static bool isValidIp(string ip)
        {
            return (Regex.IsMatch(ip, @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")) ;
        }
    }
}
