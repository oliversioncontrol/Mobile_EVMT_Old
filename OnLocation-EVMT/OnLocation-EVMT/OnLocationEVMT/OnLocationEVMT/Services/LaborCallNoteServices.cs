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
    public class LaborCallNoteServices
    {
        /// <summary>
        /// Method for Get Labor Call Note
        /// </summary>
        /// <param name="JobNo"></param>
        /// <returns></returns>
        public async Task<List<LaborCallModels>> GetLaborCallNote(string JobNo)
        {           
            List<LaborCallModels> LaborCallNotes = new List<LaborCallModels>();
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
                    string serializedJsonRequest = "{\"Method\":\"GetLaborCallNotes\", \"JobNumber\":\"" + JobNo + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<LaborCallModels> Result1 = JsonConvert.DeserializeObject<List<LaborCallModels>>(Result);
                        LaborCallNotes = Result1;

                    }
                    else
                    {
                        LaborCallNotes = null;
                    }
                }
                else
                {
                    LaborCallNotes = null;
                    IsConneciton.IsConnection = false;
                }
            }
            catch (Exception ex)
            {
                LaborCallNotes = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LaborCallNotes;
        }
    }
}
