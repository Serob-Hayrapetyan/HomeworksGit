using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MathClient
{
    public class UDP : INetworkService
    {
        Int32 port = 8001;
        string localAddr = "127.0.0.1";

        /// <summary>
        /// Sends message using UDP protocol clients
        /// </summary>
        public void SendMessage()
        {
            //disign
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("WELCOME to UDP PROTOCOL.\nEnter operations in this format : NUMBER space OPERATOR space NUMBER");
            Console.ResetColor();
            //end disign
           
            //for sending
            UdpClient clientforsend = new UdpClient();
            clientforsend.Connect(localAddr,port);

            //for getting
            UdpClient getclient = new UdpClient();
            getclient.Client.Bind(new IPEndPoint(IPAddress.Any, 1000));           
            
            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                string message = String.Empty;        //this object must be sent to the server
                string result = String.Empty;         //this object must be received from server

                do
                {
                    //reading user's message
                    Console.Write("Enter expression: ");
                    message = Console.ReadLine();

                    //checking protocol choice
                    if (message == "other protocol")
                    {
                        clientforsend.Close();
                        getclient.Close();
                        return;
                    }

                    //Sending to Math server
                    var sendBytes = Encoding.ASCII.GetBytes(message);
                    clientforsend.Send(sendBytes, sendBytes.Length);

                    //Receiving result from math server
                    var receiveBytes = getclient.Receive(ref RemoteIpEndPoint);
                    result = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine("Result = " + result);
                }
                while (message != String.Empty);

                //closing clients
                clientforsend.Close();
                getclient.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Something goes wrong...disconnected");
                return;
            }
        }
    }
}