using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using XEGallery.Core.Interfaces;
using XEGallery.ViewModels;

namespace XEGallery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accelerometer : ContentPage
    {
        private readonly IXEAccelerometer _xeAccelerometer = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXEAccelerometer>();

        public AccelerometerViewModel VM { get; }

        public Accelerometer()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            
            VM = new AccelerometerViewModel(_xeAccelerometer);
            BindingContext = VM;
        }

        protected override void OnDisappearing()
        {
            VM.StopAccelerometer();
        }        
    }
}