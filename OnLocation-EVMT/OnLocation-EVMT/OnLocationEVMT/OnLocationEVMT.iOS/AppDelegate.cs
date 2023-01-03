using System;
using System.Collections.Generic;
using System.Linq;
using ObjCRuntime;
using Foundation;
using UIKit;
using OnLocationEVMT.Controls;
using OnLocationEVMT.Views;
using Xamarin.Forms;

namespace OnLocationEVMT.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ScreenHeightWidth.IsCheckApp = true;
            ScreenHeightWidth.LastInstalledVersionName = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
            ScreenHeightWidth.LastInstalledVersionCode = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
            ScreenHeightWidth.OSVersion = UIDevice.CurrentDevice.SystemVersion;
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
        {
            try
            {
                if (Xamarin.Forms.Application.Current == null || Xamarin.Forms.Application.Current.MainPage == null)
                {
                    return UIInterfaceOrientationMask.All;
                }
                var mainPage = Xamarin.Forms.Application.Current.MainPage;
                if (mainPage is BoothcardSign || (mainPage is NavigationPage && ((NavigationPage)mainPage).CurrentPage is BoothcardSign) || (mainPage.Navigation != null && mainPage.Navigation.ModalStack.LastOrDefault() is BoothcardSign))
                {
                    return UIInterfaceOrientationMask.Landscape;
                }
                else
                {
                    //var deviceType = UIKit.UIDevice.CurrentDevice.UserInterfaceIdiom;
                    //if (Convert.ToString(deviceType).Equals("Pad"))
                    //{
                    //    return UIInterfaceOrientationMask.All;
                    //}
                    //else
                    //{          
                    //}
                    return UIInterfaceOrientationMask.Portrait;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return UIInterfaceOrientationMask.Portrait;
            }
        }
    }
}
