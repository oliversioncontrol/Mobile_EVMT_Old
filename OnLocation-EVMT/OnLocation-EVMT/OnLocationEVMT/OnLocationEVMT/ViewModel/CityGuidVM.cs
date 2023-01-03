using OnLocationEVMT.Helpers;
using Plugin.Connectivity;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class CityGuidVM: ObservableObject
    {
        Command CommandLasVegas;
        Command CommandOrlando;
        Command CommandChicago;
        Command CommandPhiladelphia;
        Command CommandNewyork;


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
        public CityGuidVM()
        {
            Get();
        }

        /// <summary>
        /// Get Method For showing loader
        /// </summary>
        public async void Get()
        {
            try
            {
                await Task.Run(async () =>
                {
                    IsBusy = true;
                    await Task.Delay(3000);
                    IsBusy = false;
                });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Open commandYourTeam events
        /// </summary>
        public Command CommandLasVegasEvents
        {
            get
            {
                if (CommandLasVegas == null)
                    CommandLasVegas = new Command(async(req) =>
                    {
                        try
                        {                           
                            bool isconnected = CrossConnectivity.Current.IsConnected;
                            if (isconnected)
                            {
                                Device.OpenUri(new Uri(Resource.LasPDF));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandLasVegas;
            }
        }

        /// <summary>
        /// Open commandYourProject events
        /// </summary>
        public Command CommandOrlandoEvents
        {
            get
            {
                if (CommandOrlando == null)
                    CommandOrlando = new Command(async(req) =>
                    {
                        try
                        {                           
                            bool isconnected = CrossConnectivity.Current.IsConnected;
                            if (isconnected)
                            {
                                Device.OpenUri(new Uri(Resource.OrlandoPDF));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandOrlando;
            }
        }

        /// <summary>
        /// Open commandYourResource events
        /// </summary>
        public Command CommandChicagoEvents
        {
            get
            {
                if (CommandChicago == null)
                    CommandChicago = new Command(async(req) =>
                    {
                        try
                        {
                            bool isconnected = CrossConnectivity.Current.IsConnected;
                            if (isconnected)
                            {
                                Device.OpenUri(new Uri(Resource.ChicagoPDF));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandChicago;
            }
        }

        /// <summary>
        /// Open commandYourPic events
        /// </summary>
        public Command CommandPhiladelphiaEvents
        {
            get
            {
                if (CommandPhiladelphia == null)
                    CommandPhiladelphia = new Command(async(req) =>
                    {
                        try
                        {
                           
                            bool isconnected = CrossConnectivity.Current.IsConnected;
                            if (isconnected)
                            {
                                Device.OpenUri(new Uri(Resource.PhiladephiaPDF));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandPhiladelphia;
            }
        }

        /// <summary>
        ///  CommandNewyork events
        /// </summary>
        public Command CommandNewYorkEvents
        {
            get
            {
                if (CommandNewyork == null)
                    CommandNewyork = new Command(async (req) =>
                    {
                        try
                        {

                            bool isconnected = CrossConnectivity.Current.IsConnected;
                            if (isconnected)
                            {
                                Device.OpenUri(new Uri(Resource.NYCPDF));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandNewyork;
            }
        }

    }
}
