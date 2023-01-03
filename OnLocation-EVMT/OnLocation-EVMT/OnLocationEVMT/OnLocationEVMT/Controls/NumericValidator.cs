using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Controls
{
    /// <summary>
    /// Class Numeric Validator
    /// </summary>
    class NumericValidator : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry entry)
        {
            try
            {
                entry.TextChanged += OnEntryTextChanged;
                base.OnAttachedTo(entry);
            }
            catch (Exception)
            {

            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            try
            {
                entry.TextChanged -= OnEntryTextChanged;
                base.OnDetachingFrom(entry);
            }
            catch (Exception)
            {

            }
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {
                double result;
                bool isValid = double.TryParse(args.NewTextValue, out result);
                ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            }
            catch (Exception)
            {

            }
        }
    }
}
