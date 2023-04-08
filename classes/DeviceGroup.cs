using System.Collections.Generic;

namespace YControl.classes
{
    internal class DeviceGroup
    {
        private string name;

        private List<Device> devices;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public List<Device> Devices
        {
            get
            {
                return devices;
            }
            set
            {
                devices = value;
            }
        }

        public DeviceGroup(string Name, List<Device> Devices)
        {
            name = Name;
            devices = Devices;
        }
    }
}
