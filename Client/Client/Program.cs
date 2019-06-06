using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('_', 55) + "PROGRAMM" + new string('_', 55) + "\n");
            Console.ResetColor();
            choose: Console.WriteLine("Please choose which service to use - TCP(1) or UDP(2).If you want to change the protocol, write -other protocol- \n");
            start: string ch = Console.ReadLine();
            if (ch == "1")
            {
                try
                {
                    TcpClient client = new TcpClient();
                    client.SendTimeout = 1000;
                    client.Connect("127.0.0.1", 1000);
                    
                    byte[] data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    NetworkStream stream = client.GetStream();

                    //Connection confirming
                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    Console.WriteLine(response.ToString());
                    Console.WriteLine("Enter operations in this format : NUMBER space OPERATOR space NUMBER");

                    string message = String.Empty;

                    do
                    {
                        if(message == "other protocol")
                        {
                            stream.Close();
                            client.Close();
                            goto choose;

                        }
                        message = Console.ReadLine();
                        byte[] data1 = Encoding.UTF8.GetBytes(message);
                        stream.Write(data1, 0, data1.Length);

                        StringBuilder result = new StringBuilder();
                        var data2 = new byte[256];
                        int bytes = stream.Read(data2, 0, data2.Length);
                        result.Append(Encoding.UTF8.GetString(data2, 0, bytes));
                        Console.WriteLine("Result = " + result);
                    }
                    while (message != String.Empty);

                    stream.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something goes wrong...disconnected");
                }
            }
            else if(ch == "2")
            {
                Console.Clear();

                Console.WriteLine("WELCOME \nEnter operations in this format : NUMBER space OPERATOR space NUMBER");

                //for sending
                UdpClient client = new UdpClient();
                client.Connect("localhost", 1000);

                //for getting
                UdpClient udpClient = new UdpClient();
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 1001));

                try
                {
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                    string message = String.Empty;        //this object must be sent to the server
                    string result = String.Empty;         //this object must be received from server

                    do
                    {
                        //Sending to Math server
                        message = Console.ReadLine();

                        if (message == "other protocol")
                        {
                            client.Close();
                            goto choose;
                        }

                        var sendBytes = Encoding.ASCII.GetBytes(message);
                        client.Send(sendBytes, sendBytes.Length);

                        //Receiving result from math server
                        var receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                        result = Encoding.ASCII.GetString(receiveBytes);
                        Console.WriteLine("Result = " + result);
                    }
                    while (message != String.Empty);

                    client.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something goes wrong...disconnected");
                    return;
                }
            }
            else
            {
                goto start;
            }
        }
    }
}
