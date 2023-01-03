using System.Collections.Generic;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class industry implementation
    /// </summary>
    public  class Industry
    {
        public string IndustryID { get; set; }
        public string IndustryName { get; set; }
    }

    public class TradeIndustry
    {
        public List<Industry> IndustryList = new List<Industry>()
        {
            new Industry()
            {
                IndustryID="1",
                IndustryName="Accounting"
            },
            new Industry()
            {
                IndustryID="1",
                IndustryName="Adverting & Marketting"
            },
            new Industry()
            {
                IndustryID="1",
                IndustryName="Aerospace & Aviation"
            },
            new Industry()
            {
                IndustryID="1",
                IndustryName="Agriculture & Family"
            },new Industry()
            {
                IndustryID="1",
                IndustryName="Amusement,Entertainment,Gaming"
            }
           
        };
    }
}
