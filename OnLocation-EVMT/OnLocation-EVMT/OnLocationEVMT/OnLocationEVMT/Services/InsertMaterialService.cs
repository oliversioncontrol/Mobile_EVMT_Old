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
  public  class InsertMaterialService
    {
        /// <summary>
        /// Method for Insert New Material
        /// </summary>
        /// <param name="MaterialModel"></param>
        /// <returns></returns>
        public async Task<string> InsertEquipment(InstMaterialModel MaterialModel)
        {
            IsConneciton.IsConnection = true;
            string Result = string.Empty;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {
                    var url = ServiceUrl+ "PutOliData";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = JsonConvert.SerializeObject(MaterialModel);
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                    }
                }
                else
                {
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return Result;
        }
    }
}
