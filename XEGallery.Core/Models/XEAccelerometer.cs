using System;
using Xamarin.Essentials;
using XEGallery.Core.Interfaces;
using XEGallery.Core.Enums;
using System.Diagnostics;

namespace XEGallery.Core.Models
{
    public class XEAccelerometer : IXEAccelerometer
    {
        public float XAccelleration { get; private set; }

        public float YAcceleration { get; private set; }

        public float ZAcceleration { get; private set; }

        public event EventHandler ReadingsChanged;

        private SensorSpeed _xeSensorSpeed = SensorSpeed.UI;

        public XEAccelerometer()
        {
            Accelerometer.ReadingChanged += OnReadingChanged;
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

        public void StartAccelerometer()
        {
            try
            {
                if (!Accelerometer.IsMonitoring)
                {
                    Accelerometer.Start(_xeSensorSpeed);
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

        public void StopAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.Stop();
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

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(_xeSensorSpeed);
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

        private void OnReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            XAccelleration = e.Reading.Acceleration.X;
            YAcceleration = e.Reading.Acceleration.Y;
            ZAcceleration = e.Reading.Acceleration.Z;

            ReadingsChanged?.Invoke(this, e);
        }
    }
}
