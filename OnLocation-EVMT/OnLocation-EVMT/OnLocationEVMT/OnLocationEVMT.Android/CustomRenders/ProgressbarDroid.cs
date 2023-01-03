using AndroidHUD;
using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Droid.CustomRenders;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProgressbarDroid))]
namespace OnLocationEVMT.Droid.CustomRenders
{

    class ProgressbarDroid: IProgressInterface
    {
        public void Hide()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Dismiss();
            });
        }

        public void Show(string title = "Loading")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Show(Forms.Context, status: title, maskType: MaskType.Clear,centered:true);
            });
        }
    }
}