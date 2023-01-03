using OnLocationEVMT.Helpers;
using OnLocationEVMT.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.ViewModel
{
    class ShippingNotesVM: ObservableObject
    {
        bool _IsBusy;
        /// <summary>
        /// Gets or sets the IsBusy.
        /// </summary>
        /// <value>The _IsBusy.</value>
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public bool _IsClicked;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public bool IsClicked
        {
            get { return _IsClicked; }
            set
            {
                _IsClicked = value;
                OnPropertyChanged(nameof(IsClicked));
            }
        }

        public string _SpeicalNote;
        /// <summary>
        /// Gets or Sets SpeicalNote
        /// </summary>
        public string ShippinglNote
        {
            get { return _SpeicalNote; }
            set
            {
                _SpeicalNote = value;
                OnPropertyChanged(nameof(ShippinglNote));
            }
        }

        public ShippingNotesVM()
        {
            LoadData();
        }

        public async Task LoadData()
        {
            try
            {
                if (!string.IsNullOrEmpty(ShippingNotes._ShipNote))
                {
                    ShippinglNote = ShippingNotes._ShipNote;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NotFound, Resource.OK);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

    }
}
