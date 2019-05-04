using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public delegate void MyDelegate(DieEvent die, List<int> x);

    public class DieEvent
    {
        public int value = 0;

        public event MyDelegate TwoFour;
        public event MyDelegate MoreThwenty;

        public void InvokeTwoFour(DieEvent var, List<int> x)
        {
            TwoFour.Invoke(var, x);
        }

        public void InvokeMoreThanTwenty(DieEvent die, List<int> x)
        {
            MoreThwenty.Invoke(die, x);
        }

        /// <summary>
        /// Method that throws the die.
        /// </summary>
        /// <param name="rd"></param>
        public void Die(Random rd)
        {
            value = rd.Next(1, 7);
            Console.Write(value + " ");
        }

        /// <summary>
        /// Method that throws the die as much as we want.
        /// </summary>
        /// <param name="die"></param>
        /// <param name="i"></param>
        static List<int> MixThrow(DieEvent die, int i)
        {
            List<int> dieList = new List<int>();
            Random rd = new Random();
            for (int k = i; k > 0; k--)
            {
                die.Die(rd);
                dieList.Add(die.value);
            }
            return dieList;
        }
    }
}
