using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

using XEGallery.Core.Models;

namespace XEGallery.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppInfo : ContentPage
	{
		public AppInfo()
		{
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            var currentAppInfo = new XEAppInfo();

            AppNameLabel.Text = "Application Name: " + currentAppInfo.GetApplicationName();
            BuildLabel.Text = "Build: " + currentAppInfo.GetBuildString();
            PackageNameLabel.Text = "Package Name: " + currentAppInfo.GetPackageName();
            VersionLabel.Text = "Version: " + currentAppInfo.GetVersionString();
        }
	}
}