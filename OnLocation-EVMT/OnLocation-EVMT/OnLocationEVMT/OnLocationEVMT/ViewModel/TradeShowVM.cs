using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{

    ////Currently This class Not Used////

    /// <summary>
    /// Class TradeShowVM implementation
    /// </summary>
    class TradeShowVM : ObservableObject
    {
        
        public ObservableRangeCollection<TradeShowModel> LstTradeShow { get; set; }
        List<TradeShowModel> LstTrade { get; set; }
        Command CommandSearch;
        Command CommandReset;

        private List<MonthModel> _month;
        /// <summary>
        /// Gets and Sets the Month.
        /// </summary>
        public List<MonthModel> Month
        {
            get { return _month; }
            set
            {
                _month = value;
                OnPropertyChanged(nameof(Month));
            }
        }
        private MonthModel _monthSelected;
        /// <summary>
        /// Gets and Sets the Selected Month.
        /// </summary>
        public MonthModel MonthSelected
        {
            get { return _monthSelected; }
            set
            {
                _monthSelected = value;
                OnPropertyChanged(nameof(MonthSelected));
            }
        }


        private List<City> _city;
        /// <summary>
        /// Gets and Sets the City.
        /// </summary>
        public List<City> City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        private City _citySelected;
        /// <summary>
        /// Gets and Sets the Selected City.
        /// </summary>
        public City CitySelected
        {
            get { return _citySelected; }
            set
            {
                _citySelected = value;
                OnPropertyChanged(nameof(CitySelected));
            }
        }

        private List<Industry> _industry;
        /// <summary>
        /// Gets and Sets the City.
        /// </summary>
        public List<Industry> Industry
        {
            get { return _industry; }
            set
            {
                _industry = value;
                OnPropertyChanged(nameof(Industry));
            }
        }
        private Industry _industrySelected;
        /// <summary>
        /// Gets and Sets the Selected City.
        /// </summary>
        public Industry IndustrySelected
        {
            get { return _industrySelected; }
            set
            {
                _industrySelected = value;
                OnPropertyChanged(nameof(IndustrySelected));
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


        /// <summary>
        /// Constructor
        /// </summary>
        public TradeShowVM()
        {
            try
            {
                TradeMonth MonthList = new TradeMonth();
                TradeCity CityList = new TradeCity();
                TradeIndustry IndustryList = new TradeIndustry();
                Month = MonthList.MonthShow;
                City = CityList.CityList;
                Industry = IndustryList.IndustryList;
                LstTradeShow = new ObservableRangeCollection<TradeShowModel>();
                List<TradeShowModel> getlist = new List<TradeShowModel>();
                getlist = GetDummyData();
                LstTradeShow.AddRange(getlist);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Open commandYourTeam events
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
                            //Implement here
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
        /// Open commandYourTeam events
        /// </summary>
        public Command CommandResetEvents
        {
            get
            {
                if (CommandReset == null)
                    CommandReset = new Command((req) =>
                    {
                        try
                        {
                            //if (IsClicked)
                            //{
                            //    IsClicked = false;
                            //    App.Current.MainPage.Navigation.PushModalAsync(new Views.yourTeam());
                            //}
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandReset;
            }
        }
        public List<TradeShowModel> GetDummyData()
        {
            LstTrade = new List<TradeShowModel>()
            {
                new TradeShowModel()
                {
                    ShowCity="Cleveland, OH",
                    ShowState="United States",
                    ShowName="Cleveland Auto Show",
                    NextDate="FEB/23 - MAR/04/2018"
                },
                new TradeShowModel()
                {
                    ShowCity="Milwaukee, WI",
                    ShowState="United States",
                    ShowName="Greater Milwaukee Auto Show",
                    NextDate="FEB/24 - MAR/04/2018"
                },
                new TradeShowModel()
                {
                    ShowCity="Houston, TX",
                    ShowState="United States",
                    ShowName="Houston Livestock Show & Rodeo",
                    NextDate="FEB/23 - MAR/04/2018"
                },
                new TradeShowModel()
                {
                    ShowCity="Houston, TX",
                    ShowState="United States",
                    ShowName="Houston Fishing Show",
                    NextDate="FEB/23 - MAR/04/2018"
                },
                new TradeShowModel()
                {
                    ShowCity="Houston, TX",
                    ShowState="United States",
                    ShowName="Academy of Osseointegration",
                    NextDate="FEB/23 - MAR/04/2018"
                },
            };
            return LstTrade;
        }
    }
}
