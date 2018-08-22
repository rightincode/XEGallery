using XEGallery.Core.Interfaces;
using Xamarin.Essentials;
using System;

namespace XEGallery.Core.Models
{
    public class XEBatteryInfo : IXEBatteryInfo, IDisposable
    {
        public double BatteryChargeLevel { get; private set; }
        public double BatteryChargePercentage { get; private set; }
        public string BatteryPowerSourceString { get; private set; }
        public string BatteryStateString { get; private set; }

        public event EventHandler ReadingsChanged;

        public XEBatteryInfo()
        {
            Initialize();
            Battery.BatteryChanged += XEBatteryInfo_BatteryChanged;
        }

        private void XEBatteryInfo_BatteryChanged(object sender, BatteryChangedEventArgs e)
        {
            Initialize();
            ReadingsChanged?.Invoke(this, e);
        }

        private void Initialize()
        {
            GetBatteryChargeLevel();
            GetBatteryChargePercentage();
            GetBatteryPowerSource();
            GetBatteryState();
        }

        private void GetBatteryChargeLevel()
        {
            BatteryChargeLevel = Battery.ChargeLevel;
        }

        private void GetBatteryChargePercentage()
        {
            BatteryChargePercentage = Battery.ChargeLevel * 100;
        }

        private void GetBatteryPowerSource()
        {            
            switch (Battery.PowerSource)
            {
                case BatteryPowerSource.AC:
                    BatteryPowerSourceString = "AC";
                    break;

                case BatteryPowerSource.Battery:
                    BatteryPowerSourceString = "Battery";
                    break;

                case BatteryPowerSource.Usb:
                    BatteryPowerSourceString = "USB";
                    break;

                case BatteryPowerSource.Wireless:
                    BatteryPowerSourceString = "Wireless";
                    break;

                case BatteryPowerSource.Unknown:
                default:
                    BatteryPowerSourceString = "Unknown";
                    break;
            }
        }

        private void GetBatteryState()
        {            
            switch (Battery.State)
            {
                case BatteryState.Charging:
                    BatteryStateString = "Charging";
                    break;

                case BatteryState.Discharging:
                    BatteryStateString = "Discharging";
                    break;

                case BatteryState.Full:
                    BatteryStateString = "Full";
                    break;

                case BatteryState.NotCharging:
                    BatteryStateString = "Not Charging";
                    break;

                case BatteryState.NotPresent:
                    BatteryStateString = "Not Present";
                    break;

                case BatteryState.Unknown:
                default:
                    BatteryStateString = "Unknown";
                    break;
            }
        }

        public void Dispose()
        {
            Battery.BatteryChanged -= XEBatteryInfo_BatteryChanged;
        }
    }
}
