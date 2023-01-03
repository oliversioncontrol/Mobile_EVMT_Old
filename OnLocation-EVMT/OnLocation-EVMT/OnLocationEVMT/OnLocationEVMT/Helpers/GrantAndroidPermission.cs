using OnLocationEVMT.Controls;
using OnLocationEVMT.DependencyServices;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace OnLocationEVMT.Helpers
{
    public class GrantAndroidPermission
    {
        /// <summary>
        /// method to grant permission for android version 23 and greater
        /// </summary>
        public static void GrantPermissions(int iPermission = -1)
        {
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (ScreenHeightWidth.CurrentSDKVersion >= 23)
                    {
                        DependencyService.Get<IAndroidPermission>().GrantPermission(iPermission);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// method to check permission for android version 23 and greater
        /// </summary>
        public static bool CheckPermissions(int iPermission)
        {
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (ScreenHeightWidth.CurrentSDKVersion >= 23)
                    {
                        return DependencyService.Get<IAndroidPermission>().CheckPermission(iPermission);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }

    public enum AndroidPermissionName
    {
        Camera,
        Storage
    }
}
