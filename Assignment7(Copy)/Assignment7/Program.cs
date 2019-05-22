using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;

namespace Assignment7
{
    class Program
    {
        public static bool str = true;
        static void Main(string[] args)
        {
            var from = @"C:\Users\Serob\Desktop\HomeworksGit\Assignment7(Copy)\from\copy.txt";
            var into = @"C:\Users\Serob\Desktop\HomeworksGit\Assignment7(Copy)\in\final.txt";

            Console.WriteLine("Starting copiing the file: ");
            GetProgAsync(from,into);

            Console.Write("Progress bar - ");
            
            while (str)
            {
                Console.Write("#");
                Thread.Sleep(5);
            }
            Console.WriteLine("\nCopiing is finished.");
        }
        static Task GetProgress(string from,string inTo)
        {
            return Task.Run(() =>
            {
                File.Copy(from, inTo);
                str = false;
            });
         
        }
        static async Task GetProgAsync(string from,string to)
        {
            await GetProgress(from, to);
            //str = false;
        }
    }
}
