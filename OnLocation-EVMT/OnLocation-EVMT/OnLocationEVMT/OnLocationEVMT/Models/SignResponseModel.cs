using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Sign Response Model
    /// </summary>
  public class SignResponseModel
    {
        public string JobNumber { get; set; }
        public string BoothcardId { get; set; }
        public string DocumentType { get; set; }
        public string BoothcardSummary { get; set; }
    }
}
