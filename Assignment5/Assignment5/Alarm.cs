using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class OnlineAttendance
    {
        public Action<string> CheckNames = Banned;

        public string Name { get; set; }

        public void Attend()
        {
            while (true)
            {
                Console.WriteLine("Enter the name!");

                this.Name = Console.ReadLine();
                if ((this.Name == "Jack" || this.Name == "Steven" || this.Name == "Mathew") && this.CheckNames != null)

                {
                    this.CheckNames(Name);
                    break;
                }
            }
        }
        public static void Banned(string name)
        {
            Console.WriteLine("He is banned for organization");
        }
    }
}
