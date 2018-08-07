namespace XEGallery.Core.Interfaces
{
    public interface IXEAppInfo
    {
        string GetApplicationName();
        
        string GetPackageName();

        string GetVersionString();

        string GetBuildString();
    }
}
