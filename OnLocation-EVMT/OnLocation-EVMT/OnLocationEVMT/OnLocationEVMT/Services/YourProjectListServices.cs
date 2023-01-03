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
    public  class YourProjectListServices
    {
        /// <summary>
        /// Method for Get Project Details
        /// </summary>
        /// <param name="MethodType"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public async Task<List<YourProjectListResponse>> GetProjectDetails(string UserID,string SearchKeywords,int index,string SortOrder,string Year)
        {          
            List<YourProjectListResponse> LstProjectList = new List<YourProjectListResponse>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            string serializedJsonRequest = string.Empty;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl+ "OliDetails";
                    HttpClient client = new HttpClient();
                    if (string.IsNullOrEmpty(Year))
                    {
                        serializedJsonRequest = "{\"Method\":\"GetYourProjectList\", \"UserName\":\"" + UserID + "\", \"Searchkeyword\":\"" + SearchKeywords + "\", \"Index\":\"" + index + "\", \"SortOrder\":\"" + SortOrder.ToLower() + "\" }";
                    }
                    else
                    {
                        serializedJsonRequest = "{\"Method\":\"GetYourProjectList\", \"UserName\":\"" + UserID + "\", \"Searchkeyword\":\"" + SearchKeywords + "\", \"Index\":\"" + index + "\", \"SortOrder\":\"" + SortOrder.ToLower() + "\", \"Year\":\""+Year+"\"  }";
                    }
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<YourProjectListResponse> YourTeamResult = JsonConvert.DeserializeObject<List<YourProjectListResponse>>(Result);
                        LstProjectList = YourTeamResult;

                    }
                    else
                    {
                        LstProjectList = null;
                    }
                }
                else
                {
                    LstProjectList = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstProjectList = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstProjectList;
        }
    }
}
