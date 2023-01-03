using Newtonsoft.Json;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Services
{
   public class EmployeeAccoladesService
    {
        public async Task<EmpAccol> GetEmpAccolades(int Startpage)
        {
            EmpAccol LstEmpAccolades = new EmpAccol();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = null;
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {


                    HttpClient client = new HttpClient();
                    //client.DefaultRequestHeaders.Add("Accept-Language", Constants.SelectedLanguage);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    //string authData = Constants.AccessToken;
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", authData);
                    var RestUrl = "https://api.awardco.com/api/social-feed";
                    var Uri = new Uri(RestUrl);
                    var dict = new Dictionary<string, string>();
                    dict.Add("apiKey", "e1bb5e3534294b38becf295f5b1abf54");
                    dict.Add("page", Convert.ToString(Startpage));
                    dict.Add("limit",  "20");
                    var content = new FormUrlEncodedContent(dict);
                    HttpResponseMessage response = await client.PostAsync(Uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();                       
                        EmpAccol result = JsonConvert.DeserializeObject<EmpAccol>(resp);
                        LstEmpAccolades = result;
                                             
                    }
                    else
                    {
                        LstEmpAccolades = null;
                    }
                }
                else
                {
                    LstEmpAccolades = null;
                    IsConneciton.IsConnection = false;
                }

            }
            catch (Exception ex)
            {
                LstEmpAccolades = null;
                Debug.WriteLine(ex.StackTrace);
            }
            return LstEmpAccolades;
        }
    }
}
