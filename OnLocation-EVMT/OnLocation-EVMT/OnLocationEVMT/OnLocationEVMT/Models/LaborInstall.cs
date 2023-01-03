using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Labor Install Model
    /// </summary>
    public class LaborInstall
    {
        public string InstlDismId { get; set; }
        public string Service { get; set; }
        public string WorkDate { get; set; }
        public string ServiceRateType { get; set; }
        public string NumberOfWorkers { get; set; }
        public string NumOfHours { get; set; }
        public string TotalHours { get; set; }
        public string HourlyRate { get; set; }
        public string Total { get; set; }
    }
}

