using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    /// <summary>
    /// KeyContact View Model class implementation
    /// </summary>
    class KeyContactVM : ObservableObject
    {
        int CurPage { get; set; }
        int ID = 0;
        public ObservableRangeCollection<KeyContactModel> LstKeyContact { get; set; }
       // public List<KeyContactResponse> LstKeyContactDetails { get; set; }
        ImageSource attachmentImage;
        public ImageSource AttachmentImage
        {
            get { return attachmentImage; }
            set { SetProperty(ref attachmentImage, value); }
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
        /// <summary>
        /// Constructor
        /// </summary>
        public KeyContactVM()
        {
            try
            {
                
                LstKeyContact = new ObservableRangeCollection<KeyContactModel>();
                CurPage = 1;
                Get();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        /// <summary>
        /// Method Gor Get With Loader
        /// </summary>
        public async void Get()
        {
            IsBusy = true;
            await GetKeyContact();
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
                catch(Exception ex)
                {                    
                    Debug.WriteLine(ex.StackTrace);
                    return AutoEmailCommand;
                }
            }
        }

        /// <summary>
        /// Method For Key Contacts
        /// </summary>
        /// <returns></returns>
        public async Task GetKeyContact()
        {
            List<KeyContactResponse> LstKeyContactDetails = new List<KeyContactResponse>();
            List<KeyContactModel> keycontactlist = new List<KeyContactModel>();
            KeyContactServices ServiceProvider = new KeyContactServices();
            try
            {
                LstKeyContactDetails = await ServiceProvider.GetClientDetails(CurPage);
                if (LstKeyContactDetails != null)
                {
                    foreach (var item in LstKeyContactDetails)
                    {
                        KeyContactModel objkey = new KeyContactModel();
                        objkey.AutoCall = CallStoreCommandEvents;
                        objkey.AutoEmail = AutoEmailCommandEvents;
                        objkey.EmpName = item.FullName;
                        if (!string.IsNullOrEmpty(item.JobTitle))
                        {
                            objkey.EmpProfile = item.JobTitle;                            
                        }
                        else
                        {
                            objkey.EmpProfile = Resource.NAWithHash;
                        }
                        
                        if (!string.IsNullOrEmpty(item.EmailAddress))
                        {
                            objkey.IsEmail = true;
                            objkey.EmpEmail = item.EmailAddress;
                        }
                        else
                        {
                            objkey.EmpEmail = string.Empty;
                            objkey.IsEmail = false;
                        }
                        if (!string.IsNullOrEmpty(item.BusinessPhone))
                        {
                            objkey.IsTelephone = true;
                            objkey.EmpTelephone = item.BusinessPhone;
                        }
                        else
                        {
                            objkey.EmpTelephone = string.Empty;
                            objkey.IsTelephone = false;
                        }
                        if (!string.IsNullOrEmpty(item.MobileNumber))
                        {
                            objkey.IsMobile = true;
                            objkey.EmpContact = item.MobileNumber;
                        }
                        else
                        {
                            objkey.EmpContact = string.Empty;
                            objkey.IsMobile = false;
                        }


                        if (!string.IsNullOrEmpty(item.Picture))
                        {
                            byte[] ProfileImage = null;                           
                            ProfileImage = System.Convert.FromBase64String(item.Picture.Replace("data:image/jpg;base64,", ""));
                            Stream stream = new MemoryStream(ProfileImage);
                            byte[] m_Bytes = StreamHelper.ReadToEnd(stream);
                            ProfileImage = m_Bytes;
                            objkey.EmpImage = ImageSource.FromStream(() => new MemoryStream(ProfileImage));
                        }
                        else
                        {                            
                            objkey.EmpImage = "NotFound.png";
                        }
                        objkey.ID = ID + 1;
                        ID++;
                        CurPage++;
                        LstKeyContact.Add(objkey);
                    }
                    //LstKeyContact.AddRange(keycontactlist.OrderBy(order => order.EmpName).ToList());
                    //LstKeyContact.AddRange(keycontactlist);


                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        if (LstKeyContact == null)
                        {
                            await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.RequestError, Resource.OK);
                            await App.Current.MainPage.Navigation.PopModalAsync();
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        if (LstKeyContact == null)
                        {
                            await App.Current.MainPage.Navigation.PopModalAsync();
                        }
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
