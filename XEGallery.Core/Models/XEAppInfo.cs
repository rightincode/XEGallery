using XEGallery.Core.Interfaces;
using Xamarin.Essentials;


namespace XEGallery.Core.Models
{
    public class XEAppInfo : IXEAppInfo
    {
        public string GetApplicationName()
        {
            return AppInfo.Name;
        }

        public string GetBuildString()
        {
            return AppInfo.BuildString;
        }

        public string GetPackageName()
        {
            return AppInfo.PackageName;
        }

        public string GetVersionString()
        {
            return AppInfo.VersionString;

        }
    }
}
