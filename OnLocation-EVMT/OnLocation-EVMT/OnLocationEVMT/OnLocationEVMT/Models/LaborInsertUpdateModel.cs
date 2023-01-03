using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Labor Insert Update Model
    /// </summary>
 public  class LaborInsertUpdateModel
    {
        public string Method { get; set; }
        public string LaborDetailId { get; set; }
        public string BoothcardId { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Task { get; set; }
        public string TaskDescription { get; set; }
        public bool Billable { get; set; }
        public bool Payroll { get; set; }
        public bool Partner { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string LunchHours { get; set; }
        public string STHours { get; set; }
        public string OTHours { get; set; }
        public string DTHours { get; set; }
    }
}
