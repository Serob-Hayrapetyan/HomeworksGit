using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_LINQ_Ext_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-', 30) + "EXTENSION METHODS" + new string('-', 30) + "\n\n");

            int[] arr = new int[] { 5, 7, -5, -2, -89, 79, 0, 56, -34 };       
            string[] array = { "cat", "dog", "mouse" };
            List<Book> book = new List<Book>
            {
                new Book{value = 4,name = "Martin Iden"},
                new Book{value = 5,name = "The Old Man and the Sea"},
                new Book{value = 6,name = "The Little Prince"},
                new Book{value = 7,name = "Master and Margarit"}
            };

            //checking SelectExt
            Console.WriteLine("Selecting elements of String type array");
            var resu = array.SelectExt(element => element.ToLower());
            
            foreach (string value in resu)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine();

            //checking WhereExt
            Console.WriteLine("\nPositiv numbers");
            var positiv = arr.WhereExt(y => y > 0);
            foreach(int value in positiv)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine();

            //Checking ToListExt
            Console.Write("\nType of collection - ");
            var list = arr.ToListExt();
            Console.Write(list.GetType()+ "\n");

            //checking OrderByExt
            Console.WriteLine("\nOrdered array");
            var ordered = arr.OrderByExt(x => x);
            foreach (int value in ordered)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine();

            //Checking ToDictionaryExt
            var dict = book.ToDictionaryExt(x => x.value);
            Console.Write("\nKeys of book-dictionary are - ");
            foreach(var value in dict)
            {
                Console.Write(value.Key + ",");
            }
        }
    }
}
