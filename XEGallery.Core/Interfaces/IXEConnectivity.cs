using System;

namespace XEGallery.Core.Interfaces
{
    public interface IXEConnectivity : IDisposable
    {
        string CurrentNetworkAccess { get; }

        string CurrentNetworkProfiles { get; }

        event EventHandler ReadingsChanged;
    }
}
