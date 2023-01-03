using OnLocationEVMT.Controls;
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
    public partial class Shipping : ContentPage
    {
        public static string JobNumber { get; set; }
        bool IsClicked = true;
        bool Isappering = false;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public Shipping( string JobNum,string ShowName,string OrderBoothSize,string ExhibitorName,string JobPortfolio)
        {
            try
            {
                JobNumber = JobNum;
                InitializeComponent();
                VM.ShowName = ShowName;
                VM.OrderBoothSize = "Booth Size " + OrderBoothSize;
                VM.ExhibitorNameHeader = ExhibitorName;
                VM.JobPortfolio = JobPortfolio;
                Isappering = true;
                boxInbound.Color = Color.Gray;
                gridInbound.IsVisible = true;
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
        /// Backbutton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            JobNumber = string.Empty;
            Navigation.PopModalAsync();
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
                JobNumber = string.Empty;
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
        /// Open Loan Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void InboundClick(object sender, EventArgs e)
        {
            boxInbound.Color = Color.Gray;
            gridInbound.IsVisible = true;
            gridOutbound.IsVisible = false;
            boxOutbound.Color = Color.Transparent;
        }

        /// <summary>
        /// Pending Loans Tab click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OutboundClick(object sender, EventArgs e)
        {
            boxInbound.Color = Color.Transparent;
            gridInbound.IsVisible = false;
            gridOutbound.IsVisible = true;
            boxOutbound.Color = Color.Gray;
        }
    }
}