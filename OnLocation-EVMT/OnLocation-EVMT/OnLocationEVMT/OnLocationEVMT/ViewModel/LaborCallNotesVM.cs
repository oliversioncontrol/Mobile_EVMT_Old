using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    class LaborCallNotesVM : ObservableObject
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

        public string _CallNote;
        /// <summary>
        /// Gets or Sets CallNote
        /// </summary>
        public string LaborCallNote
        {
            get { return _CallNote; }
            set
            {
                _CallNote = value;
                OnPropertyChanged(nameof(LaborCallNote));
            }
        }


        public string _SpeicalNote;
        /// <summary>
        /// Gets or Sets SpeicalNote
        /// </summary>
        public string SpecialNote
        {
            get { return _SpeicalNote; }
            set
            {
                _SpeicalNote = value;
                OnPropertyChanged(nameof(SpecialNote));
            }
        }



        public LaborCallNotesVM()
        {
            try
            {
               // LoadData();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        public async Task LoadData()
        {
            if (!string.IsNullOrEmpty(YourProjectTabVM.SpecialInstructionNote))
            {
                SpecialNote = YourProjectTabVM.SpecialInstructionNote;
            }
            if (!string.IsNullOrEmpty(YourProjectTabVM.LaborCallNote))
            {
                LaborCallNote = YourProjectTabVM.LaborCallNote;
            }
            if (string.IsNullOrEmpty(YourProjectTabVM.SpecialInstructionNote) && string.IsNullOrEmpty(YourProjectTabVM.LaborCallNote))
            {
               await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NotFound, Resource.OK);
               await App.Current.MainPage.Navigation.PopModalAsync();
            }
        }
       
    }
}
