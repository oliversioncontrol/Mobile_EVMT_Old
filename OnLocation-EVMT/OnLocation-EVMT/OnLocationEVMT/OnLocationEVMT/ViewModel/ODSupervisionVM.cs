using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System.Diagnostics;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class ODSupervisionVM : ObservableObject
    {
        public ObservableRangeCollection<SupervisionModel> LstOrderDetailSuperv { get; set; }
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
        /// Constructor
        /// </summary>
        public ODSupervisionVM()
        {
            try
            {
                LstOrderDetailSuperv = new ObservableRangeCollection<SupervisionModel>();
                SuperVision();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method for Get Supervision
        /// </summary>
        public async void SuperVision()
        {
            IsBusy = true;
            await GetSupervision();
            IsBusy = false;
        }




        Command CallStoreCommand;

        /// <summary>
        /// Command to Auto Call 
        /// /// </summary>
        public Command CallStoreCommandEvents
        {
            get
            {
                try
                {
                    if (CallStoreCommand == null)
                        CallStoreCommand = new Command((req) =>
                        {
                            Device.OpenUri(new Uri(String.Format("tel:{0}", req.ToString())));
                        });
                    return CallStoreCommand;
                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex.StackTrace);
                    return CallStoreCommand;
                }


            }
        }


        Command AutoEmailCommand;

        /// <summary>
        /// Command to Auto Email 
        /// /// </summary>
        public Command AutoEmailCommandEvents
        {
            get
            {
                try
                {
                    if (AutoEmailCommand == null)
                        AutoEmailCommand = new Command((req) =>
                        {
                            try
                            {
                                Device.OpenUri(new Uri("mailto:" + Convert.ToString(req)));
                            }
                            catch(Exception ex)
                            {
                                Debug.WriteLine(ex.StackTrace);
                            }
                        });

                    return AutoEmailCommand;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    return AutoEmailCommand;
                }
            }
        }




        /// <summary>
        /// Method For GetSupervision
        /// </summary>
        /// <returns></returns>
        public async Task GetSupervision()
        {
            List<SupervisionModel> LstSupInfo = new List<SupervisionModel>();
            List<SupervisionModel> LstSupervision = new List<SupervisionModel>();
            OrderSupervisonServices ServiceProviderShow = new OrderSupervisonServices();
            try
            {

                LstSupervision = await ServiceProviderShow.GetSupervision(Views.OrderDatails.JobNumber);
                if (LstSupervision != null)
                {
                    if (LstSupervision.Count > 0)
                    {
                        foreach (var item in LstSupervision)
                        {
                           
                           SupervisionModel ObjSup = new SupervisionModel();
                            ObjSup.OLImg = Resource.RdUnChecked; 
                            ObjSup.ClientImg = Resource.RdUnChecked;
                            ObjSup.ExhibitImg = Resource.RdUnChecked;
                            ObjSup.DisOLImg = Resource.RdUnChecked;
                            ObjSup.DisClientImg = Resource.RdUnChecked;
                            ObjSup.DisExhibitImg = Resource.RdUnChecked;
                            ObjSup.SupInstallContactId = item.SupInstallContactId;
                            if(item.SupInstallation== Resource.OnLocation)
                            {
                                ObjSup.OLImg = Resource.RdChecked;
                            }
                            else if (item.SupInstallation ==Resource.Client)
                            {
                                ObjSup.ClientImg = Resource.RdChecked;
                            }
                            else if (item.SupInstallation == Resource.ExhibitHouse)
                            {
                                ObjSup.ExhibitImg = Resource.RdChecked;
                            }
                            ObjSup.SupInstallContact = item.SupInstallContact;
                            ObjSup.SupInstallContactPhone = item.SupInstallContactPhone;
                            ObjSup.SupDismantleContactId = item.SupDismantleContactId;                           
                            if (item.SupDismantle == Resource.OnLocation)
                            {
                                ObjSup.DisOLImg = Resource.RdChecked;
                            }
                            else if (item.SupDismantle == Resource.Client)
                            {
                                ObjSup.DisClientImg = Resource.RdChecked;
                            }
                            else if (item.SupDismantle == Resource.ExhibitHouse)
                            {
                                ObjSup.DisExhibitImg = Resource.RdChecked;
                            }
                            ObjSup.SupDismantleContact = item.SupDismantleContact;
                            ObjSup.SupDismantleContactPhone = item.SupDismantleContactPhone;
                            ObjSup.AutoCall = CallStoreCommandEvents;
                            LstSupInfo.Add(ObjSup);
                        }
                        LstOrderDetailSuperv.AddRange(LstSupInfo);

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
