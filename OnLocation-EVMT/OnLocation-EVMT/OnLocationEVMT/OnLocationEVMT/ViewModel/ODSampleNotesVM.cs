using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.ViewModel
{
    class ODSampleNotesVM : ObservableObject
    {
        public ObservableRangeCollection<ODSample> LstOrderDetailsSample { get; set; }

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
        /// Method For Get Order Sample
        /// </summary>
        /// <returns></returns>
        public async Task GetOrderSample()
        {
            List<ODSample> LstOrderSampleObj = new List<ODSample>();
            List<ODSampleResponse> LstSample = new List<ODSampleResponse>();
            ODSampleServices ServiceProviderShow = new ODSampleServices();
            try
            {

                LstSample = await ServiceProviderShow.GetOrderSample(Views.OrderDatails.JobNumber);
                if (LstSample != null)
                {
                    if (LstSample.Count > 0)
                    {
                        int NumOfWork = 0;
                        float Hours = 0;
                        float TotalHours = 0;
                        foreach (var item in LstSample)
                        {
                            ODSample ObjOder = new ODSample();
                            if (!string.IsNullOrEmpty(item.WorkDate))
                            {
                                DateTime objworkdate = new DateTime();
                                objworkdate = Convert.ToDateTime(item.WorkDate);
                                string WorkingDate = objworkdate.ToString(Resource.DateFormat);
                                if (WorkingDate != Resource.BlankDate)
                                {
                                    ObjOder.LaborDate = WorkingDate;
                                }
                                else
                                {
                                    ObjOder.LaborDate = Resource.NA;
                                }
                            }
                            else
                            {
                                ObjOder.LaborDate = string.Empty;
                            }
                            if (!string.IsNullOrEmpty(item.StartTime))
                            {
                                ObjOder.StartTime = item.StartTime.ToUpper();
                            }
                            else
                            {
                                ObjOder.StartTime = Resource.NA;
                            }
                            ObjOder.OLIMen = item.NumWorkers;
                            if(!string.IsNullOrEmpty(item.Service))
                            {
                                ObjOder.Service = item.Service;
                            }
                            else
                            {
                                ObjOder.Service = Resource.NA;
                            }
                           
                            ObjOder.Hours = item.Hours;
                            if (!string.IsNullOrEmpty(item.NumWorkers))
                            {
                                NumOfWork = Convert.ToInt32(item.NumWorkers);
                            }
                            if (!string.IsNullOrEmpty(item.Hours))
                            {
                                Hours = float.Parse(item.Hours);
                            }
                            TotalHours = NumOfWork * Hours;
                            ObjOder.TotalHours = Convert.ToString(TotalHours);
                            LstOrderSampleObj.Add(ObjOder);
                        }
                        LstOrderDetailsSample.AddRange(LstOrderSampleObj);
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


        /// <summary>
        /// Method For Order Sample
        /// </summary>
        public async void OrderSample()
        {
            IsBusy = true;
            await GetOrderSample();
            IsBusy = false;
        }


        /// <summary>
        /// Method for Dummy Data
        /// </summary>
        public ODSampleNotesVM()
        {
            try
            {
                LstOrderDetailsSample = new ObservableRangeCollection<ODSample>();
                OrderSample();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            
        }
    }
}
