using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YControl.classes
{
    internal sealed class FormSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool SyncAuto
        {
            get { return (bool)this["SyncAuto"]; }
            set { this["SyncAuto"] = value; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />")]
        public StringCollection Devices
        {
            get { return (StringCollection)this["devices"]; }
            set { this["devices"] = value; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0.0.0.0")]
        public string LocalIpAddress
        {
            get { return (string)this["LocalIpAddress"]; }
            set { this["LocalIpAddress"] = value; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0.0")]
        public string Version
        {
            get { return (string)this["version"]; }
            set { this["version"] = value; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int Brightness
        {
            get { return (int)this["Brightness"]; }
            set { this["Brightness"] = value;  }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("6500")]
        public int Temperature
        {
            get { return (int)this["Temperature"]; }
            set { this["Temperature"] = value; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("500")]
        public int Smoothness
        {
            get { return (int)this["Smoothness"]; }
            set { this["Smoothness"] = value; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("50")]
        public int Syncronization
        {
            get { return (int)this["Syncronization"]; }
            set { this["Syncronization"] = value; }
        }
    }
}
