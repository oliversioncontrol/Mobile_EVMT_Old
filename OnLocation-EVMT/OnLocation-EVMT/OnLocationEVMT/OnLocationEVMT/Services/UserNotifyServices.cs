using Newtonsoft.Json;
using OnLocationEVMT.Controls;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Services
{
    /// <summary>
    /// Class for User Notify Services
    /// </summary>
    public class UserNotifyServices
    {
        /// <summary>
        /// Method for GetAppVersion
        /// </summary>
        /// <param name="PlatformType"></param>
        /// <returns></returns>
        public async Task<string> GetAppVersion(string PlatformType)
        {
            string versionresult = string.Empty;
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl + "OliDetails";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"Method\":\"GetAppVersion\", \"PlatformType\":\"" + PlatformType + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var ResponseResult = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(ResponseResult);
                        List<VersionNo> VersionNo = JsonConvert.DeserializeObject<List<VersionNo>>(Result);
                        versionresult = VersionNo[0].Version;
                    }
                    else
                    {
                        versionresult = ScreenHeightWidth.LastInstalledVersionName; 
                    }
                }
                else
                {
                    versionresult = ScreenHeightWidth.LastInstalledVersionName;
                    await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                }
            }
            catch (Exception ex)
            {
                versionresult = ScreenHeightWidth.LastInstalledVersionName;
                Debug.WriteLine(ex.StackTrace);
            }
            return versionresult;
        }
    }
    /// <summary>
    /// Class Version No
    /// </summary>
    public class VersionNo
    {
        public string Version { get; set; }
    }
}
