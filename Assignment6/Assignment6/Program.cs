using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, int> dict = new MyDictionary<int, int>();
            dict.Add(7, 7);
            dict.Add(7, 8, 5435, 9);
            Console.WriteLine(dict.values[1]);
        }
    }
}
