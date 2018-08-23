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

        private double latitude;
        private double longitude;

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

        public MapsViewModel(IXEMaps xEMaps)
        {
            _xeMaps = xEMaps;
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
