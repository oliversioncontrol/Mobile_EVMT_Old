using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Employee Model
    /// </summary>
    public class EmployeeModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeeYearOfBirth { get; set; }
        public string EmployeeMobilePhone { get; set; }

        public string DisplayName { get; set; }
        public Command EmpTabed { get; set; }
    }
}
