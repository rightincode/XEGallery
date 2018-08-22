using System;
using System.ComponentModel;
using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class CompassViewModel : ExtendedBindableObject, INotifyPropertyChanged, IDisposable
    {
        private readonly IXECompass _xeCompass;

        public double CurrentCompassReading { get { return _xeCompass.CurrentCompassReading; } }

        public CompassViewModel(IXECompass xeCompass)
        {
            _xeCompass = xeCompass;
            _xeCompass.ReadingsChanged += OnReadingsChanged;

            _xeCompass.SetSensorSpeed(Core.Enums.XESensorSpeed.UI);
            _xeCompass.Start();
        }

        public void Dispose()
        {
            _xeCompass.ReadingsChanged += OnReadingsChanged;
            _xeCompass.Dispose();
        }

        private void OnReadingsChanged(Object sender, EventArgs e)
        {
            RaisePropertyChanged(() => CurrentCompassReading);
        }
    }
}
