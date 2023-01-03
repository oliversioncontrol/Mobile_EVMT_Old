using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Order Sample Response
    /// </summary>
   public class ODSampleResponse
    {
        public string LaborEstimateId { get; set; }
        public string WorkDate { get; set; }
        public string StartTime { get; set; }
        public string Service { get; set; }
        public string NumWorkers { get; set; }
        public string Hours { get; set; }
    }
}
