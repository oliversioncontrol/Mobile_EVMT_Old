using System;
using Android.App;
using Android.Content.PM;
using Android.Provider;
using Android.OS;
using OnLocationEVMT.Controls;
using Android.Support.V4.App;
using Android.Content;
using Xamarin.Forms;
using Android.Content.Res;
using Android.Locations;
using System.Threading;
using System.IO;
using OnLocationEVMT.Droid.CustomRenders;
using Android.Views;

namespace OnLocationEVMT.Droid
{
    //Label = "OnLocation",Icon ="@drawable/logoon"
    [Activity(Theme = "@style/MainTheme", MainLauncher =false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        public static Context thisContext;   
        protected override void OnCreate(Bundle bundle)
        {
            try
            {               
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
                thisContext = this;
                base.OnCreate(bundle);                
                var metrics = Resources.DisplayMetrics;
                ScreenHeightWidth.IsCheckApp = true;
                ScreenHeightWidth.ScreenWidth = ConvertPixelsToDp(metrics.WidthPixels);
                ScreenHeightWidth.ScreenHeight = ConvertPixelsToDp(metrics.HeightPixels);
                ScreenHeightWidth.CurrentSDKVersion = Convert.ToInt32(Build.VERSION.SdkInt);
                ScreenHeightWidth.LastInstalledVersionName = thisContext.PackageManager.GetPackageInfo(thisContext.PackageName, 0).VersionName;
               
                ScreenHeightWidth.LastInstalledVersionCode = Convert.ToString(thisContext.PackageManager.GetPackageInfo(thisContext.PackageName, 0).VersionCode);
                ScreenHeightWidth.OSVersion = Android.OS.Build.VERSION.Release;
                
                ScreenshotManager.Activity= (MainActivity)Forms.Context;               
                global::Xamarin.Forms.Forms.Init(this, bundle);
                LoadApplication(new App());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var objDP = (int)(pixelValue / Resources.DisplayMetrics.Density);
            return objDP;
        }
        void ActivityCompat.IOnRequestPermissionsResultCallback.OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            try
            {
                if (requestCode == 0)
                {
                    for (int indexCount = 0; indexCount < grantResults.Length; indexCount++)
                    {
                        if (grantResults[indexCount] != 0)
                        {
                            ((Activity)Forms.Context).StartActivityForResult(new Intent(Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:com.app.onlocation")), 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        //public override void OnBackPressed()
        //{
        //    // This prevents a user from being able to hit the back button and leave the login page.
        //    // if (!user.IsLoggedIn())
        //    return;
        //    // base.OnBackPressed();
        //}


       
    }
}

