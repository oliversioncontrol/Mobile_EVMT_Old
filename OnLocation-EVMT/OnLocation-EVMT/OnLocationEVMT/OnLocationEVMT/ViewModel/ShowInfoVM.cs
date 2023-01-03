using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class ShowInfoVM : ObservableObject
    {
        Command CommandOpenMap;

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

        //*******************//\\**********************\\
        public string _JobNumber;
        /// <summary>
        /// Gets or Sets JobNumber
        /// </summary>
        public string JobNumber
        {
            get { return _JobNumber; }
            set
            {
                _JobNumber = value;
                OnPropertyChanged(nameof(JobNumber));
            }
        }

        public string _JobStatus;
        /// <summary>
        /// Gets or Sets JobStatus
        /// </summary>
        public string JobStatus
        {
            get { return _JobStatus; }
            set
            {
                _JobStatus = value;
                OnPropertyChanged(nameof(JobStatus));
            }
        }

        public string _ExhibitorName;
        /// <summary>
        /// Gets or Sets ExhibitorName
        /// </summary>
        public string ExhibitorName
        {
            get { return _ExhibitorName; }
            set
            {
                _ExhibitorName = value;
                OnPropertyChanged(nameof(ExhibitorName));
            }
        }

        public string _OrderBoothSize;
        /// <summary>
        /// Gets or Sets OrderBoothSize
        /// </summary>
        public string OrderBoothSize
        {
            get { return _OrderBoothSize; }
            set
            {
                _OrderBoothSize = value;
                OnPropertyChanged(nameof(OrderBoothSize));
            }
        }

        public string _Version;
        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
                OnPropertyChanged(nameof(Version));
            }
        }

        public string _ShowName;
        /// <summary>
        /// Gets or Sets ShowName
        /// </summary>
        public string ShowName
        {
            get { return _ShowName; }
            set
            {
                _ShowName = value;
                OnPropertyChanged(nameof(ShowName));
            }
        }

        public string _Venue;
        /// <summary>
        /// Get or Sets Venue
        /// </summary>
        public string Venue
        {
            get { return _Venue; }
            set
            {
                _Venue = value;
                OnPropertyChanged(nameof(Venue));
            }
        }

        public string _ShowCity;
        /// <summary>
        /// Get or Sets ShowCity
        /// </summary>
        public string ShowCity
        {
            get { return _ShowCity; }
            set
            {
                _ShowCity = value;
                OnPropertyChanged(nameof(ShowCity));
            }
        }

        public string _ShowState;
        /// <summary>
        /// Get or Sets ShowState
        /// </summary>
        public string ShowState
        {
            get { return _ShowState; }
            set
            {
                _ShowState = value;
                OnPropertyChanged(nameof(ShowState));
            }
        }

        public string _ShowOpenDate;
        /// <summary>
        /// Get or Sets ShowOpenDate
        /// </summary>
        public string ShowOpenDate
        {
            get { return _ShowOpenDate; }
            set
            {
                _ShowOpenDate = value;
                OnPropertyChanged(nameof(ShowOpenDate));
            }
        }

        public string _ShowCloseDate;
        /// <summary>
        /// Get or Sets ShowCloseDate
        /// </summary>
        public string ShowCloseDate
        {
            get { return _ShowCloseDate; }
            set
            {
                _ShowCloseDate = value;
                OnPropertyChanged(nameof(ShowCloseDate));
            }
        }

        public string _ShortName;
        /// <summary>
        /// Get or Sets ShortName
        /// </summary>
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                _ShortName = value;
                OnPropertyChanged(nameof(ShortName));
            }
        }
        public string _EACDueDate;
        /// <summary>
        /// Get or Sets EACDueDate
        /// </summary>
        public string EACDueDate
        {
            get { return _EACDueDate; }
            set
            {
                _EACDueDate = value;
                OnPropertyChanged(nameof(EACDueDate));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ShowInfoVM()
        {
            GetShowInfo();
        }

        /// <summary>
        /// Method for Get Show Info
        /// </summary>
        public async void GetShowInfo()
        {
            IsBusy = true;
            await GetShowInfoDetails();
            IsBusy = false;
        }

        /// <summary>
        /// Method for GetProjectList
        /// </summary>
        /// <returns></returns>
        public async Task GetShowInfoDetails()
        {
            List<ShowInfoResponse> ShowInfoList = new List<ShowInfoResponse>();
            ShowInfoServices ServiceProvider = new ShowInfoServices();
            try
            {
                ShowInfoList = await ServiceProvider.GetShowInfoDetails(Resource.MethodGetProjectDetails, Views.ShowInformation.JobNumber);
                IsBusy = false;
                if (ShowInfoList != null && ShowInfoList.Count != 0)
                {
                    if (ShowInfoList[0].JobNumber != null)
                    {
                        JobNumber = ShowInfoList[0].JobNumber;
                    }
                    if (ShowInfoList[0].Version != null)
                    {
                        JobNumber = JobNumber + ", Version " + ShowInfoList[0].Version;
                    }
                    if (ShowInfoList[0].ExhibitorName != null)
                    {
                        ExhibitorName = ShowInfoList[0].ExhibitorName;
                    }
                    if (ShowInfoList[0].OrderBoothSize != null)
                    {
                        OrderBoothSize = "Booth Size " + ShowInfoList[0].OrderBoothSize;
                    }
                    if (ShowInfoList[0].ShowName != null)
                    {
                        ShowName = ShowInfoList[0].ShowName;
                    }
                    if (ShowInfoList[0].Venue != null)
                    {
                        Venue = ShowInfoList[0].Venue;
                    }
                    if (ShowInfoList[0].ShowCity != null)
                    {
                        ShowCity = ShowInfoList[0].ShowCity;
                    }
                    if (ShowInfoList[0].ShowState != null)
                    {
                        ShowCity = ShowCity + "," + ShowInfoList[0].ShowState;
                    }
                    if (ShowInfoList[0].ShowState != null)
                    {
                        ShowState = ShowInfoList[0].ShowCity;
                    }

                    if (ShowInfoList[0].ShowOpenDate != null)
                    {
                        DateTime objOpenDate = new DateTime();
                        objOpenDate = Convert.ToDateTime(ShowInfoList[0].ShowOpenDate);
                        string CheckTime= objOpenDate.ToString(Resource.TimeFormat);
                        ShowOpenDate = CheckTime== Resource.DefaultTimeFormat? objOpenDate.ToString(Resource.DateFormat): objOpenDate.ToString(Resource.DateFormatWithTime);
                    }
                    if (ShowInfoList[0].ShowCloseDate != null)
                    {
                        DateTime objCloseDate = new DateTime();
                        objCloseDate = Convert.ToDateTime(ShowInfoList[0].ShowCloseDate);
                        string CheckCloseTime = objCloseDate.ToString(Resource.TimeFormat);
                        ShowCloseDate = CheckCloseTime == Resource.DefaultTimeFormat ? objCloseDate.ToString(Resource.DateFormat): objCloseDate.ToString(Resource.DateFormatWithTime);
                    }
                    if (ShowInfoList[0].ShortName != null)
                    {
                        ShortName = ShowInfoList[0].ShortName;
                    }
                    if (ShowInfoList[0].EACDueDate != null)
                    {
                        EACDueDate = ShowInfoList[0].EACDueDate;
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.StackTrace);
            }
        }

        

        /// <summary>
        /// Open commandYourPic events
        /// </summary>
        public Command CommandOpenMapEvents
        {
            get
            {
                if (CommandOpenMap == null)
                    CommandOpenMap = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (Device.RuntimePlatform == Device.Android)
                                {                                    
                                    var uri = new Uri("http://maps.google.com/maps?q=" + Venue + "," + ShowState);
                                   
                                    Device.OpenUri(uri);
                                }
                                else
                                {
                                    var uri = new Uri("http://maps.apple.com/?daddr=" + Venue + "+," + ShowState + "&saddr=520+Fellowship+Road+Suite+A112+Mt+Laurel+NJ+08054");
                                    Device.OpenUri(uri);
                                }
                            }
                            IsClicked = true;
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandOpenMap;
            }
        }
    }
}
