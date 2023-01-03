using Newtonsoft.Json;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Services
{
    public class EquipmentServices
    {
        /// <summary>
        /// Method for Get Equipment Details
        /// </summary>
        /// <param name="BoothcardID"></param>
        /// <returns></returns>
        public async Task<List<EquipmentModel>> GetBoothEquipment(string BoothcardID)
        {
            //BoothcardID = "29806";
            List<EquipmentModel> LstEquipment = new List<EquipmentModel>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothEquipment\", \"BoothcardId\":\""+BoothcardID+"\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<EquipmentModel> lstEquip = JsonConvert.DeserializeObject<List<EquipmentModel>>(result);
                        LstEquipment = lstEquip;

                    }
                    else
                    {
                        LstEquipment = null;
                    }
                }
                else
                {
                    LstEquipment = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstEquipment = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstEquipment;
        }
    }
}
