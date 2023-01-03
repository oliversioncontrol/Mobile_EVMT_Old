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

[assembly: ExportRenderer(typeof(CustomPicker), typeof(PickerRenderWithoutLine))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    /// <summary>
    /// PickerRenderWithoutLine 
    /// </summary>
    class PickerRenderWithoutLine : PickerRenderer
    {

        public PickerRenderWithoutLine(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (e.OldElement != null || e.NewElement != null)
                {
                    Control.TextSize = 14;
                    Control.Background = null;
                    var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                    layoutParams.SetMargins(0, 0, 0, 0);
                    LayoutParameters = layoutParams;
                    Control.LayoutParameters = layoutParams;
                    Control.SetPadding(0, 0, 0, 0);
                    SetPadding(0, 0, 0, 0);
                    //Control.SetPadding(0, 30, 5, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}