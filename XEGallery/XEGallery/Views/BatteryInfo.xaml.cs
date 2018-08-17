using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

using XEGallery.Core.Interfaces;
using XEGallery.ViewModels;

namespace XEGallery.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatteryInfo : ContentPage
	{
        private readonly IXEBatteryInfo _xeBatteryInfo = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXEBatteryInfo>();

        public BatteryInfoViewModel VM { get; }

        public BatteryInfo()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            VM = new BatteryInfoViewModel(_xeBatteryInfo);
            BindingContext = VM;
        }
    }
}