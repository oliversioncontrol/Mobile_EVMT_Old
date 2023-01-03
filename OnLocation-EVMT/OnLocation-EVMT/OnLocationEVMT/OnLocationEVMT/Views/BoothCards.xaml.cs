using OnLocationEVMT.Controls;
using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnLocationEVMT.Views
{
    public partial class BoothCards : ContentPage
    {       
        bool ParentPage = false;
        bool Isappering = false;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public BoothCards(bool IsPage)
        {
           
            try
            {
                InitializeComponent();
                ParentPage = IsPage;
                Isappering = true;
                lstBoothcard.IsPullToRefreshEnabled = true;
                lstBoothcard.RefreshCommand = VM.RefreshCommand;
                lstBoothcard.SetBinding(ListView.IsRefreshingProperty, nameof(VM.IsBusyPull));
                Loader objLoader = new Loader();
                overlay = objLoader.GetLoader(overlay);
                RelativeLayout relativeLayout = new RelativeLayout();
                relativeLayout.Children.Add(
                           gridMain,
                           Constraint.Constant(0),
                           Constraint.Constant(0),
                           Constraint.RelativeToParent((parent) => { return parent.Width; }),
                           Constraint.RelativeToParent((parent) => { return parent.Height; }));

                relativeLayout.Children.Add(
                   overlay,
                   Constraint.Constant(0),
                   Constraint.Constant(0),
                   Constraint.RelativeToParent((parent) => { return parent.Width; }),
                   Constraint.RelativeToParent((parent) => { return parent.Height; }));
                Content = relativeLayout;
                overlay.SetBinding(AbsoluteLayout.IsVisibleProperty, OnLocationEVMT.Resource.IsBusy);
                //StartDate_Picker.Date = DateTime.Now.AddDays(-6);
                //EndDate_Picker.Date = DateTime.Now;
                VM.EndDate = DateTime.Now.AddDays(2); ;
                VM.StartDate = DateTime.Now.AddDays(-29);
                StartDate_Picker.DateSelected += StartDate_Picker_DateSelected;
                EndDate_Picker.DateSelected += EndDate_Picker_DateSelected;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }


        }

        /// <summary>
        /// listview item tapped command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstOpenLoans_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void EndDate_Picker_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                DateTime EndDate = new DateTime();
                EndDate = e.NewDate;
                if (EndDate != null)
                {                   
                    VM.WorkEndDate = EndDate.ToString(OnLocationEVMT.Resource.DateFormatOpp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void StartDate_Picker_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                DateTime StartDate = new DateTime();
                StartDate = e.NewDate;
                if (StartDate != null)
                {                    
                   VM.WorkStartDate = StartDate.ToString(OnLocationEVMT.Resource.DateFormatOpp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Backbutton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (ParentPage)
            {
                if (VM.IsClicked)
                {
                    VM.IsClicked = false;
                    Navigation.PushModalAsync(new Views.Home());
                }
            }
            else
            {
                Navigation.PopModalAsync();
            }
        }

        /// <summary>
        /// Homebutton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (VM.IsClicked)
            {
                VM.IsClicked = false;                
                App.Current.MainPage = new NavigationPage(new Home());
            }
        }



        /// <summary>
        /// OnAppering Events
        /// </summary>
        protected override void OnAppearing()
        {
            VM.IsClicked = true;
            try
            {
                if (Isappering)
                {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        Loader objLoader = new Loader();
                        AbsoluteLayout overlay = new AbsoluteLayout();
                        RelativeLayout relativeLayout = new RelativeLayout();
                        overlay = objLoader.GetLoader(overlay);
                        relativeLayout.Children.Add(
                                   gridMain,
                                   Constraint.Constant(0),
                                   Constraint.Constant(0),
                                   Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                   Constraint.RelativeToParent((parent) => { return parent.Height; }));
                        relativeLayout.Children.Add(
                           overlay,
                           Constraint.Constant(0),
                           Constraint.Constant(0),
                           Constraint.RelativeToParent((parent) => { return parent.Width; }),
                           Constraint.RelativeToParent((parent) => { return parent.Height; }));
                        Content = relativeLayout;
                        overlay.SetBinding(AbsoluteLayout.IsVisibleProperty, OnLocationEVMT.Resource.IsBusy);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            Isappering = false;
        }

        /// <summary>
        /// End Date Picker Tab Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndDatePkr_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => {
                EndDate_Picker.Focus();
            });
        }
        /// <summary>
        /// Start Date Picke tab events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDatePkr_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => {
                StartDate_Picker.Focus();
            });
        }


        /// <summary>
        /// Listview Item Appering events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lstBoothcard_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                BoothCardModel item = e.Item as BoothCardModel;
                if (item.ID == VM.LstSearchList[VM.LstSearchList.Count - 1].ID)
                {
                    if (VM.LstSearchList.Count > 9)
                    {
                        //we do'nt want show the loader we can comment
                        //vm.IsBusyLoader = true;
                        VM.IsBusy = true;
                        // await Task.Delay(1000);
                        await VM.GetBoothCardDetails(false,1);
                        VM.IsBusy = false;
                        // vm.IsBusyLoader = false;
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