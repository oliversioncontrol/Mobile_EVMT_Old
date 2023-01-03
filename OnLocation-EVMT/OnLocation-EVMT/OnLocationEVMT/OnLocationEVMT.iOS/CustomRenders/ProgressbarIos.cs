using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using OnLocationEVMT.DependencyServices;
using Xamarin.Forms;
using OnLocationEVMT.iOS.CustomRenders;
using BigTed;

[assembly: Dependency(typeof(ProgressbarIos))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    class ProgressbarIos: IProgressInterface
    {
        public void Hide()
        {
            BTProgressHUD.Dismiss();
        }

        public void Show(string title = "Loading")
        {
            BTProgressHUD.Show(title, maskType: ProgressHUD.MaskType.Black);
        }
    }
}