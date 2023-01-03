using System.Collections.Generic;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Month implementation
    /// </summary>
    public class MonthModel
    {
        public string MonthID { get; set; }
        public string MonthName { get; set; }
    }

    public class TradeMonth
    {
        public List<MonthModel> MonthShow = new List<MonthModel>()
        {
            new MonthModel()
            {
                MonthID="1",
                MonthName="January"
            },
            new MonthModel()
            {
                MonthID="2",
                MonthName="February"
            },
            new MonthModel()
            {
                MonthID="3",
                MonthName="March"
            },
            new MonthModel()
            {
                MonthID="4",
                MonthName="April"
            },
            new MonthModel()
            {
                MonthID="5",
                MonthName="May"
            },
            new MonthModel()
            {
                MonthID="6",
                MonthName="June"
            },
            new MonthModel()
            {
                MonthID="7",
                MonthName="July"
            },
            new MonthModel()
            {
                MonthID="8",
                MonthName="August"
            },
            new MonthModel()
            {
                MonthID="9",
                MonthName="September"
            },
             new MonthModel()
            {
                MonthID="10",
                MonthName="October"
            },
             new MonthModel()
            {
                MonthID="11",
                MonthName="November"
            },
            new MonthModel()
            {
                MonthID="12",
                MonthName="December"
            }
        };
    }
}
