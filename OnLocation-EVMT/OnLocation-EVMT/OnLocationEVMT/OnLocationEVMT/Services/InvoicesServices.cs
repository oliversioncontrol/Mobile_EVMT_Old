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
   public class InvoicesServices
    {

        /// <summary>
        /// Method for Get Invoice Details
        /// </summary>
        /// <param name="Jobnumber"></param>
        /// <returns></returns>
        public async Task<List<InvoiceModel>> GetInvoices(string Jobnumber)
        {
           // Jobnumber = "49969";
            List<InvoiceModel> LstInvoices = new List<InvoiceModel>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL+ "GetFinalInvoiceList";
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl;
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"JobNumber\":\""+ Jobnumber + "\"}";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<InvoiceModel> ResultEstimate = JsonConvert.DeserializeObject<List<InvoiceModel>>(Result);
                        LstInvoices = ResultEstimate;

                    }
                    else
                    {
                        LstInvoices = null;
                    }
                }
                else
                {
                    LstInvoices = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstInvoices = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstInvoices;
        }
    }
}
