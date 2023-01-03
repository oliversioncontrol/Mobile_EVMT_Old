using OnLocationEVMT.Controls;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class BoothCardDetailVM : ObservableObject
    {


       // public ObservableRangeCollection<LaborDetailModel> LstLaborDetails { get; set; }
        // public ObservableRangeCollection<EmployeeModel> LstEmployeeList { get; set; }
        // public ObservableRangeCollection<EmployeeModel> EmpList { get; set; }
        // public ObservableRangeCollection<Tasks> TaskLists { get; set; }
        //public ObservableRangeCollection<EquipmentModel> LstEquipment { get; set; }
        //  public ObservableRangeCollection<MaterialModel> LstMaterial { get; set; }

        private ObservableRangeCollection<LaborDetailModel> _LstLaborDetails;

        public ObservableRangeCollection<LaborDetailModel> LstLaborDetails
        {
            get { return _LstLaborDetails; }
            set { _LstLaborDetails = value;
                OnPropertyChanged(nameof(LstLaborDetails));
            }
        }



        private ObservableRangeCollection<EmployeeModel> _LstEmployeeList;

        public ObservableRangeCollection<EmployeeModel> LstEmployeeList
        {
            get { return _LstEmployeeList; }
            set { _LstEmployeeList = value;
                OnPropertyChanged(nameof(LstEmployeeList));
            }
        }



        List<BoothHeader> LstBoothHeader { get; set; }

        private ObservableRangeCollection<Tasks> _TaskLists;

        public ObservableRangeCollection<Tasks> TaskLists
        {
            get { return _TaskLists; }
            set { _TaskLists = value;
                OnPropertyChanged(nameof(TaskList));
            }
        }


        private ObservableRangeCollection<MaterialModel> _LstMaterial;

        public ObservableRangeCollection<MaterialModel> LstMaterial
        {
            get { return _LstMaterial; }
            set
            {
                _LstMaterial = value;
                OnPropertyChanged(nameof(LstMaterial));
            }
        }


        private ObservableRangeCollection<EquipmentModel> _LstEquipment;

        public ObservableRangeCollection<EquipmentModel> LstEquipment
        {
            get { return _LstEquipment; }
            set { _LstEquipment = value;
                OnPropertyChanged(nameof(LstEquipment));
            }
        }



        private Command CommandBill;
        private Command CommandPay;
        private Command CommandPar;
        private Command CommandAddEmployee;
        private Command CommandEmpName;
        private Command CommandEditLabor;



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


        private bool _IsReport;
        /// <summary>
        /// Gets or Sets IsReport
        /// </summary>
        public bool IsReport
        {
            get { return _IsReport; }
            set { _IsReport = value;
                OnPropertyChanged(nameof(IsReport));
            }
        }

        private ObservableRangeCollection<EmployeeModel> myVar;

        public ObservableRangeCollection<EmployeeModel> EmpList
        {
            get { return myVar; }
            set { myVar = value;
                OnPropertyChanged(nameof(EmpList));
            }
        }


        private TimeSpan _StartTime;
        /// <summary>
        /// Gets or Sets StartTime
        /// </summary>
        public TimeSpan StartTime
        {
            get { return _StartTime; }
            set
            {
                _StartTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }


        private TimeSpan _EndTime;
        /// <summary>
        /// Gets or Sets EndTime
        /// </summary>
        public TimeSpan EndTime
        {
            get { return _EndTime; }
            set
            {
                _EndTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }
        

        private string _PreparedByID;
        /// <summary>
        /// Gets or Sets PreparedByID
        /// </summary>
        public string PreparedByID
        {
            get { return _PreparedByID; }
            set { _PreparedByID = value;
                OnPropertyChanged(nameof(PreparedByID));
            }
        }

        private string _ReviewByID;
        /// <summary>
        /// Gets or Sets PreparedByID
        /// </summary>
        public string ReviewByID
        {
            get { return _ReviewByID; }
            set
            {
                _ReviewByID = value;
                OnPropertyChanged(nameof(ReviewByID));
            }
        }


        private string _StartHours;
        /// <summary>
        /// Gets or Sets TimeStart
        /// </summary>
        public string StartHours
        {
            get { return _StartHours; }
            set
            {
                _StartHours = value;
                OnPropertyChanged(nameof(StartHours));
            }
        }

        private string _StartMinutes;
        /// <summary>
        /// Get or Sets TimeEnd
        /// </summary>
        public string StartMinutes
        {
            get { return _StartMinutes; }
            set
            {
                _StartMinutes = value;
                OnPropertyChanged(nameof(StartMinutes));
            }
        }


        private string _EndHours;
        /// <summary>
        /// Gets or Sets TimeStart
        /// </summary>
        public string EndHours
        {
            get { return _EndHours; }
            set
            {
                _EndHours = value;
                OnPropertyChanged(nameof(EndHours));
            }
        }

        private string _EndMinutes;
        /// <summary>
        /// Get or Sets TimeEnd
        /// </summary>
        public string EndMinutes
        {
            get { return _EndMinutes; }
            set
            {
                _EndMinutes = value;
                OnPropertyChanged(nameof(EndMinutes));
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


        private string _ST;
        /// <summary>
        /// Gets or Sets Straight Time
        /// </summary>
        public string ST
        {
            get { return _ST; }
            set
            {
                _ST = value;
                OnPropertyChanged(nameof(ST));
            }
        }

        private string _OT;
        /// <summary>
        /// Gets or Sets Over Time
        /// </summary>
        public string OT
        {
            get { return _OT; }
            set
            {
                _OT = value;
                OnPropertyChanged(nameof(OT));
            }
        }

        private string _DT;
        /// <summary>
        /// Gets or Sets Double Time
        /// </summary>
        public string DT
        {
            get { return _DT; }
            set
            {
                _DT = value;
                OnPropertyChanged(nameof(DT));
            }
        }

        private string _PreparedBy;
        /// <summary>
        /// Gets or Sets Prepared By
        /// </summary>
        public string PreparedBy
        {
            get { return _PreparedBy; }
            set
            {
                _PreparedBy = value;
                OnPropertyChanged(nameof(PreparedBy));
            }
        }


        private string _SubmittedBy;
        /// <summary>
        /// Gets or Sets Submitted By
        /// </summary>
        public string SubmittedBy
        {
            get { return _SubmittedBy; }
            set
            {
                _SubmittedBy = value;
                OnPropertyChanged(nameof(SubmittedBy));
            }
        }

        private string _ReviewedBy;
        /// <summary>
        /// Gets or Sets Reviewed By
        /// </summary>
        public string ReviewedBy
        {
            get { return _ReviewedBy; }
            set
            {
                _ReviewedBy = value;
                OnPropertyChanged(nameof(ReviewedBy));
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

        private string _Leadman;
        /// <summary>
        /// Gets or Sets Lead man
        /// </summary>
        public string Leadman
        {
            get { return _Leadman; }
            set
            {
                _Leadman = value;
                OnPropertyChanged(nameof(Leadman));
            }
        }

        private string _RegionalManager;
        /// <summary>
        /// Gets or Sets Regional Manager
        /// </summary>
        public string RegionalManager
        {
            get { return _RegionalManager; }
            set
            {
                _RegionalManager = value;
                OnPropertyChanged(nameof(RegionalManager));
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

        private string _LaunchTime;
        /// <summary>
        /// Gets or Sets Launch Time
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

        private string _ImgPay;
        /// <summary>
        /// Gets or Sets Image payroll
        /// </summary>
        public string ImgPay
        {
            get { return _ImgPay; }
            set
            {
                _ImgPay = value;
                OnPropertyChanged(nameof(ImgPay));
            }
        }


        private string _ImgBill;
        /// <summary>
        /// Gets or Sets Image Billable
        /// </summary>
        public string ImgBill
        {
            get { return _ImgBill; }
            set
            {
                _ImgBill = value;
                OnPropertyChanged(nameof(ImgBill));
            }
        }

        private string _ImgPar;
        /// <summary>
        /// Gets or Sets Image Partner
        /// </summary>
        public string ImgPar
        {
            get { return _ImgPar; }
            set
            {
                _ImgPar = value;
                OnPropertyChanged(nameof(ImgPar));
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


        private string _SelectedEmpName;
        /// <summary>
        /// Gets or Sets Selected Employee Name
        /// </summary>
        public string SelectedEmpName
        {
            get { return _SelectedEmpName; }
            set
            {
                _SelectedEmpName = value;
                OnPropertyChanged(nameof(SelectedEmpName));
            }
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


        private string _SelectedEmpID;
        /// <summary>
        /// Gets or Sets Selected Employee ID
        /// </summary>
        public string SelectedEmpID
        {
            get { return _SelectedEmpID; }
            set
            {
                _SelectedEmpID = value;
                OnPropertyChanged(nameof(SelectedEmpID));
            }
        }

        private bool _IsEmployeePopup;
        /// <summary>
        /// Gets or Sets IsEmployee Popup
        /// </summary>
        public bool IsEmployeePopup
        {
            get { return _IsEmployeePopup; }
            set
            {
                _IsEmployeePopup = value;
                OnPropertyChanged(nameof(IsEmployeePopup));
            }
        }


        private bool _IsEmployeeListPopup;
        /// <summary>
        /// Gets or Sets IsEmployee List Popup
        /// </summary>
        public bool IsEmployeeListPopup
        {
            get { return _IsEmployeeListPopup; }
            set
            {
                _IsEmployeeListPopup = value;
                OnPropertyChanged(nameof(IsEmployeeListPopup));
            }
        }


        private string _SortText;
        /// <summary>
        /// Gets or Sets Sorting Text
        /// </summary>
        public string SortText
        {
            get { return _SortText; }
            set
            {
                try
                {
                    _SortText = value;
                    if (_SortText.Length > 2)
                    {
                        EmpList = new ObservableRangeCollection<EmployeeModel>();                        
                        EmpList.AddRange(LstEmployeeList.Where(code => code.DisplayName.ToLower().Contains(_SortText.ToLower())));
                    }
                    OnPropertyChanged(nameof(SortText));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
            }
        }


        private List<Tasks> _TaskList;
        /// <summary>
        /// Gets and Sets the TaskList.
        /// </summary>
        public List<Tasks> TaskList
        {
            get { return _TaskList; }
            set
            {
                _TaskList = value;
                OnPropertyChanged(nameof(TaskList));
            }
        }



        private bool _IsFinalSubmitted;
        /// <summary>
        /// Gets or Sets IsFinal Submitted
        /// </summary>
        public bool IsFinalSubmitted
        {
            get { return _IsFinalSubmitted; }
            set
            {
                _IsFinalSubmitted = value;
                OnPropertyChanged(nameof(IsFinalSubmitted));
            }
        }


        private Color _StartAMImage;
        /// <summary>
        /// Gets or Sets Start AM image
        /// </summary>
        public Color StartAMImage
        {
            get { return _StartAMImage; }
            set
            {
                _StartAMImage = value;
                OnPropertyChanged(nameof(StartAMImage));
            }
        }


        private Color _StartPMImage;
        /// Gets or Sets Start PM image
        public Color StartPMImage
        {
            get { return _StartPMImage; }
            set
            {
                _StartPMImage = value;
                OnPropertyChanged(nameof(StartPMImage));
            }
        }


        private Color _EndAMImage;
        /// <summary>
        /// Gets or Sets Start AM image
        /// </summary>
        public Color EndAMImage
        {
            get { return _EndAMImage; }
            set
            {
                _EndAMImage = value;
                OnPropertyChanged(nameof(EndAMImage));
            }
        }


        private Color _EndPMImage;
        /// Gets or Sets Start PM image
        public Color EndPMImage
        {
            get { return _EndPMImage; }
            set
            {
                _EndPMImage = value;
                OnPropertyChanged(nameof(EndPMImage));
            }
        }




        private Tasks _TaskSelected;
        /// <summary>
        /// Gets and Sets the Phone Type Selected.
        /// </summary>
        public Tasks TaskSelected
        {
            get { return _TaskSelected; }
            set
            {
                _TaskSelected = value;
                try
                {
                    if (TaskSelected.TaskCode != Resource.TaskInstall && TaskSelected.TaskCode != Resource.TaskService && TaskSelected.TaskCode != Resource.TaskDismantle && TaskSelected.TaskCode != Resource.TaskTravel)
                    {
                        ImgBill = string.Empty;
                    }
                    else
                    {
                        if (Exhibitor != Resource.InternalUse)
                        {
                            ImgBill = Resource.checkImage;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
                OnPropertyChanged(nameof(TaskSelected));
            }
        }

        private Command commandAMorPM;
        /// <summary>
        /// Open command AM or PM events
        /// </summary>
        /// 
        public Command CommandAMorPM
        {
            get
            {
                if (commandAMorPM == null)
                    commandAMorPM = new Command((req) =>
                    {
                        try
                        {
                            if (Convert.ToInt32(req) == 0)
                            {
                                if (StartAMImage == Color.FromHex(Resource.GreenHex))
                                {
                                    StartAMImage = Color.White;
                                    StartPMImage = Color.FromHex(Resource.GreenHex);
                                }
                                else
                                {
                                    StartAMImage = Color.FromHex(Resource.GreenHex);
                                    StartPMImage = Color.White;
                                }
                            }
                            else
                            {
                                if (StartPMImage == Color.FromHex(Resource.GreenHex))
                                {
                                    StartAMImage = Color.FromHex(Resource.GreenHex);
                                    StartPMImage = Color.White;
                                }
                                else
                                {
                                    StartAMImage = Color.White;
                                    StartPMImage = Color.FromHex(Resource.GreenHex);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return commandAMorPM;
            }
        }


        private Command commandEndAMorPM;
        /// <summary>
        /// Open command AM or PM events
        /// </summary>
        /// 
        public Command CommandEndAMorPM
        {
            get
            {
                if (commandEndAMorPM == null)
                    commandEndAMorPM = new Command((req) =>
                    {
                        try
                        {
                            if (Convert.ToInt32(req) == 0)
                            {
                                if (EndAMImage == Color.FromHex(Resource.GreenHex))
                                {
                                    EndAMImage = Color.White;
                                    EndPMImage = Color.FromHex(Resource.GreenHex);
                                }
                                else
                                {
                                    EndAMImage = Color.FromHex(Resource.GreenHex);
                                    EndPMImage = Color.White;
                                }
                            }
                            else
                            {
                                if (EndPMImage == Color.FromHex(Resource.GreenHex))
                                {
                                    EndAMImage = Color.FromHex(Resource.GreenHex);
                                    EndPMImage = Color.White;
                                }
                                else
                                {
                                    EndAMImage = Color.White;
                                    EndPMImage = Color.FromHex(Resource.GreenHex);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return commandEndAMorPM;
            }
        }



        private Command CommandDeleteLabor;
        /// <summary>
        /// Open command Edit Labor Details events
        /// </summary>
        /// 
        public Command CommandDeleteLaborEvents
        {
            get
            {
                if (CommandDeleteLabor == null)
                    CommandDeleteLabor = new Command(async (req) =>
                    {
                        try
                        {
                            bool IsDelete = await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ConfirmationMessage, Resource.Yes, Resource.Cancel);
                            if (IsDelete)
                            {
                                DeleteLabor(Convert.ToString(req));
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandDeleteLabor;
            }
        }

        /// <summary>
        /// Method for Delete Labor Details
        /// </summary>
        /// <param name="ID"></param>
        public async void DeleteLabor(string ID)
        {
            IsBusy = true;
            bool result = await DeleteLaborDetails(ID);
            if (result)
            {
                await GetLaborDetails();
            }
            IsBusy = false;
        }

        private bool _IsEdit;
        /// <summary>
        /// Gets or Sets IsEdit
        /// </summary>
        public bool IsEdit
        {
            get { return _IsEdit; }
            set
            {
                _IsEdit = value;
                OnPropertyChanged(nameof(IsEdit));
            }
        }

        private bool _IsUpdate;
        /// <summary>
        /// Gets or Sets IsUpdate
        /// </summary>
        public bool IsUpdate
        {
            get { return _IsUpdate; }
            set
            {
                _IsUpdate = value;
                OnPropertyChanged(nameof(IsUpdate));
            }
        }

        private string _LaborDetailsID;
        /// <summary>
        /// Gets or Sets Labor Details ID
        /// </summary>
        public string LaborDetailsID
        {
            get { return _LaborDetailsID; }
            set
            {
                _LaborDetailsID = value;
                OnPropertyChanged(nameof(LaborDetailsID));
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
                OnPropertyChanged(nameof(IsSupervisorPresent));
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

        private string _ReviewDate;
        /// <summary>
        /// Gets or Sets Supervisor present
        /// </summary>
        public string ReviewDate
        {
            get { return _ReviewDate; }
            set
            {
                _ReviewDate = value;
                OnPropertyChanged(nameof(ReviewDate));
            }
        }
               


        /// <summary>
        /// Open command Edit Labor Details events
        /// </summary>
        /// 
        public Command CommandEditLaborEvents
        {
            get
            {
                if (CommandEditLabor == null)
                    CommandEditLabor = new Command((req) =>
                    {
                        try
                        {
                            if (req != null)
                            {                               
                                IsEmployeePopup = true;
                                IsEdit = false;
                                IsUpdate = true;
                                LaborDetailModel ObjModel = req as LaborDetailModel;
                                LaborDetailsID = ObjModel.LaborDetailId;
                                SelectedEmpName = ObjModel.EmployeeName;
                                TaskSelected = TaskLists.Where(code => code.TaskDescription.Equals(ObjModel.TaskDescription)).ElementAtOrDefault(0);                             
                                if (!string.IsNullOrEmpty(ObjModel.StartTime))
                                {
                                    var Start = ObjModel.StartTime.ToUpper().Split(':');
                                    StartHours = Start[0];
                                    StartMinutes = Start[1].Substring(0, 2);                                   
                                    if (Start[1].Substring(Start[1].Length - 2, 2) == "AM")
                                    {
                                        StartAMImage = Color.FromHex(Resource.GreenHex);
                                        StartPMImage = Color.White;
                                    }
                                    else
                                    {
                                        StartPMImage = Color.FromHex(Resource.GreenHex);
                                        StartAMImage = Color.White;
                                    }
                                }
                                if (!string.IsNullOrEmpty(ObjModel.EndTime))
                                {
                                    var EndT = ObjModel.EndTime.ToUpper().Split(':');
                                    EndHours = EndT[0];
                                    EndMinutes = EndT[1].Substring(0, 2);
                                    if (EndT[1].Substring(EndT[1].Length - 2, 2) == "AM")
                                    {
                                        EndAMImage = Color.FromHex(Resource.GreenHex);
                                        EndPMImage = Color.White;
                                    }
                                    else
                                    {
                                        EndPMImage = Color.FromHex(Resource.GreenHex);
                                        EndAMImage = Color.White;
                                    }
                                }
                                double Lunch = Convert.ToDouble(ObjModel.LunchTime);
                                int Lun = Convert.ToInt32(Lunch);
                                LaunchTime = Convert.ToString(Lun);
                                if (!string.IsNullOrEmpty(ObjModel.ST))
                                {
                                    double StraightTime = Convert.ToDouble(ObjModel.ST);
                                    ST = Convert.ToString(StraightTime);
                                }
                                if (!string.IsNullOrEmpty(ObjModel.OT))
                                {
                                    double OverTime = Convert.ToDouble(ObjModel.OT);
                                    OT = Convert.ToString(OverTime);
                                }
                                if (!string.IsNullOrEmpty(ObjModel.DT))
                                {
                                    double DoubleTime = Convert.ToDouble(ObjModel.DT);
                                    DT = Convert.ToString(DoubleTime);
                                }
                                if (!string.IsNullOrEmpty(ObjModel.TotalHours))
                                {
                                    double Total = Convert.ToDouble(ObjModel.TotalHours);
                                    TotalTime = Convert.ToString(Total);
                                }
                                if (ObjModel.Billable)
                                {
                                    ImgBill = Resource.checkImage;
                                }
                                else
                                {
                                    ImgBill = string.Empty;
                                }
                                if (ObjModel.Payroll)
                                {
                                    ImgPay = Resource.checkImage;
                                }
                                else
                                {
                                    ImgPay = string.Empty;
                                }
                                if (ObjModel.Partner)
                                {
                                    ImgPar = Resource.checkImage;
                                }
                                else
                                {
                                    ImgPar = string.Empty;
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandEditLabor;
            }
        }


        private Command CommandEmpSelect;

        /// <summary>
        /// Open command Select Employee Name events
        /// </summary>
        /// 
        public Command CommandSelectEmpEvents
        {
            get
            {
                if (CommandEmpSelect == null)
                    CommandEmpSelect = new Command((req) =>
                    {
                        try
                        {
                            IsEmployeeListPopup = false;
                            if (req != null)
                            {
                                EmployeeModel SelectEmp = req as EmployeeModel;
                                SortText = string.Empty;// Convert.ToString(SelectEmp.DisplayName);
                                SelectedEmpName = Convert.ToString(SelectEmp.DisplayName);
                                SelectedEmpID = SelectEmp.EmployeeId;
                                EmpList=new ObservableRangeCollection<EmployeeModel>();
                                EmpList.AddRange(LstEmployeeList);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandEmpSelect;
            }
        }

        /// <summary>
        /// Open command Employee Name events
        /// </summary>
        /// 
        public Command CommandEmpNameEvents
        {
            get
            {
                if (CommandEmpName == null)
                    CommandEmpName = new Command(() =>
                    {
                        try
                        {
                            IsEmployeeListPopup = true;
                            //if (EmpList != null)
                            //{
                            //    IsBusy = true;                                
                            //    await GetEmpListList();
                            //    IsBusy = false;
                            //}

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandEmpName;
            }
        }

        /// <summary>
        /// Open command billable events
        /// </summary>
        /// 
        public Command CommandImgBillEvents
        {
            get
            {
                if (CommandBill == null)
                    CommandBill = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (Exhibitor != Resource.InternalUse)
                                {
                                    if (TaskSelected != null)
                                    {
                                        if (TaskSelected.TaskCode != Resource.TaskInstall && TaskSelected.TaskCode != Resource.TaskService && TaskSelected.TaskCode != Resource.TaskDismantle && TaskSelected.TaskCode != Resource.TaskTravel)
                                        {
                                            ImgBill = string.Empty;
                                        }
                                        else
                                        {
                                            if (ImgBill == Resource.checkImage)
                                            {
                                                ImgBill = string.Empty;
                                            }
                                            else
                                            {
                                                ImgBill = Resource.checkImage;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ImgBill == Resource.checkImage)
                                        {
                                            ImgBill = string.Empty;
                                        }
                                        else
                                        {
                                            ImgBill = Resource.checkImage;
                                        }
                                    }
                                }
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandBill;
            }
        }

        /// <summary>
        /// Open command ImgPay events
        /// </summary>
        /// 
        public Command CommandImgPayEvents
        {
            get
            {
                if (CommandPay == null)
                    CommandPay = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (ImgPay == Resource.checkImage)
                                {
                                    ImgPay = string.Empty;
                                }
                                else
                                {
                                    ImgPay = Resource.checkImage;
                                }
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandPay;
            }
        }



        /// <summary>
        /// Open command Command Add Employee Events
        /// </summary>
        /// 
        public Command CommandAddEmployeeEvents
        {
            get
            {
                if (CommandAddEmployee == null)
                    CommandAddEmployee = new Command((req) =>
                    {
                        try
                        {
                            LaborDetailsID = Resource.Zero;
                            IsEmployeePopup = true;
                            IsEdit = true;
                            IsUpdate = false;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandAddEmployee;
            }
        }

        /// <summary>
        /// Open command ImgPar events
        /// </summary>
        /// 
        public Command CommandImgParEvents
        {
            get
            {
                if (CommandPar == null)
                    CommandPar = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (ImgPar == "check.png")
                                {
                                    ImgPar = string.Empty;
                                }
                                else
                                {
                                    ImgPar = "check.png";
                                }
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandPar;
            }
        }



        private Command CommandCancel;

        /// <summary>
        /// Open command Command Cancel EmpList Popup
        /// </summary>
        /// 
        public Command CommandCancelEmpListPopup
        {
            get
            {
                if (CommandCancel == null)
                    CommandCancel = new Command(() =>
                    {
                        try
                        {
                            IsEmployeeListPopup = false;
                            SortText = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandCancel;
            }
        }


        private Command CommandAddNewLabor;

        /// <summary>
        /// Open command CommandAddNewLaborEvents
        /// </summary>
        /// 
        public Command CommandAddNewLaborEvents
        {
            get
            {
                try
                {
                    if (CommandAddNewLabor == null)
                        CommandAddNewLabor = new Command(async (req) =>
                        {

                            if (IsClicked)
                            {
                                IsClicked = false;
                                bool valid = await LaborValidation();
                                if (valid)
                                {
                                    bool result = await InsertUpdateDetails();
                                    if (Convert.ToString(req) == Resource.AddNew)
                                    {                                                                      
                                        StartHours = string.Empty;
                                        StartMinutes = string.Empty;
                                        EndHours = string.Empty;
                                        EndMinutes = string.Empty;
                                        StartAMImage = Color.FromHex(Resource.GreenHex);
                                        StartPMImage = Color.White;
                                        EndAMImage = Color.FromHex(Resource.GreenHex);
                                        EndPMImage = Color.White;
                                        TasksIndex = 0;
                                        ST = string.Empty;
                                        OT = string.Empty;
                                        DT = string.Empty;
                                        TotalTime = string.Empty;
                                        LaunchTime = string.Empty;
                                        ImgBill = Resource.checkImage;
                                        ImgPay = Resource.checkImage;
                                        SelectedEmpID = string.Empty;
                                        SelectedEmpName = Resource.SelectEmployee;
                                        IsEmployeePopup = false;
                                        IsClicked = true;

                                    }
                                    else
                                    {
                                        IsEmployeePopup = true;
                                        IsClicked = true;
                                        SelectedEmpID = string.Empty;
                                        SelectedEmpName = Resource.SelectEmployee;
                                    }
                                    if (result)
                                    {
                                        RefreshLaborDetails();
                                    }
                                }
                                else
                                {
                                    IsClicked = true;
                                }
                            }

                        });
                    return CommandAddNewLabor;
                }
                catch (Exception ex)
                {
                    IsClicked = true;
                    Debug.WriteLine(ex.StackTrace);
                }
                return CommandAddNewLabor;
            }
        }


        private Command CommandClosePopup;
        //CommandCancelEvents

        /// <summary>
        /// Open command Command Cancel EmpList Popup
        /// </summary>
        /// 
        public Command CommandCancelEvents
        {
            get
            {
                if (CommandClosePopup == null)
                    CommandClosePopup = new Command((req) =>
                    {
                        try
                        {
                            TasksIndex = 0;
                            IsEmployeePopup = false;
                            ClearEmployeePopup();
                            IsUpdate = false;
                            IsEdit = false;

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandClosePopup;
            }
        }


        private Command CommandUpdateLabor;
        /// <summary>
        /// Open command Command Command Update Labor Events
        /// </summary>
        /// 
        public Command CommandUpdateLaborEvents
        {
            get
            {
                if (CommandUpdateLabor == null)
                    CommandUpdateLabor = new Command((req) =>
                    {
                        try
                        {
                            IsEmployeePopup = true;
                            IsEdit = true;
                            IsUpdate = false;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandUpdateLabor;
            }
        }


        /// <summary>
        /// Method for Refresh Record 
        /// </summary>
        public async void RefreshLaborDetails()
        {
            IsBusy = true;
            await GetLaborDetails();
            IsBusy = false;
        }


        /// <summary>
        /// Method for Clear Employee Details
        /// </summary>
        public void ClearEmployeePopup()
        {
          
            StartHours = string.Empty;
            StartMinutes = string.Empty;
            EndHours = string.Empty;
            EndMinutes = string.Empty;
            StartAMImage = Color.FromHex(Resource.GreenHex);
            StartPMImage = Color.White;
            EndAMImage = Color.FromHex(Resource.GreenHex);
            EndPMImage = Color.White;
            TasksIndex = 0;
            ST = string.Empty;
            OT = string.Empty;
            DT = string.Empty;
            TotalTime = string.Empty;
            LaunchTime = string.Empty;
            ImgBill = Resource.checkImage;
            ImgPay = Resource.checkImage;
            SelectedEmpID = string.Empty;
            SelectedEmpName = Resource.SelectEmployee;
            // IsEmployeePopup = false;
        }

        /// <summary>
        /// Method for Insert/Update LaborDetails
        /// </summary>
        public async Task<bool> InsertUpdateDetails()
        {
            bool billable, payroll, partner, LblMess = false;
            string SelectStartAMPM, SelectEndAMPM = string.Empty;
            try
            {
                IsBusy = true;
                if (ImgBill == Resource.checkImage)
                {
                    billable = true;
                }
                else
                {
                    billable = false;
                }
                if (ImgPar == Resource.checkImage)
                {
                    partner = true;
                }
                else
                {
                    partner = false;
                }
                if (ImgPay == Resource.checkImage)
                {
                    payroll = true;
                }
                else
                {
                    payroll = false;
                }
                if (StartAMImage == Color.FromHex(Resource.GreenHex))
                {
                    SelectStartAMPM = "AM";
                }
                else
                {
                    SelectStartAMPM = "PM";
                }
                if (EndAMImage == Color.FromHex(Resource.GreenHex))
                {
                    SelectEndAMPM = "AM";
                }
                else
                {
                    SelectEndAMPM = "PM";
                }               
                string SelectSTime = StartHours + ":" + StartMinutes + " " + SelectStartAMPM;// stime.ToString(Resource.TimeFormat); // It will give format "03:00 AM"               
                string SelectETime = EndHours + ":" + EndMinutes + " " + SelectEndAMPM;// etime.ToString(Resource.TimeFormat); // It will give format "03:00 AM"
                LaborInsertUpdateModel LbrObj = new LaborInsertUpdateModel()
                {
                    Method = Resource.MethodPutBoothLaborDetails,
                    LaborDetailId = LaborDetailsID,
                    BoothcardId = Boothcard,
                    EmployeeNumber = SelectedEmpID,
                    EmployeeName = SelectedEmpName,
                    Task = TaskSelected.TaskCode,
                    TaskDescription = TaskSelected.TaskDescription,
                    Billable = billable,
                    Payroll = payroll,
                    Partner = partner,
                    StartTime = SelectSTime,
                    EndTime = SelectETime,
                    LunchHours = LaunchTime,
                    STHours = ST,
                    OTHours = OT,
                    DTHours = DT
                };
                LblMess = await UpdateInsertLaborDetails(LbrObj);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.StackTrace);
            }
            return LblMess;
        }


        private Command CommandSubmitted;
        /// <summary>
        /// Command for Save and Submitted Events
        /// </summary>
        public Command CommandSubmittedEvents
        {
            get
            {
                if (CommandSubmitted == null)
                    CommandSubmitted = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (!string.IsNullOrEmpty(EditorNote))
                                {
                                    if (Convert.ToString(req) == Resource.SaveAll)
                                    {
                                        UpdateHeader(0);
                                    }
                                    else
                                    {
                                        UpdateHeader(1);
                                    }
                                }
                                else
                                {
                                    App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.EnterNote, Resource.OK);
                                }
                                IsClicked = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandSubmitted;
            }
        }


        /// <summary>
        /// Constructior
        /// </summary>
        public BoothCardDetailVM()
        {
            try
            {
                StartAMImage = Color.FromHex(Resource.GreenHex);
                StartPMImage = Color.White;
                EndAMImage = Color.FromHex(Resource.GreenHex);
                EndPMImage = Color.White;

                LstBoothHeader = new List<BoothHeader>();
                PcardImage = string.Empty;
                IsFinalSubmitted = Views.BoothCardDetails.IsSubmited;
                SelectedEmpName = Resource.SelectEmployee;
                ImgBill = Resource.checkImage;
                ImgPay = Resource.checkImage;
                TaskList = new List<Tasks>();
                EmpList = new ObservableRangeCollection<EmployeeModel>();               
                LstEmployeeList = new ObservableRangeCollection<EmployeeModel>();
                LstLaborDetails = new ObservableRangeCollection<LaborDetailModel>();
                TaskLists = new ObservableRangeCollection<Tasks>();
                LstEquipment = new ObservableRangeCollection<EquipmentModel>();
                LstMaterial = new ObservableRangeCollection<MaterialModel>();
                MaterialUsed = new ObservableRangeCollection<Models.MaterialUsed>();
                EquipmentUsed = new ObservableRangeCollection<Models.Equipment>();
                BindMaterial lstMaterialUsed = new Models.BindMaterial();
                BindEquipment lstEquip = new BindEquipment();
               // MaterialUsed = lstMaterialUsed.materialUsed;
               // EquipmentUsed = lstEquip.EquipmentUsed;
                MaterialUsedSelected = new Models.MaterialUsed();
                Get();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method For Get
        /// </summary>
        public async void Get()
        {
            IsMgrORLeadManServices ObjService = new IsMgrORLeadManServices();
            try
            {
                IsBusy = true;
                bool result = await ObjService.IsBoothcardLeadman(Views.BoothCardDetails.ProjID);
                if (result)
                {
                    AdminType = 0;  
                    if(!Views.BoothCardDetails.IsReviewed)
                    {
                        IsFinalSubmitted = false;
                       // if(!Views.BoothCardDetails.IsBoothSign)
                       // {
                            IsReport = true;
                       // }
                    }
                }
                else
                {
                    bool resultSec = await ObjService.IsBoothcardMgr(Views.BoothCardDetails.ProjID);
                    if (resultSec)
                    {
                        AdminType = 1;                      
                    }       
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, "No Permission for this Job(" + Views.BoothCardDetails.ProjID + ").", Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
                
                await GetBoothHeader();
                if (IsFinalSubmitted)
                {
                    await GetTaskList();
                    await GetEmpListList();
                }
                IsBusy = false;
            }
            catch(Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.StackTrace);
            }

        }

        /// <summary>
        /// Method For Get Booth header
        /// </summary>
        /// <returns></returns>
        public async Task GetBoothHeader()
        {

            LstBoothHeader = new List<BoothHeader>();
            BTCHeaderService ServiceProviderShow = new BTCHeaderService();
            try
            {

                LstBoothHeader = await ServiceProviderShow.GetBoothHeader(Views.BoothCardDetails.BoothNumber);
                if (LstBoothHeader != null)
                {
                    if (LstBoothHeader.Count > 0)
                    {
                        foreach (var item in LstBoothHeader)
                        {
                            Boothcard = item.BoothcardId;
                            IsSupervisorPresent = item.SupervisorPresent;
                            if (IsSupervisorPresent)
                            {
                                SupervisorPresent = Resource.RdChecked;
                            }
                            else
                            {
                                SupervisorPresent = Resource.RdUnChecked;
                            }
                            if (!string.IsNullOrEmpty(item.WorkDate))
                            {
                                DateTime obj = new DateTime();
                                obj = Convert.ToDateTime(item.WorkDate);
                                string WorkDate1 = obj.ToString(Resource.DateFormat);
                                if (WorkDate1 != Resource.BlankDate)
                                {
                                    WorkDate = obj.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    WorkDate = Resource.NA;
                                }

                            }
                            else
                            {
                                WorkDate = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ProjectNum))
                            {
                                ProjectId = item.ProjectNum;
                            }
                            else
                            {
                                ProjectId = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.Exhibitor))
                            {
                                Exhibitor = item.Exhibitor;
                                if (Exhibitor == Resource.InternalUse)
                                {
                                    ImgBill = string.Empty;
                                }
                            }
                            else
                            {
                                Exhibitor = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ShowName))
                            {
                                Show = item.ShowName;
                            }
                            else
                            {
                                Show = Resource.NAWithHash;
                            }

                            if (!string.IsNullOrEmpty(item.BoothNum))
                            {
                                Booth = item.BoothNum;
                            }
                            else
                            {
                                Booth = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.AccountExec))
                            {
                                AccountExc = item.AccountExec;
                            }
                            else
                            {
                                AccountExc = Resource.NAWithHash;
                            }

                            if (!string.IsNullOrEmpty(item.BoothcardId))
                            {
                                Boothcard = item.BoothcardId;
                            }
                            else
                            {
                                Boothcard = Resource.NAWithHash;
                            }
                            if (!string.IsNullOrEmpty(item.ShowCity))
                            {
                                ShowCity = item.ShowCity;
                            }
                            if (!string.IsNullOrEmpty(item.RegionalManager))
                            {
                                RegionalManager = item.RegionalManager;
                            }
                            if (!string.IsNullOrEmpty(item.Leadman))
                            {
                                Leadman = item.Leadman;
                            }
                            if (!string.IsNullOrEmpty(item.SupervisorName))
                            {
                                SupervisorName = item.SupervisorName;
                            }
                            if (!string.IsNullOrEmpty(item.SubmittedBy))
                            {
                                SubmittedBy = item.SubmittedByDisplayName;
                            }
                            if (!string.IsNullOrEmpty(item.DateSubmitted))
                            {
                                DateTime obj = new DateTime();
                                obj = Convert.ToDateTime(item.DateSubmitted);
                                string SubmitDate = obj.ToString(Resource.DateFormat);
                                if (SubmitDate != Resource.BlankDate)
                                {
                                    DateSubmitted = obj.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    DateSubmitted = Resource.NA;
                                }

                            }
                            else
                            {
                                DateSubmitted = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedDate))
                            {
                                DateTime objReview = new DateTime();
                                objReview = Convert.ToDateTime(item.ReviewSubmittedDate);
                                string _ReviewDate = objReview.ToString(Resource.DateFormat);
                                if (_ReviewDate != Resource.BlankDate)
                                {
                                    ReviewDate = objReview.ToString(Resource.DateFormat);
                                }
                                else
                                {
                                    ReviewDate = Resource.NA;
                                }
                            }
                            else
                            {
                                ReviewDate = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedByDisplayName))
                            {
                                ReviewedBy = item.ReviewSubmittedByDisplayName;
                            }
                            else
                            {
                                ReviewedBy = Resource.NA;
                            }
                            if (!string.IsNullOrEmpty(item.ReviewSubmittedBy))
                            {
                                var splitrev = item.ReviewSubmittedBy.Split('\\');
                                ReviewByID = splitrev[1];
                            }
                            else
                            {
                                ReviewByID = string.Empty;
                            }
                            if (!string.IsNullOrEmpty(item.PreparedBy))
                            {
                                var splitdata = item.PreparedBy.Split('\\');
                                PreparedByID = splitdata[1];
                            }
                            else
                            {
                                PreparedByID = PreparedBy;
                            }
                           
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


        /// <summary>
        /// Method For Get TaskList
        /// </summary>
        /// <returns></returns>
        public async Task GetTaskList()
        {

            List<Tasks> LstTask = new List<Tasks>();
            TaskServices ServiceProvider = new TaskServices();
            try
            {
                LstTask = await ServiceProvider.GetTasks();
                if (LstTask != null)
                {
                    if (LstTask.Count > 0)
                    {

                        foreach (var item in LstTask)
                        {
                            Tasks ObjTask = new Tasks();
                            ObjTask.ID = item.ID;
                            ObjTask.TaskCode = item.TaskCode;
                            ObjTask.TaskDescription = item.TaskDescription;
                            ObjTask.SortOrder = item.SortOrder;
                            ObjTask.Timesheets = item.Timesheets;
                            ObjTask.Billable = item.Billable;
                            TaskLists.Add(ObjTask);
                        }
                        Tasks Obj = new Tasks();
                        Obj.ID = Resource.Zero;
                        Obj.TaskCode = Resource.Zero;
                        Obj.TaskDescription = Resource.SelectTask;
                        Obj.SortOrder = Resource.Zero;
                        Obj.Timesheets = false;
                        Obj.Billable = false;
                        TaskLists.Insert(0, Obj);
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
        /// Method For Get Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task GetLaborDetails()
        {

            List<LaborDetailModel> LstLabor = new List<LaborDetailModel>();
            LaborDetailServices ServiceProvider = new LaborDetailServices();
            try
            {
                LstLabor = await ServiceProvider.GetLaborDetails(Views.BoothCardDetails.BoothNumber);
                LstLaborDetails = new ObservableRangeCollection<LaborDetailModel>();
                if (LstLabor != null)
                {
                    if (LstLabor.Count > 0)
                    {
                        foreach (var item in LstLabor)
                        {
                            LaborDetailModel ObjLabor = new LaborDetailModel();
                            ObjLabor.IsEdit = IsFinalSubmitted;
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
                            ObjLabor.DT = item.DT;
                            ObjLabor.ST = item.ST;
                            ObjLabor.OT = item.OT;
                            ObjLabor.StartTime = item.StartTime;
                            ObjLabor.EndTime = item.EndTime;
                            ObjLabor.LunchTime = item.LunchTime;
                            ObjLabor.TotalHours = item.TotalHours;
                            ObjLabor.EditLabor = CommandEditLaborEvents;
                            ObjLabor.DeleteLabor = CommandDeleteLaborEvents;
                            ObjLabor.Repeat = RepeatLaborDetailsEvents;
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
        /// Method For Get Employee List
        /// </summary>
        /// <returns></returns>
        public async Task GetEmpListList()
        {

            List<EmployeeModel> LstEmp = new List<EmployeeModel>();
            EmployeeServices ServiceProvider = new EmployeeServices();
            try
            {
                LstEmp = await ServiceProvider.GetEmployee();
                if (LstEmp != null)
                {
                    if (LstEmp.Count > 0)
                    {
                        foreach (var item in LstEmp)
                        {
                            EmployeeModel ObjEmp = new EmployeeModel();
                            ObjEmp.EmployeeId = item.EmployeeId;
                            ObjEmp.EmployeeMobilePhone = item.EmployeeMobilePhone;
                            ObjEmp.EmployeeName = item.EmployeeName;
                            ObjEmp.EmployeeState = item.EmployeeState;
                            ObjEmp.EmployeeYearOfBirth = item.EmployeeYearOfBirth;
                            ObjEmp.DisplayName = item.EmployeeName + " " + "[" + item.EmployeeState + "-" + item.EmployeeYearOfBirth + "]";
                            ObjEmp.EmpTabed = CommandSelectEmpEvents;
                            EmpList.Add(ObjEmp);
                            LstEmployeeList.Add(ObjEmp);
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

       

        /// <summary>
        /// Method For Insert Update Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateInsertLaborDetails(LaborInsertUpdateModel LaborObj)
        {
            bool Labormess = false;
            LaborInsertUpdateServices ServiceProvider = new LaborInsertUpdateServices();
            try
            {
                string result = await ServiceProvider.InsertUpdateLaborDetails(LaborObj);
                if (!string.IsNullOrEmpty(result))
                {
                    Labormess = true;
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.InsertUpdateSuccess, Resource.OK);
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
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
            return Labormess;
        }

        /// <summary>
        /// Method For Insert Update Labor Details
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteLaborDetails(string LaborDetailsId)
        {
            bool message = false;
            LaborInsertUpdateServices ServiceProvider = new LaborInsertUpdateServices();
            try
            {
                string result = await ServiceProvider.DeleteLaborDetails(LaborDetailsId);
                if (!string.IsNullOrEmpty(result))
                {
                    message = true;
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.DeleteSuccess, Resource.OK);
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
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
            return message;
        }


        /// <summary>
        /// Method for Update Header
        /// </summary>
        /// <param name="SaveOrSubmit"></param>
        public async void UpdateHeader(int SaveOrSubmit)
        {
            try
            {
                IsBusy = true;
                await SaveOrFinalSubmitBoothHeader(SaveOrSubmit);
                if (SaveOrSubmit != 0)
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                    if (AdminType != 1)
                    {
                        await App.Current.MainPage.Navigation.PushModalAsync(new Views.BoothcardReport(LstBoothHeader, EditorNote));
                    }
                    else
                    {
                        if(AdminType != 0)
                        {
                            if (Views.BoothCardDetails.IsBoothSign)
                            {
                                await App.Current.MainPage.Navigation.PushModalAsync(new Views.BoothcardReport(LstBoothHeader, EditorNote));
                            }
                        }
                    }
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private int _AdminType;

        public int AdminType
        {
            get { return _AdminType; }
            set
            {
                _AdminType = value;
                OnPropertyChanged(nameof(AdminType));
            }
        }

        /// <summary>
        /// Method for Update Booth Header Details
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>

        public async Task SaveOrFinalSubmitBoothHeader(int Type)
        {

            UpdateBoothHeaderData ServiceProvider = new UpdateBoothHeaderData();
            try
            {
                string result = string.Empty;
                if (Type == 0)
                {
                    UpdateHeaderRequest ObjBooth = new UpdateHeaderRequest()
                    {
                        Method = Resource.MethodUpdateBoothHeaderData,
                        BoothcardId = Boothcard,
                        PreparedBy = PreparedByID,
                        SubmittedBy = (Type == 0) ? string.Empty : UserAccounts.LoginUserID,
                        WorkDate = WorkDate,
                        ProjectNum = ProjectId,
                        Exhibitor = Exhibitor,
                        BoothNum = Booth,
                        ShowName = Show,
                        ShowCity = ShowCity,
                        AccountExec = AccountExc,
                        Leadman = Leadman,
                        RegionalManager = RegionalManager,
                        DateSubmitted = (Type == 0) ? string.Empty : DateTime.Now.ToString(Resource.DateFormat),
                        SupervisorName = SupervisorName,
                        SupervisorPresent = IsSupervisorPresent,
                        Note = EditorNote,
                        ReviewSubmittedBy = ReviewByID,
                        ReviewSubmittedDate= (ReviewDate == Resource.NA) ? string.Empty : ReviewDate

                    };
                     result = await ServiceProvider.UpdateBoothHeader(ObjBooth);
                }
                else
                {
                    UpdateHeaderRequest ObjBooth = new UpdateHeaderRequest()
                    {
                        Method = Resource.MethodUpdateBoothHeaderData,
                        BoothcardId = Boothcard,
                        PreparedBy = PreparedByID,
                        SubmittedBy = (AdminType == 0) ? string.Empty : UserAccounts.LoginUserID,
                        ReviewSubmittedBy = (AdminType == 0) ? UserAccounts.LoginUserID : (ReviewByID==string.Empty)?UserAccounts.LoginUserID: ReviewByID,
                        WorkDate = WorkDate,
                        ProjectNum = ProjectId,
                        Exhibitor = Exhibitor,
                        BoothNum = Booth,
                        ShowName = Show,
                        ShowCity = ShowCity,
                        AccountExec = AccountExc,
                        Leadman = Leadman,
                        RegionalManager = RegionalManager,
                        DateSubmitted = (AdminType == 0) ? string.Empty : DateTime.Now.ToString(Resource.DateFormat),
                        ReviewSubmittedDate = (AdminType == 0) ? DateTime.Now.ToString(Resource.DateFormat) :(ReviewDate==Resource.NA)? DateTime.Now.ToString(Resource.DateFormat) : ReviewDate,
                        SupervisorName = SupervisorName,
                        SupervisorPresent = IsSupervisorPresent,
                        Note = EditorNote
                    };
                     result = await ServiceProvider.UpdateBoothHeader(ObjBooth);
                }

               
                if (!string.IsNullOrEmpty(result))
                {
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.SaveSuccess, Resource.OK);
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
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

        private Command GenerateReport;
        /// <summary>
        /// Command For Generate Reports
        /// </summary>
        public Command GenerateReportEvents
        {
            get
            {
                if (GenerateReport == null)
                    GenerateReport = new Command(async() =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (Device.RuntimePlatform == Device.Android)
                                {
                                    if (ScreenHeightWidth.CurrentSDKVersion >= 23)
                                    {
                                        if (!GrantAndroidPermission.CheckPermissions((int)AndroidPermissionName.Storage))
                                        {
                                            await App.Current.MainPage.DisplayAlert(Resource.Permission, Resource.PermissionMessgae, Resource.OK);
                                            GrantAndroidPermission.GrantPermissions((int)AndroidPermissionName.Storage);
                                        }
                                        if (GrantAndroidPermission.CheckPermissions((int)AndroidPermissionName.Storage))
                                        {
                                            IsBusy = true;
                                            await GetBoothcardReport();
                                            IsBusy = false;
                                        }
                                    }
                                    else
                                    {
                                        IsBusy = true;
                                        await GetBoothcardReport();
                                        IsBusy = false;
                                    }
                                }
                                else
                                {
                                    IsBusy = true;
                                    await GetBoothcardReport();
                                    IsBusy = false;
                                }
                                IsClicked = true;
                            }

                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            IsBusy = false;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return GenerateReport;
            }
        }

        private Command RepeatLaborDetails;
        /// <summary>
        /// Open command Edit Labor Details events
        /// </summary>
        /// 
        public Command RepeatLaborDetailsEvents
        {
            get
            {
                if (RepeatLaborDetails == null)
                    RepeatLaborDetails = new Command((req) =>
                    {
                        try
                        {
                            if (req != null)
                            {
                                IsEmployeePopup = true;
                                IsEdit = true;
                                IsUpdate = false;
                                LaborDetailModel ObjModel = req as LaborDetailModel;
                                LaborDetailsID = Resource.Zero;
                                SelectedEmpName = Resource.SelectEmployee;
                                SelectedEmpID = string.Empty;
                                TaskSelected = TaskLists.Where(code => code.TaskDescription.Equals(ObjModel.TaskDescription)).ElementAtOrDefault(0);                                                            
                                double Lunch = Convert.ToDouble(ObjModel.LunchTime);
                                int Lun = Convert.ToInt32(Lunch);
                                LaunchTime = Convert.ToString(Lun);
                                if (!string.IsNullOrEmpty(ObjModel.ST))
                                {
                                    double StraightTime = Convert.ToDouble(ObjModel.ST);
                                    ST = Convert.ToString(StraightTime);
                                }
                                if (!string.IsNullOrEmpty(ObjModel.OT))
                                {
                                    double OverTime = Convert.ToDouble(ObjModel.OT);
                                    OT = Convert.ToString(OverTime);
                                }
                                if (!string.IsNullOrEmpty(ObjModel.DT))
                                {
                                    double DoubleTime = Convert.ToDouble(ObjModel.DT);
                                    DT = Convert.ToString(DoubleTime);
                                }
                                if (!string.IsNullOrEmpty(ObjModel.TotalHours))
                                {
                                    double Total = Convert.ToDouble(ObjModel.TotalHours);
                                    TotalTime = Convert.ToString(Total);
                                }
                                if (ObjModel.Billable)
                                {
                                    ImgBill = Resource.checkImage;
                                }
                                else
                                {
                                    ImgBill = string.Empty;
                                }
                                if (ObjModel.Payroll)
                                {
                                    ImgPay = Resource.checkImage;
                                }
                                else
                                {
                                    ImgPay = string.Empty;
                                }
                                if (ObjModel.Partner)
                                {
                                    ImgPar = Resource.checkImage;
                                }
                                else
                                {
                                    ImgPar = string.Empty;
                                }

                                if (!string.IsNullOrEmpty(ObjModel.StartTime))
                                {
                                    var Start = ObjModel.StartTime.ToUpper().Split(':');
                                    StartHours = Start[0];
                                    StartMinutes = Start[1].Substring(0, 2);
                                    if (Start[1].Substring(Start[1].Length - 2, 2) == "AM")
                                    {
                                        StartAMImage = Color.FromHex(Resource.GreenHex);
                                        StartPMImage = Color.White;
                                    }
                                    else
                                    {
                                        StartPMImage = Color.FromHex(Resource.GreenHex);
                                        StartAMImage = Color.White;
                                    }
                                }
                                if (!string.IsNullOrEmpty(ObjModel.EndTime))
                                {
                                    var EndT = ObjModel.EndTime.ToUpper().Split(':');
                                    EndHours = EndT[0];
                                    EndMinutes = EndT[1].Substring(0, 2);
                                    if (EndT[1].Substring(EndT[1].Length - 2, 2) == "AM")
                                    {
                                        EndAMImage = Color.FromHex(Resource.GreenHex);
                                        EndPMImage = Color.White;
                                    }
                                    else
                                    {
                                        EndPMImage = Color.FromHex(Resource.GreenHex);
                                        EndAMImage = Color.White;
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return RepeatLaborDetails;
            }
        }

        /// <summary>
        /// Method for Labor Validation
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LaborValidation()
        {
            bool message = true;
            try
            {
                List<string> lst = new List<string>();
                lst.Clear();
                if (SelectedEmpName == Resource.SelectEmployee)
                {
                    lst.Add(Resource.ValidEmployee);
                }
                if (TaskSelected != null)
                {
                    if (TaskSelected.TaskDescription == Resource.SelectTask)
                    {
                        lst.Add(Resource.ValidTask);
                    }
                }
                else
                {
                    lst.Add(Resource.ValidTask);
                }
                if (string.IsNullOrEmpty(StartHours))
                {
                    lst.Add(Resource.StartHours);
                }
                if (string.IsNullOrEmpty(StartMinutes))
                {
                    lst.Add(Resource.StartMinute);
                }
                if (string.IsNullOrEmpty(EndHours))
                {
                    lst.Add(Resource.EndHour);
                }
                if (string.IsNullOrEmpty(EndMinutes))
                {
                    lst.Add(Resource.EndMinute);
                }
                if (string.IsNullOrEmpty(LaunchTime))
                {
                    lst.Add(Resource.ValidLT);
                }
                if (string.IsNullOrEmpty(ST))
                {
                    lst.Add(Resource.ValidST);
                }
                if (string.IsNullOrEmpty(OT))
                {
                    lst.Add(Resource.ValidOT);
                }
                if (string.IsNullOrEmpty(DT))
                {
                    lst.Add(Resource.ValidDT);
                }
                if (lst.Count > 0)
                {
                    int lstcount = lst.Count;
                    message = false;
                    string value = string.Join(", ", lst.Take(lst.Count - 1)) + (lst.Count <= 1 ? "" : " & ") + lst.LastOrDefault();
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, "Please enter" + " " + value + ".", Resource.OK);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return message;
        }




        /// <summary>
        /// Method For Open Report
        /// </summary>
        /// <param name="Profile"></param>
        public async void OpenReport(byte[] Profile)
        {
            try
            {
                DependencyService.Get<DependencyServices.IDocumentManager>().SaveFile(Profile, Resource.PDFName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method for GetBoothcard Report
        /// </summary>
        /// <returns></returns>
        public async Task GetBoothcardReport()
        {

            List<SignResponseModel> LstSignResponse = new List<SignResponseModel>();
            BoothReportServices ServiceProvider = new BoothReportServices();
            try
            {
                LstSignResponse = await ServiceProvider.GetBoothcardReport(ProjectId, Boothcard);
                if (LstSignResponse != null)
                {
                    if (LstSignResponse.Count > 0)
                    {
                        foreach (var item in LstSignResponse)
                        {
                            byte[] SummaryReport = null;
                            SummaryReport = System.Convert.FromBase64String(item.BoothcardSummary);
                            OpenReport(SummaryReport);
                        }

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NotFound, Resource.OK);                       
                    }
                }
                else
                {
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

        //**************************************************************Add Material and Equipment******************************************************\\



        private string _NewMaterial;

        public string NewMaterial
        {
            get { return _NewMaterial; }
            set
            {
                _NewMaterial = value;
                OnPropertyChanged(nameof(NewMaterial));
            }
        }


        private string _NewEquipment;

        public string NewEquipment
        {
            get { return _NewEquipment; }
            set
            {
                _NewEquipment = value;
                OnPropertyChanged(nameof(NewEquipment));
            }
        }

        private bool _IsMaterialType;

        public bool IsMaterialType
        {
            get { return _IsMaterialType; }
            set { _IsMaterialType = value;
                OnPropertyChanged(nameof(IsMaterialType));
            }
        }

        private bool _IsEquipmentType;

        public bool IsEquipmentType
        {
            get { return _IsEquipmentType; }
            set
            {
                _IsEquipmentType = value;
                OnPropertyChanged(nameof(IsEquipmentType));
            }
        }
        


        private bool _IsEquipmentPopup;
        /// <summary>
        /// Get or Set IsEquipmentPopup
        /// </summary>
        public bool IsEquipmentPopup
        {
            get { return _IsEquipmentPopup; }
            set
            {
                _IsEquipmentPopup = value;
                OnPropertyChanged(nameof(IsEquipmentPopup));
            }
        }

        private bool _IsMaterialPopup;
        /// <summary>
        /// Get or Set IsMaterialPopup
        /// </summary>
        public bool IsMaterialPopup
        {
            get { return _IsMaterialPopup; }
            set
            {
                _IsMaterialPopup = value;
                OnPropertyChanged(nameof(IsMaterialPopup));
            }
        }




        private string _Material;
        /// <summary>
        /// Get or Set Material
        /// </summary>
        public string Material
        {
            get { return _Material; }
            set
            {
                _Material = value;
                OnPropertyChanged(nameof(Material));
            }
        }

        private string _Unit;
        /// <summary>
        /// Get or Set Unit
        /// </summary>
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        private string _Quantity;
        /// <summary>
        /// Get or Set Quantity
        /// </summary>
        public string Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private string _Category;
        /// <summary>
        /// Get or Set Category
        /// </summary>
        public string Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private string _StoreName;
        /// <summary>
        /// Get or Set Store Name
        /// </summary>
        public string StoreName
        {
            get { return _StoreName; }
            set
            {
                _StoreName = value;
                OnPropertyChanged(nameof(StoreName));
            }
        }

        private string _Cost;
        /// <summary>
        /// Get or Set Cost
        /// </summary>
        public string Cost
        {
            get { return _Cost; }
            set
            {
                _Cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }


        private string _PcardImage;
        /// <summary>
        /// Get or Set PcardImage
        /// </summary>
        public string PcardImage
        {
            get { return _PcardImage; }
            set
            {
                _PcardImage = value;
                OnPropertyChanged(nameof(PcardImage));
            }
        }


        private bool _IsMaterialEquipment;
        /// <summary>
        /// Get or Set IsMaterialEquipment
        /// </summary>
        public bool IsMaterialEquipment
        {
            get { return _IsMaterialEquipment; }
            set
            {
                _IsMaterialEquipment = value;
                OnPropertyChanged(nameof(IsMaterialEquipment));
            }
        }


        private string _Equipment;

        public string Equipment
        {
            get { return _Equipment; }
            set
            {
                _Equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }


        private string _EquUnit;

        public string EquUnit
        {
            get { return _EquUnit; }
            set
            {
                _EquUnit = value;
                OnPropertyChanged(nameof(EquUnit));
            }
        }

        private string _EquQuantity;

        public string EquQuantity
        {
            get { return _EquQuantity; }
            set
            {
                _EquQuantity = value;
                OnPropertyChanged(nameof(EquQuantity));
            }
        }

        private string _MaterialId;

        public string MaterialId
        {
            get { return _MaterialId; }
            set
            {
                _MaterialId = value;
                OnPropertyChanged(nameof(MaterialId));
            }
        }



        private bool _IsUpdateMaterial;

        public bool IsUpdateMaterial
        {
            get { return _IsUpdateMaterial; }
            set
            {
                _IsUpdateMaterial = value;
                OnPropertyChanged(nameof(IsUpdateMaterial));
            }
        }

        private bool _IsAddMaterial;

        public bool IsAddMaterial
        {
            get { return _IsAddMaterial; }
            set
            {
                _IsAddMaterial = value;
                OnPropertyChanged(nameof(IsAddMaterial));
            }
        }


        private string _EquipmentId;

        public string EquipmentId
        {
            get { return _EquipmentId; }
            set
            {
                _EquipmentId = value;
                OnPropertyChanged(nameof(IsAddMaterial));
            }
        }

        private bool _IsUpdateEquipment;

        public bool IsUpdateEquipment
        {
            get { return _IsUpdateEquipment; }
            set
            {
                _IsUpdateEquipment = value;
                OnPropertyChanged(nameof(IsUpdateEquipment));
            }
        }

        private bool _IsAddEquipment;

        public bool IsAddEquipment
        {
            get { return _IsAddEquipment; }
            set
            {
                _IsAddEquipment = value;
                OnPropertyChanged(nameof(IsAddEquipment));
            }
        }


        private Command CommandPcard;

        /// <summary>
        /// Command for Pcard Events
        /// </summary>
        public Command CommandCommandPcardEvents
        {
            get
            {
                if (CommandPcard == null)
                    CommandPcard = new Command((req) =>
                    {
                        try
                        {
                            if (PcardImage == Resource.checkImage)
                            {
                                PcardImage = string.Empty;
                            }
                            else
                            {
                                PcardImage = Resource.checkImage;
                            }
                        }
                        catch (Exception ex)
                        {

                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandPcard;
            }
        }



        private Command CommandMaterialCancel;

        /// <summary>
        /// Command for Cancel Material Events
        /// </summary>
        public Command CommandMaterialCancelEvents
        {
            get
            {
                if (CommandMaterialCancel == null)
                    CommandMaterialCancel = new Command((req) =>
                    {
                        try
                        {
                            if (PcardImage == Resource.checkImage)
                            {
                                PcardImage = string.Empty;
                            }
                            else
                            {
                                PcardImage = Resource.checkImage;
                            }
                        }
                        catch (Exception ex)
                        {

                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandMaterialCancel;
            }
        }

        /// <summary>
        /// Method for GetEquipment And Material
        /// </summary>
        public async void GetEquipmentAndMaterial()
        {
            try
            {
                IsBusy = true;
                if (IsFinalSubmitted)
                {
                    if (EquipmentUsed.Count <= 0)
                    {
                        await GetEquipmentPkr();
                        await GetMaterialPkr();
                    }
                }
                await GetMaterial();
                await GetEquipment();
                IsBusy = false;
            }
            catch(Exception ex)
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
            EquipmentServices EquipmentService = new EquipmentServices();
            List<EquipmentModel> ObjEquipmentlst = new List<EquipmentModel>();
            try
            {
                ObjEquipmentlst = await EquipmentService.GetBoothEquipment(Boothcard);
                LstEquipment = new ObservableRangeCollection<EquipmentModel>();
                if (ObjEquipmentlst != null)
                {
                    if (ObjEquipmentlst.Count > 0)
                    {

                        foreach (var item in ObjEquipmentlst)
                        {
                            EquipmentModel ObjEquipmentModel = new EquipmentModel();
                            ObjEquipmentModel.BoothcardId = item.BoothcardId;
                            ObjEquipmentModel.CreatedDate = item.CreatedDate;
                            ObjEquipmentModel.ModifiedDate = item.ModifiedDate;
                            ObjEquipmentModel.EquipmentId = item.EquipmentId;
                            ObjEquipmentModel.Equipment = item.Equipment;
                            ObjEquipmentModel.Quantity = item.Quantity;
                            ObjEquipmentModel.Unit = item.Unit;
                            ObjEquipmentModel.DeleteCommand = CommandDeleteEquipmentEvents;
                            ObjEquipmentModel.EditCommand = CommandEditEquipmentEvents;
                            ObjEquipmentModel.IsEdit = IsFinalSubmitted;
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
            MaterialServices MaterialService = new MaterialServices();
            List<MaterialModel> ObjMateriallst = new List<MaterialModel>();
            try
            {                
                ObjMateriallst = await MaterialService.GetBoothMaterials(Boothcard);
                LstMaterial = new ObservableRangeCollection<MaterialModel>();
                if (ObjMateriallst != null)
                {
                    if (ObjMateriallst.Count > 0)
                    {

                        foreach (var item in ObjMateriallst)
                        {
                            MaterialModel ObjMaterialModel = new MaterialModel();
                            ObjMaterialModel.IsEdit = IsFinalSubmitted;
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
                            ObjMaterialModel.DeleteCommand = CommandDeleteMaterialEvents;
                            ObjMaterialModel.EditCommand = CommandEditMaterialEvents;
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

        private Command DeleteMaterial;

        /// <summary>
        /// Command for Delete Material Events
        /// </summary>
        public Command CommandDeleteMaterialEvents
        {
            get
            {
                if (DeleteMaterial == null)
                    DeleteMaterial = new Command(async (req) =>
                    {
                        try
                        {
                            if (req != null)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    bool isConfirm = await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ConfirmationMessage, Resource.Yes, Resource.Cancel);
                                    if (isConfirm)
                                    {
                                        IsBusy = true;
                                        await DeleteMaterialDetails(Convert.ToString(req));
                                        await GetMaterial();
                                        IsBusy = false;
                                    }
                                    IsClicked = true;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return DeleteMaterial;
            }
        }

        private Command CancelMaterial;

        /// <summary>
        /// Command for Delete Material Events
        /// </summary>
        public Command CommandCancelMaterialEvents
        {
            get
            {
                if (CancelMaterial == null)
                    CancelMaterial = new Command(() =>
                    {
                        try
                        {
                            IsMaterialEquipment = false;
                            IsMaterialPopup = false;
                            IsEquipmentPopup = false;
                            ResetMaterialModel();
                            ResetEquipmentModel();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CancelMaterial;
            }
        }


        private Command CommandAddMaterial;
        /// <summary>
        /// Command for Add Material Events
        /// </summary>
        public Command CommandAddMaterialEvents
        {
            get
            {
                if (CommandAddMaterial == null)
                    CommandAddMaterial = new Command((req) =>
                    {
                        try
                        {
                            MaterIndex = 0;
                            IsMaterialEquipment = true;
                            IsMaterialPopup = true;
                            IsEquipmentPopup = false;
                            MaterialId = Resource.Zero;
                            IsAddMaterial = true;
                            IsUpdateMaterial = false;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandAddMaterial;
            }
        }

        private Command CommandInsertMaterial;
        /// <summary>
        /// Command for Add Material Events
        /// </summary>
        public Command CommandInsertMaterialEvents
        {
            get
            {
                if (CommandInsertMaterial == null)
                    CommandInsertMaterial = new Command(async (req) =>
                    {
                        try
                        {                            
                            if (IsClicked)
                            {
                                IsClicked = false;
                                bool materialResult = await MaterialValidation();
                                if (materialResult)
                                {
                                    IsBusy = true;
                                    bool Pcard = false;
                                    if (!string.IsNullOrEmpty(PcardImage))
                                    {
                                        Pcard = true;
                                    }
                                    string CurrentMaterial = string.Empty;
                                    if(MaterialUsedSelected.Id=="1")
                                    {
                                        CurrentMaterial = NewMaterial;
                                    }
                                    else
                                    {
                                        CurrentMaterial = MaterialUsedSelected.Name;
                                    }
                                    InstMaterialModel RequestMaterial = new InstMaterialModel()
                                    {
                                        Method = "PutBoothMaterial",
                                        MaterialId = MaterialId,
                                        Material = CurrentMaterial,
                                        Unit = Unit,
                                        Category = Category,
                                        Quantity = Quantity,
                                        PCard = Pcard,
                                        StoreName = StoreName,
                                        Cost = Cost,
                                        BoothcardId = Boothcard
                                    };
                                    bool result = await UpdateInsertMaterialDetails(RequestMaterial);
                                    IsClicked = true;
                                    if (result)
                                    {
                                        if (Convert.ToString(req) != "Repeat")
                                        {
                                            IsMaterialEquipment = false;
                                            IsMaterialPopup = false;
                                            ResetMaterialModel();
                                        }
                                        await GetMaterial();
                                    }
                                    IsBusy = false;
                                    IsClicked = true;
                                }
                                IsClicked = true;
                            }


                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandInsertMaterial;
            }
        }



        private Command CommandEditMaterial;
        /// <summary>
        /// Command for Add Material Events
        /// </summary>
        public Command CommandEditMaterialEvents
        {
            get
            {
                if (CommandEditMaterial == null)
                    CommandEditMaterial = new Command((req) =>
                    {
                        try
                        {
                            if (req != null)
                            {
                                IsAddMaterial = false;
                                IsUpdateMaterial = true;
                                MaterialModel EditModel = req as MaterialModel;
                                MaterialId = EditModel.MaterialId;
                                MaterialUsedSelected = MaterialUsed.Where(code => code.Name.Equals(EditModel.Material)).ElementAtOrDefault(0);// EditModel.Material;
                                if (MaterialUsedSelected == null)
                                {
                                    IsMaterialType = true;
                                    MaterialUsedSelected = MaterialUsed.Where(code => code.Id.Equals("1")).ElementAtOrDefault(0);
                                    NewMaterial = EditModel.Material;
                                }
                                Unit = EditModel.Unit;
                                Quantity = EditModel.Quantity;
                                Category = EditModel.Category;
                                if (EditModel.PCard)
                                {
                                    PcardImage = Resource.checkImage;
                                }
                                else
                                {
                                    PcardImage = string.Empty;
                                }
                                StoreName = EditModel.StoreName;
                                Cost = EditModel.Cost;
                                IsMaterialEquipment = true;
                                IsMaterialPopup = true;
                                IsEquipmentPopup = false;
                            }

                        }
                        catch (Exception ex)
                        {
                            App.Current.MainPage.DisplayAlert("", ex.Message.ToString(), "OK");
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandEditMaterial;
            }
        }

        private Command DeleteEquipment;

        /// <summary>
        /// Command for Delete Material Events
        /// </summary>
        public Command CommandDeleteEquipmentEvents
        {
            get
            {
                if (DeleteEquipment == null)
                    DeleteEquipment = new Command(async (req) =>
                    {
                        try
                        {
                            if (req != null)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    bool isConfirm = await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ConfirmationMessage, Resource.Yes, Resource.Cancel);
                                    if (isConfirm)
                                    {
                                        IsBusy = true;
                                        await DeleteEquipmentDetails(Convert.ToString(req));
                                        await GetEquipment();
                                        IsBusy = false;
                                    }
                                    IsClicked = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return DeleteEquipment;
            }
        }


        private Command EditEquipment;

        /// <summary>
        /// Command for Command Edit Equipment Events
        /// </summary>
        public Command CommandEditEquipmentEvents
        {
            get
            {
                if (EditEquipment == null)
                    EditEquipment = new Command((req) =>
                    {
                        try
                        {
                            if (req != null)
                            {


                                IsMaterialEquipment = true;
                                IsMaterialPopup = false;
                                IsEquipmentPopup = true;
                                IsAddEquipment = false;
                                IsUpdateEquipment = true;
                                EquipmentModel ObjEquipment = req as EquipmentModel;
                                EquipmentSelected = EquipmentUsed.Where(code => code.Name.Equals(ObjEquipment.Equipment)).ElementAtOrDefault(0);// EditModel.Material; //ObjEquipment.Equipment;
                                if(EquipmentSelected==null)
                                {
                                    IsEquipmentType = true;
                                    EquipmentSelected = EquipmentUsed.Where(code => code.Id.Equals("1")).ElementAtOrDefault(0);
                                    NewEquipment = ObjEquipment.Equipment;
                                }
                               
                                EquipmentId = ObjEquipment.EquipmentId;
                                EquUnit = ObjEquipment.Unit;
                                EquQuantity = ObjEquipment.Quantity;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return EditEquipment;
            }
        }



        private Command AddEquipment;
        /// <summary>
        /// Command for Command Add Equipment Events
        /// </summary>
        public Command CommandAddEquipmentEvents
        {
            get
            {
                if (AddEquipment == null)
                    AddEquipment = new Command(() =>
                    {
                        try
                        {
                            EquIndex = 0;
                            IsMaterialEquipment = true;
                            IsMaterialPopup = false;
                            IsEquipmentPopup = true;
                            IsAddEquipment = true;
                            IsUpdateEquipment = false;
                            EquipmentId = Resource.Zero;

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return AddEquipment;
            }
        }


        private Command InsertEquipment;
        /// <summary>
        /// Command for Command Add Equipment Events
        /// </summary>
        public Command CommandInsertEquipmentEvents
        {
            get
            {
                if (InsertEquipment == null)
                    InsertEquipment = new Command(async (req) =>
                    {
                        try
                        {
                            IsBusy = true;
                            if (IsClicked)
                            {
                                IsClicked = false;
                                bool equResult = await EquipmentValidation();
                                if (equResult)
                                {
                                    string CurrentEquipment = string.Empty;
                                    if(EquipmentSelected.Id=="1")
                                    {
                                        CurrentEquipment = NewEquipment;
                                    }
                                    else
                                    {
                                        CurrentEquipment = EquipmentSelected.Name;
                                    }
                                    InstEquipment ObjEqu = new InstEquipment()
                                    {
                                        Method = "PutBoothEquipment",
                                        EquipmentId = EquipmentId,
                                        Equipment = CurrentEquipment,// Equipment,
                                        Unit = EquUnit,
                                        Quantity = EquQuantity,
                                        BoothcardId = Boothcard
                                    };
                                    bool result = await UpdateInsertEquipDetails(ObjEqu);
                                    if (result)
                                    {
                                        if (Convert.ToString(req) != "Repeat")
                                        {
                                            IsMaterialEquipment = false;
                                            IsMaterialPopup = false;
                                            IsEquipmentPopup = false;
                                            ResetEquipmentModel();
                                        }
                                        await GetEquipment();
                                    }
                                }
                            }
                            IsBusy = false;
                            IsClicked = true;
                        }
                        catch (Exception ex)
                        {
                            IsBusy = false;
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return InsertEquipment;
            }
        }


        /// <summary>
        /// Method for Delete Material
        /// </summary>
        /// <param name="MaterialID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMaterialDetails(string MaterialID)
        {
            bool message = false;
            DeleteMaterialService ServiceProvider = new DeleteMaterialService();
            try
            {
                string result = await ServiceProvider.DeleteBoothMaterialById(MaterialID);
                if (!string.IsNullOrEmpty(result))
                {
                    message = true;
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.DeleteSuccess, Resource.OK);
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
            return message;
        }


        /// <summary>
        /// Method for Delete Equipment
        /// </summary>
        /// <param name="EquipmentID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEquipmentDetails(string EquipmentID)
        {
            bool message = false;
            DeleteEquipmentServices ServiceProvider = new DeleteEquipmentServices();
            try
            {
                string result = await ServiceProvider.DeleteBoothEquipmentById(EquipmentID);
                if (!string.IsNullOrEmpty(result))
                {
                    message = true;
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.DeleteSuccess, Resource.OK);
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
            return message;
        }



        /// <summary>
        /// Method For Insert Update Material Details
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateInsertMaterialDetails(InstMaterialModel ObjMaterialModel)
        {
            bool message = false;
            InsertMaterialService InsertMaterialServ = new InsertMaterialService();
            try
            {
                string result = await InsertMaterialServ.InsertEquipment(ObjMaterialModel);
                if (!string.IsNullOrEmpty(result))
                {
                    message = true;
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.InsertUpdateSuccess, Resource.OK);
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
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
            return message;
        }


        /// <summary>
        /// Method For Insert Update Material Details
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateInsertEquipDetails(InstEquipment ObjEquipModel)
        {
            bool message = false;
            InsertEquipmentService InsertEquipServ = new InsertEquipmentService();
            try
            {
                string result = await InsertEquipServ.InsertEquipment(ObjEquipModel);
                if (!string.IsNullOrEmpty(result))
                {
                    message = true;
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, result + Resource.InsertUpdateSuccess, Resource.OK);
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
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
            return message;
        }

        /// <summary>
        /// Method for Reset Equipment Model
        /// </summary>
        public void ResetEquipmentModel()
        {
            Equipment = string.Empty;
            EquipmentId = Resource.Zero;
            EquQuantity = string.Empty;
            EquUnit = string.Empty;
            NewEquipment = string.Empty;
            IsEquipmentType = false;
        }

        /// <summary>
        /// Method for Reset Equipment Model
        /// </summary>
        public void ResetMaterialModel()
        {
            Material = string.Empty;
            MaterialId = Resource.Zero;
            Quantity = string.Empty;
            Unit = string.Empty;
            Cost = string.Empty;
            StoreName = string.Empty;
            Category = string.Empty;
            PcardImage = string.Empty;
            IsMaterialType = false;
            NewMaterial = string.Empty;

        }

        public async Task<bool> MaterialValidation()
        {
            bool message = true;
            try
            {
                List<string> lst = new List<string>();
                lst.Clear();
                if (MaterialUsedSelected == null)
                {
                    lst.Add(Resource.MaterialUsed);
                }
                else
                {
                    if (MaterialUsedSelected.Index == 0)
                    {
                        lst.Add(Resource.MaterialUsed);
                    }
                    if (MaterialUsedSelected.Id == "1")
                    {
                        if (string.IsNullOrEmpty(NewMaterial))
                        {
                            lst.Add(Resource.MaterialUsed);
                        }
                    }
                }
                if (string.IsNullOrEmpty(Unit))
                {
                    lst.Add(Resource.UnitOfMeasure);
                }
                if (string.IsNullOrEmpty(Quantity))
                {
                    lst.Add(Resource.Quantity);
                }
                if (lst.Count > 0)
                {
                    int lstcount = lst.Count;
                    message = false;
                    string value = string.Join(", ", lst.Take(lst.Count - 1)) + (lst.Count <= 1 ? "" : " & ") + lst.LastOrDefault();
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.Pleaseenter + " " + value + ".", Resource.OK);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return message;
        }

        public async Task<bool> EquipmentValidation()
        {
            bool message = true;
            try
            {
                List<string> lst = new List<string>();
                lst.Clear();
                if (EquipmentSelected == null)
                {

                    lst.Add(Resource.Equipment);

                }
                else
                {
                    if (EquipmentSelected.Index == 0)
                    {
                        lst.Add(Resource.Equipment);
                    }
                    if(EquipmentSelected.Id == "1")
                    {
                        if(string.IsNullOrEmpty(NewEquipment))
                        {
                            lst.Add(Resource.Equipment);
                        }
                    }
                }
                if (string.IsNullOrEmpty(EquQuantity))
                {
                    lst.Add(Resource.EquipmentQuantity);
                }
                if (lst.Count > 0)
                {
                    int lstcount = lst.Count;
                    message = false;
                    string value = string.Join(", ", lst.Take(lst.Count - 1)) + (lst.Count <= 1 ? "" : " & ") + lst.LastOrDefault();
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.Pleaseenter + " " + value + ".", Resource.OK);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return message;
        }


        private ObservableRangeCollection<MaterialUsed> _MaterialUsed;
        /// <summary>
        /// Gets and Sets The State.
        /// </summary>
        public ObservableRangeCollection<MaterialUsed> MaterialUsed
        {
            get { return _MaterialUsed; }
            set
            {
                _MaterialUsed = value;
                OnPropertyChanged(nameof(MaterialUsed));
            }
        }
        private MaterialUsed _MaterialUsedSelected;
        /// <summary>
        /// Gets or sets the State Selected Index.
        /// </summary>
        /// <value>The State Selected Index.</value>
        public MaterialUsed MaterialUsedSelected
        {
            get { return _MaterialUsedSelected; }
            set
            {
                _MaterialUsedSelected = value;
                try
                {
                    if (MaterialUsedSelected != null)
                    {
                        if (MaterialUsedSelected.Id == "1")
                        {
                            NewMaterial = string.Empty;
                            IsMaterialType = true;
                        }
                        else
                        {
                            IsMaterialType = false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
                OnPropertyChanged(nameof(MaterialUsedSelected));
            }
        }


        private ObservableRangeCollection<Equipment> _EquipmentUsed;
        /// <summary>
        /// Gets and Sets The State.
        /// </summary>
        public ObservableRangeCollection<Equipment> EquipmentUsed
        {
            get { return _EquipmentUsed; }
            set
            {
                _EquipmentUsed = value;
                OnPropertyChanged(nameof(EquipmentUsed));
            }
        }
        private Equipment _EquipmentSelected;
        /// <summary>
        /// Gets or sets the State Selected Index.
        /// </summary>
        /// <value>The State Selected Index.</value>
        public Equipment EquipmentSelected
        {
            get { return _EquipmentSelected; }
            set
            {
                _EquipmentSelected = value;
                try
                {
                    if(EquipmentSelected!=null)
                    {
                        if(EquipmentSelected.Id=="1")
                        {
                            NewEquipment = string.Empty;
                            IsEquipmentType = true;
                        }
                        else
                        {
                            IsEquipmentType = false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
                OnPropertyChanged(nameof(EquipmentSelected));
            }
        }


        private int _MaterIndex;
        /// <summary>
        /// Gets or Sets Task Index
        /// </summary>
        public int MaterIndex
        {
            get { return _MaterIndex; }
            set
            {
                _MaterIndex = value;
                OnPropertyChanged(nameof(MaterIndex));
            }
        }

        private int _EquIndex;
        /// <summary>
        /// Gets or Sets Task Index
        /// </summary>
        public int EquIndex
        {
            get { return _EquIndex; }
            set
            {
                _EquIndex = value;
                OnPropertyChanged(nameof(EquIndex));
            }
        }

        /// <summary>
        /// Method for Get Equipment list
        /// </summary>
        /// <returns></returns>
        public async Task GetEquipmentPkr()
        {

            List<EquipmentResponse> lstEquipresponse = new List<EquipmentResponse>();
            EquipmentAndMaterial  ServiceProvider = new EquipmentAndMaterial();
            try
            {
                Equipment ObjEquipIndex = new Equipment()
                {
                    Index = 0,
                    Id = "0",
                    Name = "Select Equipment"
                };
                EquipmentUsed.Add(ObjEquipIndex);
                Equipment ObjEquipType = new Equipment()
                {
                    Index = 1,
                    Id = "1",
                    Name = "--Type Equipment--"
                };
                EquipmentUsed.Add(ObjEquipType);
                lstEquipresponse = await ServiceProvider.GetEquipment();                
                if (lstEquipresponse != null)
                {
                    int id = 2;
                    if (lstEquipresponse.Count > 0)
                    {                       
                        foreach (var item in lstEquipresponse)
                        {
                            Equipment ObjEquip = new Equipment();
                            ObjEquip.Index = id;
                            ObjEquip.Id =Convert.ToString(id);
                            ObjEquip.Name = item.EquipmentDescription;
                            EquipmentUsed.Add(ObjEquip);
                            id++;
                        }
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                        //await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                       // await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method for Get Material List
        /// </summary>
        /// <returns></returns>
        public async Task GetMaterialPkr()
        {

            List<MaterialResponse> lstMatresponse = new List<MaterialResponse>();
            EquipmentAndMaterial ServiceProvider = new EquipmentAndMaterial();
            try
            {
                MaterialUsed ObjMatIndex = new MaterialUsed()
                {
                    Index = 0,
                    Id = "0",
                    Name = "Select Material"
                };
                MaterialUsed.Add(ObjMatIndex);
                MaterialUsed ObjMatType = new MaterialUsed()
                {
                    Index = 1,
                    Id = "1",
                    Name = "--Type Material--"
                };
                MaterialUsed.Add(ObjMatType);
                lstMatresponse = await ServiceProvider.GetMaterial();
                if (lstMatresponse != null)
                {
                    int id = 2;
                    if (lstMatresponse.Count > 0)
                    {
                        foreach (var item in lstMatresponse)
                        {
                            MaterialUsed ObjMaterial = new MaterialUsed();
                            ObjMaterial.Index = id;
                            ObjMaterial.Id = Convert.ToString(id);
                            ObjMaterial.Name = item.MaterialDescription;
                            MaterialUsed.Add(ObjMaterial);
                            id++;
                        }
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                        //await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        // await App.Current.MainPage.Navigation.PopModalAsync();
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
