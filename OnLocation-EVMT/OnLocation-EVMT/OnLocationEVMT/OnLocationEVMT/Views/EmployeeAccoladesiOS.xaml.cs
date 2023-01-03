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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeAccoladesiOS : ContentPage
    {
        /// <summary>
        /// Load Content on scroll view
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_Scrolled(object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            try
            {
                // ScrollView scrollView = sender as MyScrollView;
                double scrollingSpace = MyScrollView.ContentSize.Height - MyScrollView.Height;

                if (scrollingSpace <= e.ScrollY) // Touched bottom
                {
                    if (!VM.IsRunning)
                    {
                        if (VM.totaldata > VM.page)
                        {
                            VM.IsRunning = true;
                            LoadData();
                        }
                    }

                }
                // Do the things you want to do
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        public async void LoadData()
        {
            VM.IsBusy = true;
            await VM.GetEmpAccolades();
            VM.IsBusy = false;
        }

        bool ParentPage = false;
        bool Isappering = false;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public EmployeeAccoladesiOS(bool IsPage)
        {
            try
            {
                InitializeComponent();
                ParentPage = IsPage;
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
                if (VM.IsClicked)
                {
                    VM.IsClicked = false;
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
              

        private void lstEmpAccolades_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}