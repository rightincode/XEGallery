using System.Threading.Tasks;
using Xamarin.Essentials;
using XEGallery.Core.Interfaces;

namespace XEGallery.Core.Models
{
    public class XEMaps : IXEMaps
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public XEMaps()
        {

        }

        public async Task OpenMapsAsync()
        {
            var location = new Location(Latitude, Longitude);

            if (location != null)
            {
                await Maps.OpenAsync(location);
            }            
        }
    }
}
