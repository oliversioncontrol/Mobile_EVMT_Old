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
    class OrderDetailsVM : ObservableObject
    {        
        private Command CommandLaborCallNotes;
        private Command CommandSupervision;
        private Command CommandSpecialNotes;

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


        public string _JobNumWithVersion;
        /// <summary>
        /// Gets or Sets JobNumWithVersion
        /// </summary>
        public string JobNumWithVersion
        {
            get { return _JobNumWithVersion; }
            set
            {
                _JobNumWithVersion = value;
                OnPropertyChanged(nameof(JobNumWithVersion));
            }
        }

        public string _JobNumber;
        /// <summary>
        /// Gets or Sets _JobNumber
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

        public string _BoothSize;
        /// <summary>
        /// Gets or Sets BoothSize
        /// </summary>
        public string BoothSize
        {
            get { return _BoothSize; }
            set
            {
                _BoothSize = value;
                OnPropertyChanged(nameof(BoothSize));
            }
        }

        public string _BoothNumber;
        /// <summary>
        /// Gets or Sets BoothSize
        /// </summary>
        public string BoothNumber
        {
            get { return _BoothNumber; }
            set
            {
                _BoothNumber = value;
                OnPropertyChanged(nameof(BoothNumber));
            }
        }

        public string _Status;
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string _LastYearJob;
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        public string LastYearJob
        {
            get { return _LastYearJob; }
            set
            {
                _LastYearJob = value;
                OnPropertyChanged(nameof(LastYearJob));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderDetailsVM()
        {          
            GetOrder();            
        }

        /// <summary>
        // //Command NewsSampleNoteEvents
        /// </summary>
        public Command NewsSampleNoteEvents
        {
            get
            {
                if (CommandLaborCallNotes == null)
                    CommandLaborCallNotes = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.ODSampleAndNote());                               
                            }                          

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }

                    });
                return CommandLaborCallNotes;
            }
        }

        /// <summary>
        // //Command NewsSampleNoteEvents
        /// </summary>
        public Command NewsSupervisionEvents
        {
            get
            {
                if (CommandSupervision == null)
                    CommandSupervision = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.OrderDetailSupervision());
                               
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }

                    });
                return CommandSupervision;
            }
        }


        /// <summary>
        // //Command SpecialNotesEvents
        /// </summary>
        public Command SpecialNotesEvents
        {
            get
            {
                if (CommandSpecialNotes == null)
                    CommandSpecialNotes = new Command((req) =>
                    {
                        try
                        {                           
                            if (IsClicked)
                            {
                                IsClicked = false;
                               App.Current.MainPage.Navigation.PushModalAsync(new Views.LaborCallNotes());                              
                            }                          

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }

                    });
                return CommandSpecialNotes;
            }
        }


        /// <summary>
        /// Method for GetOrder
        /// </summary>
        public async void GetOrder()
        {
            IsBusy = true;
            await GetOrderInfo();
            IsBusy = false;
        }

        /// <summary>
        /// Method For Get OrderInfo
        /// </summary>
        /// <returns></returns>
        public async Task GetOrderInfo()
        {
            List<OrderInfoModel> LstOrderObj = new List<OrderInfoModel>();
            List<OrderInfoModel> LstOrder = new List<OrderInfoModel>();
            OrderInfoServices ServiceProviderShow = new OrderInfoServices();
            try
            {

                LstOrder = await ServiceProviderShow.GetOrderInfo(Views.OrderDatails.JobNumber);
                if (LstOrder != null)
                {
                    if (LstOrder.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(LstOrder[0].ExhibitorName))
                        {
                            ExhibitorName = LstOrder[0].ExhibitorName;
                        }
                        else
                        {
                            ExhibitorName = string.Empty;
                        }
                        if(!string.IsNullOrEmpty(LstOrder[0].ShortName))
                        {
                            ShowName = LstOrder[0].ShowName;
                        }
                        else
                        {
                            ShowName = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(LstOrder[0].JobNumber))
                        {
                           
                            if (!string.IsNullOrEmpty(LstOrder[0].Version))
                            {
                                JobNumber = LstOrder[0].JobNumber;
                                JobNumWithVersion = LstOrder[0].JobNumber + ", Version " + LstOrder[0].Version;
                            }
                            else
                            {
                                JobNumWithVersion = LstOrder[0].JobNumber;
                            }
                        }
                        else
                        {
                            JobNumWithVersion = string.Empty;
                        }
                        if(!string.IsNullOrEmpty(LstOrder[0].OrderBoothSize))
                        {
                            BoothSize= LstOrder[0].OrderBoothSize;
                            OrderBoothSize =  Resource.BoothSize+" " + LstOrder[0].OrderBoothSize;
                        }
                        else
                        {
                            OrderBoothSize = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(LstOrder[0].LastYearJobNumber))
                        {                            
                            LastYearJob = LstOrder[0].LastYearJobNumber;
                        }
                        else
                        {
                            LastYearJob = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(LstOrder[0].JobStatus))
                        {
                            Status = LstOrder[0].JobStatus;
                        }
                        else
                        {
                            Status = string.Empty;
                        }
                        if(!string.IsNullOrEmpty(LstOrder[0].BoothNumber))
                        {
                            BoothNumber = LstOrder[0].BoothNumber;
                        }
                        else
                        {
                            BoothNumber = string.Empty;
                        }


                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NoRecord, Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
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
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
