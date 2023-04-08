using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YControl.classes
{
    internal class Device
    {
        private static int port = 55443;

        private string m_Ip;

        private string m_Id;

        private bool m_State;

        private int m_Brightness;

        private string m_Model;

        private int m_Temperature;

        private string m_Name;

        private string m_Firmware;

        private int m_Rgb;

        public string Ip
        {
            get
            {
                return m_Ip;
            }
            set
            {
                m_Ip = value;
                OnPropertyChanged("Ip");
            }
        }

        public string Firmware
        {
            get
            {
                return m_Firmware;
            }
            set
            {
                m_Firmware = value;
                OnPropertyChanged("Firmware");
            }
        }

        public string Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
                OnPropertyChanged("Id");
            }
        }

        public int Brightness
        {
            get
            {
                return m_Brightness;
            }
            set
            {
                m_Brightness = value;
                OnPropertyChanged("Brightness");
            }
        }

        public bool State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
                OnPropertyChanged("State");
            }
        }

        public string Model => m_Model;

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public int Rgb
        {
            get
            {
                return m_Rgb;
            }
            set
            {
                m_Rgb = value;
            }
        }

        public int Temperature
        {
            get
            {
                return m_Temperature;
            }
            set
            {
                m_Temperature = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Device(string ip, string id, bool state, int bright, string model, string name, string firmware, int rgb, int temperature)
        {
            m_Id = id;
            m_Ip = ip;
            m_State = state;
            m_Brightness = bright;
            m_Model = model;
            Name = name;
            m_Firmware = firmware;
            Rgb = rgb;
            m_Temperature = temperature;
        }

        public IPEndPoint getEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(m_Ip), port);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
