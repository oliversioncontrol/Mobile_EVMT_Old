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
  public class MaterialServices
    {
        /// <summary>
        /// Method for Get Booth Materials
        /// </summary>
        /// <param name="BoothcardID"></param>
        /// <returns></returns>
        public async Task<List<MaterialModel>> GetBoothMaterials(string BoothcardID)
        {
            //BoothcardID = "29806";
            List<MaterialModel> lstMaterial = new List<MaterialModel>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothMaterials\", \"BoothcardId\":\"" + BoothcardID + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<MaterialModel> lstMate = JsonConvert.DeserializeObject<List<MaterialModel>>(result);
                        lstMaterial = lstMate;

                    }
                    else
                    {
                        lstMaterial = null;
                    }
                }
                else
                {
                    lstMaterial = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lstMaterial = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lstMaterial;
        }
    }
}
