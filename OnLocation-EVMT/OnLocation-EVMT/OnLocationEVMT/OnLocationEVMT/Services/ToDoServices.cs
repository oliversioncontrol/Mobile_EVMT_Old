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
  public  class ToDoServices
    {
        /// <summary>
        /// Method For Get TO Do Notes
        /// </summary>
        /// <param name="Jobnumber"></param>
        /// <returns></returns>
        public async Task<List<ToDoNote>> GetToDo(string Jobnumber)
        {            
            List<ToDoNote> LstToDoNotes = new List<ToDoNote>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {
                   // Jobnumber = "44823";
                    var url = ServiceUrl+ "OliDetails";
                    HttpClient client = new HttpClient();
                    string serializedJsonRequest = "{\"Method\":\"GetProjectToDos\", \"JobNumber\":\"" + Jobnumber + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var EstimateDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(EstimateDetails);
                        List<ToDoNote> ResultEstimate = JsonConvert.DeserializeObject<List<ToDoNote>>(Result);
                        LstToDoNotes = ResultEstimate;

                    }
                    else
                    {
                        LstToDoNotes = null;
                    }
                }
                else
                {
                    LstToDoNotes = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstToDoNotes = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstToDoNotes;
        }
    }
}
