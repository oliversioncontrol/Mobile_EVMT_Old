using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
 public class EquipmentModel
    {
        public string EquipmentId { get; set; }
        public string BoothcardId { get; set; }
        public string Equipment { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public Command DeleteCommand { get; set; }
        public Command EditCommand { get; set; }
        public bool IsEdit { get; set; }
    }


    public class BoothEquipment
    {
        public string EquipmentId { get; set; }
        public string BoothcardId { get; set; }
        public string Equipment { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string WorkDate { get; set; }
    }
}
