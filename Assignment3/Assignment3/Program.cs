using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int[,] x = new int[3, 3]
            {
                {0,0,1 },
                {1,0,0 },
                {0,1,0 },
            };
            int[,] y = new int[3, 2]
            {
                { 4,2},
                { 3,1},
                { 1,5},
            };

            int[,] arr = new int[5, 5];
            AutoGen(arr, rd);
            Matrix.Print(arr);

            //Determinanti voroshum@
            double d = Matrix.Determinant(arr);
            Console.WriteLine("Det = " + d);

            //matrici Inversia
            float[,] u = Matrix.Inverse(arr);
            Matrix.Print(u);

            Console.WriteLine("Max of matrix = " + Matrix.Max(arr));
            Console.WriteLine("Min of matrix = " + Matrix.Min(arr));

            //matrici transponacia
            int[,] to = Matrix.Transpos(x);
            Matrix.Print(to);

            //matricneri bazmapatkum
            int[,] mult = Matrix.Mult(x, to);
            Matrix.Print(mult);

            //ortogonalutyan stugum
            bool bl = false;
            bl = Matrix.Ortogonal(x);
            if (bl == true)
                Console.WriteLine("Matrix is ortogonal:");
            else
                Console.WriteLine("Matrix is not ortogonal:");
        }
        //AUTOGENERATION
        public static void AutoGen(int[,] arr, Random rd)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    arr[i, k] = rd.Next(1, 10);
                }
            }
        }
    }
}
