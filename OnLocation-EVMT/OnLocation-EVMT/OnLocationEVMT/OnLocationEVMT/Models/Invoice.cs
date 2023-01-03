using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
   public class Invoice
    {
        public string InvoiceDate { get; set; }
        public string JobNumber { get; set; }
        public string InvoiceAmount { get; set; }
        public string InvoiceItemId { get; set; }
        public Command OpenPDF { get; set; }
    }

    public class InvoiceModel
    {
        public string JobNumber { get; set; }
        public string InvoiceItemId { get; set; }
        public string InvoiceItemDesc { get; set; }
    }

    
}
