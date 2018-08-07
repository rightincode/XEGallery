using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class AppInfoViewModel
    {
        private IXEAppInfo _appInfo { get; set; }
     

        public string ApplicationName { get { return _appInfo.GetApplicationName(); } }

        public string PackageName { get { return _appInfo.GetPackageName(); } }

        public string Version {  get { return _appInfo.GetVersionString(); } }

        public string Build { get { return _appInfo.GetBuildString(); } }

        public AppInfoViewModel(IXEAppInfo appInfo)
        {
            _appInfo = appInfo;
        }
    }
}
