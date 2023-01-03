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
using Xamarin.Forms;
using OnLocationEVMT.Droid.CustomRenders;
using Android.Content.PM;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ContentPage), typeof(CustomContentPageRenderer))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    public class CustomContentPageRenderer : Xamarin.Forms.Platform.Android.PageRenderer
    {
        private ScreenOrientation _previousOrientation = ScreenOrientation.Unspecified;

        protected override void OnWindowVisibilityChanged(ViewStates visibility)
        {
            try
            {
                base.OnWindowVisibilityChanged(visibility);
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    var activity = (Activity)Context;
                    if (visibility == ViewStates.Gone)
                    {
                        // Revert to previous orientation
                        activity.RequestedOrientation = _previousOrientation == ScreenOrientation.Unspecified ?
                       ScreenOrientation.Portrait : _previousOrientation;
                    }
                    else if (visibility == ViewStates.Visible)
                    {
                        if (_previousOrientation == ScreenOrientation.Unspecified)
                        {
                            _previousOrientation = activity.RequestedOrientation;
                        }

                        activity.RequestedOrientation = ScreenOrientation.Portrait;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}