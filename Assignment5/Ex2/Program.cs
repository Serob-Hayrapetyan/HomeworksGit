using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string acr = Acronym(line);
            Console.WriteLine(acr);
        }

        /// <summary>
        /// Method, that converts phrase to acronym.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Acronym(string name)
        {
            string acronym = Convert.ToString(name[0]);

            for (int i = 0; i < name.Length; i++)
            {
                if (i < name.Length)
                {
                    if (name[i] == ' ' && name[i + 1] != ' ')
                    {
                        acronym = acronym + name[i + 1];
                    }
                }
            }
            return acronym;
        }
    }
}
