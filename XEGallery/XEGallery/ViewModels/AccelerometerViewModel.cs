using System;
using System.ComponentModel;
using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class AccelerometerViewModel : ExtendedBindableObject, INotifyPropertyChanged, IDisposable
    {
        private readonly IXEAccelerometer _xeAccelerometer;

        public float AccelerationX { get { return _xeAccelerometer.XAccelleration; } }

        public float AccelerationY { get { return _xeAccelerometer.YAcceleration; } }

        public float AccelerationZ { get { return _xeAccelerometer.ZAcceleration; } }

        public AccelerometerViewModel(IXEAccelerometer xeAccelerometer)
        {
            _xeAccelerometer = xeAccelerometer;
            _xeAccelerometer.ReadingsChanged += OnReadingsChanged;

            _xeAccelerometer.SetSensorSpeed(Core.Enums.XESensorSpeed.UI);
            _xeAccelerometer.StartAccelerometer();
        }

        private void OnReadingsChanged(Object sender, EventArgs e)
        {
            RaisePropertyChanged(() => AccelerationX);
            RaisePropertyChanged(() => AccelerationY);
            RaisePropertyChanged(() => AccelerationZ);
        }

        public void Dispose()
        {
            _xeAccelerometer.StopAccelerometer();
            _xeAccelerometer.ReadingsChanged -= OnReadingsChanged;
        }
    }
}
