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
   public class SignatureServices
    {
        /// <summary>
        ///  Method for Get Boothcard Report With Signature
        /// </summary>
        /// <param name="SignRequest"></param>
        /// <returns></returns>
        public async Task<List<SignResponseModel>> GetBoothcardReport(SignRequestModel SignRequest)
        {
           
            List<SignResponseModel> LstSignatureReponse = new List<SignResponseModel>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;           
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {
                    var url = Resource.ServiceURL+"GetBoothcardSummary";
                    // var url = Resource.BoothSummaryURL;
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = JsonConvert.SerializeObject(SignRequest);
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<SignResponseModel> ResultEstimate = JsonConvert.DeserializeObject<List<SignResponseModel>>(Result);
                        LstSignatureReponse = ResultEstimate;

                    }
                    else
                    {
                        LstSignatureReponse = null;
                    }
                }
                else
                {
                    LstSignatureReponse = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstSignatureReponse = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstSignatureReponse;
        }
    }
}
