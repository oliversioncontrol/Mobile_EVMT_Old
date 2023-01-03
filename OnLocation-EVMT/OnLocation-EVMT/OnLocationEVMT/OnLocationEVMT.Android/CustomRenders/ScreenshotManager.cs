using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OnLocationEVMT.DependencyServices;
using Android.Graphics;
using System.IO;
using Xamarin.Forms;
using OnLocationEVMT.Droid.CustomRenders;

[assembly: Dependency(typeof(ScreenshotManager))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    class ScreenshotManager : IScreenshotManager
    {
        public static Activity Activity { get; set; }
        public async Task<byte[]> CaptureAsync()
        {
            Grid grd = new Grid();
            byte[] bitmapData=null;
            try
            {
                if (Activity != null)
                {
                    throw new Exception("You have to set ScreenshotManager.Activity in your Android project");
                }
                // ((Activity)Forms.Context).Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutHideNavigation;
                //var view =  ((Activity)Forms.Context).Window.DecorView;// Activity.Window.DecorView;
                var view = ((Activity)Forms.Context).Window.DecorView;
                view.DrawingCacheEnabled = true;
               
                Bitmap bitmap = view.GetDrawingCache(true);              

                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    bitmapData = stream.ToArray();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return bitmapData;
        }



    }
}