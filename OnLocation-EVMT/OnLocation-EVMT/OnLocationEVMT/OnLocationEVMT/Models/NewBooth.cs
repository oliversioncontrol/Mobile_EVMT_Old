using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class News Booth
    /// </summary>
   public class NewBooth
    {
        public string Method { get; set; }
        public string PreparedBy { get; set; }
        public string SubmittedBy { get; set; }
        public string WorkDate { get; set; }
        public string ProjectNum { get; set; }
        public string Exhibitor { get; set; }
        public string BoothNum { get; set; }
        public string ShowName { get; set; }
        public string ShowCity { get; set; }
        public string AccountExec { get; set; }
        public string Leadman { get; set; }
        public string RegionalManager { get; set; }
        public string DateSubmitted { get; set; }
        public string SupervisorName { get; set; }
        public bool SupervisorPresent { get; set; }
        public string ReviewSubmittedBy { get; set; }
        public string ReviewSubmittedDate { get; set; }
    }
}
