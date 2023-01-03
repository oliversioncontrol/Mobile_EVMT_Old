using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    /// <summary>
    /// Class YourTeam implementation
    /// </summary>
    class YourTeamVM: ObservableObject
    {
        
        private ObservableCollection<GroupedYourTeamModel> _GroupedYourTeamList;

        /// <summary>
        /// Get or Sets GroupedYourTeamList
        /// </summary>
        public ObservableCollection<GroupedYourTeamModel> GroupedYourTeamList
        {
            get { return _GroupedYourTeamList; }
            set { _GroupedYourTeamList = value;
                OnPropertyChanged(nameof(GroupedYourTeamList));
            }
        }


        Command CallStoreCommand;

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
                catch(Exception ex)
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
                                string email = Convert.ToString(req);
                                int count = 0;
                                foreach (char c in email)
                                {
                                    if ('@' == c)
                                        count++;
                                }
                                if (count == 1)
                                {

                                    Device.OpenUri(new Uri("mailto:" + Convert.ToString(req)));
                                }
                                else
                                {
                                    var emails = email.Split(';');
                                    if (emails != null)
                                    {
                                        Device.OpenUri(new Uri("mailto:" + Convert.ToString(emails[0])));
                                    }
                                }
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
        /// Constructor
        /// </summary>
        public YourTeamVM()
        {
            try
            {              
                GroupedYourTeamList = new ObservableRangeCollection<GroupedYourTeamModel>();
                GetYourTeam();

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        /// <summary>
        /// Methdo for Get Your Team
        /// </summary>
        public async void GetYourTeam()
        {
            IsBusy = true;
            await GetYourTeamData();
            IsBusy = false;
        }

        /// <summary>
        /// Method for Get your team details
        /// </summary>
        /// <returns></returns>
        public async Task GetYourTeamData()
        {
            var YourTeamGroup = new GroupedYourTeamModel() { LongName = "Your Team" };
            var FieldGroup = new GroupedYourTeamModel() { LongName = "In The Field" };
            List<YourTeamResponse> YourTeamObj = new List<YourTeamResponse>();
            YourTeamServices SPyourTeam = new YourTeamServices();
           
            try
            {
                YourTeamObj = await SPyourTeam.GetYourTeamDetails(Resource.MethodGetYourTeam, UserAccounts.LoginUserID);
                if (YourTeamObj != null)
                {
                    foreach (var item in YourTeamObj)
                    {
                        YourTeamModel YourTM = new YourTeamModel();
                        if(item.DisplaySection=="YT")
                        {
                            YourTM.AutoCall = CallStoreCommandEvents;
                            YourTM.AutoEmail = AutoEmailCommandEvents;
                            YourTM.EmpName = item.FullName;
                            if (!string.IsNullOrEmpty(item.JobTitle))
                            {
                                YourTM.EmpProfile = item.JobTitle;
                            }
                            else
                            {
                                YourTM.EmpProfile = Resource.NAWithHash;
                            }

                            if (!string.IsNullOrEmpty(item.EmailAddress))
                            {
                                YourTM.IsEmail = true;
                                YourTM.EmpEmail = item.EmailAddress;
                            }
                            else
                            {
                                YourTM.EmpEmail = string.Empty;
                                YourTM.IsEmail = false;
                            }
                            if (!string.IsNullOrEmpty(item.BusinessPhone))
                            {
                                YourTM.IsTelephone = true;
                                YourTM.EmpTelephone = item.BusinessPhone;
                            }
                            else
                            {
                                YourTM.EmpTelephone = string.Empty;
                                YourTM.IsTelephone = false;
                            }
                            if (!string.IsNullOrEmpty(item.MobileNumber))
                            {
                                YourTM.IsMobile = true;
                                YourTM.EmpContact = item.MobileNumber;
                            }
                            else
                            {
                                YourTM.EmpContact = string.Empty;
                                YourTM.IsMobile = false;
                            }


                            if (!string.IsNullOrEmpty(item.Picture))
                            {
                                byte[] ProfileImage = null;                                
                                ProfileImage = System.Convert.FromBase64String(item.Picture.Replace("data:image/jpg;base64,", ""));
                                Stream stream = new MemoryStream(ProfileImage);
                                byte[] m_Bytes = StreamHelper.ReadToEnd(stream);
                                ProfileImage = m_Bytes;
                                YourTM.EmpImage = ImageSource.FromStream(() => new MemoryStream(ProfileImage));
                            }
                            else
                            {                               
                                YourTM.EmpImage = "NotFound.png";
                            }
                            YourTeamGroup.Add(YourTM);
                        }
                        else
                        {
                            YourTM.AutoCall = CallStoreCommandEvents;
                            YourTM.AutoEmail = AutoEmailCommandEvents;
                            YourTM.EmpName = item.FullName;
                            if (!string.IsNullOrEmpty(item.JobTitle))
                            {
                                YourTM.EmpProfile = item.JobTitle;
                            }
                            else
                            {
                                YourTM.EmpProfile = Resource.NAWithHash;
                            }

                            if (!string.IsNullOrEmpty(item.EmailAddress))
                            {
                                YourTM.IsEmail = true;
                                YourTM.EmpEmail = item.EmailAddress;
                            }
                            else
                            {
                                YourTM.EmpEmail = string.Empty;
                                YourTM.IsEmail = false;
                            }
                            if (!string.IsNullOrEmpty(item.BusinessPhone))
                            {
                                YourTM.IsTelephone = true;
                                YourTM.EmpTelephone = item.BusinessPhone;
                            }
                            else
                            {
                                YourTM.EmpTelephone = string.Empty;
                                YourTM.IsTelephone = false;
                            }
                            if (!string.IsNullOrEmpty(item.MobileNumber))
                            {
                                YourTM.IsMobile = true;
                                YourTM.EmpContact = item.MobileNumber;
                            }
                            else
                            {
                                YourTM.EmpContact = string.Empty;
                                YourTM.IsMobile = false;
                            }


                            if (!string.IsNullOrEmpty(item.Picture))
                            {
                                byte[] ProfileImage = null;                                
                                ProfileImage = System.Convert.FromBase64String(item.Picture.Replace("data:image/jpg;base64,", ""));
                                Stream stream = new MemoryStream(ProfileImage);
                                byte[] m_Bytes = StreamHelper.ReadToEnd(stream);
                                ProfileImage = m_Bytes;
                                YourTM.EmpImage = ImageSource.FromStream(() => new MemoryStream(ProfileImage));
                            }
                            else
                            {                                
                                YourTM.EmpImage = "NotFound.png";
                            }
                            FieldGroup.Add(YourTM);
                        }
                    }
                    GroupedYourTeamList.Add(YourTeamGroup); GroupedYourTeamList.Add(FieldGroup);
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
