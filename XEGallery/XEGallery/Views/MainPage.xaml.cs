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

        public ICommand AppInfoCommand => new Command(async () => await LoadAppInfoView());

        private async Task LoadAppInfoView()
        {
            await Navigation.PushAsync(new AppInfo());
        }
    }
}
