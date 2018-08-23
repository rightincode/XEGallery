using System.Threading.Tasks;

namespace XEGallery.Core.Interfaces
{
    public interface IXEMaps
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        Task OpenMapsAsync();
    }
}
