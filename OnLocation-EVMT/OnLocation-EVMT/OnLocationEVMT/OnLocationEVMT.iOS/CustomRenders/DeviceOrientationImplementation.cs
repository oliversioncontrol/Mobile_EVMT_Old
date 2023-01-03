using System;
using Foundation;
using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.iOS.CustomRenders;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationImplementation))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class DeviceOrientationImplementation:IDeviceOrientation
    {
        
        //public DeviceOrientations GetOrientation()
        //{
        //    var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
        //    bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
        //        || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

        //    return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
        //}
        public void ForceLandscape()
        {
            //UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
           
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.LandscapeLeft)), new NSString("orientation"));
        }

        public void ForcePortrait()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
        }
    }
}
