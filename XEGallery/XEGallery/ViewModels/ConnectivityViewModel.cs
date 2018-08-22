using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XEGallery.Core.Interfaces;

namespace XEGallery.ViewModels
{
    public class ConnectivityViewModel : ExtendedBindableObject, INotifyPropertyChanged, IDisposable
    {
        private readonly IXEConnectivity _xeConnectivity;

        public string NetworkAccess { get { return _xeConnectivity.CurrentNetworkAccess; } }

        public string NetworkProfiles { get { return _xeConnectivity.CurrentNetworkProfiles; } }

        public ConnectivityViewModel(IXEConnectivity xeConnectivity)
        {
            _xeConnectivity = xeConnectivity;
            _xeConnectivity.ReadingsChanged += OnReadingsChanged;
        }
        
        public void Dispose()
        {
            _xeConnectivity.ReadingsChanged -= OnReadingsChanged;
            _xeConnectivity.Dispose();
        }

        private void OnReadingsChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged(() => NetworkAccess);
            RaisePropertyChanged(() => NetworkProfiles);
        }
    }
}
