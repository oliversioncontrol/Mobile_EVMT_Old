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
   public class MaterialExtrasServices
    {
        /// <summary>
        /// Method for Get Material and Extras
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="Jobnumber"></param>
        /// <returns></returns>
        public async Task<List<MaterialExtras>> GetMaterialExtras(string Method, string Jobnumber)
        {
            List<MaterialExtras> LstMaterial = new List<MaterialExtras>();
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
                    string serializedJsonRequest = "{\"Method\":\"" + Method + "\", \"JobNumber\":\"" + Jobnumber + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<MaterialExtras> ResultLaborInstall = JsonConvert.DeserializeObject<List<MaterialExtras>>(Result);
                        LstMaterial = ResultLaborInstall;
                    }
                    else
                    {
                        LstMaterial = null;
                    }
                }
                else
                {
                    LstMaterial = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstMaterial = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstMaterial;
        }
    }
}
