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
   public class InvoicesPDFServices
    {
        /// <summary>
        ///  Method for Get Boothcard Report With Signature
        /// </summary>
        /// <param name="SignRequest"></param>
        /// <returns></returns>
        public async Task<List<InvoicePDFModel>> GetInvoiceReport(string JobNo,string ItemID)
        {

            List<InvoicePDFModel> LstInvoicePdfReponse = new List<InvoicePDFModel>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = Resource.ServiceURL+ "GetFinalInvoiceByItemId";
                    HttpClient client = new HttpClient();
                    
                    string serializedJsonRequest = "{\"JobNumber\":\""+ JobNo+"\", \"InvoiceItemId\":\"" + ItemID + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<InvoicePDFModel> ResultEstimate = JsonConvert.DeserializeObject<List<InvoicePDFModel>>(Result);
                        LstInvoicePdfReponse = ResultEstimate;

                    }
                    else
                    {
                        LstInvoicePdfReponse = null;
                    }
                }
                else
                {
                    LstInvoicePdfReponse = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstInvoicePdfReponse = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstInvoicePdfReponse;
        }
    }
}
