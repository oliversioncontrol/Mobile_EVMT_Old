using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnLocationEVMT.Services
{
    class NewsEventsServices
    {
        /// <summary>
        /// Method For Get News Announcements
        /// </summary>
        public async Task<List<NewsAnnouncemetns>> GetNewsAnnouncement()
        {
            List<NewsAnnouncemetns> newsList = new List<NewsAnnouncemetns>();
            try
            {
               
                XDocument doc = XDocument.Load("http://onlocationind.com/feed/");

                foreach (var r in doc.Descendants("item"))
                {
                    NewsAnnouncemetns newObj = new NewsAnnouncemetns();
                    if (r.Element("title").Value.Length > 44)
                    {
                        newObj.title = r.Element("title").Value.Substring(0, 44) + "...";                        
                    }
                    else
                    {
                        newObj.title = r.Element("title").Value;
                    }
                    newObj.URL= r.Element("link").Value;
                    newObj.fulltitle = r.Element("title").Value;                   
                    string publishdate = r.Element("pubDate").Value;
                    DateTime myDate = new DateTime();
                    myDate = Convert.ToDateTime(publishdate);                    
                    string year =Convert.ToString(myDate.Year);
                    string month = myDate.ToString("MMM", CultureInfo.InvariantCulture);
                    string d = Convert.ToString(myDate.Day);
                    if(d.Length>1)
                    {
                        newObj.datepart = Convert.ToString(myDate.Day);
                    }
                    else
                    {
                        newObj.datepart="0"+ Convert.ToString(myDate.Day);
                    }                    
                    newObj.pubDate = month+", "+year;
                    if (r.Element("description").Value.Length > 66)
                    {
                        string desc = r.Element("description").Value.Substring(0, 66);
                        newObj.description = Regex.Replace(desc, "<.*?>", String.Empty) + "...";
                    }
                    else
                    {
                        newObj.description = Regex.Replace(r.Element("description").Value, "<.*?>", String.Empty);
                    }
                    newObj.fullDesc =string.Empty;
                    newsList.Add(newObj);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return newsList;
        }
    }
}