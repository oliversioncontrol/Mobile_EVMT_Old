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
  public  class EmpAccoladesVM: ObservableObject
    {
        public ObservableRangeCollection<Recognition> lstEmpAccolades { get; set; }
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
        public EmpAccoladesVM()
        {
            lstEmpAccolades = new ObservableRangeCollection<Recognition>();
            Get();
        }

        /// <summary>
        /// Method for Get
        /// </summary>
        public async void Get()
        {
            IsBusy = true;
           await GetEmpAccolades();
            IsBusy = false;
        }
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
                    if(lstProjectYear.success)
                    {
                        index++;
                        foreach (var item  in lstProjectYear.recognitions)
                        {
                           // var tt = item.date.ToUniversalTime();
                            item.DateTime= item.date.ToUniversalTime().ToString("MMMM dd yyyy, hh:mm tt");
                            item.avatar = "http:"+ item.avatar;
                            //item.date = Convert.ToDateTime(date);
                            if (!string.IsNullOrEmpty(item.text))
                             {
                                item.text = item.text.Replace("/n", "&#10;");
                            }
                            StackLayout empstk = new StackLayout();
                            foreach (var itemTo in item.to)
                            {
                                empstk.Children.Add(new Views.EmpTagView(itemTo));
                            }

                            item.EmpTagView = new ContentView();
                            item.EmpTagView.Content = empstk;
                            //if (item.to[0] != null)
                            //{
                            //    item.ColorIcon = "http:" + item.to[0].avatar;
                            //    item.toname = item.to[0].name;
                            //}
                            item.IDCount = page;
                            page++;
                            lstEmpAccolades.Add(item);
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
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
