using CoolerMasterSharpSDK.Helpers;
using System.ComponentModel;

namespace CoolerMasterSharpSDK.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum KeyboardLayouts
    {
        [Description("Unplug")]
        LAYOUT_UNINIT,
        [Description("US")]
        LAYOUT_US,
        [Description("EU")]
        LAYOUT_EU,
        [Description("JP")]
        LAYOUT_JP
    }
}
