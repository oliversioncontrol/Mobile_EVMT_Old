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
    public class ShippingVM : ObservableObject
    {


        public string _JobPortfolio;
        /// <summary>
        /// Gets or Sets JobNumber
        /// </summary>
        public string JobPortfolio
        {
            get { return _JobPortfolio; }
            set
            {
                _JobPortfolio = value;
                OnPropertyChanged(nameof(JobPortfolio));
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

        public string _ExhibitorNameHeader;
        /// <summary>
        /// Gets or Sets ExhibitorName
        /// </summary>
        public string ExhibitorNameHeader
        {
            get { return _ExhibitorNameHeader; }
            set
            {
                _ExhibitorNameHeader = value;
                OnPropertyChanged(nameof(ExhibitorNameHeader));
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


        private bool _IsShippingNote;
        /// <summary>
        /// Gets or sets the IsShippingNote.
        /// </summary>
        /// <value>The _IsShippingNote.</value>
        public bool IsShippingNote
        {
            get { return _IsShippingNote; }
            set
            {
                _IsShippingNote = value;
                OnPropertyChanged(nameof(IsShippingNote));
            }
        }

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





        private string _ShipInboundShipDate;
        /// <summary>
        /// Gets or Sets ShipInboundShipDate
        /// </summary>
        public string ShipInboundShipDate
        {
            get { return _ShipInboundShipDate; }
            set
            {
                _ShipInboundShipDate = value;
                OnPropertyChanged(nameof(ShipInboundShipDate));
            }
        }


        private string _ShipInboundDeliveryDate;
        /// <summary>
        /// Gets or Sets ShipInboundDeliveryDate
        /// </summary>
        public string ShipInboundDeliveryDate
        {
            get { return _ShipInboundDeliveryDate; }
            set
            {
                _ShipInboundDeliveryDate = value;
                OnPropertyChanged(nameof(ShipInboundDeliveryDate));
            }
        }

        private string _ShipInboundCarrierId;
        /// <summary>
        /// Gets or Sets ShipInboundCarrierId
        /// </summary>
        public string ShipInboundCarrierId
        {
            get { return _ShipInboundCarrierId; }
            set
            {
                _ShipInboundCarrierId = value;
                OnPropertyChanged(nameof(ShipInboundCarrierId));
            }
        }

        private string _ShipInboundCarrier;
        /// <summary>
        /// Gets or Sets ShipInboundCarrier
        /// </summary>
        public string ShipInboundCarrier
        {
            get { return _ShipInboundCarrier; }
            set
            {
                _ShipInboundCarrier = value;
                OnPropertyChanged(nameof(ShipInboundCarrier));
            }
        }

        private string _ShipInboundHandling;
        /// <summary>
        /// Gets or Sets ShipInboundHandling
        /// </summary>
        public string ShipInboundHandling
        {
            get { return _ShipInboundHandling; }
            set
            {
                _ShipInboundHandling = value;
                OnPropertyChanged(nameof(ShipInboundHandling));
            }
        }

        private string _ShipInboundFrom;
        /// <summary>
        /// Gets or Sets ShipInboundFrom
        /// </summary>
        public string ShipInboundFrom
        {
            get { return _ShipInboundFrom; }
            set
            {
                _ShipInboundFrom = value;
                OnPropertyChanged(nameof(ShipInboundFrom));
            }
        }

        private string _ShipInboundCarrierContact;
        /// <summary>
        /// Gets or Sets ShipInboundCarrierContact
        /// </summary>
        public string ShipInboundCarrierContact
        {
            get { return _ShipInboundCarrierContact; }
            set
            {
                _ShipInboundCarrierContact = value;
                OnPropertyChanged(nameof(ShipInboundCarrierContact));
            }
        }

        private string _ShipInboundPieces;
        /// <summary>
        /// Gets or Sets ShipInboundPieces
        /// </summary>
        public string ShipInboundPieces
        {
            get { return _ShipInboundPieces; }
            set
            {
                _ShipInboundPieces = value;
                OnPropertyChanged(nameof(ShipInboundPieces));
            }
        }

        private string _ShipInboundDescription;
        /// <summary>
        /// Gets or Sets ShipInboundDescription
        /// </summary>
        public string ShipInboundDescription
        {
            get { return _ShipInboundDescription; }
            set
            {
                _ShipInboundDescription = value;
                OnPropertyChanged(nameof(ShipInboundDescription));
            }
        }

        private string _ShipInboundPhone;
        /// <summary>
        /// Gets or Sets ShipInboundPhone
        /// </summary>
        public string ShipInboundPhone
        {
            get { return _ShipInboundPhone; }
            set
            {
                _ShipInboundPhone = value;
                OnPropertyChanged(nameof(ShipInboundPhone));
            }
        }

        private string _ShipInboundFax;
        /// <summary>
        /// Gets or Sets ShipInboundFax
        /// </summary>
        public string ShipInboundFax
        {
            get { return _ShipInboundFax; }
            set
            {
                _ShipInboundFax = value;
                OnPropertyChanged(nameof(ShipInboundFax));
            }
        }

        private string _ShipInboundTracking;
        /// <summary>
        /// Gets or Sets ShipInboundTracking
        /// </summary>
        public string ShipInboundTracking
        {
            get { return _ShipInboundTracking; }
            set
            {
                _ShipInboundTracking = value;
                OnPropertyChanged(nameof(ShipInboundTracking));
            }
        }

        private string _ShipInboundEmail;
        /// <summary>
        /// Gets or Sets ShipInboundEmail
        /// </summary>
        public string ShipInboundEmail
        {
            get { return _ShipInboundEmail; }
            set
            {
                _ShipInboundEmail = value;
                OnPropertyChanged(nameof(ShipInboundEmail));
            }
        }

        private string _ShipOutboundPickupDate;
        /// <summary>
        /// Gets or Sets ShipOutboundPickupDate
        /// </summary>
        public string ShipOutboundPickupDate
        {
            get { return _ShipOutboundPickupDate; }
            set
            {
                _ShipOutboundPickupDate = value;
                OnPropertyChanged(nameof(ShipOutboundPickupDate));
            }
        }

        private string _ShipOutboundDeliveryDate;
        /// <summary>
        /// Gets or Sets ShipOutboundDeliveryDate
        /// </summary>
        public string ShipOutboundDeliveryDate
        {
            get { return _ShipOutboundDeliveryDate; }
            set
            {
                _ShipOutboundDeliveryDate = value;
                OnPropertyChanged(nameof(ShipOutboundDeliveryDate));
            }
        }

        private string _ShipOutboundPickupTime;
        /// <summary>
        /// Gets or Sets ShipOutboundPickupTime
        /// </summary>
        public string ShipOutboundPickupTime
        {
            get { return _ShipOutboundPickupTime; }
            set
            {
                _ShipOutboundPickupTime = value;
                OnPropertyChanged(nameof(ShipOutboundPickupTime));
            }
        }

        private string _ShipOutboundDeliveryTime;
        /// <summary>
        /// Gets or Sets ShipOutboundDeliveryTime
        /// </summary>
        public string ShipOutboundDeliveryTime
        {
            get { return _ShipOutboundDeliveryTime; }
            set
            {
                _ShipOutboundDeliveryTime = value;
                OnPropertyChanged(nameof(ShipOutboundDeliveryTime));
            }
        }

        private string _ShipOutboundCarrierId;
        /// <summary>
        /// Gets or Sets ShipOutboundCarrierId
        /// </summary>
        public string ShipOutboundCarrierId
        {
            get { return _ShipOutboundCarrierId; }
            set
            {
                _ShipOutboundCarrierId = value;
                OnPropertyChanged(nameof(ShipOutboundCarrierId));
            }
        }

        private string _ShipOutboundCarrier;
        /// <summary>
        /// Gets or Sets ShipOutboundCarrier
        /// </summary>
        public string ShipOutboundCarrier
        {
            get { return _ShipOutboundCarrier; }
            set
            {
                _ShipOutboundCarrier = value;
                OnPropertyChanged(nameof(ShipOutboundCarrier));
            }
        }

        private string _ShipOutboundCarrierContact;
        /// <summary>
        /// Gets or Sets ShipOutboundCarrierContact
        /// </summary>
        public string ShipOutboundCarrierContact
        {
            get { return _ShipOutboundCarrierContact; }
            set
            {
                _ShipOutboundCarrierContact = value;
                OnPropertyChanged(nameof(ShipOutboundCarrierContact));
            }
        }

        private string _ShipOutboundPieces;
        /// <summary>
        /// Gets or Sets ShipOutboundPieces
        /// </summary>
        public string ShipOutboundPieces
        {
            get { return _ShipOutboundPieces; }
            set
            {
                _ShipOutboundPieces = value;
                OnPropertyChanged(nameof(ShipOutboundPieces));
            }
        }

        private string _ShipOutboundDescription;
        /// <summary>
        /// Gets or Sets ShipOutboundDescription
        /// </summary>
        public string ShipOutboundDescription
        {
            get { return _ShipOutboundDescription; }
            set
            {
                _ShipOutboundDescription = value;
                OnPropertyChanged(nameof(ShipOutboundDescription));
            }
        }

        private string _ShipOutboundPhone;
        /// <summary>
        /// Gets or Sets ShipOutboundPhone
        /// </summary>
        public string ShipOutboundPhone
        {
            get { return _ShipOutboundPhone; }
            set
            {
                _ShipOutboundPhone = value;
                OnPropertyChanged(nameof(ShipOutboundPhone));
            }
        }

        private string _ShipOutboundFax;
        /// <summary>
        /// Gets or Sets ShipOutboundFax
        /// </summary>
        public string ShipOutboundFax
        {
            get { return _ShipOutboundFax; }
            set
            {
                _ShipOutboundFax = value;
                OnPropertyChanged(nameof(ShipOutboundFax));
            }
        }

        private string _ShipOutboundTracking;
        /// <summary>
        /// Gets or Sets ShipOutboundTracking
        /// </summary>
        public string ShipOutboundTracking
        {
            get { return _ShipOutboundTracking; }
            set
            {
                _ShipOutboundTracking = value;
                OnPropertyChanged(nameof(ShipOutboundTracking));
            }
        }

        private string _ShipOutboundEmail;
        /// <summary>
        /// Gets or Sets ShipOutboundEmail
        /// </summary>
        public string ShipOutboundEmail
        {
            get { return _ShipOutboundEmail; }
            set
            {
                _ShipOutboundEmail = value;
                OnPropertyChanged(nameof(ShipOutboundEmail));
            }
        }

        private string _ShipToOutboundTo;
        /// <summary>
        /// Gets or Sets ShipToOutboundTo
        /// </summary>
        public string ShipToOutboundTo
        {
            get { return _ShipToOutboundTo; }
            set
            {
                _ShipToOutboundTo = value;
                OnPropertyChanged(nameof(ShipToOutboundTo));
            }
        }

        private string _ShipToName;
        /// <summary>
        /// Gets or Sets ShipToName
        /// </summary>
        public string ShipToName
        {
            get { return _ShipToName; }
            set
            {
                _ShipToName = value;
                OnPropertyChanged(nameof(ShipToName));
            }
        }

        private string _ShipToAttn;
        /// <summary>
        /// Gets or Sets ShipToAttn
        /// </summary>
        public string ShipToAttn
        {
            get { return _ShipToAttn; }
            set
            {
                _ShipToAttn = value;
                OnPropertyChanged(nameof(ShipToAttn));
            }
        }

        private string _ShipToAddress;
        /// <summary>
        /// Gets or Sets ShipToAddress
        /// </summary>
        public string ShipToAddress
        {
            get { return _ShipToAddress; }
            set
            {
                _ShipToAddress = value;
                OnPropertyChanged(nameof(ShipToAddress));
            }
        }

        private string _ShipBillingTo;
        /// <summary>
        /// Gets or Sets ShipBillingTo
        /// </summary>
        public string ShipBillingTo
        {
            get { return _ShipBillingTo; }
            set
            {
                _ShipBillingTo = value;
                OnPropertyChanged(nameof(ShipBillingTo));
            }
        }

        private string _ShipBillingName;
        /// <summary>
        /// Gets or Sets ShipBillingName
        /// </summary>
        public string ShipBillingName
        {
            get { return _ShipBillingName; }
            set
            {
                _ShipBillingName = value;
                OnPropertyChanged(nameof(ShipBillingName));
            }
        }

        private string _ShipBillingAttn;
        /// <summary>
        /// Gets or Sets ShipBillingAttn
        /// </summary>
        public string ShipBillingAttn
        {
            get { return _ShipBillingAttn; }
            set
            {
                _ShipBillingAttn = value;
                OnPropertyChanged(nameof(ShipBillingAttn));
            }
        }

        private string _ShipBillingAddress;
        /// <summary>
        /// Gets or Sets ShipBillingAddress
        /// </summary>
        public string ShipBillingAddress
        {
            get { return _ShipBillingAddress; }
            set
            {
                _ShipBillingAddress = value;
                OnPropertyChanged(nameof(ShipBillingAddress));
            }
        }

        private string _ShipNotes;
        /// <summary>
        /// Gets or Sets ShipNotes
        /// </summary>
        public string ShipNotes
        {
            get { return _ShipNotes; }
            set
            {
                _ShipNotes = value;
                OnPropertyChanged(nameof(ShipNotes));
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

        /// <summary>
        /// Constructor
        /// </summary>
        public ShippingVM()
        {
            GetShipping();
        }


        /// <summary>
        /// Method gor Get Shipping
        /// </summary>
        public async void GetShipping()
        {
            IsBusy = true;
            await GetShippingInfo();
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

        Command ShippingNote;
        /// <summary>
        /// Open CommandShippingNotes events
        /// </summary>
        public Command ShippingNoteEvents
        {
            get
            {
                if (ShippingNote == null)
                    ShippingNote = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.ShippingNotes(ShipNotes));
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return ShippingNote;
            }
        }


        /// <summary>
        /// Method For Get Shipping Info
        /// </summary>
        /// <returns></returns>
        public async Task GetShippingInfo()
        {
            List<ShippingModel> LstShipping = new List<ShippingModel>();
            ShippingServices ServiceProviderShow = new ShippingServices();
            try
            {

                LstShipping = await ServiceProviderShow.GetShippingDetails(Views.Shipping.JobNumber);
                if (LstShipping != null)
                {
                    if (LstShipping.Count > 0)
                    {
                       

                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundDeliveryDate))
                        {
                            DateTime obj = new DateTime();
                            obj = Convert.ToDateTime(LstShipping[0].ShipInboundDeliveryDate);
                            string ShipDelDate = obj.ToString(Resource.DateFormat);
                            if(ShipDelDate!=Resource.BlankDate)
                            {
                                ShipInboundDeliveryDate = obj.ToString(Resource.DateFormat);
                            }
                            else
                            {
                                ShipInboundDeliveryDate = Resource.NA;
                            }
                            
                        }
                        else
                        {
                            ShipInboundDeliveryDate = Resource.NA;
                        }

                        string ShipDate = string.Empty;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundShipDate))
                        {                           
                            ShipDate = LstShipping[0].ShipInboundShipDate;
                        }
                        else
                        {
                            ShipDate = Resource.NA;
                        }

                        ShipInboundShipDate = ShipDate + "/" + ShipInboundDeliveryDate;

                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundFrom))
                        {
                            ShipInboundFrom = LstShipping[0].ShipInboundFrom;
                        }
                        else
                        {
                            ShipInboundFrom = Resource.NA;
                        }
                        string Handling = string.Empty;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundHandling))
                        {
                            Handling = LstShipping[0].ShipInboundHandling;
                        }
                        else
                        {
                            Handling = Resource.NA;
                        }
                        ShipInboundHandling = Handling + "/" + ShipInboundFrom;
                        string Pieces = string.Empty;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundPieces))
                        {
                            Pieces = LstShipping[0].ShipInboundPieces;
                        }
                        else
                        {
                            Pieces = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundDescription))
                        {
                            ShipInboundDescription = LstShipping[0].ShipInboundDescription;
                        }
                        else
                        {
                            ShipInboundDescription = Resource.NA;
                        }
                        ShipInboundPieces = Pieces + "/" + ShipInboundDescription;

                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundTracking))
                        {
                            ShipInboundTracking = LstShipping[0].ShipInboundTracking;
                        }
                        else
                        {
                            ShipInboundTracking = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundCarrier))
                        {
                            ShipInboundCarrier = LstShipping[0].ShipInboundCarrier;
                        }
                        else
                        {
                            ShipInboundCarrier = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundCarrierContact))
                        {
                            ShipInboundCarrierContact = LstShipping[0].ShipInboundCarrierContact;
                        }
                        else
                        {
                            ShipInboundCarrierContact = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundPhone))
                        {
                            ShipInboundPhone = LstShipping[0].ShipInboundPhone;
                        }
                        else
                        {
                            ShipInboundPhone = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundFax))
                        {
                            ShipInboundFax = LstShipping[0].ShipInboundFax;
                        }
                        else
                        {
                            ShipInboundFax = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipInboundEmail))
                        {
                            ShipInboundEmail = LstShipping[0].ShipInboundEmail;
                        }
                        else
                        {
                            ShipInboundEmail = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundDeliveryDate))
                        {
                            DateTime objout = new DateTime();
                            objout = Convert.ToDateTime(LstShipping[0].ShipOutboundDeliveryDate);
                            string shipOutDate = objout.ToString(Resource.DateFormat);
                            if (shipOutDate != Resource.BlankDate)
                            {
                                ShipOutboundDeliveryDate = objout.ToString(Resource.DateFormat);
                            }
                            else
                            {
                                ShipOutboundDeliveryDate = Resource.NA;
                            }
                        }
                        else
                        {
                            ShipOutboundDeliveryDate = Resource.NA;
                        }
                        string shipOut = string.Empty;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundPickupDate))
                        {
                            DateTime objoutpic = new DateTime();
                            objoutpic = Convert.ToDateTime(LstShipping[0].ShipOutboundPickupDate);
                            string shipPic = objoutpic.ToString(Resource.DateFormat);
                            if (shipPic != Resource.BlankDate)
                            {
                                shipOut = objoutpic.ToString(Resource.DateFormat);
                            }
                            else
                            {
                                shipOut = Resource.NA;
                            }
                        }
                        else
                        {
                            shipOut = Resource.NA;
                        }
                        ShipOutboundPickupDate = shipOut + "-" + ShipOutboundDeliveryDate;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundPickupTime))
                        {
                            ShipOutboundPickupTime = LstShipping[0].ShipOutboundPickupTime;
                        }
                        else
                        {
                            ShipOutboundPickupTime = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundDeliveryTime))
                        {
                            ShipOutboundDeliveryTime = LstShipping[0].ShipOutboundDeliveryTime;
                        }
                        else
                        {
                            ShipOutboundDeliveryTime = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundCarrier))
                        {
                            ShipOutboundCarrier = LstShipping[0].ShipOutboundCarrier;
                        }
                        else
                        {
                            ShipOutboundCarrier = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundCarrierContact))
                        {
                            ShipOutboundCarrierContact = LstShipping[0].ShipOutboundCarrierContact;
                        }
                        else
                        {
                            ShipOutboundCarrierContact = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundCarrierContact))
                        {
                            ShipOutboundCarrierContact = LstShipping[0].ShipOutboundCarrierContact;
                        }
                        else
                        {
                            ShipOutboundCarrierContact = Resource.NA;
                        }
                        string OutPieces = string.Empty;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundPieces))
                        {
                            OutPieces = LstShipping[0].ShipOutboundPieces;
                        }
                        else
                        {
                            OutPieces = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundDescription))
                        {
                            ShipOutboundDescription = LstShipping[0].ShipOutboundDescription;
                        }
                        else
                        {
                            ShipOutboundDescription = Resource.NA;
                        }
                        ShipOutboundPieces = OutPieces + "/" + ShipOutboundDescription;
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundPhone))
                        {
                            ShipOutboundPhone = LstShipping[0].ShipOutboundPhone;
                        }
                        else
                        {
                            ShipOutboundPhone = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundEmail))
                        {
                            ShipOutboundEmail = LstShipping[0].ShipOutboundEmail;
                        }
                        else
                        {
                            ShipOutboundEmail = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundFax))
                        {
                            ShipOutboundFax = LstShipping[0].ShipOutboundFax;
                        }
                        else
                        {
                            ShipOutboundFax = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipOutboundTracking))
                        {
                            ShipOutboundTracking = LstShipping[0].ShipOutboundTracking;
                        }
                        else
                        {
                            ShipOutboundTracking = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipToOutboundTo))
                        {
                            ShipToOutboundTo = LstShipping[0].ShipToOutboundTo;
                        }
                        else
                        {
                            ShipToOutboundTo = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipToName))
                        {
                            ShipToName = LstShipping[0].ShipToName;
                        }
                        else
                        {
                            ShipToName = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipToAttn))
                        {
                            ShipToAttn = LstShipping[0].ShipToAttn;
                        }
                        else
                        {
                            ShipToAttn = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipToAddress))
                        {
                            ShipToAddress = LstShipping[0].ShipToAddress;
                        }
                        else
                        {
                            ShipToAddress = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipBillingTo))
                        {
                            ShipBillingTo = LstShipping[0].ShipBillingTo;
                        }
                        else
                        {
                            ShipBillingTo = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipBillingName))
                        {
                            ShipBillingName = LstShipping[0].ShipBillingName;
                        }
                        else
                        {
                            ShipBillingName = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipBillingAttn))
                        {
                            ShipBillingAttn = LstShipping[0].ShipBillingAttn;
                        }
                        else
                        {
                            ShipBillingAttn = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipBillingAttn))
                        {
                            ShipBillingAttn = LstShipping[0].ShipBillingAttn;
                        }
                        else
                        {
                            ShipBillingAttn = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipBillingAddress))
                        {
                            ShipBillingAddress = LstShipping[0].ShipBillingAddress;
                        }
                        else
                        {
                            ShipBillingAddress = Resource.NA;
                        }
                        if (!string.IsNullOrEmpty(LstShipping[0].ShipNotes))
                        {
                            IsShippingNote = true;
                            ShipNotes = LstShipping[0].ShipNotes;
                        }
                        else
                        {
                            IsShippingNote = false;
                            ShipNotes = Resource.NA;
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
    }
}
