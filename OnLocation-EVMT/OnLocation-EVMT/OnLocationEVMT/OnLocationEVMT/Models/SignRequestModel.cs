using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Sign Request Models
    /// </summary>
  public class SignRequestModel
    {
        public string JobNumber { get; set; }
        public string BoothcardId { get; set; }
        public string Signature { get; set; }
    }
}
