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
  public  class OrderInfoServices
    {
        /// <summary>
        ///  Method for Get Order Info
        /// </summary>
        /// <param name="Jobnumber"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoModel>> GetOrderInfo(string Jobnumber)
        {
            List<OrderInfoModel> LstOrderInfo = new List<OrderInfoModel>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetProjectDetails\", \"JobNumber\":\""+Jobnumber+"\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<OrderInfoModel> ResultOrderInfo = JsonConvert.DeserializeObject<List<OrderInfoModel>>(Result);
                        LstOrderInfo = ResultOrderInfo;
                    }
                    else
                    {
                        LstOrderInfo = null;
                    }
                }
                else
                {
                    LstOrderInfo = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstOrderInfo = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstOrderInfo;
        }
    }
}
