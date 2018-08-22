using System;
using XEGallery.Core.Enums;

namespace XEGallery.Core.Interfaces
{
    public interface IXESensor
    {
        event EventHandler ReadingsChanged;
        void SetSensorSpeed(XESensorSpeed sensorSpeed);
        void Start();
        void Stop();
        void Toggle();
    }
}
