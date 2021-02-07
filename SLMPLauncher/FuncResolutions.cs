using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SLMPLauncher
{
    public class FuncResolutions
    {
        [DllImport("user32.dll")]
        static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
        const int ENUM_CURRENT_SETTINGS = -1;
        const int ENUM_REGISTRY_SETTINGS = -2;
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        public static void Resolutions(string screenName)
        {
            try
            {
                DEVMODE devMode = new DEVMODE();
                int modeNum = 0;
                int resCount = -1;
                while (EnumDisplaySettings(screenName, modeNum, ref devMode))
                {
                    int w = devMode.dmPelsWidth;
                    int h = devMode.dmPelsHeight;
                    if (devMode.dmBitsPerPel == 32 && w >= 800 && h >= 600 && (resCount == -1 || (FormOptions.screenListW[resCount] != w || FormOptions.screenListH[resCount] != h)))
                    {
                        FormOptions.screenListW.Add(w);
                        FormOptions.screenListH.Add(h);
                        resCount++;
                    }
                    modeNum++;
                }
            }
            catch
            {
                FormOptions.screenListW.Clear();
                FormOptions.screenListH.Clear();
            }
        }
    }
}