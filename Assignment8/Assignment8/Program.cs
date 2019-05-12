using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Assignment8
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> action;
            action = Factorial;
            MyParallel.ParallelFor(0, 10, action); //using my ParallelFor

            int[] arr = new int[] { 2, 5, 9, 7, 8, 4, 3, 10 };
            MyParallel.ParallelForEach(arr, action);//using my ParallelForEach

            ParallelOptions pr = new ParallelOptions();
            pr.MaxDegreeOfParallelism = 5;
            //MyParallel.ParallelForEachWithOptions(arr, pr, Factorial);         
        }
        
        /// <summary>
        /// Method FActorial for checking ParallelFor
        /// </summary>
        /// <param name="x"></param>
        static void Factorial(int x)
        {
            int factorial = 1;

            for (int i = 1; i <= x; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(" {0} task is going", Task.CurrentId);
            Console.WriteLine("Factorial of {0} = {1}", x, factorial);
        }
    }
}
