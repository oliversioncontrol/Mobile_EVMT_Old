using System;
using OnLocationEVMT.Controls;
using OnLocationEVMT.iOS.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRendererIOS))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    class CustomPickerRendererIOS : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement != null)
            {
                var deviceType = UIKit.UIDevice.CurrentDevice.UserInterfaceIdiom;
                if (Convert.ToString(deviceType).Equals("Pad"))
                {
                    Control.Font = UIKit.UIFont.SystemFontOfSize(16f);
                }
                else
                {
                    Control.Font = UIKit.UIFont.SystemFontOfSize(12f);
                }
            }
        }
    }
}
