using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
   public class EmpAccoladesModel
    {
        public string Img { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string MessageText { get; set; }
        public string Email { get; set; }
        public string ColorHex { get; set; }
        public string From { get; set; }
        public string EmpName { get; set; }
    }

    public class To
    {
        public string name { get; set; }
        public string avatar { get; set; }
        public object employeeId { get; set; }
        public string email { get; set; }
        public ImageSource img { get; set; }
    }

    public class Recognition
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public object employeeId { get; set; }
        public string email { get; set; }
        public string text { get; set; }
        public List<To> to { get; set; }
        public int votes { get; set; }
        public List<object> comments { get; set; }
        public string DateTime { get; set; }
        public string ColorIcon { get; set; }
        public string toname { get; set; }
        public string toemail { get; set; }
        public int IDCount { get; set; }
        public ContentView EmpTagView { get; set; }
    }

    public class EmpAccol
    {
        public bool success { get; set; }
        public int total { get; set; }
        public List<Recognition> recognitions { get; set; }
    }
}
