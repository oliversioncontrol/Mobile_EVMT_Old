namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Your Project List Response
    /// </summary>
    public class YourProjectListResponse
    {
        public string PortfolioVersion { get; set; }
        public string JobNumber { get; set; }
        public string JobStatus { get; set; }
        public string ExhibitorName { get; set; }
        public string OrderBoothSize { get; set; }
        public string ShowName { get; set; }
        public string Venue { get; set; }
        public string ShowCity { get; set; }
        public string ShowState { get; set; }
        public string ShowOpenDate { get; set; }
        public string ShowCloseDate { get; set; }
        public string ShowOpenDateType { get; set; }
    }


    public class ProjectYear
    {
        public string ShowOpenYear { get; set; }
    }
}
