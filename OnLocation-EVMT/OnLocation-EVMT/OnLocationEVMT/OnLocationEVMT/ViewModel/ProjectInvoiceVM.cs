using OnLocationEVMT.Controls;
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
    public class ProjectInvoiceVM : ObservableObject
    {

        public ObservableRangeCollection<Invoice> LstInvoiceProject { get; set; }
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

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectInvoiceVM()
        {
            LstInvoiceProject = new ObservableRangeCollection<Invoice>();
            Get();
                
        }

        public async void Get()
        {
            IsBusy = true;
            await GetFinalInvoices();
            IsBusy = false;
        }

        /// <summary>
        /// Method For Get Final Invoice
        /// </summary>
        /// <returns></returns>
        public async Task GetFinalInvoices()
        {
            List<InvoiceModel> LstInvoices = new List<InvoiceModel>();

            InvoicesServices ServiceProvider = new InvoicesServices();
            try
            {                
               LstInvoices = await ServiceProvider.GetInvoices(Views.YourProjectTab.YourProjectDTO.JobNumber);
                if (LstInvoices != null)
                {
                    foreach (var item in LstInvoices)
                    {
                        Invoice Obj = new Invoice();
                        Obj.OpenPDF = OpenPDFCommandEvents;
                        Obj.InvoiceItemId = item.InvoiceItemId;
                        Obj.JobNumber = item.JobNumber;
                        var SplitData = item.InvoiceItemDesc.Split('-');
                        if (!string.IsNullOrEmpty(SplitData[0]))
                        {
                            DateTime obj = new DateTime();
                            obj = Convert.ToDateTime(SplitData[0]);
                            Obj.InvoiceDate = obj.ToString(Resource.DateFormat);   
                        }
                        else
                        {
                            Obj.InvoiceDate = Resource.NA;
                        }                        
                        Obj.InvoiceAmount = SplitData[1];
                       
                        LstInvoiceProject.Add(Obj);
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

       private Command OpenPDFCommand;

        /// <summary>
        /// Command to Auto Call 
        /// /// </summary>
        public Command OpenPDFCommandEvents
        {
            get
            {
                try
                {
                    if (OpenPDFCommand == null)
                        OpenPDFCommand = new Command(async(req) =>
                        {
                            try
                            {
                                if (req != null)
                                {
                                    if (IsClicked)
                                    {
                                        IsClicked = false;
                                        Invoice ModelReq = req as Invoice;
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
                                                    await GetInvoicePDF(ModelReq.JobNumber, ModelReq.InvoiceItemId);
                                                    IsBusy = false;
                                                }
                                            }
                                            else
                                            {
                                                IsBusy = true;
                                                await GetInvoicePDF(ModelReq.JobNumber, ModelReq.InvoiceItemId);
                                                IsBusy = false;
                                            }
                                        }
                                        else
                                        {
                                            IsBusy = true;
                                            await GetInvoicePDF(ModelReq.JobNumber, ModelReq.InvoiceItemId);
                                            IsBusy = false;
                                        }
                                        IsClicked = true;
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                IsBusy = false;
                                Debug.WriteLine(ex.StackTrace);                              
                            }
                        });
                    return OpenPDFCommand;
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.StackTrace);
                    return OpenPDFCommand;
                }
            }
        }

       

        /// <summary>
        /// Method for GetInvoicePDF Report
        /// </summary>
        /// <returns></returns>
        public async Task GetInvoicePDF(string JobNumber, string InvoiceID)
        {

            List<InvoicePDFModel> LstInvoiceResponse = new List<InvoicePDFModel>();
            InvoicesPDFServices ServiceProvider = new InvoicesPDFServices();
            try
            {
                LstInvoiceResponse = await ServiceProvider.GetInvoiceReport(JobNumber, InvoiceID);
                if (LstInvoiceResponse != null)
                {
                    if (LstInvoiceResponse.Count > 0)
                    {
                        foreach (var item in LstInvoiceResponse)
                        {
                            byte[] SummaryReport = null;
                            SummaryReport = System.Convert.FromBase64String(item.Invoice);

                            OpenInvoiceReport(SummaryReport);
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

        /// <summary>
        /// Method for Open Invoce Report
        /// </summary>
        /// <param name="Profile"></param>
        public async void OpenInvoiceReport(byte[] InvoiceData)
        {
            try
            {
                DependencyService.Get<DependencyServices.IDocumentManager>().SaveFile(InvoiceData, "Invoice.pdf");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
