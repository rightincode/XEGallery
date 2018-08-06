namespace XEGallery.Core.Interfaces
{
    interface IXEAppInfo
    {
        string GetApplicationName();
        
        string GetPackageName();

        string GetVersionString();

        string GetBuildString();
    }
}
