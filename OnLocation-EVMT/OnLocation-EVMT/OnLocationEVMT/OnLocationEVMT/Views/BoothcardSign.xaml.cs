using OnLocationEVMT.Controls;
using OnLocationEVMT.Helpers;
using System;
using System.Diagnostics;
using System.IO;

using Xamarin.Forms;

namespace OnLocationEVMT.Views
{
    public partial class BoothcardSign : ContentPage
	{
        bool isappering = false;        
        AbsoluteLayout overlay = new AbsoluteLayout();
        public BoothcardSign (string ProjectID, string BoothcardID)
		{
			InitializeComponent ();
            try
            {
                VM.JobNumber = ProjectID;
                VM.BoothcardID = BoothcardID;
                isappering = true;
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
            catch(Exception ex)
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
            Navigation.PopModalAsync();
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
                if (isappering)
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
            isappering = false;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (!sign.IsBlank)
                {                   
                    Size size = new Size();
                    size.Height = 200;
                    size.Width = 400;
                    Stream image = await sign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png, size, true);
                    byte[] Sign = StreamHelper.ReadToEnd(image);
                    VM.Signature = Convert.ToBase64String(Sign);
                    VM.Get();
                }
                else
                {
                    await DisplayAlert(OnLocationEVMT.Resource.Alert, OnLocationEVMT.Resource.SignHere, OnLocationEVMT.Resource.OK);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}