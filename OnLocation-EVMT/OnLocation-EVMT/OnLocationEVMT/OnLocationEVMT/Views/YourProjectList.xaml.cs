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
	public partial class YourProjectList : ContentPage
	{
        bool Isappering = false;
        AbsoluteLayout overlay = new AbsoluteLayout();       
        public YourProjectList (bool IsPage)
		{

			InitializeComponent ();
            VM.SearchImage = "SearchIcon.png";
            VM.ParentPage = IsPage;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
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
        /// Backbutton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (VM.ParentPage)
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
        /// listview item tapped command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstProjectList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// Listview Item Apperaing Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void   lstProjectList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                YourProjectListModel item = e.Item as YourProjectListModel;
                if (item.ID == VM.LstSearchList[VM.LstSearchList.Count - 1].ID)
                {
                    if (VM.LstSearchList.Count > 9)
                    {
                        //we do'nt want show the loader we can comment
                        //vm.IsBusyLoader = true;
                        VM.IsBusy = true;
                        // await Task.Delay(1000);
                        await VM.GetProjectList(false);
                        VM.IsBusy = false;
                        // vm.IsBusyLoader = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Open picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    pkryear.Focus();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
            });
        }
    }
}