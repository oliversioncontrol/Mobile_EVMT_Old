using OnLocationEVMT.Controls;
using OnLocationEVMT.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace OnLocationEVMT.Views
{
    public partial class BoothCardDetails : ContentPage
    {
        public static string BoothNumber;
        public static bool IsSubmited;
        public static bool IsReviewed;
        public static string ProjID;
        public static bool IsBoothSign;
        bool Isappering = false;
        private double hours, TotalTimes, totime=1D;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public BoothCardDetails(BoothCardModel DTO)
        {
            ProjID = DTO.Project;
            BoothNumber = DTO.Boothcard;
            IsSubmited = ((DTO.SubmittedDate == OnLocationEVMT.Resource.NA) ? true : false);
            IsReviewed= ((DTO.ReviewSubmittedDate == OnLocationEVMT.Resource.NA) ? true : false);
            IsBoothSign = DTO.IsBoothcardSigned == "F" ? true : false;
            InitializeComponent();
            boxStep1.Color = Color.Gray;
            try
            {
                Isappering = true;
                VM.IsReport= ((DTO.SubmittedDate == OnLocationEVMT.Resource.NA) ? false : true);
                VM.PreparedBy = DTO.Preparedby;
                VM.SubmittedBy = DTO.Submittedby;
                VM.ReviewedBy = DTO.ReviewSubmittedByDisplayName;
                VM.EditorNote = DTO.Notes;
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
            }
            catch(Exception ex)
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
        /// Step1 Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void TapStepOne_Tapped(object sender, EventArgs e)
        {
            //Show Open loan section click on open loan tab
            StkEmployee.IsVisible = false;
            StkHeader.IsVisible = true;
            StkNote.IsVisible = false;
            StkMaterial.IsVisible = false;
            boxStep1.Color = Color.Gray;
            boxStep2.Color = Color.Transparent;
            boxStep3.Color = Color.Transparent;
            boxStep4.Color = Color.Transparent;

        }

        /// <summary>
        /// Step 2 Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private async void TapStepTwo_Tapped(object sender, EventArgs e)
        {
            //Show pending loan section click on pending loan tab
            try
            {
                StkEmployee.IsVisible = true;
                StkHeader.IsVisible = false;
                StkNote.IsVisible = false;
                StkMaterial.IsVisible = false;
                boxStep1.Color = Color.Transparent;
                boxStep2.Color = Color.Gray;
                boxStep3.Color = Color.Transparent;
                boxStep4.Color = Color.Transparent;
                VM.IsBusy = true;
                await VM.GetLaborDetails();
                VM.IsBusy = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }


        }
        /// <summary>
		/// Step 3  Tab click.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void TapStepThree_Tapped(object sender, EventArgs e)
        {
            //Show close loan section click on close loan tab
            StkNote.IsVisible = false;
            StkHeader.IsVisible = false;
            StkEmployee.IsVisible = false;
            StkMaterial.IsVisible = true;
            VM.GetEquipmentAndMaterial();
            boxStep1.Color = Color.Transparent;
            boxStep2.Color = Color.Transparent;
            boxStep3.Color = Color.Gray;
            boxStep4.Color = Color.Transparent;

        }

        /// <summary>
        /// Step 4 Tap click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapStepFour_Tapped(object sender, EventArgs e)
        {
            //Show close loan section click on close loan tab
            StkMaterial.IsVisible = false;
          //  VM.GetEquipmentAndMaterial();
            

            StkNote.IsVisible = true;
            StkHeader.IsVisible = false;
            StkEmployee.IsVisible = false;
            boxStep1.Color = Color.Transparent;
            boxStep2.Color = Color.Transparent;
            boxStep3.Color = Color.Transparent;
            boxStep4.Color = Color.Gray;
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
            catch(Exception ex)
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

        private void lstMaterial_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// entryStartHours TextChanged Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryStartHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(VM.StartHours.Length>=2)
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
    }
}