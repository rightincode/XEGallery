using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XEGallery.Core.Interfaces
{
    public interface IXEGeolocation
    {
        Location LastKnowLocation { get; }
        Location CurrentLocation { get; }

        Task SetLastKnownLocationAsync();

        Task SetLocationAsync();
    }
}
