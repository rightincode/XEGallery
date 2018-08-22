using System;
using System.Collections.Generic;
using System.Text;

namespace XEGallery.Core.Interfaces
{
    public interface IXECompass : IXESensor, IDisposable
    {
        double CurrentCompassReading { get; }        
    }
}
