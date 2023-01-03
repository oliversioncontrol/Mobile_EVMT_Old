using System;
using OnLocationEVMT.Controls;
using OnLocationEVMT.iOS.CustomRenders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
//[assembly: ExportRenderer(typeof(CustomFrames), typeof(CustomFrame))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class CustomFrame:FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs <Frame> e) { 

            try{

            base.OnElementChanged(e); 

            Layer.BackgroundColor = UIColor.FromRGB(252,250,251).CGColor; 

        }

            catch(Exception ex)

            {

                ex.StackTrace.ToString();

            }

        } 
    }
}
