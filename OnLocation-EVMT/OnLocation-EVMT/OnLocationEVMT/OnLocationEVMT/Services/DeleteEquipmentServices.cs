using Newtonsoft.Json;
using OnLocationEVMT.Helpers;
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
   public class DeleteEquipmentServices
    {
        /// <summary>
        /// Method for Delete Equipment
        /// </summary>
        /// <param name="EquipmentId"></param>
        /// <returns></returns>
        public async Task<string> DeleteBoothEquipmentById(string EquipmentId)
        {

            string Result = string.Empty;
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl+ "PutOliData";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"Method\":\"DeleteBoothEquipmentById\",\"EquipmentId\":" + EquipmentId + "}";
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
                    Result = string.Empty;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                Result = string.Empty;
                Debug.WriteLine(ex.StackTrace);
            }
            return Result;

        }
    }
}
