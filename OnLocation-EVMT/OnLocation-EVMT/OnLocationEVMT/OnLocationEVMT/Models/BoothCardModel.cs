using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class boothcard Models
    /// </summary>
  public class BoothCardModel
    {
        public int ID { get; set; }
        public string Boothcard { get; set; }
        public string WorkDate { get; set; }
        public string Project { get; set; }
        public string Exhibitor { get; set; }
        public string Show { get; set; }
        public string Citys { get; set; }
        public string Booth { get; set; }
        public string AccountExec { get; set; }
        public string Submittedby { get; set; }        
        public string Preparedby { get; set; }
        public string SubmittedDate { get; set; }
        public string Notes { get; set; }
        public Command CommandBoothcard { get; set; }
        public Command CommandOverview { get; set; }
        public string SupervisorName { get; set; }
        public bool SupervisorPresent { get; set; }
        public string ReviewSubmittedBy { get; set; }
        public string ReviewSubmittedDate { get; set; }
        public string ReviewSubmittedByDisplayName { get; set; }
        public string CreateDate { get; set; }
        public Color ReviewColor { get; set; }
        public Color SubmittedColor { get; set; }

        public string IsBoothcardSigned { get; set; }
    }
}
