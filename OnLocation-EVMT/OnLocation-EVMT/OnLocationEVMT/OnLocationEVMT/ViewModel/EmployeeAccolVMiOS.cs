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
   public class EmployeeAccolVMiOS: ObservableObject
    {

        public ObservableRangeCollection<Recognition> lstEmpAccolades { get; set; }
        public bool _IsRunning;
        /// <summary>
        /// Gets or Sets IsRunning
        /// </summary>
        public bool IsRunning
        {
            get { return _IsRunning; }
            set
            {
                _IsRunning = value;
                OnPropertyChanged(nameof(IsRunning));
            }
        }

        public ContentView _EmpTagViewBind;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public ContentView EmpTagViewBind
        {
            get { return _EmpTagViewBind; }
            set
            {
                _EmpTagViewBind = value;
                OnPropertyChanged(nameof(EmpTagViewBind));
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

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeAccolVMiOS()
        {
            try
            {
                EmpTagViewBind = new ContentView();
                EmpTagViewBind.Content = stklayout;
                lstEmpAccolades = new ObservableRangeCollection<Recognition>();
                Get();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method For Get
        /// </summary>
        public async void Get()
        {
            try
            {
                IsBusy = true;
                await GetEmpAccolades();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
        StackLayout stklayout = new StackLayout();
        public int totaldata = 0;
        public int page = 1;
        public int index = 1;

        /// <summary>
        /// Method for Get Employee Accolades
        /// </summary>
        /// <returns></returns>
        public async Task GetEmpAccolades()
        {

            EmpAccol lstProjectYear = new EmpAccol();
            EmployeeAccoladesService EmpAccoladesServices = new EmployeeAccoladesService();
            try
            {

                lstProjectYear = await EmpAccoladesServices.GetEmpAccolades(index);
                if (lstProjectYear != null)
                {
                    if (lstProjectYear.success)
                    {
                        totaldata = lstProjectYear.total;
                        index++;

                        foreach (var item in lstProjectYear.recognitions)
                        {
                            stklayout.Children.Add(new Views.EmpTagViewiOS(item));                            
                            page++;                           
                        }
                      
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, "No Record Found", Resource.OK);
                    }
                }
                else
                {
                    if (IsConneciton.IsConnection)
                    {
                        await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.ProcessingRequest, Resource.OK);
                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert(Resource.NetworkAlert, Resource.NetworkError, Resource.OK);
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                }
                IsRunning = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }

}
