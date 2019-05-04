using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    /// <summary>
    /// Class represents an airport
    /// </summary>
    public class Airport
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public int AirportSize { get; set; }

        public Airport()
        {

        }

        public Airport(string name, string countryCode, int sizeOfTheAirport)
        {
            Name = name;
            CountryCode = countryCode;
            AirportSize = sizeOfTheAirport;
        }
        public void Sort(List<string> arr)
        {
            arr.Sort();
        }
        public enum Size
        {
            small = 1,
            medium,
            large,
            mega,
            supermega,
        }
    }
}
