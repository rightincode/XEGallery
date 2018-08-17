using System;
using System.Collections.Generic;
using System.Text;
using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class BatteryInfoViewModel
    {
        private readonly IXEBatteryInfo _batteryInfo;

        public double BatteryChargeLevel { get { return _batteryInfo.BatteryChargeLevel; } }

        public double BatteryChargePercentage {  get { return _batteryInfo.BatteryChargePercentage;  } }

        public string BatteryPowerSource { get { return _batteryInfo.BatteryPowerSourceString; } }

        public string BatteryState { get { return _batteryInfo.BatteryStateString; } }        

        public BatteryInfoViewModel(IXEBatteryInfo batteryInfo)
        {
            _batteryInfo = batteryInfo;
        }
    }
}
