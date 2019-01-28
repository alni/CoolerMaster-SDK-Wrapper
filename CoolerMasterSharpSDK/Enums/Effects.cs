using CoolerMasterSharpSDK.Helpers;
using System.ComponentModel;

namespace CoolerMasterSharpSDK.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Effects
    {
        [Description("Full ON")]
        EFF_FULL_ON = 0,
        [Description("Breathing")]
        EFF_BREATH = 1,
        [Description("Color Cycle")]
        EFF_BREATH_CYCLE = 2,
        [Description("Single Key")]
        EFF_SINGLE = 3,
        [Description("Wave Color")]
        EFF_WAVE = 4,
        [Description("Ripple")]
        EFF_RIPPLE = 5,
        [Description("Cross Mode")]
        EFF_CROSS = 6,
        [Description("Rain Drop")]
        EFF_RAIN = 7,
        [Description("Star Effect")]
        EFF_STAR = 8,
        [Description("Snake Game")]
        EFF_SNAKE = 9,
        [Description("Customization")]
        EFF_REC = 10,
        [Description("Circle Spectrum")]
        EFF_SPECTRUM = 11,
        [Description("Indicator")]
        EFF_INDICATOR = 13,
        [Description("Fireball")]
        EFF_FIRE_BALL = 14,
        [Description("Water Ripple")]
        EFF_WATER_RIPPLE = 15,
        [Description("Reactive Punch")]
        EFF_REACTIVE_PUNCH = 16,
        [Description("Snowing")]
        EFF_SNOWING = 17,
        [Description("Heartbeat")]
        EFF_HEART_BEAT = 18,
        [Description("Reactive Tornado")]
        EFF_REACTIVE_TORNADO = 19,
        [Description("Multi 1")]
        EFF_MULTI_1 = 0xE0,
        [Description("Multi 2")]
        EFF_MULTI_2 = 0xE1,
        [Description("Multi 3")]
        EFF_MULTI_3 = 0xE2,
        [Description("Multi 4")]
        EFF_MULTI_4 = 0xE3,
        [Description("Off")]
        EFF_OFF = 0xFE
    }
}
