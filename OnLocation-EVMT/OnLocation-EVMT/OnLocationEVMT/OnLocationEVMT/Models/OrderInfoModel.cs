using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Order Info Model
    /// </summary>
   public class OrderInfoModel
    {
        public string JobNumber { get; set; }
        public string JobStatus { get; set; }
        public string ExhibitorName { get; set; }
        public string OrderBoothSize { get; set; }
        public string BoothNumber { get; set; }
        public string Version { get; set; }
        public string LastYearJobNumber { get; set; }
        public string ShowName { get; set; }
        public string Venue { get; set; }
        public string ShowCity { get; set; }
        public string ShowState { get; set; }
        public string ShowOpenDate { get; set; }
        public string ShowCloseDate { get; set; }
        public string ShortName { get; set; }
        public string EACDueDate { get; set; }
    }
}
