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
    public  class ShowInfoServices
    {
        /// <summary>
        ///  Method for Get Show Info Details
        /// </summary>
        /// <param name="MethodType"></param>
        /// <param name="JobNumber"></param>
        /// <returns></returns>
        public async Task<List<ShowInfoResponse>> GetShowInfoDetails(string MethodType, string JobNumber)
        {
            List<ShowInfoResponse> ListShowInformation = new List<ShowInfoResponse>();
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
                    string serializedJsonRequest = "{\"Method\":\"" + MethodType + "\",\"JobNumber\":\"" + JobNumber + "\"}";                 
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<ShowInfoResponse> YourResult = JsonConvert.DeserializeObject<List<ShowInfoResponse>>(Result);
                        ListShowInformation = YourResult;

                    }
                    else
                    {
                        ListShowInformation = null;
                    }
                }
                else
                {
                    ListShowInformation = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                ListShowInformation = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return ListShowInformation;
        }
    }
}
