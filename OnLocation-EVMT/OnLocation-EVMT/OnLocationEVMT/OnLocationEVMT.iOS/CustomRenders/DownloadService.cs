using System;
using System.IO;
using System.Net;
using AssetsLibrary;
using Foundation;
using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.iOS.CustomRenders;
using Photos;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DownloadService))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class DownloadService : IDownloadService
    {
        public byte[] DownloadImage(string URL,string name)
        {
            try
            {


                var url = new NSUrl(URL);
                var data = NSData.FromUrl(url);
                return data.ToArray();
            }
            catch(Exception ex)
            {
                return null;
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
