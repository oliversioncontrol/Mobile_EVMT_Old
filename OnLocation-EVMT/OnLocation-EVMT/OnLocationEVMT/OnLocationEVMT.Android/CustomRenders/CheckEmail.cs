using System;
using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Droid.CustomRenders;
using Xamarin.Forms;
using Plugin.Connectivity;
using Android.Content;
using Android.Content.PM;
using System.Collections.Generic;

[assembly: Dependency(typeof(CheckEmail))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    class CheckEmail : ICheckEmail
    {
        public bool IsEmail()
        {
            bool result = false;
            var isNetworkAvailable = CrossConnectivity.Current.IsConnected;
            if (isNetworkAvailable == true)
            {
                Intent intent = new Intent(Intent.ActionSendMultiple);
                intent.SetType("text/plain");
                PackageManager packageManager = Forms.Context.PackageManager;
                IList<ResolveInfo> resInfo = packageManager.QueryIntentActivities(intent, 0);
                if (resInfo.Count > 1)
                {
                    result = true;
                   // Xamarin.Forms.Forms.Context.StartActivity(intent);
                }
                else
                {
                    result = false;
                    App.Current.MainPage.DisplayAlert("Alert", "No email client is found to send exportsheet.Please install first and then retry.", "OK");
                }

            }

            return result;
        }
    }
}