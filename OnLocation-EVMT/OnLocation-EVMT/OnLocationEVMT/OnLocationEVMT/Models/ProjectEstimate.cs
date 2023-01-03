namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Project Estimate
    /// </summary>
    public class ProjectEstimate
    {
        public string Service { get; set; }
        public string TotalAmount { get; set; }
    }
    public class EstimateSummary
    {
        public string LaborInstall { get; set; }
        public string LaborShowServices { get; set; }
        public string LaborDismantle { get; set; }
        public string Supervision { get; set; }
        public string MaterialsExtras { get; set; }
        public string Total { get; set; }
        public string Tax { get; set; }
    }
}
