using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class NewAndEventsVM : ObservableObject
    {

        Command CommandNewsDetails;
        public List<NewAndEvents> lstNewsAndEvents{get;set;}
        public ObservableRangeCollection<NewsAnnouncemetns> lstNewsAnnouncement { get; set; }

        bool _IsBusy;
        /// <summary>
        /// Gets or sets the IsBusy.
        /// </summary>
        /// <value>The _IsBusy.</value>
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        public bool _IsClicked;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public bool IsClicked
        {
            get { return _IsClicked; }
            set
            {
                _IsClicked = value;
                OnPropertyChanged(nameof(IsClicked));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NewAndEventsVM()
        {
            lstNewsAnnouncement = new ObservableRangeCollection<NewsAnnouncemetns>();            
            lstNewsAndEvents = new List<NewAndEvents>();            
            GetNews();
        }

        /// <summary>
        /// Method for Get News
        /// </summary>
        public async void GetNews()
        {
            try
            {
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {
                    IsBusy = true;
                    await GetNewsAndEvents();
                    IsBusy = false;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method for get New Announcements
        /// </summary>
        public async Task GetNewsAndEvents()
        {            
            NewsEventsServices obj = new NewsEventsServices();
            try
            {                
                List<NewsAnnouncemetns> lstnews = new List<NewsAnnouncemetns>();
                List<NewsAnnouncemetns> lstNewswithCommand = new List<NewsAnnouncemetns>();
                lstnews = await obj.GetNewsAnnouncement();
                foreach (var item in lstnews)
                {
                    NewsAnnouncemetns NewsAnno = new NewsAnnouncemetns();
                    NewsAnno.NewsDetails= NewsDetailCommand;
                    NewsAnno.title = item.title;
                    NewsAnno.description = item.description;
                    NewsAnno.datepart = item.datepart;
                    NewsAnno.pubDate = item.pubDate;
                    NewsAnno.URL = item.URL;
                    lstNewswithCommand.Add(NewsAnno);                    
                }
                lstNewsAnnouncement.AddRange(lstNewswithCommand);               
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
        /// <summary>
        /// Command News Details
        /// </summary>

        public Command NewsDetailCommand
        {
            get
            {
                if (CommandNewsDetails == null)
                    CommandNewsDetails = new Command((req) =>
                    {
                        try
                        {

                            if (!string.IsNullOrEmpty(Convert.ToString(req)))
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;                                   
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.NewsReadMore(Convert.ToString(req)));
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }

                    });
                return CommandNewsDetails;
            }
        }

    }
}
