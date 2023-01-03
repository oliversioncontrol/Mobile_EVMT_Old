using Xamarin.Forms;

namespace OnLocationEVMT.Models
{

    /// <summary>
    /// Class KeyContactModel
    /// </summary>
    public class KeyContactModel
    {
        public int ID { get; set; }
        public ImageSource EmpImage { get; set; }
        public string EmpTelephone { get; set; }
        public string EmpName { get; set; }
        public string EmpProfile { get; set; }
        public string EmpContact { get; set; }
        public string EmpEmail { get; set; }
        public bool IsEmail { get; set; }
        public bool IsMobile { get; set; }
        public bool IsTelephone { get; set; }

        public Command AutoCall { get; set; }

        public Command AutoEmail { get; set; }
    }
}
