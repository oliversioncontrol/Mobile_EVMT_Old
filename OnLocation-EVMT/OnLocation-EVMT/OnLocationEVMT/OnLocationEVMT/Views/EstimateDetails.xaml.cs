using OnLocationEVMT.Controls;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace OnLocationEVMT.Views
{
    public partial class EstimateDetails : ContentPage
    {
        public static string JobNumber { get; set; }
        public static string Service { get; set; }
        bool IsClicked = true;
        bool Isappering = false;
        bool ParentPage = false;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public EstimateDetails(string MethodType, string JobNo,string Services)
        {
            JobNumber = JobNo;
            Service = Services;
            InitializeComponent();
            try
            {               
                Isappering = true;
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
                if (IsClicked)
                {
                    IsClicked = false;
                    App.Current.MainPage = new NavigationPage(new Home());
                }
            }
            else
            {
                Navigation.PopModalAsync();
            }
        }

        /// <summary>
        /// HomeButton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (IsClicked)
            {
                IsClicked = false;
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
        /// List view item tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstOpenLoans_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}