using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XEGallery.Core.Interfaces;

namespace XEGallery.Core.Models
{
    public class XEGeolocation : IXEGeolocation
    {
        public XEGeolocation()
        {

        }

        public Location LastKnowLocation { get; private set; }

        public Location CurrentLocation { get; private set; }

        public async Task SetLastKnownLocationAsync()
        {
            try
            {
                LastKnowLocation = await Geolocation.GetLastKnownLocationAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Debug.WriteLine(fnsEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Debug.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine(ex);
            }
        }

        public async Task SetLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                CurrentLocation = await Geolocation.GetLocationAsync(request);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Debug.WriteLine(fnsEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Debug.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Debug.WriteLine(ex);
            }
        }
    }
}
