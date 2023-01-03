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
  public  class BoothcardServices
    {
        /// <summary>
        /// Method for Get Boothcard
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="SearchKey"></param>
        /// <returns></returns>
        public async Task<List<BoothCardResponse>> GetBoothcards(string StartDate, string EndDate, string SearchKey,int index)
        {           
            List<BoothCardResponse> LstBoothcard = new List<BoothCardResponse>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL+ "OliDetails";
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl;
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"Method\":\"GetBoothcards\", \"StartDate\":\""+ StartDate + "\", \"EndDate\":\""+ EndDate + "\" , \"Searchkeyword\":\""+ SearchKey + "\", \"Index\":\""+ index + "\" }";
                   // string serializedJsonRequest = "{\"Method\":\"GetBoothcards\", \"StartDate\":\""+StartDate+"\", \"EndDate\":\""+EndDate+"\",\"Searchkeyword\":\""+ SearchKey + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<BoothCardResponse> ResultEstimate = JsonConvert.DeserializeObject<List<BoothCardResponse>>(Result);
                        LstBoothcard = ResultEstimate;

                    }
                    else
                    {
                        LstBoothcard = null;
                    }
                }
                else
                {
                    LstBoothcard = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstBoothcard = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstBoothcard;
        }
    }
}
