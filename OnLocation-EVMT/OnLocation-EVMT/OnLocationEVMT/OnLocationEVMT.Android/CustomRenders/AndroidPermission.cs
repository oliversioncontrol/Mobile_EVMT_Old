using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Xamarin.Forms;
using OnLocationEVMT.Droid.CustomRenders;
using Android.Support.V4.App;
using Android;
using OnLocationEVMT.DependencyServices;
using Android.Content.PM;

[assembly: Dependency(typeof(AndroidPermission))]

namespace OnLocationEVMT.Droid.CustomRenders
{
    /// <summary>
    /// Mapping to Android Permission
    /// </summary>
    public class AndroidPermission : IAndroidPermission
    {
        private List<string> permissionGrant = new List<string>()
        {
            Manifest.Permission.Camera,
            Manifest.Permission.WriteExternalStorage,
        };


        private List<string> permissiongrant1 = new List<string>() { Manifest.Permission.WriteExternalStorage };

        public List<string> PERMISSIONGRANT
        {
            get { return permissiongrant1; }
            set { permissiongrant1 = value; }
        }


        /// <summary>
        /// method to check and grant Camera permission 
        /// </summary>
        public void GrantPermission(int iPermissionindex = -1)
        {
            List<string> permissionGrant = new List<string>()
            {
            Manifest.Permission.Camera,
            Manifest.Permission.WriteExternalStorage,
            };
            try
            {
                if (iPermissionindex == -1)
                {
                    string[] lstRequiredPermission = new string[2];
                    permissionGrant.CopyTo(lstRequiredPermission, 0);
                    foreach (string strPermission in lstRequiredPermission)
                    {
                        if (ActivityCompat.CheckSelfPermission((Activity)Forms.Context, strPermission) == (int)Permission.Granted)
                        {
                            permissionGrant.Remove(strPermission);
                        }
                    }

                    if (permissionGrant.Count > 0)
                    {
                        ActivityCompat.RequestPermissions((Activity)Forms.Context, permissionGrant.ToArray(), 0);
                    }
                }
                else
                {
                    if (ActivityCompat.CheckSelfPermission((Activity)Forms.Context, permissionGrant[iPermissionindex]) != (int)Permission.Granted)
                    {
                        ActivityCompat.RequestPermissions((Activity)Forms.Context, new string[] { permissionGrant[iPermissionindex] }, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        /// <summary>
        /// method to check permission
        /// </summary>
        /// <param name="iPermissionindex"></param>
        /// <returns></returns>
        public bool CheckPermission(int iPermissionindex)
        {
            try
            {
                if (ActivityCompat.CheckSelfPermission((Activity)Forms.Context, permissionGrant[iPermissionindex]) == (int)Permission.Granted)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// method to request Camera permission
        /// </summary>
        [Obsolete]
        public void RequestPermission()
        {
            try
            {
                if (ActivityCompat.ShouldShowRequestPermissionRationale((Activity)Forms.Context, Manifest.Permission.Camera))
                {
                    ActivityCompat.RequestPermissions((Activity)Forms.Context, new string[] { Manifest.Permission.Camera }, 0);
                }
                else
                {
                    ActivityCompat.RequestPermissions((Activity)Forms.Context, new string[] { Manifest.Permission.Camera }, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        /// <summary>
        /// method to check permission
        /// </summary>
        /// <param name="permissionindex"></param>
        /// <returns></returns>
        public bool CheckIsNeverAskAgain(int permissionindex)
        {
            try
            {
                return ActivityCompat.ShouldShowRequestPermissionRationale((Activity)Forms.Context, this.PERMISSIONGRANT[permissionindex]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// method to open app details for permissions
        /// </summary>
        public void OpenAppDetails()
        {
            try
            {
                ((Activity)Forms.Context).StartActivityForResult(new Intent(Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:com.app.onlocation")), 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}