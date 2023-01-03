using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.ViewModel
{
    class EmpDetailsVM: ObservableObject
    {

        public List<BoothLabor> LstDetails { get; set; }
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

        /// <summary>
        /// Constructor
        /// </summary>
        public EmpDetailsVM()
        {
            try
            {
                LstDetails = new List<BoothLabor>();
                LstDetails.Add(Views.EmpDetails.ListLaborDetails);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
