using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharp_SDK
{
    public static class SDK
    {
        public const byte MAX_LED_ROW = 7;
        public const byte MAX_LED_COLUMN = 24;

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetNowTime();

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern long GetNowCPUUsage();

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetRamUsage();

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsDevicePlug();

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EnableLedControl(bool bEnable);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetLedColor(int iRow, int iColumn, byte r, byte g, byte b);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetFullLedColor(byte r, byte g, byte b);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern float GetNowVolumePeekValue();

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SwitchLedEffect(EFF_INDEX iEffectIndex);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool RefreshLed(bool bAuto);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern bool SetAllLedColor(COLOR_MATRIX_NATIVE colorMatrix);

        public static bool SetAllLedColor(COLOR_MATRIX colorMatrx)
        {
            KEY_COLOR[][] data = colorMatrx.KeyColor;
            GCHandle[] handles = new GCHandle[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                handles[i] = GCHandle.Alloc(data[i], GCHandleType.Pinned);
            }
            IntPtr[] pointers = new IntPtr[handles.Length];
            for (int i = 0; i < handles.Length; i++)
            {
                pointers[i] = handles[i].AddrOfPinnedObject();
            }
            COLOR_MATRIX_NATIVE colorMatrix = new COLOR_MATRIX_NATIVE(pointers);
            bool result = SetAllLedColor(colorMatrix);
            for (int i = 0; i < handles.Length; i++)
            {
                handles[i].Free();
            }
            return result;
        }

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetControlDevice(DEVICE_INDEX devIndex);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern LAYOUT_KEYOBARD GetDeviceLayout();


        public delegate void KEY_CALLBACK(int iRow, int iColumn, bool bPressed);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetKeyCallBack(KEY_CALLBACK callback);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EnableKeyInterrupt(bool bEnable);

    }

    public struct KEY_COLOR
    {
        public byte r;
        public byte g;
        public byte b;

        public KEY_COLOR(byte red, byte green, byte blue)
        {
            this.r = red;
            this.g = green;
            this.b = blue;
        }
    }

    public struct COLOR_MATRIX
    {
        public KEY_COLOR[][] KeyColor;

        public COLOR_MATRIX(KEY_COLOR[][] colors)
        {
            this.KeyColor = colors;
        }
    }

    public struct COLOR_MATRIX_NATIVE
    {
        public IntPtr[] KeyColor;

        public COLOR_MATRIX_NATIVE(IntPtr[] colors)
        {
            this.KeyColor = colors;
        }
    }


    public enum EFF_INDEX
    {
        EFF_FULL_ON = 0,
        EFF_BREATH = 1,
        EFF_BREATH_CYCLE = 2,
        EFF_SINGLE = 3,
        EFF_WAVE = 4,
        EFF_RIPPLE = 5,
        EFF_CROSS = 6,
        EFF_RAIN = 7,
        EFF_STAR = 8,
        EFF_SNAKE = 9,
        EFF_REC = 10,
        EFF_MULTI_1 = 0xE0,
        EFF_MULTI_2 = 0xE1,
        EFF_MULTI_3 = 0xE2,
        EFF_MULTI_4 = 0xE3,
        EFF_OFF = 0xFE
    }

    public enum DEVICE_INDEX
    {
        DEV_MKeys_L,
        DEV_MKeys_S,
        DEV_MKeys_L_White,
        DEV_MKeys_M_White,
        DEV_MMouse_L,
        DEV_MMouse_S,
        DEV_MKeys_M,
        DEV_MKeys_S_White
    }

    public enum LAYOUT_KEYOBARD
    {
        LAYOUT_UNINIT,
        LAYOUT_US,
        LAYOUT_EU
    }
}
