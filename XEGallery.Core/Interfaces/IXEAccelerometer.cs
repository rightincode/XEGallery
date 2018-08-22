using System;
using XEGallery.Core.Enums;

namespace XEGallery.Core.Interfaces
{
    public interface IXEAccelerometer : IXESensor, IDisposable
    {
        float XAccelleration { get; }
        float YAcceleration { get; }
        float ZAcceleration { get; }
    }
}
