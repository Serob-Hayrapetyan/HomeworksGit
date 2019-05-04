using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            //aveli hesht dzevov vonc karelia mtcnel es tvyalnery??
            List<string> name = new List<string> { "ATL", "PEK", "LAX", "ORD", "HND", "LHR", "DEN", "CDG", "AMS", "MAD", "LAS", "HBE", "CPT", "CAI", "FRA", "HAM", "FCO", "VRN" };
            List<string> countryCode = new List<string> { "US", "CN", "US", "US", "JP", "UK", "US", "FR", "NL", "ES", "US", "EG", "ZA", "EG", "GE", "GE", "IT", "IT" };
            List<int> size = new List<int> { 5, 4, 4, 4, 5, 3, 3, 2, 2, 2, 2, 1, 1, 2, 3, 2, 3, 1 };
            List<Airport> air = new List<Airport>();
            for (int i = 0; i < name.Count; i++)
            {
                air[i] = new Airport(name[i], countryCode[i], size[i]);
            }

            List<int> toSort = new List<int>();
            for (int i = 0; i < size.Count; i++)
            {
                toSort.Add(air[i].AirportSize);
            }
            toSort.Sort();
            foreach (var x in toSort)
            {
                Console.WriteLine(x);
            }
        }
    }
}
