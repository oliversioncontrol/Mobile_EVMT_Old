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
  public  class BTCHeaderService
    {
        /// <summary>
        /// Method for Get Boothcard Headers
        /// </summary>
        /// <param name="Boothcard"></param>
        /// <returns></returns>
        public async Task<List<BoothHeader>> GetBoothHeader(string Boothcard)
        {           
            List<BoothHeader> LstBoothHeader = new List<BoothHeader>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothHeaderInfo\", \"BoothcardId\":\""+ Boothcard + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<BoothHeader> ResultEstimate = JsonConvert.DeserializeObject<List<BoothHeader>>(Result);
                        LstBoothHeader = ResultEstimate;

                    }
                    else
                    {
                        LstBoothHeader = null;
                    }
                }
                else
                {
                    LstBoothHeader = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstBoothHeader = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstBoothHeader;
        }
    }
}
