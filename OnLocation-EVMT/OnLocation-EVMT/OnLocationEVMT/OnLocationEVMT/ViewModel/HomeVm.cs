using OnLocationEVMT.Controls;
using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    public class HomeVM : ObservableObject
    {
        Command CommandYourTeam;
        Command CommandYourProject;
        Command CommandYourResource;
        Command CommandEmpAccolades;
        Command CommandBoothCard;
        Command CommandLogoutCommand;

        bool _IsBoothCards;
        /// <summary>
        /// Gets or sets the IsBoothCards.
        /// </summary>
        /// <value>The _IsBoothCards.</value>
        public bool IsBoothCards
        {
            get { return _IsBoothCards; }
            set
            {
                _IsBoothCards = value;
                OnPropertyChanged(nameof(IsBoothCards));
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

        private string _VersionName;
        /// <summary>
        /// Gets or Sets Verison Name
        /// </summary>
        public string VersionName
        {
            get { return _VersionName; }
            set { _VersionName = value;
                OnPropertyChanged(nameof(VersionName));
            }
        }



        public bool _IsLogout;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public bool IsLogout
        {
            get { return _IsLogout; }
            set
            {
                _IsLogout = value;
                OnPropertyChanged(nameof(IsLogout));
            }
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeVM()
        {
            try
            {               
                VersionName = "Ver:" + ScreenHeightWidth.LastInstalledVersionName;
                CheckLogin();
                if (ScreenHeightWidth.IsCheckApp)
                {
                    ScreenHeightWidth.IsCheckApp = false;
                    if (Device.RuntimePlatform == Device.Android)
                    {
                         CheckAppVersion("Android");
                    }
                    else
                    {
                         CheckAppVersion("iOS");
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method Check Credential
        /// </summary>
        /// <returns></returns>
        public async void CheckLogin()
        {
            try
            {                
                var loginInfo = await DependencyService.Get<ISaveAndLoad>().LoadTextAsync("temp.txt");
                string remValue = loginInfo;
                if (!string.IsNullOrEmpty(remValue))
                {
                    string[] strSplitByName = remValue.Split('_');
                    UserAccounts.LoginUser = strSplitByName[1];
                    UserAccounts.LoginUserID = strSplitByName[0];
                    IsLogout = true;
                    if(UserAccounts.LoginUser=="E")
                    {
                        IsBoothCards = true;
                    }
                    else
                    {
                        IsBoothCards = false;
                    }
                }
                else
                {
                    UserAccounts.LoginUser = string.Empty;
                    UserAccounts.LoginUserID = string.Empty;
                    IsLogout = false;
                }                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }



        /// <summary>
        /// Open commandYourTeam events
        /// </summary>
        public Command CommandYourTeamEvents
        {
            get
            {
                if (CommandYourTeam == null)
                    CommandYourTeam = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (string.IsNullOrEmpty(UserAccounts.LoginUser))
                                {
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.Login(2));
                                }
                                else
                                {
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.YourTeam(false));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandYourTeam;
            }
        }

        /// <summary>
        /// Open commandYourProject events
        /// </summary>
        public Command CommandYourProjectEvents
        {
            get
            {
                if (CommandYourProject == null)
                    CommandYourProject = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (string.IsNullOrEmpty(UserAccounts.LoginUser))
                                {
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.Login(0));
                                }
                                else
                                {
                                    App.Current.MainPage.Navigation.PushModalAsync(new Views.YourProjectList(false));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandYourProject;
            }
        }

        /// <summary>
        /// Open commandYourResource events
        /// </summary>
        public Command CommandYourResourceEvents
        {
            get
            {
                if (CommandYourResource == null)
                    CommandYourResource = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                App.Current.MainPage.Navigation.PushModalAsync(new Views.Resource());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandYourResource;
            }
        }

        /// <summary>
        /// Open commandYourPic events
        /// </summary>
        public Command CommandEmpAccoladesEvents
        {
            get
            {
                if (CommandEmpAccolades == null)
                    CommandEmpAccolades = new Command(async(req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (string.IsNullOrEmpty(UserAccounts.LoginUser))
                                {
                                    await App.Current.MainPage.Navigation.PushModalAsync(new Views.Login(4));
                                }
                                else
                                {
                                    if (UserAccounts.LoginUser == "E")
                                    {
                                        if (Device.RuntimePlatform == Device.iOS)
                                        {
                                            await App.Current.MainPage.Navigation.PushModalAsync(new Views.EmployeeAccoladesiOS(false));
                                        }
                                        else
                                        {
                                            await App.Current.MainPage.Navigation.PushModalAsync(new Views.EmpAccolades(false));
                                        }
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert(Resource.Permission, Resource.BoothCardPermission, Resource.OK);
                                        IsClicked = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandEmpAccolades;
            }
        }


        /// <summary>
        /// Open commandYourPic events
        /// </summary>
        public Command CommandBoothCardEvents
        {
            get
            {
                if (CommandBoothCard == null)
                    CommandBoothCard = new Command(async(req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                if (string.IsNullOrEmpty(UserAccounts.LoginUser))
                                {                                    
                                  await App.Current.MainPage.Navigation.PushModalAsync(new Views.Login(3));                                                            
                                }
                                else
                                {
                                    if (UserAccounts.LoginUser == "E")
                                    {
                                       await App.Current.MainPage.Navigation.PushModalAsync(new Views.BoothCards(false));
                                    }
                                    else
                                    {
                                       await App.Current.MainPage.DisplayAlert(Resource.Permission, Resource.BoothCardPermission, Resource.OK);
                                        IsClicked = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandBoothCard;
            }
        }

        /// <summary>
        /// Open commandYourPic events
        /// </summary>
        public Command CommandLogoutCommandEvents
        {
            get
            {
                if (CommandLogoutCommand == null)
                    CommandLogoutCommand = new Command(async(req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                await DependencyService.Get<ISaveAndLoad>().SaveTextAsync("temp.txt", null);
                                UserAccounts.LoginUser = string.Empty;
                                UserAccounts.LoginUserID = string.Empty;
                                App.Current.MainPage = new NavigationPage(new Views.Home());

                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return CommandLogoutCommand;
            }
        }


        public ImageSource _IsClickeds;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public ImageSource IsClickeds
        {
            get { return _IsClickeds; }
            set
            {
                _IsClickeds = value;
                OnPropertyChanged(nameof(IsClickeds));
            }
        }
     
        /// <summary>
        /// Method for Check App version
        /// </summary>
        /// <param name="Platforms"></param>
        /// <returns></returns>
        public async void CheckAppVersion(string Platforms)
        {
            //ScreenHeightWidth.LastInstalledVersionName = "2.2";
             UserNotifyServices ServiceProvider = new UserNotifyServices();
            try
            {
                IsBusy = true;
                string AppVersion = await ServiceProvider.GetAppVersion(Platforms);
                if(AppVersion!=ScreenHeightWidth.LastInstalledVersionCode)
                {
                  await  App.Current.MainPage.DisplayAlert(Resource.Alert,Resource.NewUpdateMessage,Resource.OK);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        private Command OpenSocialLink;
        /// <summary>
        /// Open Social Media Links
        /// </summary>
        public Command OpenSocialLinkEvents
        {
            get
            {
                if (OpenSocialLink == null)
                    OpenSocialLink = new Command((req) =>
                    {
                        try
                        {
                            if (IsClicked)
                            {
                                IsClicked = false;
                                switch (Convert.ToInt32(req))
                                {
                                    case 0:
                                        Device.OpenUri(new Uri("https://plus.google.com/111828473409768500391"));
                                        IsClicked = true;
                                        break;
                                    case 1:
                                        Device.OpenUri(new Uri("https://www.facebook.com/tradeshowlabor"));
                                        IsClicked = true;
                                        break;
                                    case 2:
                                        Device.OpenUri(new Uri("https://www.linkedin.com/company/on-location-inc./"));
                                        IsClicked = true;
                                        break;
                                    case 3:
                                        Device.OpenUri(new Uri("https://twitter.com/TradeShowLabor"));
                                        IsClicked = true;
                                        break;
                                    case 4:
                                        Device.OpenUri(new Uri("https://www.instagram.com/tradeshowlabor/"));
                                        IsClicked = true;
                                        break;
                                    default:
                                        IsClicked = true;
                                        break;
                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }
                    });
                return OpenSocialLink;
            }
        }
    }
}
