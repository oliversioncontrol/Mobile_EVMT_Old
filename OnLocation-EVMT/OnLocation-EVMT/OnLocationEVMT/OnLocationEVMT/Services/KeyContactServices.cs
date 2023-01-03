using Newtonsoft.Json;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Services
{
    class KeyContactServices
    {
        /// <summary>
        /// Method for Get Key Contacts Details
        /// </summary>
        /// <returns></returns>
        public async Task<List<KeyContactResponse>> GetClientDetails(int Index)
        {
            List<KeyContactResponse> lstkeycontact = new List<KeyContactResponse>();
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
                    string serializedJsonRequest = "{ \"Method\": \"GetKeyContacts\",\"Index\":\""+ Index + "\" }";
                    //string serializedJsonRequest = "{ \"Method\": \"GetKeyContacts\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var LoanDetails = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(LoanDetails);
                        List<KeyContactResponse> Result1 = JsonConvert.DeserializeObject<List<KeyContactResponse>>(Result);
                        lstkeycontact = Result1;

                    }
                    else
                    {
                        lstkeycontact = null;
                    }
                }
                else
                {
                    lstkeycontact = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                lstkeycontact = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return lstkeycontact;
        }
    }
}
