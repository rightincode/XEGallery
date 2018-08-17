namespace XEGallery.Core.Interfaces
{
    public interface IXEBatteryInfo
    {
        double BatteryChargeLevel { get; }
        double BatteryChargePercentage { get; }
        string BatteryPowerSourceString { get; }
        string BatteryStateString { get; }

    }
}
