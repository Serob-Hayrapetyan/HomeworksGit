using Client.cs.StudentServiceReference;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Client.cs
{
    class Program
    {
        private static StudentServiceClient client;

        static void Main(string[] args)
        {
            client = new StudentServiceClient();
            var students = client.GetStudent();

            Console.WriteLine("------- Students ------- ");
            foreach (var item in students)
            {
                Console.WriteLine("{0}, {1}", item.Name, item.Age);
            }
            
            Console.ReadKey();
        }
    }
}
