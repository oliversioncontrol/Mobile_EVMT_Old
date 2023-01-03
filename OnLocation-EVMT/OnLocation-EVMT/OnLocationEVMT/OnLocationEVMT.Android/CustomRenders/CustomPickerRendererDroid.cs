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
using Xamarin.Forms.Platform.Android;
using OnLocationEVMT.Controls;
using OnLocationEVMT.Droid.CustomRenders;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRendererDroid))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    class CustomPickerRendererDroid:PickerRenderer
    {
        public CustomPickerRendererDroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement != null)
            {
                Control.TextSize = 14;
            }
        }
       
    }
}