using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Helpers
{
    /// <summary>
    /// Class String to Price Converter 
    /// </summary>
    class String2PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strPrice = string.Empty;
            string strPriceWithDollor = string.Empty;

            float fPrice;
            bool bParsed = float.TryParse(value as string, out fPrice);
            if (bParsed)
            {
                if (fPrice == 0f)
                    //strPrice = "0.00";
                    strPrice = fPrice.ToString("C2", CultureInfo.CurrentCulture);
                else
                    strPrice = fPrice.ToString("C2", CultureInfo.CurrentCulture);
            }
            if (!string.IsNullOrEmpty(strPrice))
            {
                strPrice = strPrice.Remove(0, 1);
                strPrice = strPrice.Insert(0, "$");
                strPrice = strPrice.Replace(" ", "");
            }

            //if (strPrice.Contains("£"))
            //{
            //    strPrice= strPrice.Replace("£", "$");
            //}           
            return strPrice;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return null;
        }
    }
}
