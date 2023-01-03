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
 public  class PortfolioServices
    {
        /// <summary>
        /// Method for Get JobPortfolio Details
        /// </summary>
        /// <param name="ProtfolioJob"></param>
        /// <returns></returns>
        public async Task<List<Portfolio>> GetJobPortfolioDetails(string ProtfolioJob)
        {
            List<Portfolio> LstPortfolio = new List<Portfolio>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetJobPortfolioDetails\", \"JobNumber\":\""+ ProtfolioJob + "\"}";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<Portfolio> ResultEstimate = JsonConvert.DeserializeObject<List<Portfolio>>(Result);
                        LstPortfolio = ResultEstimate;
                    }
                    else
                    {
                        LstPortfolio = null;
                    }
                }
                else
                {
                    LstPortfolio = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstPortfolio = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstPortfolio;
        }
    }
}
