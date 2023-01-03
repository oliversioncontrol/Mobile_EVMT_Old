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
   public class ShippingServices
    {
        /// <summary>
        /// Method for Get Shipping Details
        /// </summary>
        /// <param name="JobNumber"></param>
        /// <returns></returns>
        public async Task<List<ShippingModel>> GetShippingDetails(string JobNumber)
        {
            //JobNumber = "51414";
            List<ShippingModel> LstShipping = new List<ShippingModel>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetProjectShippingDetails\", \"JobNumber\":\"" + JobNumber + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<ShippingModel> Result1 = JsonConvert.DeserializeObject<List<ShippingModel>>(Result);
                        LstShipping = Result1;

                    }
                    else
                    {
                        LstShipping = null;
                    }
                }
                else
                {
                    LstShipping = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstShipping = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstShipping;
        }
    }
}
