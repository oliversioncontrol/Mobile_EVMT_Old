using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnLocationEVMT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewTemplae : ContentView
    {
        public int height=0;
        public string  TotalST, TotalDT, TotalOT, LaunchTime, TotalTime = string.Empty;
        /// <summary>
        /// lst labor details item tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstLaborDetails_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        public Double ST = 0, OT = 0, DT = 0, TT = 0, LT = 0;
        public OverviewTemplae(string Date, List<BoothLabor> lstLaborDetail)
        {
            try
            {
                InitializeComponent();
                if (lstLaborDetail.Count > 0)
                {
                    LstLaborDetails.ItemsSource = lstLaborDetail;
                    height = lstLaborDetail.Count;
                    LstLaborDetails.HeightRequest = 0;// lstLaborDetail.Count * 50+20;
                    foreach (TapGestureRecognizer item in lblnotes.GestureRecognizers)
                    {
                        item.CommandParameter= lstLaborDetail[0].AllNotes;
                    }   
                    if(lstLaborDetail[0].AllNotes==OnLocationEVMT.Resource.NA)
                    {
                        lblnotes.IsVisible = false;
                        boxview.IsVisible = false;
                    }
                    else
                    {
                        lblnotes.IsVisible = true;
                        boxview.IsVisible = true;
                    }
                    DateTime objCreateDate = new DateTime();
                    objCreateDate = Convert.ToDateTime(lstLaborDetail[0].WorkDate);
                    string CreateDate = objCreateDate.ToString(OnLocationEVMT.Resource.DateFormat);
                    if (CreateDate != OnLocationEVMT.Resource.BlankDate)
                    {
                        lblday.Text ="("+objCreateDate.ToString("dddd", CultureInfo.InvariantCulture)+")";
                        lbldate.Text = objCreateDate.ToString(OnLocationEVMT.Resource.DateFormat);
                    }
                    else
                    {
                        lbldate.Text = OnLocationEVMT.Resource.NA;
                    }
                    foreach (var item in lstLaborDetail)
                    {
                        if (!string.IsNullOrEmpty(item.ST))
                        {                            
                            ST = ST + Convert.ToDouble(item.ST);
                        }
                        if (!string.IsNullOrEmpty(item.OT))
                        {
                            
                            OT = OT + Convert.ToDouble(item.OT);
                        }
                        if (!string.IsNullOrEmpty(item.DT))
                        {
                           
                            DT = DT + Convert.ToDouble(item.DT);
                        }
                        if (!string.IsNullOrEmpty(item.LunchTime))
                        {
                            
                            LT = LT + Convert.ToDouble(item.LunchTime);
                        }
                        if (!string.IsNullOrEmpty(item.TotalHours))
                        {                            
                            TT = TT + Convert.ToDouble(item.TotalHours);
                        }
                    }

                    lbltotaldt.Text = Convert.ToString(DT);
                    lbltotalst.Text = Convert.ToString(ST);
                    lbltotalot.Text = Convert.ToString(OT);
                    lbllaunchtime.Text = Convert.ToString(LT);
                    lbltotaltime.Text = Convert.ToString(TT);
                }
                else
                {
                    lbltotaldt.Text = Convert.ToString(DT);
                    lbltotalst.Text = Convert.ToString(ST);
                    lbltotalot.Text = Convert.ToString(OT);
                    lbllaunchtime.Text = Convert.ToString(LT);
                    lbltotaltime.Text = Convert.ToString(TT);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        public OverviewTemplae(string Date,string LaborNote, List<LaborDetail> lstLaborDetail)
        {
            try
            {
                InitializeComponent();
                if (lstLaborDetail.Count > 0)
                {
                    LstLaborDetails.ItemsSource = lstLaborDetail;
                    height = lstLaborDetail.Count;
                    LstLaborDetails.HeightRequest = 0;// lstLaborDetail.Count * 50+20;
                    foreach (TapGestureRecognizer item in lblnotes.GestureRecognizers)
                    {
                        item.CommandParameter = LaborNote;
                    }
                    if (LaborNote == string.Empty)
                    {
                        lblnotes.IsVisible = false;
                        boxview.IsVisible = false;
                    }
                    else
                    {
                        lblnotes.IsVisible = true;
                        boxview.IsVisible = true;
                    }

                    //DateTime objCreateDate = new DateTime();
                    //objCreateDate = Convert.ToDateTime(Date.Replace("12:00:00 AM", string.Empty));
                    lbldate.Text = Date.Replace("12:00:00 AM", string.Empty);// objCreateDate.ToString(OnLocationEVMT.Resource.DateFormat);
                    
                    foreach (var item in lstLaborDetail)
                    {
                        if (!string.IsNullOrEmpty(item.ST))
                        {
                            ST = ST + Convert.ToDouble(item.ST);
                        }
                        if (!string.IsNullOrEmpty(item.OT))
                        {

                            OT = OT + Convert.ToDouble(item.OT);
                        }
                        if (!string.IsNullOrEmpty(item.DT))
                        {

                            DT = DT + Convert.ToDouble(item.DT);
                        }
                        if (!string.IsNullOrEmpty(item.LunchTime))
                        {

                            LT = LT + Convert.ToDouble(item.LunchTime);
                        }
                        if (!string.IsNullOrEmpty(item.TotalHours))
                        {
                            TT = TT + Convert.ToDouble(item.TotalHours);
                        }
                    }
                    lbltotaldt.Text = Convert.ToString(DT);
                    lbltotalst.Text = Convert.ToString(ST);
                    lbltotalot.Text = Convert.ToString(OT);
                    lbllaunchtime.Text = Convert.ToString(LT);
                    lbltotaltime.Text = Convert.ToString(TT);
                }
                else
                {
                    lbltotaldt.Text = Convert.ToString(DT);
                    lbltotalst.Text = Convert.ToString(ST);
                    lbltotalot.Text = Convert.ToString(OT);
                    lbllaunchtime.Text = Convert.ToString(LT);
                    lbltotaltime.Text = Convert.ToString(TT);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Image TapGestureRecognizer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (LstLaborDetails.IsVisible == true)
            {
                img.Source = "colapse.png";
                LstLaborDetails.IsVisible = false;
                LstLaborDetails.HeightRequest = 0;
                grdtotal.IsVisible = false;
                lblNote.IsVisible = false;
            }
            else
            {
                img.Source = "expand.png";
                LstLaborDetails.IsVisible = true;
                LstLaborDetails.HeightRequest =36+height * 42;
                grdtotal.IsVisible = true;
                lblNote.IsVisible = true;
            }
        }
    }
}