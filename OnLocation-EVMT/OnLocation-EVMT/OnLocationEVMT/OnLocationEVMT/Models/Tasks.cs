using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Task Model
    /// </summary>
   public class Tasks
    {
        public string ID { get; set; }
        public string TaskCode { get; set; }
        public string TaskDescription { get; set; }
        public bool Timesheets { get; set; }
        public string SortOrder { get; set; }
        public bool Billable { get; set; }
    }
}
