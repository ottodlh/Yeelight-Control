using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YControl.classes
{
    internal static class ScreenInterrogatory
    {
        public enum  QUERY_DEVICE_CONFIG : uint
        {
            QDC_ALL_PATHS = 1u,
            QDC_ONLY_ACTIVE_PATHS = 2u,
            QDC_DATABASE_CURRENT = 4u
        }

        public enum DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY : uint
        {
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER = uint.MaxValue,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15 = 0u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO = 1u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO = 2u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO = 3u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI = 4u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI = 5u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS = 6u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN = 8u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI = 9u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL = 10u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED = 11u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL = 12u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED = 13u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE = 14u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST = 15u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL = 2147483648u,
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_FORCE_UINT32 = uint.MaxValue
        }

        public enum DISPLAYCONFIG_SCANLINE_ORDERING : uint
        {
            DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0u,
            DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1u,
            DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2u,
            DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST = 2u,
            DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST = 3u,
            DISPLAYCONFIG_SCANLINE_ORDERING_FORCE_UINT32 = uint.MaxValue
        }

        public enum DISPLAYCONFIG_ROTATION : uint
        {
            DISPLAYCONFIG_ROTATION_IDENTITY = 1u,
            DISPLAYCONFIG_ROTATION_ROTATE90 = 2u,
            DISPLAYCONFIG_ROTATION_ROTATE180 = 3u,
            DISPLAYCONFIG_ROTATION_ROTATE270 = 4u,
            DISPLAYCONFIG_ROTATION_FORCE_UINT32 = uint.MaxValue
        }

        public enum DISPLAYCONFIG_SCALING : uint
        {
            DISPLAYCONFIG_SCALING_IDENTITY = 1u,
            DISPLAYCONFIG_SCALING_CENTERED = 2u,
            DISPLAYCONFIG_SCALING_STRETCHED = 3u,
            DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX = 4u,
            DISPLAYCONFIG_SCALING_CUSTOM = 5u,
            DISPLAYCONFIG_SCALING_PREFERRED = 128u,
            DISPLAYCONFIG_SCALING_FORCE_UINT32 = uint.MaxValue
        }

        public enum DISPLAYCONFIG_PIXELFORMAT : uint
        {
            DISPLAYCONFIG_PIXELFORMAT_8BPP = 1u,
            DISPLAYCONFIG_PIXELFORMAT_16BPP = 2u,
            DISPLAYCONFIG_PIXELFORMAT_24BPP = 3u,
            DISPLAYCONFIG_PIXELFORMAT_32BPP = 4u,
            DISPLAYCONFIG_PIXELFORMAT_NONGDI = 5u,
            DISPLAYCONFIG_PIXELFORMAT_FORCE_UINT32 = uint.MaxValue
        }

        public enum DISPLAYCONFIG_MODE_INFO_TYPE : uint
        {
            DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1u,
            DISPLAYCONFIG_MODE_INFO_TYPE_TARGET = 2u,
            DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32 = uint.MaxValue
        }

        public enum DISPLAYCONFIG_DEVICE_INFO_TYPE : uint
        {
            DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME = 1u,
            DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME = 2u,
            DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE = 3u,
            DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME = 4u,
            DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE = 5u,
            DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE = 6u,
            DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32 = uint.MaxValue
        }

        public struct Luid
        {
            public uint LowPart;

            public int HighPart;
        }

        public struct DisplayConfigPathSourceInfo
        {
            public Luid adapterId;

            public uint id;

            public uint modeInfoIdx;

            public uint statusFlags;
        }

        public struct DisplayConfigPathTargetInfo
        {
            public Luid adapterId;

            public uint id;

            public uint modeInfoIdx;

            private DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

            private DISPLAYCONFIG_ROTATION rotation;

            private DISPLAYCONFIG_SCALING scaling;

            private DisplayConfigRational refreshRate;

            private DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;

            public bool targetAvailable;

            public uint statusFlags;
        }

        public struct DisplayConfigRational
        {
            public uint Numerator;

            public uint Denominator;
        }

        public struct DisplayConfigPathInfo
        {
            public DisplayConfigPathSourceInfo sourceInfo;

            public DisplayConfigPathTargetInfo targetInfo;

            public uint flags;
        }

        public struct DisplayConfig2Region
        {
            public uint cx;

            public uint cy;
        }

        public struct DisplayConfigVideoSignalInfo
        {
            public ulong pixelRate;

            public DisplayConfigRational hSyncFreq;

            public DisplayConfigRational vSyncFreq;

            public DisplayConfig2Region activeSize;

            public DisplayConfig2Region totalSize;

            public uint videoStandard;

            public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
        }

        public struct DisplayConfigTargetMode
        {
            public DisplayConfigVideoSignalInfo targetVideoSignalInfo;
        }

        public struct Pointl
        {
            private int x;

            private int y;
        }

        public struct DisplayConfigSourceMode
        {
            public uint width;

            public uint height;

            public DISPLAYCONFIG_PIXELFORMAT pixelFormat;

            public Pointl position;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct DisplayConfigModeInfoUnion
        {
            [FieldOffset(0)]
            public DisplayConfigTargetMode targetMode;

            [FieldOffset(0)]
            public DisplayConfigSourceMode sourceMode;
        }

        public struct DisplayConfigModeInfo
        {
            public DISPLAYCONFIG_MODE_INFO_TYPE infoType;

            public uint id;

            public Luid adapterId;

            public DisplayConfigModeInfoUnion modeInfo;
        }

        public struct DisplayConfigTargetDeviceNameFlags
        {
            public uint value;
        }

        public struct DisplayConfigDeviceInfoHeader
        {
            public DISPLAYCONFIG_DEVICE_INFO_TYPE type;

            public uint size;

            public Luid adapterId;

            public uint id;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DisplayConfigTargetDeviceName
        {
            public DisplayConfigDeviceInfoHeader header;

            public DisplayConfigTargetDeviceNameFlags flags;

            public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

            public ushort edidManufactureId;

            public ushort edidProductCodeId;

            public uint connectorInstance;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string monitorFriendlyDeviceName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string monitorDevicePath;
        }

        public const int ERROR_SUCCESS = 0;

        [DllImport("user32.dll")]
        public static extern int GetDisplayConfigBufferSizes(QUERY_DEVICE_CONFIG flags, out uint numPathArrayElements, out uint numModeInfoArrayElements);

        [DllImport("user32.dll")]
        public static extern int QueryDisplayConfig(QUERY_DEVICE_CONFIG flags, ref uint numPathArrayElements, [Out] DisplayConfigPathInfo[] PathInfoArray, ref uint numModeInfoArrayElements, [Out] DisplayConfigModeInfo[] ModeInfoArray, IntPtr currentTopologyId);

        [DllImport("user32.dll")]
        public static extern int DisplayConfigGetDeviceInfo(ref DisplayConfigTargetDeviceName deviceName);

        private static string MonitorFriendlyName(Luid adapterId, uint targetId)
        {
            DisplayConfigTargetDeviceName dISPLAYCONFIG_TARGET_DEVICE_NAME = default(DisplayConfigTargetDeviceName);
            dISPLAYCONFIG_TARGET_DEVICE_NAME.header.size = (uint)Marshal.SizeOf(typeof(DisplayConfigTargetDeviceName));
            dISPLAYCONFIG_TARGET_DEVICE_NAME.header.adapterId = adapterId;
            dISPLAYCONFIG_TARGET_DEVICE_NAME.header.id = targetId;
            dISPLAYCONFIG_TARGET_DEVICE_NAME.header.type = DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME;
            DisplayConfigTargetDeviceName deviceName = dISPLAYCONFIG_TARGET_DEVICE_NAME;
            int num = DisplayConfigGetDeviceInfo(ref deviceName);
            if (num != 0)
            {
                throw new Win32Exception(num);
            }
            return deviceName.monitorFriendlyDeviceName;
        }

        private static IEnumerable<string> GetAllMonitorsFriendlyNames()
        {
            int error2 = GetDisplayConfigBufferSizes(QUERY_DEVICE_CONFIG.QDC_ONLY_ACTIVE_PATHS, out var pathCount, out var modeCount);
            if (error2 != 0)
            {
                throw new Win32Exception(error2);
            }
            DisplayConfigPathInfo[] displayPaths = new DisplayConfigPathInfo[pathCount];
            DisplayConfigModeInfo[] displayModes = new DisplayConfigModeInfo[modeCount];
            error2 = QueryDisplayConfig(QUERY_DEVICE_CONFIG.QDC_ONLY_ACTIVE_PATHS, ref pathCount, displayPaths, ref modeCount, displayModes, IntPtr.Zero);
            if (error2 != 0)
            {
                throw new Win32Exception(error2);
            }
            for (int i = 0; i < modeCount; i++)
            {
                if (displayModes[i].infoType == DISPLAYCONFIG_MODE_INFO_TYPE.DISPLAYCONFIG_MODE_INFO_TYPE_TARGET)
                {
                    yield return MonitorFriendlyName(displayModes[i].adapterId, displayModes[i].id);
                }
            }
        }

        public static string DeviceFriendlyName(this Screen screen)
        {
            IEnumerable<string> allMonitorsFriendlyNames = GetAllMonitorsFriendlyNames();
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (object.Equals(screen, Screen.AllScreens[i]))
                {
                    return allMonitorsFriendlyNames.ToArray()[i];
                }
            }
            return null;
        }
    }
}
