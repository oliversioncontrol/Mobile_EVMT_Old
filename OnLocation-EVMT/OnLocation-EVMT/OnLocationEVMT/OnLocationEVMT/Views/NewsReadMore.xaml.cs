using OnLocationEVMT.Controls;
using OnLocationEVMT.DependencyServices;
using Plugin.Connectivity;
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
    public partial class NewsReadMore : ContentPage
    {
        public static string _NewsURL { get; set; }
        bool Isappering = false;
        public bool IsAppering = false;       
        AbsoluteLayout overlay = new AbsoluteLayout();      

        public NewsReadMore(string url)
        {
            _NewsURL = url;
            
            try
            {
                InitializeComponent();
                BindingContext = VM;
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

                if (Device.RuntimePlatform == Device.Android)
                {
                    VM.IsBusy = true;                  
                }
                else
                {
                    IsAppering = true;
                }
                bool isconnected = CrossConnectivity.Current.IsConnected;
                if (isconnected)
                {                   
                    webview.Source = url;
                }
                else
                {
                    VM.IsBusy = false;
                    App.Current.MainPage.DisplayAlert(OnLocationEVMT.Resource.NetworkAlert, OnLocationEVMT.Resource.NetworkError, OnLocationEVMT.Resource.OK);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
           
           
        }

        /// <summary>
        /// Web on start navigation events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            //VM.IsBusy = true;
            if (IsAppering)
            {
                IsAppering = false;                
                VM.IsBusy = true;
            }
        }

        /// <summary>
        /// Web on End navigation events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WebOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {            
            VM.IsBusy = false;            
        }

        /// <summary>
        /// Back button events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        // <summary>
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

       
    }
}