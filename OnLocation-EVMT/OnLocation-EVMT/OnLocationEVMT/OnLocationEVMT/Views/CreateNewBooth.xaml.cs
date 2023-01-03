using OnLocationEVMT.Controls;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
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
    public partial class CreateNewBooth : ContentPage
    {
        public static string BoothNumber;
        public static bool IsSubmited;
        bool Isappering = false;
        private double hours, TotalTimes, totime = 1D;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public CreateNewBooth()
        {
            InitializeComponent();
            boxOpen.Color = Color.Gray;
            try
            {
                Isappering = true;
                Loader objLoader = new Loader();
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
                VM.WorkDate = DateTime.Now;
                WorkDate_Picker.DateSelected += WorkDate_Picker_DateSelected;              
                if (string.IsNullOrEmpty(VM.Boothcard))
                {
                    VM.IsFinalSubmitted = false;
                }
                else
                {
                    VM.IsFinalSubmitted = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Work Date Selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkDate_Picker_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                DateTime EndDate = new DateTime();
                EndDate = e.NewDate;
                if (EndDate != null)
                {
                    VM.SelectedWorkDate = EndDate.ToString("yyyy-MM-dd");
                }
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

        /// <summary>
        /// Backbutton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        /// <summary>
        /// HomeButton Tabgesture events
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
        /// Open Loan Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void StepOneClick(object sender, EventArgs e)
        {
            //Show Open loan section click on open loan tab
            StkEmployee.IsVisible = false;
            StkHeader.IsVisible = true;
            StkNote.IsVisible = false;
            StkMaterial.IsVisible = false;
            boxOpen.Color = Color.Gray;
            boxStep4.Color = Color.Transparent;
            boxPending.Color = Color.Transparent;
            boxClose.Color = Color.Transparent;
            if (string.IsNullOrEmpty(VM.Boothcard))
            {
                VM.IsFinalSubmitted = false;
            }
            else
            {
                VM.IsFinalSubmitted = true;
            }
        }

        /// <summary>
        /// Pending Loans Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void StepTwoClick(object sender, EventArgs e)
        {
            //Show pending loan section click on pending loan tab
            StkEmployee.IsVisible = true;
            StkHeader.IsVisible = false;
            StkNote.IsVisible = false;
            StkMaterial.IsVisible = false;
            boxStep4.Color = Color.Transparent;
            boxOpen.Color = Color.Transparent;
            boxPending.Color = Color.Gray;
            boxClose.Color = Color.Transparent;
            if(string.IsNullOrEmpty(VM.Boothcard))
            {
                VM.IsFinalSubmitted = false;
            }
            else
            {
                VM.IsFinalSubmitted = true;
            }
        }
        /// <summary>
		/// Close Loans Tab click.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void StepThreeClick(object sender, EventArgs e)
        {
            //Show close loan section click on close loan tab
            StkNote.IsVisible = false;
            StkHeader.IsVisible = false;
            StkEmployee.IsVisible = false;
            StkMaterial.IsVisible = true;
            boxStep4.Color = Color.Transparent;
            boxOpen.Color = Color.Transparent;
            boxPending.Color = Color.Transparent;
            boxClose.Color = Color.Gray;
            if (string.IsNullOrEmpty(VM.Boothcard))
            {
                VM.IsFinalSubmitted = false;
            }
            else
            {
                VM.IsFinalSubmitted = true;
            }
            VM.BindEquipmentPkr();
        }

        /// <summary>
        /// Step 4 Tab Gesture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepFourClick_Tapped(object sender, EventArgs e)
        {
            boxStep4.Color = Color.Gray;
            StkMaterial.IsVisible = false;
            StkEmployee.IsVisible = false;
            StkHeader.IsVisible = false;
            StkNote.IsVisible = true;
            boxOpen.Color = Color.Transparent;
            boxPending.Color = Color.Transparent;
            boxClose.Color = Color.Transparent;
            if (string.IsNullOrEmpty(VM.Boothcard))
            {
                VM.IsFinalSubmitted = false;
            }
            else
            {
                VM.IsFinalSubmitted = true;
            }
           
        }
        /// <summary>
        /// Entry ST Unfouced Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ST_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                //double result;
                //bool isValid = double.TryParse(VM.LaunchTime, out result);
                //if (isValid)
                //{
                if (string.IsNullOrEmpty(VM.OT))
                {
                    VM.OT = "0";
                }
                if (string.IsNullOrEmpty(VM.DT))
                {
                    VM.DT = "0";
                }
                if (string.IsNullOrEmpty(VM.ST))
                {
                    VM.ST = "0";
                }
                //if (string.IsNullOrEmpty(VM.LaunchTime))
                //{
                //    VM.LaunchTime = "0";
                //}
                TotalTimes = Convert.ToDouble(VM.ST) + Convert.ToDouble(VM.OT) + Convert.ToDouble(VM.DT);
                VM.TotalTime = Convert.ToString(TotalTimes);
                // }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Entry OT Unfouced Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OT_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                //double result;
                //bool isValid = double.TryParse(VM.LaunchTime, out result);
                //if (isValid)
                //{
                if (string.IsNullOrEmpty(VM.OT))
                {
                    VM.OT = "0";
                }
                if (string.IsNullOrEmpty(VM.DT))
                {
                    VM.DT = "0";
                }
                if (string.IsNullOrEmpty(VM.ST))
                {
                    VM.ST = "0";
                }
                //if (string.IsNullOrEmpty(VM.LaunchTime))
                //{
                //    VM.LaunchTime = "0";
                //}
                TotalTimes = Convert.ToDouble(VM.ST) + Convert.ToDouble(VM.OT) + Convert.ToDouble(VM.DT);
                VM.TotalTime = Convert.ToString(TotalTimes);
                // }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
        private void EndDatePkr_Tapped(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// entryStartHours TextChanged Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryStartHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (VM.StartHours.Length >= 2)
            {
                entryStartMinute.Focus();
            }
        }


        /// <summary>
        /// entryStartMinutes TextChanged Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryStartMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (VM.StartMinutes.Length >= 2)
            {
                entryStartMinute.Unfocus();
            }
        }



        /// <summary>
        /// entryStartHours TextChanged Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryEndHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (VM.EndHours.Length >= 2)
            {
                entryEndMinute.Focus();
            }
        }


        /// <summary>
        /// entryStartMinutes TextChanged Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryEndMinute_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (VM.EndMinutes.Length >= 2)
            {
                entryEndMinute.Unfocus();
            }
        }


        /// <summary>
        /// Entry DT Unfouced Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DT_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                //double result;
                //bool isValid = double.TryParse(VM.LaunchTime, out result);
                //if (isValid)
                //{
                if (string.IsNullOrEmpty(VM.OT))
                {
                    VM.OT = "0";
                }
                if (string.IsNullOrEmpty(VM.DT))
                {
                    VM.DT = "0";
                }
                if (string.IsNullOrEmpty(VM.ST))
                {
                    VM.ST = "0";
                }
                //if (string.IsNullOrEmpty(VM.LaunchTime))
                //{
                //    VM.LaunchTime = "0";
                //}
                TotalTimes = Convert.ToDouble(VM.ST) + Convert.ToDouble(VM.OT) + Convert.ToDouble(VM.DT);
                VM.TotalTime = Convert.ToString(TotalTimes);
                // }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private async void EntryProject_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                IsMgrORLeadManServices ObjService = new IsMgrORLeadManServices();
                if (VM.ProjectId.Length > 4)
                {
                    VM.IsBusy = true;
                    VM.LstLaborDetails.Clear();
                    bool result= await ObjService.IsBoothcardLeadman(VM.ProjectId);
                    if (result)
                    {
                        VM.AdminType = 0;
                        await VM.GetJobPortfolio();
                    }
                    else
                    {
                        bool resultSec = await ObjService.IsBoothcardMgr(VM.ProjectId);
                        if(resultSec)
                        {
                            VM.AdminType = 1;
                            await VM.GetJobPortfolio();
                        }
                        else
                        {
                            await DisplayAlert(OnLocationEVMT.Resource.Alert, "No Permission for this Job("+VM.ProjectId+").", OnLocationEVMT.Resource.OK);
                            VM.ProjectId = string.Empty;
                        }
                    }

                    VM.IsBusy = false;
                }
                else
                {
                    VM.LstLaborDetails.Clear();
                    VM.ResetPortFolio();
                   VM.IsPortfolioSubmit = false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        

        /// <summary>
        /// Entry Launch Time Unfouced Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchTime_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                double result;
                bool isValid = double.TryParse(VM.LaunchTime, out result);
                if (isValid)
                {
                    TimeSpan WholeTime = VM.EndTime - VM.StartTime;
                    hours = Convert.ToDouble(VM.LaunchTime);
                    TimeSpan sp = TimeSpan.FromHours(hours);
                    TimeSpan Worktime = WholeTime - sp;
                    totime = Convert.ToDouble(Worktime.TotalHours);
                    VM.ST = Convert.ToString(totime);
                    if (string.IsNullOrEmpty(VM.OT))
                    {
                        VM.OT = "0";
                    }
                    if (string.IsNullOrEmpty(VM.DT))
                    {
                        VM.DT = "0";
                    }
                    if (string.IsNullOrEmpty(VM.ST))
                    {
                        VM.ST = "0";
                    }
                    if (string.IsNullOrEmpty(VM.LaunchTime))
                    {
                        VM.LaunchTime = "0";
                    }
                    TotalTimes = Convert.ToDouble(VM.ST) + Convert.ToDouble(VM.OT) + Convert.ToDouble(VM.DT);
                    VM.TotalTime = Convert.ToString(TotalTimes);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        private void WorkDate_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                WorkDate_Picker.Focus();
            });
        }

        private void lstMaterial_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

    }
}