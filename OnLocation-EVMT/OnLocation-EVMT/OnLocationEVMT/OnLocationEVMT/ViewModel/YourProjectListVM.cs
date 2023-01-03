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
    /// <summary>
    /// Class Your Projectlist implementation
    /// </summary>
    class YourProjectListVM : ObservableObject
    {
        private Command CommandlistTab;
        int CurPage { get; set; }
        public ObservableRangeCollection<YourProjectListModel> LstYourProject { get; set; }

        private ObservableRangeCollection<YourProjectListModel> _LstSearchList;
        /// <summary>
        /// Gets Sets for LstSearchList
        /// </summary>
        public ObservableRangeCollection<YourProjectListModel> LstSearchList
        {
            get { return _LstSearchList; }
            set { _LstSearchList = value;
                OnPropertyChanged(nameof(LstSearchList));
            }
        }



        private ObservableRangeCollection<YearList> _LstYear;
        /// <summary>
        /// Gets Set for LstYear
        /// </summary>
        public ObservableRangeCollection<YearList> LstYear
        {
            get { return _LstYear; }
            set
            {
                _LstYear = value;
                OnPropertyChanged(nameof(LstYear));
            }
        }



        private YearList _YearSelected;
        /// <summary>
        /// Gets Sets Selected Year
        /// </summary>
        public YearList YearSelected
        {
            get { return _YearSelected; }
            set {
                _YearSelected = value;
                try
                {
                    if (YearSelected != null)
                    {
                        if (YearSelected.ID == 0)
                        {
                            CurPage = 1;
                            TextYear = "Year";
                            YearColor = Color.FromHex("#666666");
                        }
                        else
                        {
                            CurPage = 1;
                            TextYear = YearSelected.Year;
                            YearColor = Color.FromHex("#71D64A");
                        }
                        GetYearWise();
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
                OnPropertyChanged(nameof(YearSelected));
                
            }
        }

        /// <summary>
        /// Method for Get Year Wise
        /// </summary>
        public async void  GetYearWise()
        {
            IsBusy = true;
            await GetProjectList(true);            
            IsBusy = false;
        }
        private Color _YearColor;
        /// <summary>
        /// Get Sets Year color
        /// </summary>
        public Color YearColor
        {
            get { return _YearColor; }
            set { _YearColor = value;
                OnPropertyChanged(nameof(YearColor));
            }
        }



        private int _TasksIndex;
        /// <summary>
        /// Gets or Sets Task Index
        /// </summary>
        public int TasksIndex
        {
            get { return _TasksIndex; }
            set
            {
                _TasksIndex = value;
                OnPropertyChanged(nameof(TasksIndex));
            }
        }

        private bool _ParentPage;
        /// <summary>
        /// Gets Sets Parent Page
        /// </summary>
        public bool ParentPage
        {
            get { return _ParentPage; }
            set
            {
                _ParentPage = value;
                OnPropertyChanged(nameof(ParentPage));
            }
        }
        private string _SearchKey;
        /// <summary>
        /// / Gets or sets Search Keywords.
        /// </summary>
        public string Search
        {
            get { return _SearchKey; }
            set
            {
                _SearchKey = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        private string _TextYear;
        /// <summary>
        /// Gets Sets Text Year
        /// </summary>
        public string TextYear
        {
            get { return _TextYear; }
            set { _TextYear = value;
                OnPropertyChanged(nameof(TextYear));
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

        private Color _SortDesc;
        /// Gets or Sets SortDesc color
        public Color SortDesc
        {
            get { return _SortDesc; }
            set
            {
                _SortDesc = value;
                OnPropertyChanged(nameof(SortDesc));
            }
        }

        public string _SearchImage;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public string SearchImage
        {
            get { return _SearchImage; }
            set
            {
                _SearchImage = value;
                OnPropertyChanged(nameof(SearchImage));
            }
        }


        public string _ResetImage;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public string ResetImage
        {
            get { return _ResetImage; }
            set
            {
                _ResetImage = value;
                OnPropertyChanged(nameof(ResetImage));
            }
        }


        private YourProjectListModel _SelectedProject;
        /// <summary>
        /// Gets Sets selected project
        /// </summary>
        public YourProjectListModel SelectedProject
        {
            get { return _SelectedProject; }
            set
            {
                _SelectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        int ID = 0;
        /// <summary>
        /// Constructor
        /// </summary>
        public YourProjectListVM()
        {
            try
            {
                TextYear = "Year";
                SortOrder = "Asc";
                SortDesc = Color.FromHex("#666666");
                YearColor= Color.FromHex("#666666");
                CurPage = 1;
                LstYourProject = new ObservableRangeCollection<YourProjectListModel>();
                LstSearchList = new ObservableRangeCollection<YourProjectListModel>();               
                LstYear = new ObservableRangeCollection<YearList>();              
                GetProjects();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }


        private string _SortOrder;
        /// <summary>
        /// Gets Sets Sort Order
        /// </summary>
        public string SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value;
                OnPropertyChanged(nameof(SortOrder));
            }
        }


        private Command CommandSorting;

        /// <summary>
        /// Command SearchAndReset Command
        /// </summary>
        public Command CommandDescEvents
        {
            get
            {
                if (CommandSorting == null)
                    CommandSorting = new Command(async(req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                CurPage = 1;
                                if (SortDesc == Color.FromHex("#666666"))
                                {
                                    SortDesc = Color.FromHex("#71D64A");
                                    SortOrder = "Desc";                                   
                                    //ResetImage = string.Empty;
                                   // Search = string.Empty;
                                    IsBusy = true;
                                    await GetProjectList(true);
                                    IsBusy = false;
                                }
                                else
                                {
                                    SortDesc = Color.FromHex("#666666");
                                    SortOrder = "Asc";
                                    //ResetImage = string.Empty;
                                  //  Search = string.Empty;
                                    IsBusy = true;
                                    await GetProjectList(true);
                                    IsBusy = false;
                                }
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            IsBusy = false;
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandSorting;
            }
        }


        private Command CommandSearchAndReset;

        /// <summary>
        /// Command SearchAndReset Command
        /// </summary>
        public Command CommandSearchAndResetEvents
        {
            get
            {
                if (CommandSearchAndReset == null)
                    CommandSearchAndReset = new Command(async (req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (!string.IsNullOrEmpty(Search))
                                {
                                    if (ResetImage != "CrossIcon.png")
                                    {
                                        ResetImage = "CrossIcon.png";
                                    }
                                    TextYear = "Year";
                                    YearColor = Color.FromHex("#666666");
                                    IsBusy = true;
                                    CurPage = 1;
                                    await GetProjectList(true);
                                    await GetProjectYear();
                                    IsBusy = false;
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.EnterSearchKeywords, Resource.OK);
                                }
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            IsBusy = false;
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandSearchAndReset;
            }
        }


        private Command CommandReset;

        /// <summary>
        /// Command SearchAndReset Command
        /// </summary>
        public Command CommandResetEvents
        {
            get
            {
                if (CommandReset == null)
                    CommandReset = new Command(async (req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                CurPage = 1;
                                ResetImage = string.Empty;
                                Search = string.Empty;
                                TextYear = "Year";
                                YearColor = Color.FromHex("#666666");
                                IsBusy = true;
                                await GetProjectList(true);
                                await GetProjectYear();
                                IsBusy = false;
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            IsBusy = false;
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandReset;
            }
        }


        //public async void GetProjectSearch()
        //{
        //    IsBusy = true;
        //    await GetResetData();
        //    IsBusy = false;
        //}
        //public async Task GetSearchdatatData()
        //{
        //    await Task.Run(() =>
        //    {
        //        LstSearchList.Clear();
        //        // LstSearchList.AddRange(LstYourProject.Where(code => code.Searchkeyword.ToLower().Contains(Search.ToLower())));
        //    });
        //}

            /// <summary>
            /// Method for Get Project list on Search basis
            /// </summary>
        public async void SearchKey()
        {
            IsBusy = true;
            await GetProjectList(false);
            IsBusy = false;
        }

        //public async Task GetResetData()
        //{
        //    try
        //    {

        //        await Task.Run(() =>
        //        {
        //            LstSearchList.Clear();
        //            foreach (var item in LstYourProject)
        //            {
        //                YourProjectListModel LstObj = new YourProjectListModel();
        //                LstObj.JobNumber = item.JobNumber;
        //                LstObj.Status = item.Status;
        //                LstObj.Show = item.Show;
        //                LstObj.Customer = item.Customer;
        //                LstObj.Venue = item.Venue;
        //                LstObj.OrderBoothSize = item.OrderBoothSize;
        //                LstObj.PortfolioVersion = item.PortfolioVersion;
        //                LstObj.ShowOpen = item.ShowOpen;
        //                LstObj.ShowClose = item.ShowClose;
        //                LstObj.CommandTab = item.CommandTab;
        //                // LstObj.Searchkeyword = item.Searchkeyword;
        //                LstSearchList.Add(LstObj);
        //            }

        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.StackTrace);
        //    }
        //}

        /// <summary>
        /// Command Listview Row Tab Events
        /// </summary>
        public Command CommandlistTabEvents
        {
            get
            {
                if (CommandlistTab == null)
                    CommandlistTab = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                SelectedProject = req as YourProjectListModel;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.YourProjectTab(SelectedProject));
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandlistTab;
            }
        }

        /// <summary>
        /// Method for Get Projects
        /// </summary>
        public async void GetProjects()
        {
            try
            {
                IsBusy = true;
                await GetProjectYear();
                await GetProjectList(false);
                IsBusy = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method for Get Project List
        /// </summary>
        /// <returns></returns>
        public async Task GetProjectList(bool IsSearch)
        {
            string chooseYear = string.Empty;
            if(TextYear!="Year")
            {
                chooseYear = TextYear;
            }
            List<YourProjectListModel> YourProjlist = new List<YourProjectListModel>();
            List<YourProjectListResponse> ProjectList = new List<YourProjectListResponse>();
            YourProjectListServices ServiceProvider = new YourProjectListServices();
            try
            {
                ProjectList = await ServiceProvider.GetProjectDetails(UserAccounts.LoginUserID, Search, CurPage,SortOrder, chooseYear);
                if (IsSearch)
                {
                    LstSearchList=new ObservableRangeCollection<YourProjectListModel>();
                }
                if (ProjectList != null)
                {
                    if (ProjectList.Count > 0)
                    {
                        string Status = string.Empty;
                        foreach (var item in ProjectList)
                        {
                            
                            YourProjectListModel ObjYourList = new YourProjectListModel();                           

                            ObjYourList.JobNumber = item.JobNumber;
                            ObjYourList.Status = item.JobStatus;
                            string Venue = (!string.IsNullOrEmpty(item.Venue)) ? item.Venue + "," + item.ShowState : item.ShowState;
                            if (!string.IsNullOrEmpty(Venue))
                            {
                                ObjYourList.Venue = Venue;
                            }
                            else
                            {
                                ObjYourList.Venue = Resource.NA;
                            }
                            ObjYourList.OrderBoothSize = item.OrderBoothSize;
                            ObjYourList.PortfolioVersion = item.PortfolioVersion;
                            if (!string.IsNullOrEmpty(item.ShowName))
                            {
                                ObjYourList.Show = item.ShowName;
                            }
                            else
                            {
                                ObjYourList.Show = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ExhibitorName))
                            {
                                ObjYourList.Customer = item.ExhibitorName;
                            }
                            else
                            {
                                ObjYourList.Customer = Resource.NA;
                            }
                            if (item.ShowOpenDate == Resource.BlankDate)
                            {
                                ObjYourList.ShowOpen = Resource.NA;
                            }
                            else
                            {
                                if (item.ShowOpenDate != null)
                                {
                                    ObjYourList.ShowOpen = item.ShowOpenDate;
                                }
                                else
                                {
                                    ObjYourList.ShowOpen = Resource.NA;
                                }
                            }
                            if (item.ShowCloseDate == Resource.BlankDate)
                            {
                                ObjYourList.ShowClose = Resource.NA;
                            }
                            else
                            {
                                if (item.ShowCloseDate != null)
                                {
                                    ObjYourList.ShowClose = item.ShowCloseDate;
                                }
                                else
                                {
                                    ObjYourList.ShowClose = Resource.NA;
                                }
                            }
                            if (item.JobStatus.ToLower() == "active" || item.JobStatus.ToLower() == "bidding" || item.JobStatus.ToLower() == "estimated")
                            {
                                ObjYourList.Job = ObjYourList.JobNumber + "/" + item.JobStatus;
                                ObjYourList.Statusheading = "Job#/Status";
                            }
                            else
                            {
                                ObjYourList.Job = ObjYourList.JobNumber;
                                ObjYourList.Statusheading = "Job#";
                            }
                            ObjYourList.CommandTab = CommandlistTabEvents;
                            ObjYourList.ID = ID + 1;
                            ID++;
                            CurPage++;
                            LstSearchList.Add(ObjYourList);
                        }
                    }
                    else
                    {
                        if (LstSearchList.Count <= 0)
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, "Record Not Found.", Resource.OK);
                            if (!IsSearch)
                            {
                                if (ParentPage)
                                {
                                    App.Current.MainPage = new NavigationPage(new Views.Home());
                                }
                                else
                                {
                                    await App.Current.MainPage.Navigation.PopModalAsync();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (LstSearchList.Count <= 0)
                    {
                        if (IsConneciton.IsConnection)
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                            if (!IsSearch)
                            {
                                await App.Current.MainPage.Navigation.PopModalAsync();
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            if (!IsSearch)
                            {
                                await App.Current.MainPage.Navigation.PopModalAsync();
                            }
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
        /// Method for Get Project year
        /// </summary>
        /// <returns></returns>
        public async Task GetProjectYear()
        {

            List<ProjectYear> lstProjectYear = new List<ProjectYear>();
            ProjectYearServices ServiceProvider = new ProjectYearServices();
            try
            {

                lstProjectYear = await ServiceProvider.GetProjectYear(Search);
                if (lstProjectYear != null)
                {
                    if (lstProjectYear.Count > 0)
                    {
                        LstYear = new ObservableRangeCollection<YearList>();
                        YearList ObJYearNone = new YearList();
                        ObJYearNone.ID = 0;
                        ObJYearNone.Year = "None";
                        LstYear.Add(ObJYearNone);
                        foreach (var item in lstProjectYear)
                        {
                            YearList ObjYear = new YearList();
                            ObjYear.ID = 1;
                            ObjYear.Year = item.ShowOpenYear;
                            LstYear.Add(ObjYear);
                        }

                    }   
                    else
                    {
                        LstYear = new ObservableRangeCollection<YearList>();
                        YearList ObJYearNone = new YearList();
                        ObJYearNone.ID = 0;
                        ObJYearNone.Year = "None";
                        LstYear.Add(ObJYearNone);
                    }
                }
                else
                {
                    LstYear = new ObservableRangeCollection<YearList>();
                    YearList ObJYearNone = new YearList();
                    ObJYearNone.ID = 0;
                    ObJYearNone.Year = "None";
                    LstYear.Add(ObJYearNone);
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);                        
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
    }
}
