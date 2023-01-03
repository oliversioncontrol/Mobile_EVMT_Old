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
	public partial class Home : ContentPage
	{
		public Home ()
		{
            try
            {
                InitializeComponent();
                if(Device.Idiom==TargetIdiom.Tablet)
                {
                    gridcontainer.RowDefinitions[3].Height = new GridLength(1, GridUnitType.Auto);
                    gridcontainer.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    gridcontainer.RowDefinitions[3].Height = new GridLength(1, GridUnitType.Star);
                    gridcontainer.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Auto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }      
       

        /// <summary>
        /// OnAppering Events
        /// </summary>
        protected override void OnAppearing()
        {           
            try
            {
                VM.IsClicked = true;
                //Device.BeginInvokeOnMainThread(() =>
                //{
                    if (UserAccounts.LoginUser == "C")
                    {
                        VM.IsBoothCards = false;
                    }
                    else
                    {
                        VM.IsBoothCards = true;
                    }
                    if(!string.IsNullOrEmpty(UserAccounts.LoginUserID))
                    {
                        VM.IsLogout = true;
                    }
                    else
                    {
                        VM.IsLogout = false;
                    }
               // });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        
    }

}