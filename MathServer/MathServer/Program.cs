using System;
using System.Threading;

namespace MathServer
{
    class Program
    {
        public delegate void Protocol(MathService ms);

        static void Main(string[] args)
        {
            MathService ms = new MathService();

            //creating 2 threads
            TCP tcppr = new TCP();
            UDP udppr = new UDP();

            //getting them methods
            Thread tr1 = new Thread(() => tcppr.SendResult(ms));
            Thread tr2 = new Thread(() => udppr.SendResult(ms));

            //starting the threads
            tr1.Start();
            tr2.Start();
        }
    }
}
