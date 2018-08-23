using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class MapsViewModel : ExtendedBindableObject, INotifyPropertyChanged, IDisposable
    {
        private readonly IXEMaps _xeMaps;
        private readonly IXEGeolocation _xeGeolocation;

        private double latitude;
        private double longitude;
        private bool useCurrentLocation;
        
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                RaisePropertyChanged(() => Latitude);
            }
        }

        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                RaisePropertyChanged(() => Longitude);
            }
        }

        public bool UseCurrentLocation
        {
            get { return useCurrentLocation; }
            set
            {
                useCurrentLocation = value;

                if (useCurrentLocation)
                {
                    Task.Run(async () =>
                    {
                        await _xeGeolocation.SetLocationAsync();
                        Latitude = _xeGeolocation.CurrentLocation.Latitude;
                        Longitude = _xeGeolocation.CurrentLocation.Longitude;
                    });
                }

                RaisePropertyChanged(() => UseCurrentLocation);
            }
        }

        public MapsViewModel(IXEMaps xeMaps, IXEGeolocation xeGeolocation)
        {
            _xeMaps = xeMaps;
            _xeGeolocation = xeGeolocation;
            UseCurrentLocation = false;
        }
        public ICommand MapsCommand => new Command(async () => await LoadMapsApp());
        
        public void Dispose()
        {

        }

        public async Task OpenMapsAsync()
        {
            _xeMaps.Latitude = Latitude;
            _xeMaps.Longitude = Longitude;

            await _xeMaps.OpenMapsAsync();
        }

        private async Task LoadMapsApp()
        {
            await OpenMapsAsync();
        }
    }
}
