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
    /// <summary>
    /// Class Implementation
    /// </summary>
    public class IsMgrORLeadManServices
    {
        /// <summary>
        /// Method for Get Check IsBoothcardMgr
        /// </summary>
        /// <param name="ProjectID"></param>  
        /// <returns></returns>
        public async Task<bool> IsBoothcardMgr(string ProjectID)
        {
            bool ResponseResult = false;
            List<IsMgrORLead> IsMgr = new List<IsMgrORLead>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL + "OliDetails";
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl;
                    HttpClient client = new HttpClient();
                   // string serializedJsonRequest = "{\"Method\":\"IsBoothcardLeadman\", \"UserName\":\"Oliuser01\", \"JobNumber\":\"52345\" }";
                    string serializedJsonRequest = "{\"Method\":\"IsBoothcardMgr\", \"UserName\":\""+UserAccounts.LoginUserID+"\", \"JobNumber\":\""+ ProjectID + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var ReadResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(ReadResponse);
                        List<IsMgrORLead> ResultEstimate = JsonConvert.DeserializeObject<List<IsMgrORLead>>(Result);
                        if(ResultEstimate[0].ReturnValue=="T")
                        {
                            ResponseResult = true;
                        }
                        else
                        {
                            ResponseResult = false;
                        }
                        //LstBoothcard = ResultEstimate;

                    }
                    else
                    {
                        ResponseResult = false; ;
                    }
                }
                else
                {
                    ResponseResult = false; ;
                    await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                }

            }
            catch (Exception ex)
            {
                ResponseResult = false; 
                Debug.WriteLine(ex.StackTrace);
            }
            return ResponseResult;
        }

        /// <summary>
        /// Method for Check IsBoothcardLeadman
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public async Task<bool> IsBoothcardLeadman(string ProjectID)
        {
            bool ResponseResult = false;
            List<IsMgrORLead> IsMgr = new List<IsMgrORLead>();
            IsConneciton.IsConnection = true;
            string strResponseMsg = string.Empty;
            string ServiceUrl = Resource.ServiceURL + "OliDetails";
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {

                    var url = ServiceUrl;
                    HttpClient client = new HttpClient();                    
                    string serializedJsonRequest = "{\"Method\":\"IsBoothcardLeadman\", \"UserName\":\"" + UserAccounts.LoginUserID + "\", \"JobNumber\":\"" + ProjectID + "\" }";
                    var content = new StringContent(JsonConvert.SerializeObject(serializedJsonRequest), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(url), content);
                    var ReadResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        string Result = JsonConvert.DeserializeObject<string>(ReadResponse);
                        List<IsMgrORLead> ResultEstimate = JsonConvert.DeserializeObject<List<IsMgrORLead>>(Result);
                        if (ResultEstimate[0].ReturnValue == "T")
                        {
                            ResponseResult = true;
                        }
                        else
                        {
                            ResponseResult = false;
                        }                       
                    }
                    else
                    {
                        ResponseResult = false; ;
                    }
                }
                else
                {
                    ResponseResult = false; ;
                    await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                }

            }
            catch (Exception ex)
            {
                ResponseResult = false;
                Debug.WriteLine(ex.StackTrace);
            }
            return ResponseResult;
        }
    }

    /// <summary>
    /// Class ISMgrORLead
    /// </summary>
    public class IsMgrORLead
    {
        public string ReturnValue { get; set; }
    }
}
