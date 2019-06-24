using Client.cs.StudentServiceReference;
using System;

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
