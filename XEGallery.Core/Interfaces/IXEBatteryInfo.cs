using System;

namespace XEGallery.Core.Interfaces
{
    interface IXEBatteryInfo
    {
        double BatteryChargeLevel { get; }
        double BatteryChargePercentage { get; }
        string BatteryPowerSourceString { get; }
        string BatteryStateString { get; }

    }
}
