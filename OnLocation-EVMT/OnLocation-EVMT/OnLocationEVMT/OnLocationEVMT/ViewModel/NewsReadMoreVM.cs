using OnLocationEVMT.Helpers;

namespace OnLocationEVMT.ViewModel
{
    public class NewsReadMoreVM: ObservableObject
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
        /// Gets or Sets IsClicked
        /// </summary>
        public string url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(url));
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
        public NewsReadMoreVM()
        {
           // GetURL();
        }

       
    }
}
