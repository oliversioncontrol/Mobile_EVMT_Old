using System.Collections.Generic;
using Xamarin.Forms;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class Your Project Models
    /// </summary>
    public class YourProjectListModel
    {
        public int ID { get; set; }
        public string JobNumber { get; set; }
        public string Job { get; set; }
        public string Status { get; set; }
        public string Show { get; set; }
        public string Customer { get; set; }
        public string Venue { get; set; }
        public string ShowOpen { get; set; }
        public string ShowClose { get; set; }
        public string RegionalMan { get; set; }
        public string AccountExec { get; set; }
        public Command CommandTab { get; set; }
        public string PortfolioVersion { get; set; }
        public string OrderBoothSize { get; set; }
        public string Statusheading { get; set; }

    }


    public class YearList
    {
        public int ID { get; set; }
        public string Year { get; set; }
    }

    public class BindYear
    {
        public List<YearList> yearList = new List<YearList>()
        {
            new YearList()
            {
                ID=0,
                Year="None"
            },
            new YearList()
            {
                ID=40,
                Year="2040"
            },
            new YearList()
            {
                ID=39,
                Year="2039"
            },
            new YearList()
            {
                ID=38,
                Year="2038"
            },
            new YearList()
            {
                ID=37,
                Year="2037"
            },
            new YearList()
            {
                ID=36,
                Year="2036"
            },
            new YearList()
            {
                ID=35,
                Year="2035"
            },
            new YearList()
            {
                ID=34,
                Year="2034"
            },
            new YearList()
            {
                ID=33,
                Year="2033"
            },
            new YearList()
            {
                ID=32,
                Year="2032"
            },
            new YearList()
            {
                ID=31,
                Year="2031"
            },
            new YearList()
            {
                ID=30,
                Year="2030"
            },
            new YearList()
            {
                ID=29,
                Year="2029"
            },
            new YearList()
            {
                ID=28,
                Year="2028"
            },
            new YearList()
            {
                ID=27,
                Year="2027"
            },
            new YearList()
            {
                ID=26,
                Year="2026"
            },
            new YearList()
            {
                ID=25,
                Year="2025"
            },
            new YearList()
            {
                ID=24,
                Year="2024"
            },
            new YearList()
            {
                ID=23,
                Year="2023"
            },
            new YearList()
            {
                ID=22,
                Year="2022"
            },
            new YearList()
            {
                ID=21,
                Year="2021"
            },
            new YearList()
            {
                ID=20,
                Year="2020"
            },
            new YearList()
            {
                ID=19,
                Year="2019"
            },
            new YearList()
            {
                ID=18,
                Year="2018"
            },
            new YearList()
            {
                ID=17,
                Year="2017"
            },
            new YearList()
            {
                ID=16,
                Year="2016"
            },
            new YearList()
            {
                ID=15,
                Year="2015"
            },
            new YearList()
            {
                ID=14,
                Year="2014"
            },
            new YearList()
            {
                ID=13,
                Year="2013"
            },
            new YearList()
            {
                ID=12,
                Year="2012"
            },
            new YearList()
            {
                ID=11,
                Year="2011"
            },
            new YearList()
            {
                ID=10,
                Year="2010"
            },
            new YearList()
            {
                ID=9,
                Year="2009"
            },
            new YearList()
            {
                ID=8,
                Year="2008"
            },
            new YearList()
            {
                ID=7,
                Year="2007"
            },
            new YearList()
            {
                ID=6,
                Year="2006"
            },
            new YearList()
            {
                ID=5,
                Year="2005"
            },
            new YearList()
            {
                ID=4,
                Year="2004"
            },
            new YearList()
            {
                ID=3,
                Year="2003"
            },
            new YearList()
            {
                ID=2,
                Year="2002"
            },
            new YearList()
            {
                ID=1,
                Year="2001"
            }
        };
    }


}
