using System;
using XEGallery.Core.Enums;

namespace XEGallery.Core.Interfaces
{
    public interface IXEAccelerometer : IDisposable
    {
        float XAccelleration { get; }
        float YAcceleration { get; }
        float ZAcceleration { get; }

        event EventHandler ReadingsChanged;

        void SetSensorSpeed(XESensorSpeed sensorSpeed);
        void StartAccelerometer();
        void StopAccelerometer();
        void ToggleAccelerometer();

    }
}
