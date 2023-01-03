using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class boothcard Header
    /// </summary>
    public class BoothHeader
    {
        public string BoothcardId { get; set; }
        public string DateSubmitted { get; set; }
        public string PreparedBy { get; set; }
        public string PreparedByDisplayName { get; set; }
        public string SubmittedBy { get; set; }
        public string SubmittedByDisplayName { get; set; }
        public string ProjectNum { get; set; }
        public string SupervisorName { get; set; }
        public bool SupervisorPresent { get; set; }
        public string WorkDate { get; set; }
        public string Note { get; set; }
        public string ProjectNum1 { get; set; }
        public string Exhibitor { get; set; }
        public string BoothNum { get; set; }
        public string ShowName { get; set; }
        public string ShowCity { get; set; }
        public string AccountExec { get; set; }
        public string Leadman { get; set; }
        public string RegionalManager { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string ReviewSubmittedBy { get; set; }
        public string ReviewSubmittedDate { get; set; }
        public string ReviewSubmittedByDisplayName { get; set; }
        public string IsBoothcardSigned { get; set; }
    }
}
