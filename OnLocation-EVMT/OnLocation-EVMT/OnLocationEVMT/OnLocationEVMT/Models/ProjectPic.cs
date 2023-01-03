using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Project Pic
    /// </summary>
    class ProjectPic
    {
        public string Date { get; set; }
        public DateTime DateWithTime { get; set; }
        public List<ImageList> Images { get; set; }
    }
    public class ImageList
    {
        public string ImageID { get; set; }
        public string Image { get; set; }
        public ImageSource Img { get; set; }
    }

   
}
