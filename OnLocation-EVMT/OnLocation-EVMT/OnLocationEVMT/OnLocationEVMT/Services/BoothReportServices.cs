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
  public class BoothReportServices
    {
        /// <summary>
        ///  Method for Get Boothcard Report With Signature
        /// </summary>
        /// <param name="SignRequest"></param>
        /// <returns></returns>
        public async Task<List<SignResponseModel>> GetBoothcardReport(string JobID,string BoothID)
        {

            List<SignResponseModel> LstBoothResponse = new List<SignResponseModel>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = Resource.InvoiceURL+ "GetClientBoothcard";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"JobNumber\":\""+ JobID+"\", \"BoothcardId\":\""+ BoothID + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<SignResponseModel> ResultEstimate = JsonConvert.DeserializeObject<List<SignResponseModel>>(Result);
                        LstBoothResponse = ResultEstimate;

                    }
                    else
                    {
                        LstBoothResponse = null;
                    }
                }
                else
                {
                    LstBoothResponse = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstBoothResponse = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstBoothResponse;
        }
    }
}
