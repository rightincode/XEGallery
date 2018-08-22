using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using XEGallery.Core.Interfaces;
using XEGallery.ViewModels;

namespace XEGallery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connectivity : ContentPage
    {
        private readonly IXEConnectivity _xeConnectivity = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXEConnectivity>();

        public ConnectivityViewModel VM { get; }
        public Connectivity()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            VM = new ConnectivityViewModel(_xeConnectivity);
            BindingContext = VM;
        }

        protected override void OnDisappearing()
        {
            VM.Dispose();
        }
    }
}