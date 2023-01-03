
using System;
using CoreGraphics;
using OnLocationEVMT.Controls;
using OnLocationEVMT.iOS.CustomRenders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
//[assembly: ExportRenderer(typeof(CustomFrames), typeof(FrameiOS))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class FrameiOS : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {

            base.OnElementChanged(e);
           // Layer.BackgroundColor = UIColor.FromRGB(252, 250, 251).CGColor;


            Layer.CornerRadius = 5;  
            Layer.MasksToBounds = false; 
            Layer.BorderColor = UIColor.White.CGColor; 
            Layer.CornerRadius = 10; 
            Layer.MasksToBounds = false; 
            Layer.ShadowOffset = new CGSize(-2, 2); 
            Layer.ShadowRadius = 5; 
            Layer.ShadowOpacity = 0.4f;
        }
    }
}
