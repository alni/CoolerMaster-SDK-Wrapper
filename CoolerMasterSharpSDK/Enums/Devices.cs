using CoolerMasterSharpSDK.Helpers;
using System.ComponentModel;

namespace CoolerMasterSharpSDK.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Devices
    {
        [Description("Default")]
        DEV_DEFAULT = 0xFFFF,
        [Description("MasterKeys Pro L")]
        DEV_MKeys_L = 0,
        [Description("MasterKeys Pro S")]
        DEV_MKeys_S = 1,
        [Description("MasterKeys Pro L White")]
        DEV_MKeys_L_White = 2,
        [Description("MasterKeys Pro M White")]
        DEV_MKeys_M_White = 3,
        [Description("MasterMouse Pro L")]
        DEV_MMouse_L = 4,
        [Description("MasterMouse Pro S")]
        DEV_MMouse_S = 5,
        [Description("MasterKeys Pro M")]
        DEV_MKeys_M = 6,
        [Description("MasterKeys Pro S White")]
        DEV_MKeys_S_White = 7,
        [Description("MM520")]
        DEV_MM520 = 8,
        [Description("MM530")]
        DEV_MM530 = 9,
        [Description("MK750")]
        DEV_MK750 = 10,
        [Description("CK372")]
        DEV_CK372 = 11,
        [Description("CK550/552")]
        DEV_CK550_552 = 12,
        [Description("CK551")]
        DEV_CK551 = 13
    }
}
