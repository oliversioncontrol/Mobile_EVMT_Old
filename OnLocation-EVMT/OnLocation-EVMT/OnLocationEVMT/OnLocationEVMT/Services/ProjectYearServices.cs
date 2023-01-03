using Newtonsoft.Json;
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
  public class ProjectYearServices
    {

        public async Task<List<ProjectYear>> GetProjectYear(string SearchKeywords)
        {            
            List<ProjectYear> lstProjectYear = new List<ProjectYear>();
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
                    ///string serializedJsonRequest = "{\"Method\":\"GetProjectShowYears\"}";
                    string serializedJsonRequest = "{\"Method\":\"GetProjectShowYears\", \"UserName\":\""+UserAccounts.LoginUserID+"\", \"Searchkeyword\":\""+ SearchKeywords + "\"}";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<ProjectYear> lstYear = JsonConvert.DeserializeObject<List<ProjectYear>>(result);
                        lstProjectYear = lstYear;

                    }
                    else
                    {
                        lstProjectYear = null;
                    }
                }
                else
                {
                    lstProjectYear = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lstProjectYear = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lstProjectYear;
        }
    }
}
