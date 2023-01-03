using OnLocationEVMT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Group NewPost Models
    /// </summary>
    class GroupNewPostModel
    {
        public string Header { get; set; }
        public string Description { get; set; }

    }

    /// <summary>
    /// Class Group Post Image
    /// </summary>
    class GroupPostImage : ObservableObject
    {
        public string Name { get; set; }
        public int ImageId { get; set; }

        bool uploading;
        public bool Uploading
        {
            get { return uploading; }
            set { SetProperty(ref uploading, value); }
        }

        public ImageSource Image { get; set; }

        public byte[] ImageData { get; set; }
    }
}
