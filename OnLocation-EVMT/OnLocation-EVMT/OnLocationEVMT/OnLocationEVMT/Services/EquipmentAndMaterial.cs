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
  public  class EquipmentAndMaterial
    {
        /// <summary>
        /// Get Equipment list
        /// </summary>
        /// <returns></returns>
        public async Task<List<EquipmentResponse>> GetEquipment()
        {
            List<EquipmentResponse> lstEquipmentlist = new List<EquipmentResponse>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothEquipment-All\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var responseresult = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(responseresult);
                        List<EquipmentResponse> ResultEstimate = JsonConvert.DeserializeObject<List<EquipmentResponse>>(Result);
                        lstEquipmentlist = ResultEstimate;
                    }
                    else
                    {
                        lstEquipmentlist = null;
                    }
                }
                else
                {
                    lstEquipmentlist = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lstEquipmentlist = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lstEquipmentlist;
        }

        /// <summary>
        /// Get Material list
        /// </summary>
        /// <returns></returns>
        public async Task<List<MaterialResponse>> GetMaterial()
        {
            List<MaterialResponse> lstMateriallist = new List<MaterialResponse>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothMaterials-All\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var responseresult = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(responseresult);
                        List<MaterialResponse> ResultEstimate = JsonConvert.DeserializeObject<List<MaterialResponse>>(Result);
                        lstMateriallist = ResultEstimate;
                    }
                    else
                    {
                        lstMateriallist = null;
                    }
                }
                else
                {
                    lstMateriallist = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lstMateriallist = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lstMateriallist;
        }
    }
}
