using System;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XEGallery.Core.Interfaces;
using XEGallery.Core.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XEGallery
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();
            StartupConfiguration();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void StartupConfiguration()
        {
            var services = new ServiceCollection();
            services.AddTransient<IXEAppInfo, XEAppInfo>();
            services.AddTransient<IXEBatteryInfo, XEBatteryInfo>();
            services.AddTransient<IXEAccelerometer, XEAccelerometer>();
            services.AddTransient<IXECompass, XECompass>();
            services.AddTransient<IXEConnectivity, XEConnectivity>();
            services.AddTransient<IXEGeolocation, XEGeolocation>();
            services.AddTransient<IXEMaps, XEMaps>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
