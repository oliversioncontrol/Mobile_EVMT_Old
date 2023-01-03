using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Labor Detial Model
    /// </summary>
  public class LaborDetailModel
    {
        public string LaborDetailId { get; set; }
        public string BoothcardId { get; set; }
        public string EmployeeNum { get; set; }
        public string EmployeeName { get; set; }
        public string Task { get; set; }
        public string TaskDescription { get; set; }
        public bool Billable { get; set; }
        public bool Payroll { get; set; }
        public bool Partner { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string LunchTime { get; set; }
        public string ST { get; set; }
        public string OT { get; set; }
        public string DT { get; set; }
        public string TotalHours { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string WorkDate { get; set; }
        public string Note { get; set; }
        public string ImgBillable { get; set; }
        public string ImgPayroll { get; set; }
        public string ImgPartner { get; set; }

        public Command EditLabor { get; set; }
        public Command DeleteLabor { get; set; }
        public Command Repeat { get; set; }
        public bool IsEdit { get; set; }
    }

    /// <summary>
    /// Class Labor  Model
    /// </summary>
    public class LaborModelFloat
    {
        public string LaborDetailId { get; set; }
        public string BoothcardId { get; set; }
        public string EmployeeNum { get; set; }
        public string EmployeeName { get; set; }
        public string Task { get; set; }
        public string TaskDescription { get; set; }
        public bool Billable { get; set; }
        public bool Payroll { get; set; }
        public bool Partner { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double LunchTime { get; set; }
        public double ST { get; set; }
        public double OT { get; set; }
        public double DT { get; set; }
        public double TotalHours { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string WorkDate { get; set; }
        public string Note { get; set; }
        public string ImgBillable { get; set; }
        public string ImgPayroll { get; set; }
        public string ImgPartner { get; set; }

        public Command EditLabor { get; set; }
        public Command DeleteLabor { get; set; }
        public Command Repeat { get; set; }
        public bool IsEdit { get; set; }
    }


    public class BoothLabor
    {
        public int LaborDetailId { get; set; }
        public int BoothcardId { get; set; }
        public string EmployeeNum { get; set; }
        public string EmployeeName { get; set; }
        public string Task { get; set; }
        public string TaskDescription { get; set; }
        public bool Billable { get; set; }
        public bool Payroll { get; set; }
        public bool Partner { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string LunchTime { get; set; }
        public string ST { get; set; }
        public string OT { get; set; }
        public string DT { get; set; }
        public string TotalHours { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string WorkDate { get; set; }
        public string AllNotes { get; set; }
        public int rownum { get; set; }
        public string Note { get; set; }
        public string ImgBillable { get; set; }
        public string ImgPayroll { get; set; }
        public string ImgPartner { get; set; }

        public Command EditLabor { get; set; }
        public Command DeleteLabor { get; set; }
        public Command Repeat { get; set; }
        public bool IsEdit { get; set; }
    }

    public class LaborDetail
    {
        public string LaborDetailId { get; set; }
        public string BoothcardId { get; set; }
        public string Billable { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNum { get; set; }
        public string EndTime { get; set; }
        public string LunchTime { get; set; }
        public string Partner { get; set; }
        public string Payroll { get; set; }
        public string rownum { get; set; }
        public string StartTime { get; set; }
        public string Task { get; set; }
        public string TaskDescription { get; set; }
        public string TotalHours { get; set; }
        public string LaborWorkDate { get; set; }
   //Add ST OT DT
        public string ST { get; set; }
        public string OT { get; set; }
        public string DT { get; set; }
        public Command Repeat { get; set; }
    }

    public class LabborByJob
    {
        public string WorkDate { get; set; }
        public string LaborNote { get; set; }
        public List<LaborDetail> LaborDetails { get; set; }
    }
}
