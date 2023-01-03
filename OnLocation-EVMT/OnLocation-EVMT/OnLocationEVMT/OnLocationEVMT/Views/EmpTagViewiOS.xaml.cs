using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnLocationEVMT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpTagViewiOS : ContentView
    {
        List<To> list = new List<To>();
        public byte[] profileimg = null;
        public EmpTagViewiOS(Recognition lstEmpTo)
        {
            InitializeComponent();
            try
            {
                byte[] profileimg = null;
                if (lstEmpTo != null)
                {
                    if (!string.IsNullOrEmpty(lstEmpTo.avatar))
                    {
                        if (lstEmpTo.avatar.Contains("-"))
                        {
                            profileimg = DependencyService.Get<IDownloadService>().DownloadImage("http:" + lstEmpTo.avatar, "abc.png");
                            if (profileimg != null)
                            {
                                lblAvatar.Source = ImageSource.FromStream(() => new MemoryStream(profileimg));
                                // profileimg = null;
                            }
                            else
                            {
                                lblAvatar.Source = "NotFound.png";
                            }
                        }
                        else
                        {
                            lblAvatar.Source = "http:" + lstEmpTo.avatar;
                        }
                    }
                    else
                    {
                        lblAvatar.Source = "NotFound.png";
                        //lblAvatar.Source = ImageSource.FromStream(() => new MemoryStream(DependencyService.Get<IDownloadService>().DownloadImage("http:" + lstEmpTo.avatar, "abc.png")));
                    }
                    lblName.Text = lstEmpTo.name;
                    lblTest.Text = lstEmpTo.text;
                    //lblEmail.Text = lstEmpTo.email;
                    lblDateTime.Text = lstEmpTo.date.ToUniversalTime().ToString("MMMM dd yyyy, hh:mm tt", CultureInfo.InvariantCulture);
                    //lblDateTime.Text = lstEmpTo.date.ToString();

                    foreach (var item in lstEmpTo.to)
                    {
                        byte[] profileavat = null;
                        if (!string.IsNullOrEmpty(item.avatar))
                        {
                            if (item.avatar.Contains("-"))
                            {
                                profileavat = DependencyService.Get<IDownloadService>().DownloadImage("http:" + item.avatar, "abc.png");
                                if (profileavat != null)
                                {
                                    item.img = ImageSource.FromStream(() => new MemoryStream(profileavat));
                                    // profileavat = null;
                                }
                                else
                                {
                                    item.img = "NotFound.png";
                                }
                            }
                            else
                            {
                                //item.img = "NotFound.png";
                                item.img = "http:" + item.avatar;
                            }
                        }
                        else
                        {
                            item.img = "NotFound.png";
                        }
                        if (item.name.Length > 14)
                        {
                            item.name = item.name.Substring(0, 14) + "...";
                        }
                        list.Add(item);
                    }
                    lstEmpAccolades.ItemsSource = list;
                    lstEmpAccolades.HeightRequest = list.Count() * 170;
                }

            }
            catch (Exception ex)
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