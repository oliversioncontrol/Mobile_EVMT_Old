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
    class JobStaffVM : ObservableObject
    {
        public ObservableRangeCollection<JobStaffModel> ListJobStaff { get; set; }

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
        /// Constructor
        /// </summary>
        public JobStaffVM()
        {
            try
            {
                ListJobStaff = new ObservableRangeCollection<JobStaffModel>();
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
            await GetJobStaff();
            IsBusy = false;
        }

        /// <summary>
        /// Method For Key Contacts
        /// </summary>
        /// <returns></returns>
        public async Task GetJobStaff()
        {
            List<JobStaffResponse> LstJobStaf = new List<JobStaffResponse>();

            StaffServices ServiceProvider = new StaffServices();
            try
            {
                LstJobStaf = await ServiceProvider.GetJobStaff(Resource.MethodGetProjectStaff, Views.YourProjectTab.YourProjectDTO.JobNumber);
                if (LstJobStaf != null)
                {
                    foreach (var item in LstJobStaf)
                    {
                        JobStaffModel objstaff = new JobStaffModel();
                        objstaff.AutoCall = CallStoreCommandEvents;
                        objstaff.AutoEmail = AutoEmailCommandEvents;
                        objstaff.EmpName = item.FullName;
                        if (!string.IsNullOrEmpty(item.StaffType))
                        {
                            objstaff.EmpType = item.StaffType;
                        }
                        else
                        {
                            objstaff.EmpType = Resource.NAWithHash;
                        }

                        if (!string.IsNullOrEmpty(item.Email))
                        {
                            objstaff.IsEmail = true;
                            objstaff.EmpEmail = item.Email;
                        }
                        else
                        {
                            objstaff.EmpEmail = string.Empty;
                            objstaff.IsEmail = false;
                        }
                        if (!string.IsNullOrEmpty(item.Phone))
                        {
                            objstaff.IsTelephone = true;
                            objstaff.EmpTelephone = item.Phone;
                        }
                        else
                        {
                            objstaff.EmpTelephone = string.Empty;
                            objstaff.IsTelephone = false;
                        }
                        if (!string.IsNullOrEmpty(item.MobilePhone))
                        {
                            objstaff.IsMobile = true;
                            objstaff.EmpContact = item.MobilePhone;
                        }
                        else
                        {
                            objstaff.EmpContact = string.Empty;
                            objstaff.IsMobile = false;
                        }
                        ListJobStaff.Add(objstaff);
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
