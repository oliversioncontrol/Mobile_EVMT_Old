using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnLocationEVMT.Views
{	
	public partial class test : ContentPage
    {
        StackLayout objs = new StackLayout();
        public test ()
		{
			InitializeComponent ();
            objs.BackgroundColor = Color.Blue;
            scmain.Content = objs;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            WebView obj = new WebView();
            obj.HeightRequest = 100;
            obj.BackgroundColor = Color.Black;
            HtmlWebViewSource src = new HtmlWebViewSource();
            src.Html = "<html><body><img src='https://images.pexels.com/photos/112460/pexels-photo-112460.jpeg?cs=srgb&dl=car-vehicle-luxury-112460.jpg&fm=jpg' width='100' height='100'>Rakesh</body></html>";
            obj.Source = src;      
           
            objs.Children.Add(obj);
           
        }
    }
}