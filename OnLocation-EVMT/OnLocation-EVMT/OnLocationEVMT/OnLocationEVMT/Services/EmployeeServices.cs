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
   public class EmployeeServices
    {
        /// <summary>
        /// Method for Get Employee
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeModel>> GetEmployee()
        {          
            List<EmployeeModel> LstEmployee = new List<EmployeeModel>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetBoothEmployees\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<EmployeeModel> ResultEstimate = JsonConvert.DeserializeObject<List<EmployeeModel>>(Result);
                        LstEmployee = ResultEstimate;
                    }
                    else
                    {
                        LstEmployee = null;
                    }
                }
                else
                {
                    LstEmployee = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstEmployee = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstEmployee;
        }
    }
}
