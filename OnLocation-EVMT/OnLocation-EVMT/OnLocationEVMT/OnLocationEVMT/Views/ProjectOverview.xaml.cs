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
   
    public partial class ProjectOverview : ContentPage
    { 
        public static string DetialByJob { get; set; }
        bool Isappering = false;
        StackLayout st = new StackLayout();
        AbsoluteLayout overlay = new AbsoluteLayout();
        public ProjectOverview(BoothCardModel DTO)
        {
            DetialByJob = DTO.Project;
            InitializeComponent();
            boxStep1.Color = Color.Gray;
            try
            {
                VM.AddStackData += VM_AddStackData;
                VM.ProjectId = DTO.Project;
                VM.WorkDate = DTO.WorkDate;
                VM.DateSubmitted = DTO.SubmittedDate;
                VM.SupervisorName = DTO.SupervisorName;
                VM.IsSupervisorPresent = DTO.SupervisorPresent;
                VM.Show = DTO.Show;
                VM.ShowCity = DTO.Citys;
                VM.Exhibitor = DTO.Exhibitor;
                VM.AccountExc = DTO.AccountExec;
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
                grdall.Content = st;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void VM_AddStackData(StackLayout Obj)
        {
            st.Children.Add(Obj);
        }

        /// <summary>
        /// listview item tapped command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstLaborDetails_ItemTapped(object sender, ItemTappedEventArgs e)
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
        /// Open Loan Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void StepOneClick(object sender, EventArgs e)
        {
            //Show Open loan section click on open loan tab
            StkLabor.IsVisible = false;
            StkHeader.IsVisible = true;
            StkMaterial.IsVisible = false;
            boxStep1.Color = Color.Gray;
            boxStep2.Color = Color.Transparent;
            boxStep3.Color = Color.Transparent;
            
        }

        /// <summary>
        /// Pending Loans Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void StepTwoClick(object sender, EventArgs e)
        {
            //Show pending loan section click on pending loan tab
            StkLabor.IsVisible = true;
            StkHeader.IsVisible = false;
            StkMaterial.IsVisible = false;
            boxStep1.Color = Color.Transparent;
            boxStep2.Color = Color.Gray;
            boxStep3.Color = Color.Transparent;
            
        }
        /// <summary>
		/// Close Loans Tab click.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private async void StepThreeClick(object sender, EventArgs e)
        {
            //Show close loan section click on close loan tab
            StkMaterial.IsVisible = true;
            StkHeader.IsVisible = false;
            StkLabor.IsVisible = false;
            boxStep1.Color = Color.Transparent;
            boxStep2.Color = Color.Transparent;
            boxStep3.Color = Color.Gray;
            try
            {
                VM.IsBusy = true;
                if (VM.LstMaterial.Count <= 0)
                {
                    await VM.GetMaterial();
                }
                if (VM.LstEquipment.Count <= 0)
                {
                    await VM.GetEquipment();
                }
                VM.IsBusy = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
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
    }
}