using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Supervision Models
    /// </summary>
  public  class SupervisionModel
    {
       
        public string ClientImg { get; set; }
        public string OLImg { get; set; }
        public string ExhibitImg { get; set; }
        public string DisClientImg { get; set; }
        public string DisOLImg { get; set; }
        public string DisExhibitImg { get; set; }
    
        public Command AutoCall { get; set; }
        public string SupInstallContactId { get; set; }
        public string SupInstallation { get; set; }
        public string SupInstallContact { get; set; }
        public string SupInstallContactPhone { get; set; }
        public string SupDismantleContactId { get; set; }
        public string SupDismantle { get; set; }
        public string SupDismantleContact { get; set; }
        public string SupDismantleContactPhone { get; set; }
    }
}
