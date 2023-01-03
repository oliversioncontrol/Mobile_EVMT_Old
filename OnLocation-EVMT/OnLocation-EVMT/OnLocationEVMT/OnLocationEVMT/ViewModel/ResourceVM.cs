using OnLocationEVMT.Controls;
using OnLocationEVMT.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class ResourceVM: ObservableObject
    {
        Command CommandCompanyNews;
        Command CommandCityGuide;
        Command CommandTradeShow;
        Command CommandKeyContacts;



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

        /// <summary>
        /// Open CommandCompanyNews events
        /// </summary>
        public Command CommandCompanyNewsEvents
        {
            get
            {
                
                if (CommandCompanyNews == null)
                    CommandCompanyNews = new Command(async() =>
                    {
                        try
                        {                            
                            if (Device.RuntimePlatform == Device.Android)
                            {
                                if (ScreenHeightWidth.CurrentSDKVersion >= 23)
                                {
                                    if (!GrantAndroidPermission.CheckPermissions((int)AndroidPermissionName.Storage))
                                    {
                                        await App.Current.MainPage.DisplayAlert(Resource.PermissionsRequired, Resource.PermissionMessgae, Resource.OK);
                                        GrantAndroidPermission.GrantPermissions((int)AndroidPermissionName.Storage);
                                        await Task.Delay(1000);
                                    }

                                    if (GrantAndroidPermission.CheckPermissions((int)AndroidPermissionName.Storage))
                                    {
                                        if (IsClicked)
                                        {
                                            IsClicked = false;
                                            IsBusy = true;
                                            await Task.Delay(2000);
                                            await App.Current.MainPage.Navigation.PushModalAsync(new Views.NewsAndEvents());
                                            IsBusy = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (IsClicked)
                                    {
                                        IsClicked = false;
                                        IsBusy = true;
                                        await Task.Delay(2000);
                                        await App.Current.MainPage.Navigation.PushModalAsync(new Views.NewsAndEvents());
                                        IsBusy = false;
                                    }
                                }
                            }
                            else
                            {
                                if (IsClicked)
                                {
                                    IsClicked = false;
                                    IsBusy = true;
                                    await Task.Delay(2000);
                                    await App.Current.MainPage.Navigation.PushModalAsync(new Views.NewsAndEvents());
                                    IsBusy = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            IsBusy = false;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandCompanyNews;
            }
        }      

       


        /// <summary>
        /// Open CommandCityGuide events
        /// </summary>
        public Command CommandCityGuideEvents
        {
            get
            {
                if (CommandCityGuide == null)
                    CommandCityGuide = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.CityGuide());
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandCityGuide;
            }
        }

        /// <summary>
        /// Open CommandTradeShow events
        /// </summary>
        public Command CommandTradeShoweEvents
        {
            get
            {
                if (CommandTradeShow == null)
                    CommandTradeShow = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;                               
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.TradeShowURL());
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandTradeShow;
            }
        }

        /// <summary>
        /// Open CommandKeyContacts events
        /// </summary>
        public Command CommandKeyContactsEvents
        {
            get
            {
                if (CommandKeyContacts == null)
                    CommandKeyContacts = new Command((req) =>
                    {                        
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.KeyContact());
                            }
                        }
                        catch (Exception ex)
                        {
                            IsClicked = true;
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandKeyContacts;
            }
        }
    }
}