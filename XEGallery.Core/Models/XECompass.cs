using System;
using System.Diagnostics;
using Xamarin.Essentials;
using XEGallery.Core.Enums;
using XEGallery.Core.Interfaces;

namespace XEGallery.Core.Models
{
    public class XECompass : IXECompass
    {
        private SensorSpeed _xeSensorSpeed = SensorSpeed.UI;

        public double CurrentCompassReading { get; private set; }

        public event EventHandler ReadingsChanged;

        public XECompass()
        {
            Compass.ReadingChanged += OnReadingChanged;
        }

        public void Dispose()
        {
            Compass.ReadingChanged -= OnReadingChanged;
        }

        public void SetSensorSpeed(XESensorSpeed sensorSpeed)
        {
            switch (sensorSpeed)
            {
                case XESensorSpeed.Fastest:
                    _xeSensorSpeed = SensorSpeed.Fastest;
                    break;
                case XESensorSpeed.Game:
                    _xeSensorSpeed = SensorSpeed.Game;
                    break;
                case XESensorSpeed.Normal:
                    _xeSensorSpeed = SensorSpeed.Normal;
                    break;
                case XESensorSpeed.UI:
                default:
                    _xeSensorSpeed = SensorSpeed.UI;
                    break;
            }
        }

        public void Start()
        {
            try
            {
                if (!Compass.IsMonitoring)
                {
                    Compass.Start(_xeSensorSpeed);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                Debug.WriteLine(fnsEx.ToString());
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                Debug.WriteLine(ex.ToString());
            }
        }

        public void Stop()
        {
            try
            {
                if (Compass.IsMonitoring)
                {
                    Compass.Stop();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                Debug.WriteLine(fnsEx.ToString());
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                Debug.WriteLine(ex.ToString());
            }
        }

        public void Toggle()
        {
            try
            {
                if (Compass.IsMonitoring)
                    Compass.Stop();
                else
                    Compass.Start(_xeSensorSpeed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                Debug.WriteLine(fnsEx.ToString());
            }
            catch (Exception ex)
            {
                // Some other exception has occurred
                Debug.WriteLine(ex.ToString());
            }
        }

        private void OnReadingChanged(object sender, CompassChangedEventArgs e)
        {
            CurrentCompassReading = e.Reading.HeadingMagneticNorth;
            ReadingsChanged?.Invoke(this, e);
        }
    }
}
