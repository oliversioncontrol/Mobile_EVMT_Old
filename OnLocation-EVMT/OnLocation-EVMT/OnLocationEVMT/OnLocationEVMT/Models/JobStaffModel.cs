using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Job Staff Model
    /// </summary>
  public  class JobStaffModel
    {       
        public string EmpTelephone { get; set; }
        public string EmpName { get; set; }
        public string EmpType { get; set; }
        public string EmpContact { get; set; }
        public string EmpEmail { get; set; }
        public bool IsEmail { get; set; }
        public bool IsMobile { get; set; }
        public bool IsTelephone { get; set; }
        public Command AutoCall { get; set; }
        public Command AutoEmail { get; set; }
    }
}
