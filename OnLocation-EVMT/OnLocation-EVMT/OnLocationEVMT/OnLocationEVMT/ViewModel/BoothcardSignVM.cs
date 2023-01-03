using OnLocationEVMT.Controls;
using OnLocationEVMT.DependencyServices;
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
    class BoothcardSignVM: ObservableObject
    {

        private Command CommandGenertaeReport;



        private ImageSource _Imagesign;

        public ImageSource Imagesign
        {
            get { return _Imagesign; }
            set { _Imagesign = value;
                OnPropertyChanged(nameof(Imagesign));
            }
        }



        public bool _IsBusy;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
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

        private Color _StrokeColor;
        /// <summary>
        /// Gets or Sets Stroke Color
        /// </summary>
        public Color StrokeColor
        {
            get { return _StrokeColor; }
            set {
                _StrokeColor = value;
                OnPropertyChanged(nameof(StrokeColor));
            }
        }

        private int _StrokeSize;
        /// <summary>
        /// Gets or Sets Stroke Size
        /// </summary>
        public int StrokeSize
        {
            get { return _StrokeSize; }
            set
            {
                _StrokeSize = value;
                OnPropertyChanged(nameof(StrokeSize));
            }
        }

        private string _JobNumber;
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

        private string _Signature;
        /// <summary>
        /// Gets or Sets Signature
        /// </summary>
        public string Signature
        {
            get { return _Signature; }
            set
            {
                _Signature = value;
                OnPropertyChanged(nameof(Signature));
            }
        }

        private string _BoothcardID;
        /// <summary>
        /// Gets or Sets BoothcardID
        /// </summary>
        public string BoothcardID
        {
            get { return _BoothcardID; }
            set
            {
                _BoothcardID = value;
                OnPropertyChanged(nameof(BoothcardID));
            }
        }



        /// <summary>
        /// Constructor
        /// </summary>
        public BoothcardSignVM()
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    DependencyService.Get<IDeviceOrientation>().ForceLandscape();
                }
                StrokeColor = Color.FromHex(Resource.GreenHex);
                StrokeSize = 6;
               // Get();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }



        /// <summary>
        /// Cancel Report events
        /// </summary>
        /// 
        public Command CommandCancelReportEvents
        {
            get
            {
                if (CommandGenertaeReport == null)
                    CommandGenertaeReport = new Command(() =>
                    {
                        try
                        {
                            App.Current.MainPage.Navigation.PopModalAsync();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandGenertaeReport;
            }
        }

        private Command CommandStrokeColor;
        /// <summary>
        /// Stroke Color events
        /// </summary>
        /// 
        public Command CommandStrokeColorEvents
        {
            get
            {
                if (CommandStrokeColor == null)
                    CommandStrokeColor = new Command((req) =>
                    {
                        try
                        {
                            if(Convert.ToString(req)==Resource.Black)
                            {
                                StrokeColor = Color.Black;
                            }
                            else if (Convert.ToString(req) ==Resource.Blue)
                            {
                                StrokeColor = Color.Blue;
                            }
                            else if (Convert.ToString(req) == Resource.Green)
                            {
                                StrokeColor = Color.FromHex(Resource.GreenHex);
                            }
                            else if (Convert.ToString(req) == Resource.Red)
                            {
                                StrokeColor = Color.Red;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandStrokeColor;
            }
        }

        private Command CommandStrokeSize;
        /// <summary>
        /// Stroke Size events
        /// </summary>
        /// 
        public Command CommandStrokeSizeEvents
        {
            get
            {
                if (CommandStrokeSize == null)
                    CommandStrokeSize = new Command((req) =>
                    {
                        try
                        {
                            if (Convert.ToString(req) == Resource.Plus)
                            {
                                if(StrokeSize<9)
                                {
                                    StrokeSize++;
                                }
                            }
                            else if (Convert.ToString(req) == Resource.Minus)
                            {
                                if (StrokeSize >1)
                                {
                                    StrokeSize--;
                                }
                            }                           
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandStrokeSize;
            }
        }

        /// <summary>
        /// Method For Get
        /// </summary>
        public async void Get()
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
            SignatureServices ServiceProvider = new SignatureServices();
            try
            {
                SignRequestModel ObjSignRequest = new SignRequestModel()
                {
                    BoothcardId = BoothcardID,
                    JobNumber = JobNumber,
                    Signature = Signature
                };
                LstSignResponse = await ServiceProvider.GetBoothcardReport(ObjSignRequest);
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
                        //await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
                        //await App.Current.MainPage.Navigation.PopModalAsync();
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

    }
}
