using OnLocationEVMT.Controls;
using OnLocationEVMT.ViewModel;
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
	
	public partial class ToDoNotes : ContentPage
	{
        HtmlWebViewSource Obj = new HtmlWebViewSource();
        bool Isappering = false;
        public bool IsAppering = false;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public ToDoNotes ()
		{           
            InitializeComponent ();
            try
            {

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
               if(!string.IsNullOrEmpty(YourProjectTabVM.ToDoNoteDetails))
                {
                    Obj.Html = YourProjectTabVM.ToDoNoteDetails;
                    if(Device.RuntimePlatform==Device.Android)
                    {
                        ToDoNote.Source = Obj;
                    }
                }
              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
        /// <summary>
        /// Back button events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ShippingNotes._ShipNote = string.Empty;
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
                ShippingNotes._ShipNote = string.Empty;
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
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (!string.IsNullOrEmpty(YourProjectTabVM.ToDoNoteDetails))
                    {
                        ToDoNote.Source = Obj;
                    }
                });

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

        private void ShipingNote_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (IsAppering)
            {
                IsAppering = false;
                VM.IsBusy = true;
            }
        }

        private void ShipingNote_Navigated(object sender, WebNavigatedEventArgs e)
        {
            VM.IsBusy = false;
        }
    }
}