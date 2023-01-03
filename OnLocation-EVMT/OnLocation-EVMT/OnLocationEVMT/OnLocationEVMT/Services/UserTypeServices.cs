using Newtonsoft.Json;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Services
{
    class UserTypeServices
    {
        /// <summary>
        /// Method for Get Client Type
        /// </summary>
        /// <param name="MehtodType"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        public async Task<List<UserTypes>> GetClientType(string MehtodType,string Username)
        {
          List<UserTypes> lUserType = new List<UserTypes>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl+ "OliDetails";
                    HttpClient client = new HttpClient();                   
                    string serializedJsonRequest = "{\"Method\":\"" + MehtodType + "\",\"UserName\":\"" + Username + "\"}";                   
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<UserTypes> Result1 = JsonConvert.DeserializeObject<List<UserTypes>>(Result);
                        lUserType = Result1;

                    }
                    else
                    {
                        lUserType = null;
                    }
                }
                else
                {
                    lUserType = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lUserType = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lUserType;
        }
    }
}
