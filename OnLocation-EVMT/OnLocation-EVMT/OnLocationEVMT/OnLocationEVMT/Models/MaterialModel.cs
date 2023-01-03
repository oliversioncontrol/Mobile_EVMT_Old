using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
  public  class MaterialModel
    {
        public string MaterialId { get; set; }
        public string BoothcardId { get; set; }
        public string Material { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string Category { get; set; }
        public bool PCard { get; set; }
        public string StoreName { get; set; }
        public string Cost { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string PCardImge { get; set; }
        public Command DeleteCommand { get; set; }
        public Command EditCommand { get; set; }
        public bool IsEdit { get; set; }
    }

    public class BoothMaterial
    {
        public string MaterialId { get; set; }
        public string BoothcardId { get; set; }
        public string Material { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string Category { get; set; }
        public bool PCard { get; set; }
        public string StoreName { get; set; }
        public string Cost { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string WorkDate { get; set; }

        public string PCardImge { get; set; }
    }
}
