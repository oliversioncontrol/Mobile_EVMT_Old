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
  public  class ActiveMenuServices
    {
       /// <summary>
       /// Method For Active Job Number
       /// </summary>
       /// <param name="ActiveJobNumber"></param>
       /// <returns></returns>
        public async Task<List<ActiveMenu>> ActivateMenu(string ActiveJobNumber)
        {
            // EquipmentJob = "50728";
            List<ActiveMenu> LstActive = new List<ActiveMenu>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl + "GetArrowToggles";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"JobNumber\":\""+ ActiveJobNumber + "\"}";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<ActiveMenu> lstEquip = JsonConvert.DeserializeObject<List<ActiveMenu>>(result);
                        LstActive = lstEquip;

                    }
                    else
                    {
                        LstActive = null;
                    }
                }
                else
                {
                    LstActive = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstActive = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstActive;
        }
    }
}
