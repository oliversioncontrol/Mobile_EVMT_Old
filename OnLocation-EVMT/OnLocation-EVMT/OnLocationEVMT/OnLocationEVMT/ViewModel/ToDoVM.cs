using OnLocationEVMT.Helpers;
using OnLocationEVMT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.ViewModel
{
    class ToDoVM: ObservableObject
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

        public string _ToDoNote;
        /// <summary>
        /// Gets or Sets SpeicalNote
        /// </summary>
        public string ToDoNote
        {
            get { return _ToDoNote; }
            set
            {
                _ToDoNote = value;
                OnPropertyChanged(nameof(ToDoNote));
            }
        }
        public ToDoVM()
        {
           // LoadData();
        }

        /// <summary>
        /// Method for Load Data
        /// </summary>
        /// <returns></returns>
        public async Task LoadData()
        {
            if (!string.IsNullOrEmpty(YourProjectTabVM.ToDoNoteDetails))
            {
                ToDoNote = YourProjectTabVM.ToDoNoteDetails;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Resource.Alert, Resource.NotFound, Resource.OK);
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}
