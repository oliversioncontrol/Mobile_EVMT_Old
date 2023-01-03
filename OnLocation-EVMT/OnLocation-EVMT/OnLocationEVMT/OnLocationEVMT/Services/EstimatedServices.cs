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
  public  class EstimatedServices
    {
        /// <summary>
        /// Method for Get Estimated Summary
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="Jobnumber"></param>
        /// <returns></returns>
        public async Task<List<EstimateSummary>> GetEstimatedSummary(string Method, string Jobnumber)
        {
            List<EstimateSummary> LstEstimate = new List<EstimateSummary>();
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
                    string serializedJsonRequest = "{\"Method\":\""+ Method + " \", \"JobNumber\":\""+ Jobnumber + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<EstimateSummary> ResultEstimate = JsonConvert.DeserializeObject<List<EstimateSummary>>(Result);
                        LstEstimate = ResultEstimate;

                    }
                    else
                    {
                        LstEstimate = null;
                    }
                }
                else
                {
                    LstEstimate = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstEstimate = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstEstimate;
        }
    }
}
