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
    class YourProjectTabVM : ObservableObject
    {
        public static string LaborCallNote, SpecialInstructionNote,ToDoNoteDetails;
        Command CommandShowInformation;
        Command CommandEstimate;
        Command CommandOrderDetails;
        Command CommandShipping;
        Command CommandStaf;
        Command CommandFinalInvoice;
        Command CommandPostJob;


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

        public bool _IsToDO;
        /// <summary>
        /// Gets or Sets IsToDO
        /// </summary>
        public bool IsToDO
        {
            get { return _IsToDO; }
            set
            {
                _IsToDO = value;
                OnPropertyChanged(nameof(IsToDO));
            }
        }

        public bool _IsOrder;
        /// <summary>
        /// Gets or Sets IsOrder
        /// </summary>
        public bool IsOrder
        {
            get { return _IsOrder; }
            set
            {
                _IsOrder = value;
                OnPropertyChanged(nameof(IsOrder));
            }
        }


        public bool _IsEstimate;
        /// <summary>
        /// Gets or Sets IsOrder
        /// </summary>
        public bool IsEstimate
        {
            get { return _IsEstimate; }
            set
            {
                _IsEstimate = value;
                OnPropertyChanged(nameof(IsEstimate));
            }
        }

        public bool _IsShipping;
        /// <summary>
        /// Gets or Sets IsOrder
        /// </summary>
        public bool IsShipping
        {
            get { return _IsShipping; }
            set
            {
                _IsShipping = value;
                OnPropertyChanged(nameof(IsShipping));
            }
        }

        public bool _IsInvoices;
        /// <summary>
        /// Gets or Sets IsOrder
        /// </summary>
        public bool IsInvoices
        {
            get { return _IsInvoices; }
            set
            {
                _IsInvoices = value;
                OnPropertyChanged(nameof(IsInvoices));
            }
        }

        public string _JobNumber;
        /// <summary>
        /// Gets or Sets JobNumber
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

        public YourProjectTabVM()
        {
            GetNote();
        }
        /// <summary>
        /// Open CommandShowInformation events
        /// </summary>
        public Command CommandShowInformationEvents
        {
            get
            {
                if (CommandShowInformation == null)
                    CommandShowInformation = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;                                
                                 App.Current.MainPage.Navigation.PushModalAsync(new Views.ShowInformation(Views.YourProjectTab.YourProjectDTO.JobNumber));
                              
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandShowInformation;
            }
        }

        /// <summary>
        /// Open CommandEstimate events
        /// </summary>
        public Command CommandEstimateEvents
        {
            get
            {
                if (CommandEstimate == null)
                    CommandEstimate = new Command((req) =>
                    {
                        try
                        {
                            if (IsEstimate)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.ProjectEstimate(Views.YourProjectTab.YourProjectDTO));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandEstimate;
            }
        }

        /// <summary>
        /// Open CommandOrderDetails events
        /// </summary>
        public Command CommandOrderDetailsEvents
        {
            get
            {
                if (CommandOrderDetails == null)
                    CommandOrderDetails = new Command((req) =>
                    {
                        try
                        {
                            if (IsOrder)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.OrderDatails(Views.YourProjectTab.YourProjectDTO.JobNumber));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandOrderDetails;
            }
        }

        /// <summary>
        /// Open CommandShipping events
        /// </summary>
        public Command CommandShippingEvents
        {
            get
            {
                if (CommandShipping == null)
                    CommandShipping = new Command((req) =>
                    {
                        try
                        {
                            if (IsShipping)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.Shipping(Views.YourProjectTab.YourProjectDTO.JobNumber,ShowName,OrderBoothSize,ExhibitorName,JobNumber));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandShipping;
            }
        }

        /// <summary>
        /// Open CommandStaf events
        /// </summary>
        public Command CommandStafEvents
        {
            get
            {
                if (CommandStaf == null)
                    CommandStaf = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;                                
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.JobStaff());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandStaf;
            }
        }

        /// <summary>
        /// Open CommandFinalInvoice events
        /// </summary>
        public Command CommandFinalInvoiceEvents
        {
            get
            {
                if (CommandFinalInvoice == null)
                    CommandFinalInvoice = new Command((req) =>
                    {
                        try
                        {
                            if (IsInvoices)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.ProjectInvoice(Views.YourProjectTab.YourProjectDTO));

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandFinalInvoice;
            }
        }

        /// <summary>
        /// Open CommandEstimate events
        /// </summary>
        public Command CommandPostJobEvents
        {
            get
            {
                if (CommandPostJob == null)
                    CommandPostJob = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.DisplayAlert("Alert", "Coming Soon", "OK");
                                IsClicked = true;                               
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandPostJob;
            }
        }


       private  Command ToDO;
        /// <summary>
        /// Open CommandToDo events
        /// </summary>
        public Command CommandToDoEvents
        {
            get
            {
                if (ToDO == null)
                    ToDO = new Command((req) =>
                    {
                        try
                        {
                            if (IsToDO)
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.ToDoNotes());
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
                return ToDO;
            }
        }

        /// <summary>
        /// Method for GetOrder
        /// </summary>
        public async void GetNote()
        {
            try
            {
                IsBusy = true;
                await GetArrowToggles();
                await GetLaborCallNote();
                await GetToDo();
                IsBusy = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        /// <summary>
        /// Method For Get OrderInfo
        /// </summary>
        /// <returns></returns>
        public async Task GetLaborCallNote()
        {

            List<LaborCallModels> CallNote = new List<LaborCallModels>();
            LaborCallNoteServices ServiceProviderShow = new LaborCallNoteServices();
            try
            {

                CallNote = await ServiceProviderShow.GetLaborCallNote(Views.YourProjectTab.YourProjectDTO.JobNumber);
                if (CallNote != null)
                {
                    if (CallNote.Count > 0)
                    {

                        LaborCallNote = @"<html><body>" + CallNote[0].LaborCallNote + "</body></html>";
                        SpecialInstructionNote = @"<html><body>" + CallNote[0].SpecialInstructionNote + "</body></html>";
                    }
                    else
                    {
                        LaborCallNote = string.Empty;
                        SpecialInstructionNote = string.Empty;
                        //await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NoRecord, Resource.OK);
                        //await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        LaborCallNote = string.Empty;
                        SpecialInstructionNote = string.Empty;
                        //await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                        //await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                    else
                    {
                        LaborCallNote = string.Empty;
                        SpecialInstructionNote = string.Empty;
                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                LaborCallNote = string.Empty;
                SpecialInstructionNote = string.Empty;
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public async Task GetToDo()
        {

            List<ToDoNote> ToDoNotelst = new List<ToDoNote>();
            ToDoServices ServiceProviderShow = new ToDoServices();
            try
            {

                ToDoNotelst = await ServiceProviderShow.GetToDo(Views.YourProjectTab.YourProjectDTO.JobNumber);
                if (ToDoNotelst != null)
                {
                    if (ToDoNotelst.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ToDoNotelst[0].ToDoNotes))
                        {
                            IsToDO = true;
                            ToDoNoteDetails = @"<html><body>" + ToDoNotelst[0].ToDoNotes + "</body></html>";
                        }
                        else
                        {
                            IsToDO = false;
                            ToDoNoteDetails = string.Empty;
                        }
                    }
                    else
                    {
                        ToDoNoteDetails = string.Empty;
                        IsToDO = false;
                    }
                }
                else
                {
                    IsToDO = false;
                    if (IsConneciton.IsConnection)
                    {
                        ToDoNoteDetails = string.Empty;
                        
                    }
                    else
                    {
                        ToDoNoteDetails = string.Empty;
                        
                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                IsToDO = false;
                ToDoNoteDetails = string.Empty;               
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method for Get Arrow Toggles(Hide/Show)
        /// </summary>
        /// <returns></returns>
        public async Task GetArrowToggles()
        {

            List<ActiveMenu> lstToggles = new List<ActiveMenu>();
            ActiveMenuServices ServiceProviderShow = new ActiveMenuServices();
            try
            {

                lstToggles = await ServiceProviderShow.ActivateMenu(Views.YourProjectTab.YourProjectDTO.JobNumber);
                if (lstToggles != null)
                {
                    if (lstToggles.Count > 0)
                    {
                        foreach (var item in lstToggles)
                        {
                            IsEstimate = item.Estimate == "T" ? true : false;
                            IsOrder = item.OrderDetails == "T" ? true : false;
                            IsToDO = item.ToDoNotes == "T" ? true : false;
                            IsShipping = item.Shipping == "T" ? true : false;
                            IsInvoices = item.Invoices == "T" ? true : false;                           
                        }
                    }
                    else
                    {
                        IsEstimate = false;
                        IsOrder = false;
                        IsToDO = false;
                        IsShipping = false;
                        IsInvoices = false;
                    }
                }
                else
                {                   
                    if (IsConneciton.IsConnection)
                    {
                        IsEstimate = false;
                        IsOrder = false;
                        IsToDO = false;
                        IsShipping = false;
                        IsInvoices = false;
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
