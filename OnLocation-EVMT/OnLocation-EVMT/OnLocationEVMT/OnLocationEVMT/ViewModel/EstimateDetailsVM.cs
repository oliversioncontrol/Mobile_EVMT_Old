using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.ViewModel
{
    public class EstimateDetailsVM : ObservableObject
    {

        public ObservableRangeCollection<LaborInstall> LstLaborInstall { get; set; }
        public ObservableRangeCollection<MaterialExtras> LstMaterialServices { get; set; }
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

        bool _IsLaborInstall;
        /// <summary>
        /// Gets or sets the IsLaborInstall.
        /// </summary>
        /// <value>The _IsLaborInstall.</value>
        public bool IsLaborInstall
        {
            get { return _IsLaborInstall; }
            set
            {
                _IsLaborInstall = value;
                OnPropertyChanged(nameof(IsLaborInstall));
            }
        }


        bool _IsWorkServices;
        /// <summary>
        /// Gets or sets the IsLaborInstall.
        /// </summary>
        /// <value>The _IsLaborInstall.</value>
        public bool IsWorkServices
        {
            get { return _IsWorkServices; }
            set
            {
                _IsWorkServices = value;
                OnPropertyChanged(nameof(IsWorkServices));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EstimateDetailsVM()
        {
            LstLaborInstall = new ObservableRangeCollection<LaborInstall>();
            LstMaterialServices = new ObservableRangeCollection<MaterialExtras>();
            GetEstimate();
        }

        /// <summary>
        /// Method for GetEstimateDetails
        /// </summary>
        public async void GetEstimate()
        {
            IsBusy = true;
            if (!string.IsNullOrEmpty(Views.EstimateDetails.JobNumber))
            {
                if (Views.EstimateDetails.Service == Resource.Install)
                {
                    IsLaborInstall = true;
                    IsWorkServices = false;
                    await GetEstimateLaborInstall(Views.EstimateDetails.JobNumber, Views.EstimateDetails.Service);
                }
                else if (Views.EstimateDetails.Service == Resource.Dismantle)
                {
                    IsLaborInstall = true;
                    IsWorkServices = false;
                    await GetEstimateLaborInstall(Views.EstimateDetails.JobNumber, Views.EstimateDetails.Service);
                }
                else if (Views.EstimateDetails.Service == Resource.Show)
                {
                    IsLaborInstall = true;
                    IsWorkServices = false;
                    await GetEstimateShowServices(Views.EstimateDetails.JobNumber);
                }
                else if (Views.EstimateDetails.Service == Resource.MaterialsExtras)
                {
                    IsLaborInstall = false;
                    IsWorkServices = true;
                    await GetMaterialExtras(Views.EstimateDetails.JobNumber);
                }

            }
            IsBusy = false;
        }


        /// <summary>
        /// Method For Key GetEstimateLaborInstall
        /// </summary>
        /// <returns></returns>
        public async Task GetEstimateLaborInstall(string JobNumber, string ServiceType)
        {
            List<LaborInstall> LaborInstallListObj = new List<LaborInstall>();
            List<LaborInstall> LaborInstallList = new List<LaborInstall>();
            LaborInstallServices ServiceProvider = new LaborInstallServices();
            try
            {

                LaborInstallList = await ServiceProvider.GetLaborInstall(Resource.MethodGetEstDetailsInstallDismantle.Replace('_','-'), JobNumber, ServiceType);
                if (LaborInstallList != null)
                {
                    if (LaborInstallList.Count > 0)
                    {
                        foreach (var item in LaborInstallList)
                        {
                            LaborInstall objShowServices = new LaborInstall();
                            objShowServices.HourlyRate = item.HourlyRate;
                            objShowServices.NumberOfWorkers = item.NumberOfWorkers;
                            objShowServices.NumOfHours = item.NumOfHours;
                            objShowServices.ServiceRateType = item.ServiceRateType;
                            objShowServices.TotalHours = item.TotalHours;
                            objShowServices.Total = item.Total;
                            objShowServices.Service = item.Service;
                            if (!string.IsNullOrEmpty(item.WorkDate))
                            {
                                DateTime objworkdate = new DateTime();
                                objworkdate = Convert.ToDateTime(item.WorkDate);
                                objShowServices.WorkDate = objworkdate.ToString(Resource.DateFormat);
                            }
                            else
                            {
                                objShowServices.WorkDate = string.Empty;
                            }
                            LaborInstallListObj.Add(objShowServices);
                        }
                        LstLaborInstall.AddRange(LaborInstallListObj);
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
        /// Method For Key GetEstimateShowServices
        /// </summary>
        /// <returns></returns>
        public async Task GetEstimateShowServices(string Jobid)
        {
            List<LaborInstall> ShowServicesObj = new List<LaborInstall>();
            List<LaborInstall> ShowServicesList = new List<LaborInstall>();
            ShowServices ServiceProviderShow = new ShowServices();
            try
            {

                ShowServicesList = await ServiceProviderShow.GetShowServices(Resource.MethodGetEstDetailsShowServices.Replace('_','-'), Jobid);
                if (ShowServicesList != null)
                {
                    if (ShowServicesList.Count > 0)
                    {
                        foreach (var item in ShowServicesList)
                        {
                            LaborInstall objShowServices = new LaborInstall();
                            objShowServices.HourlyRate = item.HourlyRate;
                            objShowServices.NumberOfWorkers = item.NumberOfWorkers;
                            objShowServices.NumOfHours = item.NumOfHours;
                            objShowServices.ServiceRateType = item.ServiceRateType;
                            objShowServices.TotalHours = item.TotalHours;
                            objShowServices.Total = item.Total;
                            objShowServices.Service = Resource.ShowServices;
                            if (!string.IsNullOrEmpty(item.WorkDate))
                            {
                                DateTime objworkdate = new DateTime();
                                objworkdate = Convert.ToDateTime(item.WorkDate);
                                objShowServices.WorkDate = objworkdate.ToString(Resource.DateFormat);
                            }
                            else
                            {
                                objShowServices.WorkDate = string.Empty;
                            }
                            ShowServicesObj.Add(objShowServices);
                        }
                        LstLaborInstall.AddRange(ShowServicesObj);
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
        /// Method For Key GetEstimateShowServices
        /// </summary>
        /// <returns></returns>
        public async Task GetMaterialExtras(string Jobid)
        {
            List<MaterialExtras> MaterialExtrasList = new List<MaterialExtras>();
            MaterialExtrasServices ServiceProviderShow = new MaterialExtrasServices();
            try
            {

                MaterialExtrasList = await ServiceProviderShow.GetMaterialExtras(Resource.MethodGetEstDetailsMaterialsExtras.Replace('_','-'), Jobid);
                if (MaterialExtrasList != null)
                {
                    if (MaterialExtrasList.Count > 0)
                    {
                        LstMaterialServices.AddRange(MaterialExtrasList);
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
