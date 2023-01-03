using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class BoothCardVM : ObservableObject
    {
        public ObservableRangeCollection<BoothCardModel> LstSearchList { get; set; }
        private Command CommandSearch;
        private Command CommandAddBooth;
        private Command CommandSearchData;
        private Command CommandResetData;
        private Command CommandBoothCard;
        int CurPage { get; set; }
        private DateTime _startDate;
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        // To Refresh List - Pull To Refresh
        Command _refreshCommand;
        /// <summary>
        /// Gets the refresh command.
        /// </summary>
        /// <value>The refresh command.</value>
        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand;
            }
        }

        private DateTime _endDate;
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private string _WorkstartDate;
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string WorkStartDate
        {
            get { return _WorkstartDate; }
            set
            {
                _WorkstartDate = value;
                OnPropertyChanged(nameof(WorkStartDate));
            }
        }


        private string _WorkendDate;
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public string WorkEndDate
        {
            get { return _WorkendDate; }
            set
            {
                _WorkendDate = value;
                OnPropertyChanged(nameof(WorkEndDate));
            }
        }

        private string _SearchKey;
        /// <summary>
        /// / Gets or sets Search Keywords.
        /// </summary>
        public string SearchKey
        {
            get { return _SearchKey; }
            set { _SearchKey = value;
                OnPropertyChanged(nameof(SearchKey));
            }
        }


        private string _SearchImg;
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public string SearchImg
        {
            get { return _SearchImg; }
            set
            {
                _SearchImg = value;
                OnPropertyChanged(nameof(SearchImg));
            }
        }
       private bool _IsBusy;
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


        private bool _IsBusyPull;
        /// <summary>
        /// Gets or sets the IsBusy.
        /// </summary>
        /// <value>The _IsBusy.</value>
        public bool IsBusyPull
        {
            get { return _IsBusyPull; }
            set
            {
                _IsBusyPull = value;
                OnPropertyChanged(nameof(IsBusyPull));
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
        public bool _IsSearch;
        /// <summary>
        /// Gets or Sets IsSearch
        /// </summary>
        public bool IsSearch
        {
            get { return _IsSearch; }
            set
            {
                _IsSearch = value;
                OnPropertyChanged(nameof(IsSearch));
            }
        }

        public bool _IsSearchArea;
        /// <summary>
        /// Gets or Sets IsSearchArea
        /// </summary>
        public bool IsSearchArea
        {
            get { return _IsSearchArea; }
            set
            {
                _IsSearchArea = value;
                OnPropertyChanged(nameof(IsSearchArea));
            }
        }
        int ID = 0;
        /// <summary>
        /// Constructor
        /// </summary>
        public BoothCardVM()
        {
            WorkStartDate = DateTime.Now.AddDays(-29).ToString(Resource.DateFormatOpp);
            WorkEndDate = DateTime.Now.AddDays(2).ToString(Resource.DateFormatOpp);

            SearchImg = Resource.SearchIcon;
            _refreshCommand = new Command(RefreshList);
            LstSearchList = new ObservableRangeCollection<BoothCardModel>();
            IsSearch = true;
            CurPage = 1;
            Get(true,1);            
        }


        /// <summary>
        /// Refreshs the list.
        /// </summary>
        public async void RefreshList()
        {
            try
            {
                if (IsClicked)
                {
                    IsClicked = false;
                    IsBusyPull = true;
                    SearchKey = string.Empty;
                    SearchImg = Resource.SearchIcon;
                    await PullToRefreshCardDetails(true);
                    IsBusyPull = false;
                    IsClicked = true;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            

        }



        /// <summary>
        /// Open CommandSearch Events 
        /// </summary>
        public Command CommandSearchEvents
        {
            get
            {
                if (CommandSearch == null)
                    CommandSearch = new Command((req) =>
                    {
                        try
                        {                           
                            if (IsSearchArea)
                            {
                                IsSearchArea = false;
                            }
                            else
                            {
                                IsSearchArea = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandSearch;
            }
        }

        /// <summary>
        /// Open CommandAdd Events
        /// </summary>
        public Command CommandAddEvents
        {
            get
            {
                if (CommandAddBooth == null)
                    CommandAddBooth = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;                               
                                 App.Current.MainPage.Navigation.PushModalAsync(new Views.CreateNewBooth());
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandAddBooth;
            }
        }



        /// <summary>
        /// Open Command Boothcard Details Events
        /// </summary>
        public Command CommandBoothcardEvents
        {
            get
            {
                if (CommandBoothCard == null)
                    CommandBoothCard = new Command((req) =>
                    {
                        try
                        {
                            if (req != null)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    BoothCardModel DTO = req as BoothCardModel;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.BoothCardDetails(DTO));
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandBoothCard;
            }
        }



        private Command CommandOverview;
        /// <summary>
        /// Open Command Project Overview screen.
        /// </summary>
        public Command CommandOverviewEvents
        {
            get
            {
                if (CommandOverview == null)
                    CommandOverview = new Command((req) =>
                    {
                        try
                        {
                            if (req != null)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    BoothCardModel DTO = req as BoothCardModel;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.ProjectOverview(DTO));
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandOverview;
            }
        }


        public Command CommandSearchDataEvents
        {
            get
            {
                if (CommandSearchData == null)
                    CommandSearchData = new Command((req) =>
                    {
                        try
                        {
                            IsClicked = false;
                            IsSearchArea = false;                           
                            bool result = ValidateEndDate(WorkStartDate, WorkEndDate);
                           
                            if (result)
                            {
                                if (SearchImg == Resource.SearchIcon)
                                {
                                    SearchImg = Resource.FilterIcon;
                                }
                                CurPage = 1;
                                Get(false,0);
                            }
                            IsClicked = true;
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandSearchData;
            }
        }

        public Command CommandResetDataEvents
        {
            get
            {
                if (CommandResetData == null)
                    CommandResetData = new Command((req) =>
                    {
                        try
                        {
                            IsClicked = false;
                            IsSearchArea = false;
                            SearchKey = string.Empty;
                            if (SearchImg == Resource.FilterIcon)
                            {
                                SearchImg = Resource.SearchIcon;
                                StartDate = DateTime.Now.AddDays(-29);
                                EndDate = DateTime.Now.AddDays(2);
                                WorkStartDate = StartDate.ToString(Resource.DateFormatOpp);
                                WorkEndDate = EndDate.ToString(Resource.DateFormatOpp);
                                CurPage = 1;
                                Get(false,0);
                            }
                            IsClicked = true;
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandResetData;
            }
        }

        public async void Get(bool IsFilter, int type)
        {           
            IsBusy = true;
            await GetBoothCardDetails(IsFilter, type);
            IsBusy = false;
            IsClicked = true;
        }


        /// <summary>
        /// Method For Get OrderInfo
        /// </summary>
        /// <returns></returns>
        public async Task GetBoothCardDetails(bool IsFilter,int SearchORNot)
        {

            List<BoothCardResponse> LstBoothcard = new List<BoothCardResponse>();
            BoothcardServices ServiceProviderShow = new BoothcardServices();
            try
            {
                if(SearchKey=="")
                {
                    SearchKey = null;
                }
                LstBoothcard = await ServiceProviderShow.GetBoothcards(WorkStartDate,WorkEndDate, SearchKey, CurPage);
                if (SearchORNot == 0)
                {
                    LstSearchList.Clear();
                }
                if (LstBoothcard != null)
                {
                    if (LstBoothcard.Count > 0)
                    {
                       
                        foreach (var item in LstBoothcard)
                        {
                            BoothCardModel ObjBooth = new BoothCardModel();
                            ObjBooth.Boothcard = item.BoothcardId;
                            ObjBooth.IsBoothcardSigned = item.IsBoothcardSigned;
                            ObjBooth.Notes = item.Note;
                            if (!string.IsNullOrEmpty(item.WorkDate))
                            {
                                DateTime obj = new DateTime();
                                obj = Convert.ToDateTime(item.WorkDate);
                                string WorkDate = obj.ToString(Resource.DateFormat);
                                if (WorkDate != Resource.BlankDate)
                                {
                                    ObjBooth.WorkDate = obj.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.WorkDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.WorkDate = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ProjectNum))
                            {
                                ObjBooth.Project = item.ProjectNum;
                            }
                            else
                            {
                                ObjBooth.Project = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.Exhibitor))
                            {
                                ObjBooth.Exhibitor = item.Exhibitor;
                            }
                            else
                            {
                                ObjBooth.Exhibitor = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ShowName))
                            {
                                ObjBooth.Show = item.ShowName;
                            }
                            else
                            {
                                ObjBooth.Show = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ShowCity))
                            {
                                ObjBooth.Citys = item.ShowCity;
                            }
                            else
                            {
                                ObjBooth.Citys = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.BoothNum))
                            {
                                ObjBooth.Booth = item.BoothNum;
                            }
                            else
                            {
                                ObjBooth.Booth = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.AccountExec))
                            {
                                ObjBooth.AccountExec = item.AccountExec;
                            }
                            else
                            {
                                ObjBooth.AccountExec = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.SubmittedByDisplayName))
                            {
                                ObjBooth.Submittedby = item.SubmittedByDisplayName;
                            }
                            else
                            {
                                ObjBooth.Submittedby = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.PreparedByDisplayName))
                            {
                                ObjBooth.Preparedby = item.PreparedByDisplayName;
                            }
                            else
                            {
                                ObjBooth.Preparedby = Resource.NA;
                            }
                           
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedByDisplayName))
                            {
                                ObjBooth.ReviewSubmittedByDisplayName = item.ReviewSubmittedByDisplayName;
                            }
                            else
                            {
                                ObjBooth.ReviewSubmittedByDisplayName = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedDate))
                            {
                                ObjBooth.ReviewColor = Color.Transparent;
                                DateTime objReviewDate = new DateTime();
                                objReviewDate = Convert.ToDateTime(item.ReviewSubmittedDate);
                                string SubmitDate = objReviewDate.ToString(Resource.DateFormat);
                                if (SubmitDate != Resource.BlankDate)
                                {
                                    ObjBooth.ReviewSubmittedDate = objReviewDate.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.ReviewColor = Color.Yellow;
                                    ObjBooth.ReviewSubmittedDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.ReviewColor = Color.Yellow;
                                ObjBooth.ReviewSubmittedDate = Resource.NA;
                            }

                            if (!string.IsNullOrEmpty(item.DateSubmitted))
                            {
                                ObjBooth.ReviewColor = Color.Transparent;
                                ObjBooth.SubmittedColor = Color.Transparent;
                                DateTime obj = new DateTime();
                                obj = Convert.ToDateTime(item.DateSubmitted);
                                string SubmitDate = obj.ToString(Resource.DateFormat);
                                if (SubmitDate != Resource.BlankDate)
                                {
                                    ObjBooth.SubmittedDate = obj.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.SubmittedColor = Color.Yellow;
                                    ObjBooth.SubmittedDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.SubmittedColor = Color.Yellow;
                                ObjBooth.SubmittedDate = Resource.NA;
                            }

                            if (!string.IsNullOrEmpty(item.CreatedDate))
                            {
                                DateTime objCreateDate = new DateTime();
                                objCreateDate = Convert.ToDateTime(item.CreatedDate);
                                string CreateDate = objCreateDate.ToString(Resource.DateFormat);
                                if (CreateDate != Resource.BlankDate)
                                {
                                    ObjBooth.CreateDate = objCreateDate.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.CreateDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.CreateDate = Resource.NA;
                            }
                            ObjBooth.SupervisorName = item.SupervisorName;
                            ObjBooth.SupervisorPresent = item.SupervisorPresent;
                            ObjBooth.CommandBoothcard = CommandBoothcardEvents;
                            ObjBooth.CommandOverview = CommandOverviewEvents;
                            ObjBooth.ID = ID + 1;
                            ID++;
                            CurPage++;
                            LstSearchList.Add(ObjBooth);
                        }
                    }
                    else
                    {
                        if (LstSearchList.Count <= 0)
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NoRecord, Resource.OK);
                            if (IsFilter)
                            {
                                await App.Current.MainPage.Navigation.PopModalAsync();
                            }
                        }
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        if (LstSearchList.Count <= 0)
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                            if (IsFilter)
                            {
                                await App.Current.MainPage.Navigation.PopModalAsync();
                            }
                        }
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        if (IsFilter)
                        {
                            await App.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }



        /// <summary>
        /// Method For Get OrderInfo
        /// </summary>
        /// <returns></returns>
        public async Task PullToRefreshCardDetails(bool IsFilter)
        {
            ID = 0;
            CurPage = 0;
            List<BoothCardResponse> LstBoothcard = new List<BoothCardResponse>();
            BoothcardServices ServiceProviderShow = new BoothcardServices();
            try
            {
                if (SearchKey == "")
                {
                    SearchKey = null;
                }
                LstBoothcard = await ServiceProviderShow.GetBoothcards(WorkStartDate, WorkEndDate, SearchKey, 1);
                 LstSearchList.Clear();
                if (LstBoothcard != null)
                {
                    if (LstBoothcard.Count > 0)
                    {

                        foreach (var item in LstBoothcard)
                        {
                            BoothCardModel ObjBooth = new BoothCardModel();
                            ObjBooth.Boothcard = item.BoothcardId;
                            ObjBooth.IsBoothcardSigned = item.IsBoothcardSigned;
                            ObjBooth.Notes = item.Note;
                            if (!string.IsNullOrEmpty(item.WorkDate))
                            {
                                DateTime obj = new DateTime();
                                obj = Convert.ToDateTime(item.WorkDate);
                                string WorkDate = obj.ToString(Resource.DateFormat);
                                if (WorkDate != Resource.BlankDate)
                                {
                                    ObjBooth.WorkDate = obj.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.WorkDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.WorkDate = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ProjectNum))
                            {
                                ObjBooth.Project = item.ProjectNum;
                            }
                            else
                            {
                                ObjBooth.Project = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.Exhibitor))
                            {
                                ObjBooth.Exhibitor = item.Exhibitor;
                            }
                            else
                            {
                                ObjBooth.Exhibitor = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ShowName))
                            {
                                ObjBooth.Show = item.ShowName;
                            }
                            else
                            {
                                ObjBooth.Show = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ShowCity))
                            {
                                ObjBooth.Citys = item.ShowCity;
                            }
                            else
                            {
                                ObjBooth.Citys = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.BoothNum))
                            {
                                ObjBooth.Booth = item.BoothNum;
                            }
                            else
                            {
                                ObjBooth.Booth = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.AccountExec))
                            {
                                ObjBooth.AccountExec = item.AccountExec;
                            }
                            else
                            {
                                ObjBooth.AccountExec = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.SubmittedByDisplayName))
                            {
                                ObjBooth.Submittedby = item.SubmittedByDisplayName;
                            }
                            else
                            {
                                ObjBooth.Submittedby = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.PreparedByDisplayName))
                            {
                                ObjBooth.Preparedby = item.PreparedByDisplayName;
                            }
                            else
                            {
                                ObjBooth.Preparedby = Resource.NA;
                            }
                           
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedByDisplayName))
                            {
                                ObjBooth.ReviewSubmittedByDisplayName = item.ReviewSubmittedByDisplayName;
                            }
                            else
                            {
                                ObjBooth.ReviewSubmittedByDisplayName = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedDate))
                            {
                                ObjBooth.ReviewColor = Color.Transparent;
                                DateTime objReviewDate = new DateTime();
                                objReviewDate = Convert.ToDateTime(item.ReviewSubmittedDate);
                                string SubmitDate = objReviewDate.ToString(Resource.DateFormat);
                                if (SubmitDate != Resource.BlankDate)
                                {
                                    ObjBooth.ReviewSubmittedDate = objReviewDate.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.ReviewColor = Color.Yellow;
                                    ObjBooth.ReviewSubmittedDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.ReviewColor = Color.Yellow;
                                ObjBooth.ReviewSubmittedDate = Resource.NA;
                            }

                            if (!string.IsNullOrEmpty(item.DateSubmitted))
                            {
                                ObjBooth.SubmittedColor = Color.Transparent;
                                DateTime obj = new DateTime();
                                obj = Convert.ToDateTime(item.DateSubmitted);
                                string SubmitDate = obj.ToString(Resource.DateFormat);
                                if (SubmitDate != Resource.BlankDate)
                                {
                                    ObjBooth.ReviewColor = Color.Transparent;
                                    ObjBooth.SubmittedDate = obj.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.SubmittedColor = Color.Yellow;
                                    ObjBooth.SubmittedDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.SubmittedColor = Color.Yellow;
                                ObjBooth.SubmittedDate = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.CreatedDate))
                            {
                                DateTime objCreateDate = new DateTime();
                                objCreateDate = Convert.ToDateTime(item.CreatedDate);
                                string CreateDate = objCreateDate.ToString(Resource.DateFormat);
                                if (CreateDate != Resource.BlankDate)
                                {
                                    ObjBooth.CreateDate = objCreateDate.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ObjBooth.CreateDate = Resource.NA;
                                }

                            }
                            else
                            {
                                ObjBooth.CreateDate = Resource.NA;
                            }
                            ObjBooth.SupervisorName = item.SupervisorName;
                            ObjBooth.SupervisorPresent = item.SupervisorPresent;
                            ObjBooth.CommandBoothcard = CommandBoothcardEvents;
                            ObjBooth.CommandOverview = CommandOverviewEvents;
                            ObjBooth.ID = ID + 1;
                            ID++;
                            CurPage++;
                            LstSearchList.Add(ObjBooth);
                        }
                    }
                    else
                    {
                        if (LstSearchList.Count <= 0)
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NoRecord, Resource.OK);
                            if (IsFilter)
                            {
                                await App.Current.MainPage.Navigation.PopModalAsync();
                            }
                        }
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                        if (IsFilter)
                        {
                            await App.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        if (IsFilter)
                        {
                            await App.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        /// <summary>
        /// Validates the  date.
        /// </summary>
        /// <returns><c>true</c>, if end date was validated, <c>false</c> otherwise.</returns>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
		public bool ValidateEndDate(string fromDate, string toDate)
        {
            bool condition = true;
            var WstartDate = fromDate;
            var endDate = toDate;
            if (WstartDate != string.Empty && endDate != string.Empty)
            {
                if (Convert.ToDateTime(WstartDate) > Convert.ToDateTime(endDate))
                {                    
                    App.Current.MainPage.DisplayAlert(string.Empty, Resource.DateValidMessage, Resource.OK);
                    condition = false;
                    IsSearchArea = true;
                }
            }
            return condition;
        }


       
    }
}
