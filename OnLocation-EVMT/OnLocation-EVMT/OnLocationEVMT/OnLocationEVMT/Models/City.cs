using System.Collections.Generic;

namespace OnLocationEVMT.Models
{
    /// <summary>
    /// Class City implementation
    /// </summary>
    public class City
    {
        public string CityID { get; set; }
        public string CityName { get; set; }
        
    }


    public class TradeCity
    {
        public List<City> CityList = new List<City>()
        {
            new City()
            {
                CityID="1",
                CityName="Abbotsford"
            },
            new City()
            {
                CityID="2",
                CityName="Aberdeen"
            },
            new City()
            {
                CityID="3",
                CityName="Abu Dhabi"
            },
            new City()
            {
                CityID="4",
                CityName="Abuya"
            },
            new City()
            {
                CityID="5",
                CityName="Addis Ababa"
            },
            new City()
            {
                CityID="6",
                CityName="Adelaide"
            },
            new City()
            {
                CityID="7",
                CityName="Ahmedabad"
            }

        };
    }




}
