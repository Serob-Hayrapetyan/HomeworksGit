using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    static class Matrix
    {
        public static void Print(int[,] mat)
        {
            Console.WriteLine("Matrix is..");

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int k = 0; k < mat.GetLength(1); k++)
                {
                    Console.Write(mat[i, k] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void Print(float[,] mat)
        {
            Console.WriteLine("Matrix is..");

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int k = 0; k < mat.GetLength(1); k++)
                {
                    if (mat[i, k] != 0)
                        Console.Write(mat[i, k] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Adding a matrix to anouther matrix
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int[,] Add(int[,] x, int[,] y)
        {
            if (x.GetLength(0) == y.GetLength(0) && x.GetLength(0) == y.GetLength(1))
            {
                int[,] sum = new int[x.GetLength(0), x.GetLength(1)];
                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int k = 0; k < x.GetLength(1); k++)
                    {
                        sum[i, k] = x[i, k] + y[i, k];
                    }
                }
                return sum;
            }
            else
            {
                Console.WriteLine("Please,enter matrixes,which sizes are equal");
                return null;
            }
        }

        /// <summary>
        /// Multiplication of two matrices
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int[,] Mult(int[,] x, int[,] y)
        {
            if (x.GetLength(1) == y.GetLength(0))
            {
                int[,] sum = new int[x.GetLength(0), x.GetLength(1)];

                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int k = 0; k < x.GetLength(0); k++)
                    {
                        sum[i, k] = 0;
                        int num = 0;
                        for (int j = 0; j < x.GetLength(1); j++)
                        {
                            num = x[i, j] * y[j, k];
                            sum[i, k] = sum[i, k] + num;
                        }
                    }
                }
                return sum;
            }
            else
            {
                Console.WriteLine("Please,enter matrixes,which sizes are equal");
                return null;
            }
        }

        public static int[,] ScalMult(int alph, int[,] x)
        {
            int[,] mult = new int[x.GetLength(0), x.GetLength(1)];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int k = 0; k < x.GetLength(0); k++)
                {
                    mult[i, k] = alph * x[i, k];
                }
            }
            return mult;
        }

        public static int[,] Transpos(int[,] x)
        {
            int[,] tsp = new int[x.GetLength(1), x.GetLength(0)];
            for (int i = 0; i < x.GetLength(1); i++)
            {
                for (int k = 0; k < x.GetLength(0); k++)
                {
                    tsp[i, k] = x[k, i];
                }
            }
            return tsp;
        }

        public static double Determinant(int[,] x)
        {
            if (x.GetLength(0) != x.GetLength(1))
            {
                Console.WriteLine("Your matrix's rows and columns must be equal: ");
                return 0;
            }
            int n = x.GetLength(0);
            double det = 0;
            // int[,] mat = new int[n, n];

            if (n <= 2)
            {
                det = x[0, 0] * x[1, 1] - x[0, 1] * x[1, 0];
                return det;
            }

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int k = 0; k < x.GetLength(1); k++)
                {
                    det = det + Math.Pow(-1, k) * x[i, k] * Determinant(Jnjel(x, k));
                }
            }
            return det;
        }

        //Jnjely ojandak funkcia e
        static int[,] Jnjel(int[,] arr, int j)
        {
            int n = arr.GetLength(0);
            int[,] mat = new int[n - 1, n - 1];
            if (n <= 2)
            {
                return arr;
            }
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int k = 0; k < mat.GetLength(1); k++)
                {
                    if (k < j)
                    {
                        mat[i, k] = arr[i + 1, k];
                    }
                    else
                    {
                        mat[i, k] = arr[i + 1, k + 1];
                    }
                }
            }
            return mat;
        }

        public static float[,] Inverse(int[,] x)
        {
            int n = x.GetLength(0);
            float[,] mat = new float[n, n];

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int k = 0; k < x.GetLength(1); k++)
                {
                    mat[i, k] = Convert.ToSingle(x[i, k] / Determinant(x));
                }
            }
            return mat;
        }

        public static int Max(int[,] x)
        {
            int max = 0;
            for (int i = 0; i < x.GetLength(1); i++)
            {
                for (int k = 0; k < x.GetLength(0); k++)
                {
                    if (x[i, k] > max)
                    {
                        max = x[i, k];
                    }
                }
            }
            return max;
        }
        public static int Min(int[,] x)
        {
            int min = x[0, 0];
            for (int i = 0; i < x.GetLength(1); i++)
            {
                for (int k = 0; k < x.GetLength(0); k++)
                {
                    if (x[i, k] < min)
                    {
                        min = x[i, k];
                    }
                }
            }
            return min;
        }

        public static bool Ortogonal(int[,] x)
        {
            bool b = true;
            int[,] mat = new int[x.GetLength(0), x.GetLength(1)];
            if (x.GetLength(0) == x.GetLength(1))
            {
                for (int i = 0; i < x.GetLength(1); i++)
                {
                    for (int k = 0; k < x.GetLength(0); k++)
                    {
                        if (i == k)
                            mat[i, k] = 1;
                        else
                            mat[i, k] = 0;
                    }
                }
                for (int i = 0; i < x.GetLength(1); i++)
                {
                    for (int k = 0; k < x.GetLength(0); k++)
                    {
                        if (Mult(x, Transpos(x))[i, k] != mat[i, k])
                        {
                            b = false;
                        }
                    }
                }
                return b;
            }
            else
                return false;
        }
    }
}
