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
    public partial class LaborCallNotes : ContentPage
    {
        HtmlWebViewSource ObjLaborCallNote = new HtmlWebViewSource();
        HtmlWebViewSource ObjSpecialNote = new HtmlWebViewSource();
        bool Isappering = false;
        public LaborCallNotes()
        {
            try
            {
                InitializeComponent();                
                Isappering = true;
                if (!string.IsNullOrEmpty(YourProjectTabVM.SpecialInstructionNote))
                {
                    ObjSpecialNote.Html = YourProjectTabVM.SpecialInstructionNote;
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        SpecialNote.Source = ObjSpecialNote;
                    }
                }
                if (!string.IsNullOrEmpty(YourProjectTabVM.LaborCallNote))
                {
                    ObjLaborCallNote.Html = YourProjectTabVM.LaborCallNote;
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        CallNote.Source = ObjLaborCallNote;
                    }
                }
                if (string.IsNullOrEmpty(YourProjectTabVM.SpecialInstructionNote) && string.IsNullOrEmpty(YourProjectTabVM.LaborCallNote))
                {
                    DisplayAlert(OnLocationEVMT.Resource.Alert, OnLocationEVMT.Resource.NotFound, OnLocationEVMT.Resource.OK);
                    Navigation.PopModalAsync();
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
            if (VM.IsClicked)
            {
                VM.IsClicked = false;
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
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (!string.IsNullOrEmpty(YourProjectTabVM.SpecialInstructionNote))
                    {
                        SpecialNote.Source = ObjSpecialNote;
                    }
                    if (!string.IsNullOrEmpty(YourProjectTabVM.LaborCallNote))
                    {
                        CallNote.Source = ObjLaborCallNote;
                    }
                });

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