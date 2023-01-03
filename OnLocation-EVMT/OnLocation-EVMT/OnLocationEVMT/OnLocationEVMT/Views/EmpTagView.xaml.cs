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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpTagView : ContentView
    {
        /*List<*/To/*>*/ lstEmpList = new /*List<*/To/*>*/();
        public EmpTagView(/*List<*/To/*>*/ lstEmpTo)
        {
            InitializeComponent();
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (lstEmpTo != null)
                    {
                        img.Source= "http:" + lstEmpTo.avatar;
                        lbl.Text = lstEmpTo.name;
                        //if (lstEmpTo.Count > 0)
                        //{
                        //    foreach (var item in lstEmpTo)
                        //    {
                        //        item.avatar = "http:" + item.avatar;
                        //        item.name = item.name;
                        //        lstEmpList.Add(item);
                        //    }
                        //    lstviewEmpTo.ItemsSource = lstEmpList;
                        //    lstviewEmpTo.HeightRequest = lstEmpList.Count * 20;
                        //}
                    }
                });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void lstEmpTo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}