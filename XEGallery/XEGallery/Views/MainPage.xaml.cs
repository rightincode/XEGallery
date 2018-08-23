using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using XEGallery.Views;

namespace XEGallery
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = this;
        }

        public ICommand AccelerometerCommand => new Command(async () => await LoadAccelerometerView());
        public ICommand AppInfoCommand => new Command(async () => await LoadAppInfoView());
        public ICommand BatteryInfoCommand => new Command(async () => await LoadBatteryInfoView());
        public ICommand CompassCommand => new Command(async () => await LoadCompassView());
        public ICommand ConnectivityCommand => new Command(async () => await LoadConnectivityView());
        public ICommand MapsCommand => new Command(async () => await LoadMapsView());

        private async Task LoadAccelerometerView()
        {
            await Navigation.PushAsync(new Accelerometer());
        }

        private async Task LoadAppInfoView()
        {
            await Navigation.PushAsync(new AppInfo());
        }

        private async Task LoadBatteryInfoView()
        {
            await Navigation.PushAsync(new BatteryInfo());
        }

        private async Task LoadCompassView()
        {
            await Navigation.PushAsync(new Compass());
        }

        private async Task LoadConnectivityView()
        {
            await Navigation.PushAsync(new Connectivity());
        }

        private async Task LoadMapsView()
        {
            await Navigation.PushAsync(new Maps());
        }
    }
}
