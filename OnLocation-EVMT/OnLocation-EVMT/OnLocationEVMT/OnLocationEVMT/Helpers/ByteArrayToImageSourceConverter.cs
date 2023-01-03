using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Helpers
{
    /// <summary>
    /// Class ByteArray To ImageSource Converter
    /// </summary>
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSource = null;
            try
            {
                if (value != null)
                {
                    byte[] imageAsBytes = (byte[])value;
                    var stream = new MemoryStream(imageAsBytes);
                    retSource = ImageSource.FromStream(() => stream);
                }
            }
             catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return retSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
