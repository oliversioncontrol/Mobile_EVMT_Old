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
  public  class TaskServices
    {
        /// <summary>
        /// Method for Get Tasks
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tasks>> GetTasks()
        {
            List<Tasks> LstTasks = new List<Tasks>();
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
                    string serializedJsonRequest = "{ \"Method\": \"GetTasks\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<Tasks> ResultEstimate = JsonConvert.DeserializeObject<List<Tasks>>(Result);
                        LstTasks = ResultEstimate;
                    }
                    else
                    {
                        LstTasks = null;
                    }
                }
                else
                {
                    LstTasks = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstTasks = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstTasks;
        }
    }
}
