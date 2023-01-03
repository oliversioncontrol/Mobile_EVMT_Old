using System;
using Foundation;
using OnLocationEVMT.Controls;
using OnLocationEVMT.iOS.CustomRenders;
using OnLocationEVMT.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
//[assembly: ExportRenderer(typeof(Resource), typeof(BoothcardSignRender))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class BoothcardSignRender:PageRenderer
    {
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
        }
    }
}
