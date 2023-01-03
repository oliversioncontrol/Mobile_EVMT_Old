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
   public class ODSampleServices
    {
        /// <summary>
        /// Method for Get Order Sample
        /// </summary>
        /// <param name="JobNumber"></param>
        /// <returns></returns>
        public async Task<List<ODSampleResponse>> GetOrderSample(string JobNumber)
        {
            List<ODSampleResponse> LstOrderSample = new List<ODSampleResponse>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetLaborCallWorkDetails\", \"JobNumber\":\""+JobNumber+"\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<ODSampleResponse> Result1 = JsonConvert.DeserializeObject<List<ODSampleResponse>>(Result);
                        LstOrderSample = Result1;

                    }
                    else
                    {
                        LstOrderSample = null;
                    }
                }
                else
                {
                    LstOrderSample = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstOrderSample = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstOrderSample;
        }
    }
}
