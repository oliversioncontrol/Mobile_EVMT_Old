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
  public  class EquipmentByJob
    {
        /// <summary>
        /// Method for Get Equipment Details through Job id
        /// </summary>
        /// <param name="EquipmentJob"></param>
        /// <returns></returns>
        public async Task<List<EquipmentModel>> GetEquipmentByJobNumber(string EquipmentJob)
        {
           // EquipmentJob = "50728";
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
                    string serializedJsonRequest ="{\"Method\":\"GetEquipmentByJobNumber\", \"JobNumber\":\""+ EquipmentJob + "\" }";
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


        /// <summary>
        /// Method for Get Booth Equipment Details through Job id
        /// </summary>
        /// <param name="EquipmentJob"></param>
        /// <returns></returns>
        public async Task<List<BoothEquipment>> GetBoothEquipmentByJobNumber(string EquipmentJob)
        {
            // EquipmentJob = "50728";
            List<BoothEquipment> LstEquipment = new List<BoothEquipment>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl + "OliDetails";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"Method\":\"GetBoothEquipmentByJobNumber\", \"JobNumber\":\"" + EquipmentJob + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<BoothEquipment> lstEquip = JsonConvert.DeserializeObject<List<BoothEquipment>>(result);
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
