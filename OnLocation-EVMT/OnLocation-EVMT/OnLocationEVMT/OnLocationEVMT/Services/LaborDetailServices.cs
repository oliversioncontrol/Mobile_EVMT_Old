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
   public class LaborDetailServices
    {
        /// <summary>
        /// Method for Get Labor Details
        /// </summary>
        /// <param name="Boothcard"></param>
        /// <returns></returns>
        public async Task<List<LaborDetailModel>> GetLaborDetails(string Boothcard)
        {           
            List<LaborDetailModel> LstLaborDetail = new List<LaborDetailModel>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothLaborDetails\", \"BoothcardId\":\""+Boothcard+"\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<LaborDetailModel> ResultEstimate = JsonConvert.DeserializeObject<List<LaborDetailModel>>(Result);
                        LstLaborDetail = ResultEstimate;

                    }
                    else
                    {
                        LstLaborDetail = null;
                    }
                }
                else
                {
                    LstLaborDetail = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstLaborDetail = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstLaborDetail;
        }
    }
}
