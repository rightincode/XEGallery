using System;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using XEGallery.Core.Interfaces;

namespace XEGallery.Core.Models
{
    public class XEConnectivity : IXEConnectivity, IDisposable
    {
        public string CurrentNetworkAccess { get; private set; }

        public string CurrentNetworkProfiles { get; private set; }

        public XEConnectivity()
        {
            Initialize();
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        public void Dispose()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }

        public event EventHandler ReadingsChanged;

        private void Initialize()
        {
            SetNetworkAccess();
            SetNetworkProfile();
        }

        private void SetNetworkAccess()
        {
            switch (Connectivity.NetworkAccess)
            {
                case NetworkAccess.ConstrainedInternet:
                    CurrentNetworkAccess = "ConstrainedInternet";
                    break;
                case NetworkAccess.Internet:
                    CurrentNetworkAccess = "Internet";
                    break;
                case NetworkAccess.Local:
                    CurrentNetworkAccess = "Local";
                    break;
                case NetworkAccess.None:
                    CurrentNetworkAccess = "None";
                    break;
                case NetworkAccess.Unknown:
                default:
                    CurrentNetworkAccess = "Unknown";
                    break;
            }
        }

        private void SetNetworkProfile()
        {
            StringBuilder connectivityProfilesString = new StringBuilder();
            var connectivityProfiles = Connectivity.Profiles;

            if (connectivityProfiles.Contains(ConnectionProfile.Bluetooth)){
                connectivityProfilesString.Append((connectivityProfilesString.Length > 0) ?
                    ", Bluetooth" : "Bluetooth");
            }

            if (connectivityProfiles.Contains(ConnectionProfile.Cellular))
            {
                connectivityProfilesString.Append((connectivityProfilesString.Length > 0) ?
                    ", Cellular" : "Cellular");
            }

            if (connectivityProfiles.Contains(ConnectionProfile.Ethernet))
            {
                connectivityProfilesString.Append((connectivityProfilesString.Length > 0) ?
                    ", Ethernet" : "Ethernet");
            }

            if (connectivityProfiles.Contains(ConnectionProfile.Other))
            {
                connectivityProfilesString.Append((connectivityProfilesString.Length > 0) ?
                    ", Other" : "Other");
            }

            if (connectivityProfiles.Contains(ConnectionProfile.WiFi))
            {
                connectivityProfilesString.Append((connectivityProfilesString.Length > 0) ?
                    ", WiFi" : "WiFi");
            }

            if (connectivityProfiles.Contains(ConnectionProfile.WiMAX))
            {
                connectivityProfilesString.Append((connectivityProfilesString.Length > 0) ?
                    ", WiMAX" : "WiMAX");
            }

            CurrentNetworkProfiles = connectivityProfilesString.ToString();
        }

        private void OnConnectivityChanged(Object sender, ConnectivityChangedEventArgs e)
        {
            Initialize();

            ReadingsChanged?.Invoke(this, e);
        }        
    }
}
