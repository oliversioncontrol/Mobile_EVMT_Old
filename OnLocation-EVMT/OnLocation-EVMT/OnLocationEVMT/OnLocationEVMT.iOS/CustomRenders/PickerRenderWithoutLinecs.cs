using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using OnLocationEVMT.iOS.CustomRenders;
using OnLocationEVMT.Controls;

[assembly: ExportRenderer(typeof(PkrRenderWithoutLine), typeof(PickerRenderWithoutLinecs))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    class PickerRenderWithoutLinecs : PickerRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement != null)
            {
                var deviceType = UIKit.UIDevice.CurrentDevice.UserInterfaceIdiom;
                if (Convert.ToString(deviceType).Equals("Pad"))
                {
                    Control.Font = UIKit.UIFont.SystemFontOfSize(18f);
                    //Control.Layer.BorderWidth = 0;
                    //Control.BorderStyle = UITextBorderStyle.None;                   
                }
                else
                {
                    Control.Font = UIKit.UIFont.SystemFontOfSize(14f);
                    //Control.Layer.BorderWidth = 0;
                    //Control.BorderStyle = UITextBorderStyle.None;                   
                }
            }
        }
        
    }
}