using System;

namespace XEGallery.Core.Interfaces
{
    public interface IXEBatteryInfo : IDisposable
    {
        double BatteryChargeLevel { get; }
        double BatteryChargePercentage { get; }
        string BatteryPowerSourceString { get; }
        string BatteryStateString { get; }

        event EventHandler ReadingsChanged;
    }
}
