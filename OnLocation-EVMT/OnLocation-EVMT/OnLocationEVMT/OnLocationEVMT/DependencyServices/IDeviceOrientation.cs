using System;
namespace OnLocationEVMT.DependencyServices
{
    //public enum DeviceOrientations
    //{
    //    Undefined,
    //    Landscape,
    //    Portrait
    //}
    public interface IDeviceOrientation
    {
        //DeviceOrientations GetOrientation();
        void ForceLandscape();
        void ForcePortrait();
    }
}
