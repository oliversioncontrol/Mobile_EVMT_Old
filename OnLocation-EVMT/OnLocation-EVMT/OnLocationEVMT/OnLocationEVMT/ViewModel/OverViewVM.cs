using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using OnLocationEVMT.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    public class OverViewVM : ObservableObject
    {
        public delegate void  AddStack(StackLayout Obj);
        public event AddStack AddStackData;
        public ObservableRangeCollection<LaborDetailModel> LstLaborDetails { get; set; }
        public ObservableRangeCollection<BoothEquipment> LstEquipment { get; set; }
        public ObservableRangeCollection<BoothMaterial> LstMaterial { get; set; }
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

        private string _Project;
        /// <summary>
        /// Gets or Sets Project ID
        /// </summary>
        public string ProjectId
        {
            get { return _Project; }
            set
            {
                _Project = value;
                OnPropertyChanged(nameof(ProjectId));
            }
        }


        private string _BoothId;
        /// <summary>
        /// Gets or Sets Booth
        /// </summary>
        public string Booth
        {
            get { return _BoothId; }
            set { _BoothId = value; OnPropertyChanged(nameof(Booth)); }
        }


        private string _Boothcard;
        /// <summary>
        /// Gets or Sets Boothcard
        /// </summary>
        public string Boothcard
        {
            get { return _Boothcard; }
            set { _Boothcard = value; OnPropertyChanged(nameof(Boothcard)); }
        }


        private string _WorkDate;
        /// <summary>
        /// Gets or Sets Work Date
        /// </summary>
        public string WorkDate
        {
            get { return _WorkDate; }
            set { _WorkDate = value; OnPropertyChanged(nameof(WorkDate)); }
        }

        private string _Show;
        /// <summary>
        /// Gets or Sets Show Name
        /// </summary>
        public string Show
        {
            get { return _Show; }
            set { _Show = value; OnPropertyChanged(nameof(Show)); }
        }


        private string _AccountExc;
        /// <summary>
        /// Gets or Sets Account Executive
        /// </summary>
        public string AccountExc
        {
            get { return _AccountExc; }
            set { _AccountExc = value; OnPropertyChanged(nameof(AccountExc)); }
        }

        private string _DateSubmitted;
        /// <summary>
        /// Gets or Sets Date Submitted
        /// </summary>
        public string DateSubmitted
        {
            get { return _DateSubmitted; }
            set { _DateSubmitted = value; OnPropertyChanged(nameof(DateSubmitted)); }
        }

        private string _Exhibitor;
        /// <summary>
        /// Gets or Sets Exhibitor
        /// </summary>
        public string Exhibitor
        {
            get { return _Exhibitor; }
            set { _Exhibitor = value; OnPropertyChanged(nameof(Exhibitor)); }
        }

        private string _SupervisorName;
        /// <summary>
        /// Gets or Sets Supervisor Name
        /// </summary>
        public string SupervisorName
        {
            get { return _SupervisorName; }
            set
            {
                _SupervisorName = value;
                OnPropertyChanged(nameof(SupervisorName));
            }
        }


        private bool _IsSupervisorPresent;
        /// <summary>
        /// Gets or Sets IsSupervisor Present
        /// </summary>
        public bool IsSupervisorPresent
        {
            get { return _IsSupervisorPresent; }
            set
            {
                _IsSupervisorPresent = value;
                if(_IsSupervisorPresent)
                {
                    SupervisorPresent = Resource.RdChecked;
                }
                else
                {
                    SupervisorPresent = Resource.RdUnChecked;
                }
                OnPropertyChanged(nameof(IsSupervisorPresent));
            }
        }

        private string _ShowCity;
        /// <summary>
        /// Gets or Sets Show City
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

        private string _SupervisorPresent;
        /// <summary>
        /// Gets or Sets Supervisor present
        /// </summary>
        public string SupervisorPresent
        {
            get { return _SupervisorPresent; }
            set
            {
                _SupervisorPresent = value;
                OnPropertyChanged(nameof(SupervisorPresent));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public OverViewVM()
        {
            try
            {
                ShowMaterial = true;
                MaterialColor = "#71D64A";
                EquipmentColor = "#666666";
                LstLaborDetails = new ObservableRangeCollection<LaborDetailModel>();
                LstEquipment = new ObservableRangeCollection<BoothEquipment>();
                LstMaterial = new ObservableRangeCollection<BoothMaterial>();
                GetHeader();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        public async void GetHeader()
        {
            IsBusy = true;
            // await GetBoothLaborDetails();
            await GetBooth();
            IsBusy = false;
        }


        /// <summary>
        /// Method For Get Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task GetLaborDetails()
        {

            List<LaborDetailModel> LstLabor = new List<LaborDetailModel>();
            LaborDetailsByJob ServiceProvider = new LaborDetailsByJob();
            try
            {
                LstLaborDetails.Clear();
                LstLabor = await ServiceProvider.GetLaborDetails(Views.ProjectOverview.DetialByJob);
                if (LstLabor != null)
                {
                    if (LstLabor.Count > 0)
                    {
                        foreach (var item in LstLabor)
                        {
                            LaborDetailModel ObjLabor = new LaborDetailModel();                            
                            ObjLabor.LaborDetailId = item.LaborDetailId;
                            ObjLabor.EmployeeName = item.EmployeeName;
                            ObjLabor.TaskDescription = item.TaskDescription;
                            ObjLabor.Repeat = CommandEmployeeDetails;
                            if (item.Billable)
                            {
                                ObjLabor.ImgBillable = Resource.checkImage;
                            }
                            else
                            {
                                ObjLabor.ImgBillable = string.Empty;
                            }
                            if (item.Payroll)
                            {
                                ObjLabor.ImgPayroll = Resource.checkImage;
                            }
                            else
                            {
                                ObjLabor.ImgPayroll = string.Empty;
                            }
                            if (item.Partner)
                            {
                                ObjLabor.ImgPartner = Resource.checkImage;
                            }
                            else
                            {
                                ObjLabor.ImgPartner = string.Empty;
                            }
                            ObjLabor.Billable = item.Billable;
                            ObjLabor.Partner = item.Partner;
                            ObjLabor.Payroll = item.Payroll;
                            ObjLabor.BoothcardId = item.BoothcardId;
                            ObjLabor.CreatedDate = item.CreatedDate;
                            ObjLabor.DT = item.DT;
                            ObjLabor.ST = item.ST;
                            ObjLabor.OT = item.OT;
                            ObjLabor.StartTime = item.StartTime;
                            ObjLabor.EndTime = item.EndTime;
                            ObjLabor.LunchTime = item.LunchTime;
                            ObjLabor.TotalHours = item.TotalHours;                           
                            LstLaborDetails.Add(ObjLabor);
                        }
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
        /// Method for Get Equipment list
        /// </summary>
        /// <returns></returns>

        public async Task GetEquipment()
        {
            EquipmentByJob EquipmentService = new EquipmentByJob();
            List<BoothEquipment> ObjEquipmentlst = new List<BoothEquipment>();
            try
            {
                ObjEquipmentlst = await EquipmentService.GetBoothEquipmentByJobNumber(Views.ProjectOverview.DetialByJob);
                LstEquipment.Clear();
                if (ObjEquipmentlst != null)
                {
                    if (ObjEquipmentlst.Count > 0)
                    {

                        foreach (var item in ObjEquipmentlst)
                        {
                            BoothEquipment ObjEquipmentModel = new BoothEquipment();
                            ObjEquipmentModel.BoothcardId = item.BoothcardId;
                            ObjEquipmentModel.CreatedDate = item.CreatedDate;
                            ObjEquipmentModel.ModifiedDate = item.ModifiedDate;
                            ObjEquipmentModel.EquipmentId = item.EquipmentId;
                            ObjEquipmentModel.Equipment = item.Equipment;
                            ObjEquipmentModel.Quantity = item.Quantity;
                            ObjEquipmentModel.Unit = item.Unit;   
                            LstEquipment.Add(ObjEquipmentModel);

                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }


        /// <summary>
        /// Method for Get Material list
        /// </summary>
        /// <returns></returns>
        public async Task GetMaterial()
        {
            MaterialByJob MaterialService = new MaterialByJob();
            List<BoothMaterial> ObjMateriallst = new List<BoothMaterial>();
            try
            {                
                ObjMateriallst = await MaterialService.GetBoothMaterialsByJobNumber(Views.ProjectOverview.DetialByJob);
                LstMaterial.Clear();
                if (ObjMateriallst != null)
                {
                    if (ObjMateriallst.Count > 0)
                    {

                        foreach (var item in ObjMateriallst)
                        {
                            BoothMaterial ObjMaterialModel = new BoothMaterial();                           
                            ObjMaterialModel.BoothcardId = item.BoothcardId;
                            ObjMaterialModel.CreatedDate = item.CreatedDate;
                            ObjMaterialModel.ModifiedDate = item.ModifiedDate;
                            ObjMaterialModel.MaterialId = item.MaterialId;
                            ObjMaterialModel.Material = item.Material;
                            ObjMaterialModel.Quantity = item.Quantity;
                            ObjMaterialModel.PCard = item.PCard;
                            ObjMaterialModel.Cost = item.Cost;
                            ObjMaterialModel.StoreName = item.StoreName;
                            ObjMaterialModel.Unit = item.Unit;
                            ObjMaterialModel.Category = item.Category;
                           
                            if (item.PCard)
                            {
                                ObjMaterialModel.PCardImge = Resource.RdChecked;
                            }
                            else
                            {
                                ObjMaterialModel.PCardImge = Resource.RdUnChecked;
                            }
                            LstMaterial.Add(ObjMaterialModel);

                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        private Command commandMaterialEquipment;

        /// <summary>
        /// Open command Command MaterialAndEquipment events
        /// </summary>
        /// 
        public Command CommandMaterialEquipment
        {
            get
            {
                if (commandMaterialEquipment == null)
                    commandMaterialEquipment = new Command((req) =>
                    {
                        try
                        {
                           if(Convert.ToString(req)=="Material")
                            {
                                ShowMaterial = true;
                                ShowEquipment = false;
                                MaterialColor = "#71D64A";
                                EquipmentColor = "#666666";
                            }
                           else
                            {
                                ShowMaterial = false;
                                ShowEquipment = true;
                                MaterialColor = "#666666";
                                EquipmentColor = "#71D64A";
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return commandMaterialEquipment;
            }
        }


        private bool  _ShowMaterial;
        /// <summary>
        /// Gets or Sets ShowMaterial
        /// </summary>
        public bool ShowMaterial
        {
            get { return _ShowMaterial; }
            set { _ShowMaterial = value;
                OnPropertyChanged(nameof(ShowMaterial));
            }
        }

        private bool _ShowEquipment;
        /// <summary>
        /// Gets or Sets ShowMaterial
        /// </summary>
        public bool ShowEquipment
        {
            get { return _ShowEquipment; }
            set
            {
                _ShowEquipment = value;
                OnPropertyChanged(nameof(ShowEquipment));
            }
        }


        private string _MaterialColor;
        /// <summary>
        /// #71D64A
        /// </summary>
        public string MaterialColor
        {
            get { return _MaterialColor; }
            set { _MaterialColor = value;
                OnPropertyChanged(nameof(MaterialColor));
            }
        }

        private string _EquipmentColor;
        /// <summary>
        /// #71D64A
        /// </summary>
        public string EquipmentColor
        {
            get { return _EquipmentColor; }
            set
            {
                _EquipmentColor = value;
                OnPropertyChanged(nameof(EquipmentColor));
            }
        }

        private Command commandEmpDetails;

        /// <summary>
        /// Open command Command Employee Details events
        /// </summary>
        /// 
        public Command CommandEmployeeDetails
        {
            get
            {
                if (commandEmpDetails == null)
                    commandEmpDetails = new Command((req) =>
                    {
                        try
                        {
                            BoothLabor LDM = req as BoothLabor;
                            App.Current.MainPage.Navigation.PushModalAsync(new Views.EmpDetails(LDM,Exhibitor,ProjectId,Show));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return commandEmpDetails;
            }
        }


        private Command BoothcardDetails;

        /// <summary>
        /// Command for BoothcardDetails
        /// </summary>
        public Command CommandBoothcardDetails
        {
            get
            {
                if (BoothcardDetails == null)
                    BoothcardDetails = new Command(async(req) =>
                    {
                        try
                        {
                            IsBusy = true;
                            await GetBoothHeader(Convert.ToString(req));
                            IsBusy = false;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return BoothcardDetails;
            }
        }


        /// <summary>
        /// Method For Get Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task GetBoothLaborDetails()
        {
          
            int i = 0;
            string workdate = string.Empty;
            List<BoothLabor> lstlaborlist = new List<BoothLabor>();
            List<BoothLabor> LstLabor = new List<BoothLabor>();
            LaborDetailsByJob ServiceProvider = new LaborDetailsByJob();
            try
            {
                
                LstLaborDetails.Clear();
                LstLabor = await ServiceProvider.GetBoothLaborDetails(Views.ProjectOverview.DetialByJob);
                if (LstLabor != null)
                {
                    if (LstLabor.Count > 0)
                    {
                        foreach (var item in LstLabor)
                        {                            
                            if (i == 0)
                            {
                                i++;
                                workdate = item.WorkDate;
                            }
                            if (workdate == item.WorkDate)
                            {
                                BoothLabor ObjLabor = new BoothLabor();
                                ObjLabor.LaborDetailId = item.LaborDetailId;
                                ObjLabor.EmployeeName = item.EmployeeName;
                                ObjLabor.TaskDescription = item.TaskDescription;
                                ObjLabor.Repeat = CommandBoothcardDetails;
                                if(string.IsNullOrEmpty(item.Note))
                                {
                                    ObjLabor.AllNotes = Resource.NA;
                                }
                                else
                                {
                                    ObjLabor.AllNotes = item.Note;
                                }
                                if (item.Billable)
                                {
                                    ObjLabor.ImgBillable = Resource.checkImage;
                                }
                                else
                                {
                                    ObjLabor.ImgBillable = string.Empty;
                                }
                                if (item.Payroll)
                                {
                                    ObjLabor.ImgPayroll = Resource.checkImage;
                                }
                                else
                                {
                                    ObjLabor.ImgPayroll = string.Empty;
                                }
                                if (item.Partner)
                                {
                                    ObjLabor.ImgPartner = Resource.checkImage;
                                }
                                else
                                {
                                    ObjLabor.ImgPartner = string.Empty;
                                }
                                ObjLabor.Billable = item.Billable;
                                ObjLabor.Partner = item.Partner;
                                ObjLabor.Payroll = item.Payroll;
                                ObjLabor.BoothcardId = item.BoothcardId;
                                ObjLabor.CreatedDate = item.CreatedDate;
                                ObjLabor.DT = item.DT;
                                ObjLabor.ST = item.ST;
                                ObjLabor.OT = item.OT;
                                ObjLabor.StartTime = item.StartTime;
                                ObjLabor.EndTime = item.EndTime;
                                ObjLabor.LunchTime = item.LunchTime;
                                ObjLabor.TotalHours = item.TotalHours;
                                ObjLabor.WorkDate = item.WorkDate;
                                lstlaborlist.Add(ObjLabor);
                            }
                            else
                            {
                                StackLayout ObjStack = new StackLayout();
                                ObjStack.Children.Add(new OverviewTemplae(workdate, lstlaborlist));
                                AddStackData(ObjStack);
                                workdate = item.WorkDate;
                                lstlaborlist=new List<BoothLabor>();
                                BoothLabor ObjLabor = new BoothLabor();
                                ObjLabor.LaborDetailId = item.LaborDetailId;
                                ObjLabor.EmployeeName = item.EmployeeName;
                                ObjLabor.TaskDescription = item.TaskDescription;
                                ObjLabor.Repeat = CommandBoothcardDetails;
                                if (string.IsNullOrEmpty(item.Note))
                                {
                                    ObjLabor.AllNotes = Resource.NA;
                                }
                                else
                                {
                                    ObjLabor.AllNotes = item.Note;
                                }
                                if (item.Billable)
                                {
                                    ObjLabor.ImgBillable = Resource.checkImage;
                                }
                                else
                                {
                                    ObjLabor.ImgBillable = string.Empty;
                                }
                                if (item.Payroll)
                                {
                                    ObjLabor.ImgPayroll = Resource.checkImage;
                                }
                                else
                                {
                                    ObjLabor.ImgPayroll = string.Empty;
                                }
                                if (item.Partner)
                                {
                                    ObjLabor.ImgPartner = Resource.checkImage;
                                }
                                else
                                {
                                    ObjLabor.ImgPartner = string.Empty;
                                }
                                ObjLabor.Billable = item.Billable;
                                ObjLabor.Partner = item.Partner;
                                ObjLabor.Payroll = item.Payroll;
                                ObjLabor.BoothcardId = item.BoothcardId;
                                ObjLabor.CreatedDate = item.CreatedDate;
                                ObjLabor.DT = item.DT;
                                ObjLabor.ST = item.ST;
                                ObjLabor.OT = item.OT;
                                ObjLabor.StartTime = item.StartTime;
                                ObjLabor.EndTime = item.EndTime;
                                ObjLabor.LunchTime = item.LunchTime;
                                ObjLabor.TotalHours = item.TotalHours;
                                ObjLabor.WorkDate = item.WorkDate;
                                lstlaborlist.Add(ObjLabor);
                            }
                        }
                        StackLayout ObjStack1 = new StackLayout();
                        ObjStack1.Children.Add(new OverviewTemplae(workdate, lstlaborlist));
                        AddStackData(ObjStack1);
                       
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
        /// Method For Get Booth header
        /// </summary>
        /// <returns></returns>
        public async Task GetBoothHeader(string BoothNumber)
        {

            List<BoothHeader> LstBoothHeader = new List<BoothHeader>();
            BTCHeaderService ServiceProviderShow = new BTCHeaderService();
            try
            {

                LstBoothHeader = await ServiceProviderShow.GetBoothHeader(BoothNumber);
                if (LstBoothHeader != null)
                {
                    if (LstBoothHeader.Count > 0)
                    {
                        foreach (var item in LstBoothHeader)
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
                            if (!string.IsNullOrEmpty(item.DateSubmitted))
                            {
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
                            ObjBooth.CommandBoothcard = null;
                            ObjBooth.CommandOverview = null;
                            await App.Current.MainPage.Navigation.PushModalAsync(new BoothCardDetails(ObjBooth));
                            break;
                        }
                       
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NoRecord, Resource.OK);
                       // await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                        
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        private Command CommandNote;

        /// <summary>
        /// Open  Command CommandNoteEvents
        /// </summary>
        /// 
        public Command CommandNoteEvents
        {
            get
            {
                if (CommandNote == null)
                    CommandNote = new Command((req) =>
                    {
                        try
                        {
                            
                            App.Current.MainPage.Navigation.PushModalAsync(new Views.EmpDetails(Convert.ToString("<Html><Body>"+req+ "</Html></Body>")));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandNote;
            }
        }




        /// <summary>
        /// Method For Get Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task GetBooth()
        {

            int i = 0;
            string workdate = string.Empty;
            List<BoothLabor> lstlaborlist = new List<BoothLabor>();
            List<LabborByJob> LstLabor = new List<LabborByJob>();
            LaborDetailsByJob ServiceProvider = new LaborDetailsByJob();
            try
            {

                LstLaborDetails.Clear();
                LstLabor = await ServiceProvider.GetBoothLabor(Views.ProjectOverview.DetialByJob);
                if (LstLabor != null)
                {
                    if (LstLabor.Count > 0)
                    {
                        foreach (var items in LstLabor)
                        {
                            foreach (var item in items.LaborDetails)
                            {
                                item.Repeat = CommandBoothcardDetails;                               
                            }
                            StackLayout ObjStack = new StackLayout();
                            ObjStack.Children.Add(new OverviewTemplae(items.WorkDate,items.LaborNote, items.LaborDetails));
                            AddStackData(ObjStack);
                        }
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
