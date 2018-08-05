namespace XEGallery.Core.Interfaces
{
    interface IAppInfo
    {
        string GetApplicationName();
        
        string GetPackageName();

        string GetVersionString();

        string GetBuildString();
    }
}
