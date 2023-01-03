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
    public  class ProjectEstimateVM: ObservableObject
    {        
        Command CommandLaborInstall;
        Command CommandLaborShowServices;
        Command CommandLaborDismantle;      
        Command CommandMaterialsExtras;

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

        public string _JobNumber;
        /// <summary>
        /// Gets or Sets EstJobNumber
        /// </summary>
        public string EstJobNumber
        {
            get { return _JobNumber; }
            set
            {
                _JobNumber = value;
                OnPropertyChanged(nameof(EstJobNumber));
            }
        }


        public string _GrandTotal;
        /// <summary>
        /// Gets or Sets EstJobNumber
        /// </summary>
        public string GrandTotal
        {
            get { return _GrandTotal; }
            set
            {
                _GrandTotal = value;
                OnPropertyChanged(nameof(GrandTotal));
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


        public string _LaborInstall;
        /// <summary>
        /// Gets or Sets LaborInstall
        /// </summary>
        public string LaborInstall
        {
            get { return _LaborInstall; }
            set
            {
                _LaborInstall = value;
                OnPropertyChanged(nameof(LaborInstall));
            }
        }

        public string _LaborShowServices;
        /// <summary>
        /// Gets or Sets LaborShowServices
        /// </summary>
        public string LaborShowServices
        {
            get { return _LaborShowServices; }
            set
            {
                _LaborShowServices = value;
                OnPropertyChanged(nameof(LaborShowServices));
            }
        }

        public string _LaborDismantle;
        /// <summary>
        /// Gets or Sets LaborDismantle
        /// </summary>
        public string LaborDismantle
        {
            get { return _LaborDismantle; }
            set
            {
                _LaborDismantle = value;
                OnPropertyChanged(nameof(LaborDismantle));
            }
        }

        public string _Supervision;
        /// <summary>
        /// Gets or Sets Supervision
        /// </summary>
        public string Supervision
        {
            get { return _Supervision; }
            set
            {
                _Supervision = value;
                OnPropertyChanged(nameof(Supervision));
            }
        }

        public string _MaterialsExtras;
        /// <summary>
        /// Gets or Sets MaterialsExtras
        /// </summary>
        public string MaterialsExtras
        {
            get { return _MaterialsExtras; }
            set
            {
                _MaterialsExtras = value;
                OnPropertyChanged(nameof(MaterialsExtras));
            }
        }

        public string _Total;
        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        public string Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public string _Tax;
        /// <summary>
        /// Gets or Sets Tax
        /// </summary>
        public string Tax
        {
            get { return _Tax; }
            set
            {
                _Tax = value;
                OnPropertyChanged(nameof(Tax));
            }
        }


        public bool _IsInstall;
        /// <summary>
        /// Gets or Sets IsInstall
        /// </summary>
        public bool IsInstall
        {
            get { return _IsInstall; }
            set
            {
                _IsInstall = value;
                OnPropertyChanged(nameof(IsInstall));
            }
        }



        public bool _IsShowServices;
        /// <summary>
        /// Gets or Sets IsShowServices
        /// </summary>
        public bool IsShowServices
        {
            get { return _IsShowServices; }
            set
            {
                _IsShowServices = value;
                OnPropertyChanged(nameof(IsShowServices));
            }
        }

        public bool _IsDismantle;
        /// <summary>
        /// Gets or Sets IsShowServices
        /// </summary>
        public bool IsDismantle
        {
            get { return _IsDismantle; }
            set
            {
                _IsDismantle = value;
                OnPropertyChanged(nameof(IsDismantle));
            }
        }

        public bool _IsMaterialExtras;
        /// <summary>
        /// Gets or Sets IsShowServices
        /// </summary>
        public bool IsMaterialExtras
        {
            get { return _IsMaterialExtras; }
            set
            {
                _IsMaterialExtras = value;
                OnPropertyChanged(nameof(IsMaterialExtras));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectEstimateVM()
        {
            try
            {
                GetEstimatedSum();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        /// <summary>
        /// Method for GetEstimates Summary
        /// </summary>
       public async void GetEstimatedSum()
        {
            try
            {
                IsBusy = true;
                EstJobNumber = Views.ProjectEstimate.JobNumber;
                if (!string.IsNullOrEmpty(EstJobNumber))
                {
                    await GetEstimatedSummary();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                IsBusy = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        /// <summary>
        /// Method for GetEstimatedSummary
        /// </summary>
        /// <returns></returns>
        public async Task GetEstimatedSummary()
        {
            double totals = 0.00, taxes = 0.00;
            List<EstimateSummary> ShowEstimatedSummaryList = new List<EstimateSummary>();
            EstimatedServices ServiceProvider = new EstimatedServices();
            try
            {               
                ShowEstimatedSummaryList = await ServiceProvider.GetEstimatedSummary(Resource.MethodGetEstimateSummary, Views.ProjectEstimate.JobNumber);
               
                if (ShowEstimatedSummaryList != null && ShowEstimatedSummaryList.Count != 0)
                {
                    if (ShowEstimatedSummaryList[0].LaborInstall != null)
                    {
                        LaborInstall = ShowEstimatedSummaryList[0].LaborInstall;
                        if(ShowEstimatedSummaryList[0].LaborInstall != "0.00")
                        {
                            IsInstall = true;
                        }
                        else
                        {
                            IsInstall= false;
                        }
                    }
                    if (ShowEstimatedSummaryList[0].LaborDismantle != null)
                    {
                        LaborDismantle = ShowEstimatedSummaryList[0].LaborDismantle;
                        if (ShowEstimatedSummaryList[0].LaborDismantle != "0.00")
                        {
                            IsDismantle = true;
                        }
                        else
                        {
                            IsDismantle = false;
                        }
                    }
                    if (ShowEstimatedSummaryList[0].LaborShowServices != null)
                    {
                        LaborShowServices = ShowEstimatedSummaryList[0].LaborShowServices;
                        if (ShowEstimatedSummaryList[0].LaborShowServices != "0.00")
                        {
                            IsShowServices = true;
                        }
                        else
                        {
                            IsShowServices = false;
                        }
                    }
                    if (ShowEstimatedSummaryList[0].MaterialsExtras != null)
                    {
                        MaterialsExtras = ShowEstimatedSummaryList[0].MaterialsExtras;
                        if (ShowEstimatedSummaryList[0].MaterialsExtras != "0.00")
                        {
                            IsMaterialExtras = true;
                        }
                        else
                        {
                            IsMaterialExtras = false;
                        }
                    }
                    if (ShowEstimatedSummaryList[0].Supervision != null)
                    {
                        Supervision = ShowEstimatedSummaryList[0].Supervision;
                    }
                    if (ShowEstimatedSummaryList[0].Total != null)
                    {
                        Total = ShowEstimatedSummaryList[0].Total;
                        totals=Convert.ToDouble(ShowEstimatedSummaryList[0].Total);
                    }
                    if (ShowEstimatedSummaryList[0].Tax != null)
                    {
                        Tax = ShowEstimatedSummaryList[0].Tax;
                        taxes= Convert.ToDouble(ShowEstimatedSummaryList[0].Tax);
                    }
                    GrandTotal = Convert.ToString(totals + taxes);
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, "Currently there is no estimate to show (Job#" + Views.ProjectEstimate.JobNumber + "). ", Resource.OK);                       
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
        /// Open commandYourTeam events
        /// </summary>
        public Command CommandLaborInstallEvents
        {
            get
            {
                if (CommandLaborInstall == null)
                    CommandLaborInstall = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.EstimateDetails(Resource.MethodGetEstDetailsInstallDismantle, Convert.ToString(req), Resource.Install));
                              
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandLaborInstall;
            }
        }

        /// <summary>
        /// Open commandYourProject events
        /// </summary>
        public Command CommandLaborShowServicesEvents
        {
            get
            {
                if (CommandLaborShowServices == null)
                    CommandLaborShowServices = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.EstimateDetails(Resource.MethodGetEstDetailsShowServices.Replace('_','-'), Convert.ToString(req), Resource.Show));                               
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandLaborShowServices;
            }
        }

        /// <summary>
        /// Open commandYourResource events
        /// </summary>
        public Command CommandLaborDismantleEvents
        {
            get
            {
                if (CommandLaborDismantle == null)
                    CommandLaborDismantle = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                
                                 App.Current.MainPage.Navigation.PushModalAsync(new Views.EstimateDetails("GetEstDetails-InstallDismantle", Convert.ToString(req), "Dismantle"));
                               // App.Current.MainPage.DisplayAlert("Alert", "Coming Soon", "OK");
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandLaborDismantle;
            }
        }

       

        /// <summary>
        /// Open commandYourPic events
        /// </summary>
        public Command CommandMaterialsExtrasEvents
        {
            get
            {
                if (CommandMaterialsExtras == null)
                    CommandMaterialsExtras = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.EstimateDetails(Resource.MethodGetEstDetailsMaterialsExtras.Replace('_','-'), Convert.ToString(req), Resource.MaterialsExtras));
                              
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandMaterialsExtras;
            }
        }

    }
}
