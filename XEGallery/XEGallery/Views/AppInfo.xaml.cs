using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

using XEGallery.ViewModels;
using XEGallery.Core.Interfaces;

namespace XEGallery.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppInfo : ContentPage
	{
        private readonly IXEAppInfo _xeAppInfo = ((App)Xamarin.Forms.Application.Current).ServiceProvider.GetService<IXEAppInfo>();

        public AppInfoViewModel VM { get; }

        public AppInfo()
		{
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            VM = new AppInfoViewModel(_xeAppInfo);
            BindingContext = VM;
        }
	}
}