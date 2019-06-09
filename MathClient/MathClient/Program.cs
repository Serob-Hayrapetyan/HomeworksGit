using System;

namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //design
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('_', 55) + "PROGRAMM" + new string('_', 55) + "\n");
            Console.ResetColor();
            //end design

            choose: Console.WriteLine("Please choose which service to use - TCP(1) or UDP(2).\n If you want to change the protocol, write -other protocol- \n If you want to exit programm, go to choose protocol and enter -exit-\n");

            //reading user's choice
            start: string ch = Console.ReadLine();

            if (ch == "1")
            {
                TCP tcppr = new TCP();
                tcppr.SendMessage();              
            }
            else if(ch == "2")
            {
                UDP udppr = new UDP();
                udppr.SendMessage();
            }
            else if(ch == "exit")
            {
                Console.WriteLine("End Programm");
                return;
            }
            else
            {
                Console.WriteLine("Please,enter other number");
                goto start;
            }           
            goto choose;
        }
    }
}
