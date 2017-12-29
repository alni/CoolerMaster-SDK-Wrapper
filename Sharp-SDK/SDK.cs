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
        public const byte MAX_LED_ROW = 6;
        public const byte MAX_LED_COLUMN = 22;

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
        public static extern bool SetAllLedColor(COLOR_MATRIX colorMatrix);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetControlDevice(DEVICE_INDEX devIndex);

        [DllImport("SDKDLL.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern LAYOUT_KEYOBARD GetDeviceLayout();

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
