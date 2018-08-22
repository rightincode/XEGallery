using System;
using System.ComponentModel;
using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class BatteryInfoViewModel : ExtendedBindableObject, INotifyPropertyChanged, IDisposable
    {
        private readonly IXEBatteryInfo _batteryInfo;

        public double BatteryChargeLevel { get { return _batteryInfo.BatteryChargeLevel; } }

        public double BatteryChargePercentage {  get { return _batteryInfo.BatteryChargePercentage;  } }

        public string BatteryPowerSource { get { return _batteryInfo.BatteryPowerSourceString; } }

        public string BatteryState { get { return _batteryInfo.BatteryStateString; } }        

        public BatteryInfoViewModel(IXEBatteryInfo batteryInfo)
        {
            _batteryInfo = batteryInfo;
            _batteryInfo.ReadingsChanged += OnBatteryReadingsChanged;
        }

        private void OnBatteryReadingsChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged(() => BatteryChargeLevel);
            RaisePropertyChanged(() => BatteryChargePercentage);
            RaisePropertyChanged(() => BatteryPowerSource);
            RaisePropertyChanged(() => BatteryState);
        }

        public void Dispose()
        {
            _batteryInfo.ReadingsChanged -= OnBatteryReadingsChanged;
            _batteryInfo.Dispose();
        }
    }
}
