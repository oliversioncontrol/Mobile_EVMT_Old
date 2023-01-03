using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Content.PM;
using Xamarin.Forms;
using OnLocationEVMT.Droid.CustomRenders;
using OnLocationEVMT.Views;

[assembly: Xamarin.Forms.ExportRenderer(typeof(BoothcardSign), typeof(CustomSignRenderer))]
namespace OnLocationEVMT.Droid.CustomRenders
{

   public class CustomSignRenderer:PageRenderer
    {
        private ScreenOrientation _previousOrientation = ScreenOrientation.Unspecified;

        public CustomSignRenderer(Context context):base(context)
        {
            //
        }
        protected override void OnWindowVisibilityChanged(ViewStates visibility)
        {
            try
            {
                base.OnWindowVisibilityChanged(visibility);
                var activity = (Activity)Context;
                activity.RequestedOrientation = ScreenOrientation.Landscape;
                //if (Device.Idiom == TargetIdiom.Phone)
                //{
                //    var activity = (Activity)Context;
                //    activity.RequestedOrientation = ScreenOrientation.Landscape;
                //    if (visibility == ViewStates.Gone)
                //    {
                //        // Revert to previous orientation
                //        activity.RequestedOrientation = _previousOrientation == ScreenOrientation.Unspecified ?
                //       ScreenOrientation.Portrait : _previousOrientation;
                //    }
                //    else if (visibility == ViewStates.Visible)
                //    {
                //        if (_previousOrientation == ScreenOrientation.Unspecified)
                //        {
                //            _previousOrientation = activity.RequestedOrientation;
                //        }

                //        //activity.RequestedOrientation = ScreenOrientation.Landscape;
                //    }
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}