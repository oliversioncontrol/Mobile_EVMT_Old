using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
   public class InstMaterialModel
    {
        public string Method { get; set; }
        public string MaterialId { get; set; }
        public string Material { get; set; }
        public string Unit { get; set; }
        public string Category { get; set; }
        public string Quantity { get; set; }
        public bool PCard { get; set; }
        public string StoreName { get; set; }
        public string Cost { get; set; }
        public string BoothcardId { get; set; }
    }
}
