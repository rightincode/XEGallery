using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

using XEGallery.Core.Interfaces;
using XEGallery.ViewModels;

namespace XEGallery.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Compass : ContentPage
	{
        private readonly IXECompass _xeCompass = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXECompass>();

        public CompassViewModel VM { get; }

        public Compass()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            VM = new CompassViewModel(_xeCompass);
            BindingContext = VM;
        }

        protected override void OnDisappearing()
        {
            VM.Dispose();
        }
    }
}