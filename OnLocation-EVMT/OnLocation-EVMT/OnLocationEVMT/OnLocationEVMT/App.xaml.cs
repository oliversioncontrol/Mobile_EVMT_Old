using OnLocationEVMT.Models;
using OnLocationEVMT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OnLocationEVMT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
               MainPage = new Views.Home();
            // MainPage = new Views.BoothcardSign("52951","33783");
        }

        protected override void OnStart() 
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
