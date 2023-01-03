using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    /// <summary>
    /// Class Login view model implementation
    /// </summary>
    class LoginVM : ObservableObject
    {
        Command CommandGoToHome;
        public ICommand LoginCommand { private set; get; }



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

        private string _userName;
        /// <summary>
        /// Gets or sets the IsBusy.
        /// </summary>
        /// <value>The _IsBusy.</value>
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }


        private string _password;
        /// <summary>
        /// Gets or sets the IsBusy.
        /// </summary>
        /// <value>The _IsBusy.</value>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        /// <summary>
        /// Constructor implementation
        /// </summary>
        public LoginVM()
        {
            LoginCommand = new Command(async () =>

                {
                    if (IsClicked)
                    {
                        IsClicked = false;
                        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NameAndPassword, Resource.OK);
                            IsClicked = true;
                        }
                        else
                        {
                            bool isconnected = CrossConnectivity.Current.IsConnected;
                            if (isconnected)
                            {
                                await CheckLogin();
                            }
                            else
                            {
                                IsClicked = true;
                                await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                            }
                        }
                    }

                });
        }



        /// <summary>
        /// Open CommandGoToHomeEvents events
        /// </summary>
        public Command CommandGoToHomeEvents
        {
            get
            {
                if (CommandGoToHome == null)
                    CommandGoToHome = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PopModalAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandGoToHome;
            }
        }

        /// <summary>
        /// Method for check login credentials
        /// </summary>
        /// <returns></returns>
        public async Task CheckLogin()
        {
            List<UserTypes> userType = new List<UserTypes>();
            try
            {
                IsBusy = true;
                int result = await DependencyService.Get<ILoginServices>().VerfiyLogin(UserName, Password);
                if (result == 1)
                {
                    UserTypeServices ServiceProviderUserType = new UserTypeServices();
                    userType = await ServiceProviderUserType.GetClientType(Resource.MethodGetUserType, UserName);
                    if (userType != null && userType.Count != 0)
                    {
                        int TypePage = Views.Login.PageType;
                        if (userType[0] != null)
                        {
                            string Client = UserName + "_" + userType[0].UserType;
                            await DependencyService.Get<ISaveAndLoad>().SaveTextAsync("temp.txt", Client);
                            UserAccounts.LoginUser = userType[0].UserType;
                            UserAccounts.LoginUserID = UserName;
                        }
                        else
                        {
                            UserAccounts.LoginUserID = UserName;
                            UserAccounts.LoginUser = string.Empty;
                        }                       
                        switch (TypePage)
                        {
                            case 0:
                                await App.Current.MainPage.Navigation.PushModalAsync(new Views.YourProjectList(true));
                                break;                            
                            case 2:
                                await App.Current.MainPage.Navigation.PushModalAsync(new Views.YourTeam(true));
                                break;
                            case 3:
                                if (userType[0].UserType == "E")
                                {
                                    await App.Current.MainPage.Navigation.PushModalAsync(new Views.BoothCards(true));
                                }
                                else
                                {                                    
                                    await App.Current.MainPage.Navigation.PopModalAsync();
                                }
                                break;
                            case 4:
                                if (userType[0].UserType == "E")
                                {
                                    if (Device.RuntimePlatform == Device.iOS)
                                    {
                                        await App.Current.MainPage.Navigation.PushModalAsync(new Views.EmployeeAccoladesiOS(false));
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.Navigation.PushModalAsync(new Views.EmpAccolades(true));
                                    }
                                }
                                else
                                {
                                    await App.Current.MainPage.Navigation.PopModalAsync();
                                }
                                break;
                            default:
                                await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                                break;
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
                else
                {
                    if (result == 2)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Invalid, Resource.InvalidUser, Resource.OK);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Invalid, Resource.ProcessingRequest, Resource.OK);
                    }
                }
                IsClicked = true;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsClicked = true;
                Debug.WriteLine(ex.StackTrace);
            }
            IsBusy = false;
        }
    }
}
