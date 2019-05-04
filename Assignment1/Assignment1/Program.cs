using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex x = new Complex(3, 5);
            Complex y = new Complex(6, 8);
            Complex h = new Complex(5, 7);

            Complex z = x + y + h;
            Console.WriteLine(z);

            z = x - y;
            Console.WriteLine(z);

            z = x * y;
            Console.WriteLine(z);

            z = x / y;
            Console.WriteLine(z);

            double g = x.Abs();
            Console.Write(g);

        }
    }
    class Complex
    {
        public double Re;
        public double Im;

        public Complex() { }

        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        //Absolute value
        public double Abs()
        {
            return Math.Sqrt(Math.Pow(this.Re, 2) + Math.Pow(this.Im, 2));
        }
        //Addition
        public static Complex operator +(Complex x, Complex y)
        {
            Complex z = new Complex();
            z.Re = x.Re + y.Re;
            z.Im = x.Im + y.Im;
            return z;
        }
        //Subtraction
        public static Complex operator -(Complex x, Complex y)
        {
            Complex z = new Complex();
            z.Re = x.Re - y.Re;
            z.Im = x.Im - y.Im;
            return z;
        }
        //Multiplication
        public static Complex operator *(Complex x, Complex y)
        {
            Complex z = new Complex();
            z.Re = x.Re * y.Re - x.Im * y.Im;
            z.Im = x.Re * y.Im + y.Re * x.Im;
            return z;
        }
        //Division
        public static Complex operator /(Complex x, Complex y)
        {
            Complex z = new Complex();
            if (y.Re == 0 && y.Im == 0)
            {
                Console.WriteLine("Unacceptable operation!!!");
                return null;
            }

            z.Re = (x.Re * y.Re + x.Im * y.Im) / (Math.Pow(y.Re, 2) + Math.Pow(y.Im, 2));
            z.Im = (x.Im * y.Re - x.Re * y.Im) / (Math.Pow(y.Re, 2) + Math.Pow(y.Im, 2));
            return z;
        }
        //print
        public override string ToString()
        {
            if (Im > 0)
                return this.Re.ToString() + " + i*" + this.Im.ToString();
            else if (Im < 0)
                return this.Re.ToString() + " - i*" + Math.Abs(Im).ToString();
            else
                return Re.ToString();
        }
    }
}
