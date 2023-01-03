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
    public class YourTeamServices
    {
        /// <summary>
        /// Method for Get Your Team Details
        /// </summary>
        /// <param name="MethodType"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public async Task<List<YourTeamResponse>> GetYourTeamDetails(string MethodType, string UserID)
        {
            int index = 1;
            List<YourTeamResponse> lstYourTeam = new List<YourTeamResponse>();
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
                    string serializedJsonRequest = "{\"Method\":\"" + MethodType + "\",\"UserName\":\"" + UserID + "\"}";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<YourTeamResponse> YourTeamResult = JsonConvert.DeserializeObject<List<YourTeamResponse>>(Result);
                        lstYourTeam = YourTeamResult;
                    }
                    else
                    {
                        lstYourTeam = null;
                    }
                }
                else
                {
                    lstYourTeam = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lstYourTeam = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lstYourTeam;
        }
    }
}
