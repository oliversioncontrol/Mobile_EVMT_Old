using OnLocationEVMT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.ViewModel
{
    class TradeShowUrlVM: ObservableObject
    {
        public bool _IsBusy;
        /// <summary>
        /// Gets or Sets IsClicked
        /// </summary>
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public string _url;
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(Url));
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
        public TradeShowUrlVM()
        {

        }
    }
}
