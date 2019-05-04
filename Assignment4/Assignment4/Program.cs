using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A Simulation of ROLLING DIE \n");
            Console.ResetColor();

            Random rd = new Random();
            DieEvent die = new DieEvent();

            die.TwoFour += TwoFour_Handler;
            die.MoreThwenty += MoreThanTwenty_Handler;

            List<int> dieList = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                die.Die(rd);
                dieList.Add(die.value);
                Thread.Sleep(100);
            }
            Console.WriteLine();

            die.InvokeTwoFour(die, dieList);
            die.InvokeMoreThanTwenty(die, dieList);
            Console.WriteLine();
        }

        /// <summary>
        /// Checks if ther are two fours in 
        /// </summary>
        /// <param name="die"></param>
        static void TwoFour_Handler(DieEvent die, List<int> dieList)
        {
            int count = 0;
            List<int> dieListTwoElement = new List<int>();

            for (int i = 0; i < dieList.Count; i++)
            {
                dieListTwoElement.Add(dieList[i]);
                if (dieListTwoElement.Count >= 2)
                {
                    if (dieListTwoElement[0] == 4 && dieListTwoElement[1] == 4)
                    {
                        count++;
                    }
                    dieListTwoElement.Remove(dieListTwoElement[0]);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTwo of four repeated {0} times ", count);
            Console.ResetColor();
        }

        /// <summary>
        /// Checks the sum of last 5 tosses.
        /// </summary>
        /// <param name="die"></param>
        static void MoreThanTwenty_Handler(DieEvent die, List<int> dieList)
        {
            int count = 0;
            List<int> dieListFiveElement = new List<int>();

            for (int i = 0; i < dieList.Count; i++)
            {
                dieListFiveElement.Add(dieList[i]);
                if (dieListFiveElement.Count == 5)
                {
                    if (dieListFiveElement.Sum() >= 20)
                    {
                        count++;
                    }
                    dieListFiveElement.Remove(dieListFiveElement[0]);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("There were {0} times ,when sum of 5 tosses greather than or equal to 20", count);
            Console.ResetColor();
        }
    }
}
