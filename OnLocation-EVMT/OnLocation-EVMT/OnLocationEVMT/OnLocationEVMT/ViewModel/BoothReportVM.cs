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
   public class BoothReportVM: ObservableObject
    {
        public ObservableRangeCollection<LaborModelFloat> LstLaborDetails { get; set; }
        public Double ST=0, OT=0, DT=0,TT=0,LT=0;
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


        public string _HeighRequest;
        /// <summary>
        /// Gets or Sets HeighRequest
        /// </summary>
        public string HeighRequest
        {
            get { return _HeighRequest; }
            set
            {
                _HeighRequest = value;
                OnPropertyChanged(nameof(HeighRequest));
            }
        }

        private string _EditorNote;
        /// <summary>
        /// Gets or Sets Editor Note
        /// </summary>
        public string EditorNote
        {
            get { return _EditorNote; }
            set
            {
                _EditorNote = value;
                OnPropertyChanged(nameof(EditorNote));
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


        private string _ST;
        /// <summary>
        /// Gets or Sets Straight Time
        /// </summary>
        public string TotalST
        {
            get { return _ST; }
            set
            {
                _ST = value;
                OnPropertyChanged(nameof(TotalST));
            }
        }

        private string _OT;
        /// <summary>
        /// Gets or Sets Over Time
        /// </summary>
        public string TotalOT
        {
            get { return _OT; }
            set
            {
                _OT = value;
                OnPropertyChanged(nameof(TotalOT));
            }
        }


        private string _DT;
        /// <summary>
        /// Gets or Sets Double Time
        /// </summary>
        public string TotalDT
        {
            get { return _DT; }
            set
            {
                _DT = value;
                OnPropertyChanged(nameof(TotalDT));
            }
        }

        private string _TotalTime;
        /// <summary>
        /// Gets or Sets Total Time
        /// </summary>
        public string TotalTime
        {
            get { return _TotalTime; }
            set
            {
                _TotalTime = value;
                OnPropertyChanged(nameof(TotalTime));
            }
        }


        private string _LaunchTime;
        /// <summary>
        /// Gets or Sets Total Time
        /// </summary>
        public string LaunchTime
        {
            get { return _LaunchTime; }
            set
            {
                _LaunchTime = value;
                OnPropertyChanged(nameof(LaunchTime));
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


        private string _Exhibitor;
        /// <summary>
        /// Gets or Sets Exhibitor
        /// </summary>
        public string Exhibitor
        {
            get { return _Exhibitor; }
            set { _Exhibitor = value; OnPropertyChanged(nameof(Exhibitor)); }
        }

        private string _IsSupervisorPresent;
        /// <summary>
        /// Gets or Sets IsSupervisor Present
        /// </summary>
        public string IsSupervisorPresent
        {
            get { return _IsSupervisorPresent; }
            set
            {
                _IsSupervisorPresent = value;
                OnPropertyChanged(nameof(IsSupervisorPresent));
            }
        }

        private string _Comment;
        /// <summary>
        /// Gets or Sets IsSupervisor Present
        /// </summary>
        public string Comment
        {
            get { return _Comment; }
            set
            {
                _Comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BoothReportVM()
        {
            HeighRequest = "200";
            LstLaborDetails = new ObservableRangeCollection<LaborModelFloat>();
            Get();
        }


        /// <summary>
        /// Method For Get
        /// </summary>
        public async void Get()
        {
            IsBusy = true;            
            await GetLaborDetails();            
            IsBusy = false;

        }


        private Command CommandRedirect;
        /// <summary>
        /// Open CommandAdd Events
        /// </summary>
        public Command CommandAddEvents
        {
            get
            {
                if (CommandRedirect == null)
                    CommandRedirect = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.BoothcardSign(ProjectId, Boothcard));
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandRedirect;
            }
        }

        /// <summary>
        /// Method For Get Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task GetLaborDetails()
        {

            List<LaborDetailModel> LstLabor = new List<LaborDetailModel>();
            LaborDetailServices ServiceProvider = new LaborDetailServices();
            try
            {
                LstLaborDetails.Clear();
                LstLabor = await ServiceProvider.GetLaborDetails(Views.BoothcardReport.BoothID);
                if (LstLabor != null)
                {
                    if (LstLabor.Count > 0)
                    {
                        HeighRequest = Convert.ToString(LstLabor.Count * 40+200);
                        foreach (var item in LstLabor)
                        {
                            LaborModelFloat ObjLabor = new LaborModelFloat();                          
                            ObjLabor.LaborDetailId = item.LaborDetailId;
                            ObjLabor.EmployeeName = item.EmployeeName;
                            ObjLabor.TaskDescription = item.TaskDescription;
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
                            //ObjLabor.DT = item.DT;
                            //ObjLabor.ST = item.ST;
                            //ObjLabor.OT = item.OT;
                            ObjLabor.StartTime = item.StartTime;
                            ObjLabor.EndTime = item.EndTime;
                            //ObjLabor.LunchTime = item.LunchTime;
                            //ObjLabor.TotalHours = item.TotalHours; 
                            if(!string.IsNullOrEmpty(item.ST))
                            {
                               ObjLabor.ST = Convert.ToDouble(item.ST);
                               ST = ST+Convert.ToDouble(item.ST);
                            }
                            if (!string.IsNullOrEmpty(item.OT))
                            {
                                ObjLabor.OT = Convert.ToDouble(item.OT);
                                OT = OT + Convert.ToDouble(item.OT);
                            }
                            if (!string.IsNullOrEmpty(item.DT))
                            {
                                ObjLabor.DT = Convert.ToDouble(item.DT);
                                DT = DT + Convert.ToDouble(item.DT);
                            }
                            if (!string.IsNullOrEmpty(item.LunchTime))
                            {
                                ObjLabor.LunchTime = Convert.ToDouble(item.LunchTime);
                                LT = LT + Convert.ToDouble(item.LunchTime);
                            }
                            if (!string.IsNullOrEmpty(item.TotalHours))
                            {
                                ObjLabor.TotalHours = Convert.ToDouble(item.TotalHours);
                                TT = TT + Convert.ToDouble(item.TotalHours);
                            }
                            LstLaborDetails.Add(ObjLabor);
                        }
                        TotalDT = Convert.ToString(DT);
                        TotalST = Convert.ToString(ST);
                        TotalOT = Convert.ToString(OT);
                        LaunchTime = Convert.ToString(LT);
                        TotalTime= Convert.ToString(TT);

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
