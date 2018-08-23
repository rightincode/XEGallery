using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

using XEGallery.Core.Interfaces;
using XEGallery.ViewModels;

namespace XEGallery.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Maps : ContentPage
	{
        private readonly IXEMaps _xeMaps = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXEMaps>();
        private readonly IXEGeolocation _xeGeolocation = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXEGeolocation>();

        public MapsViewModel VM { get; }

        public Maps ()
		{
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            VM = new MapsViewModel(_xeMaps, _xeGeolocation);
            BindingContext = VM;

            VM.Longitude = -122.130603;
            VM.Latitude = 47.645160;
        }        
    }
}