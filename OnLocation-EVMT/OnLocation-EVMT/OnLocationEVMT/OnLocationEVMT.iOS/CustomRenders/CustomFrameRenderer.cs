using System;
using OnLocationEVMT.iOS.CustomRenders;
using OnLocationEVMT.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(CustomFrames), typeof(CustomFrameRenderer))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class CustomFrameRenderer:FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs <Frame> e) { 

            base.OnElementChanged(e); 
            Layer.BackgroundColor = UIColor.FromRGB(255,255,255).CGColor; 


            //Layer.CornerRadius = 5;  

            //Layer.MasksToBounds = false; 

 

            //Layer.BorderColor = UIColor.White.CGColor; 

            //Layer.CornerRadius = 10; 

            //Layer.MasksToBounds = false; 

            //Layer.ShadowOffset = new CGSize(-2, 2); 

            //Layer.ShadowRadius = 5; 

            //Layer.ShadowOpacity = 0.4f;

        } 
    }
}
