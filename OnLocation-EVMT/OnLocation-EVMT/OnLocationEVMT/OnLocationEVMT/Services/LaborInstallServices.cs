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
   public class LaborInstallServices
    {
        /// <summary>
        /// Method for Get Estimated
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="Jobnumber"></param>
        /// <param name="ServiceType"></param>
        /// <returns></returns>
        public async Task<List<LaborInstall>> GetLaborInstall(string Method, string Jobnumber,string ServiceType)
        {
            List<LaborInstall> LstLaborInstall = new List<LaborInstall>();
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
                    string serializedJsonRequest = "{\"Method\":\""+Method+"\", \"JobNumber\":\""+Jobnumber+"\", \"Service\":\""+ ServiceType + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<LaborInstall> ResultLaborInstall = JsonConvert.DeserializeObject<List<LaborInstall>>(Result);
                        LstLaborInstall = ResultLaborInstall;
                    }
                    else
                    {
                        LstLaborInstall = null;
                    }
                }
                else
                {
                    LstLaborInstall = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstLaborInstall = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstLaborInstall;
        }
    }
}
