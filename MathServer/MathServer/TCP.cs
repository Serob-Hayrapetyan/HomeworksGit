using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MathServer
{
    public class TCP : INetworkService
    {
        int port = 8001;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        /// <summary>
        /// Sends result to the user using TCP protocol
        /// </summary>
        /// <param name="ms"></param>
        public void SendResult(MathService ms)
        {
            while (true)
            {
                try
                {
                    TcpListener server = new TcpListener(localAddr, port);
                    server.Start();
                    Console.WriteLine("Waiting for connection... ");

                    TcpClient tcpClient = server.AcceptTcpClient();
                    Console.WriteLine("Client is connected,doing queary...");

                    //getting network stream for reading and writing
                    NetworkStream stream = tcpClient.GetStream();

                    //Confirming message
                    string response = "CONNECTED";
                    byte[] data1 = Encoding.UTF8.GetBytes(response);

                    //sending message
                    stream.Write(data1, 0, data1.Length);

                    string messageString;
                    do
                    {
                        StringBuilder message = new StringBuilder();
                        byte[] data = new byte[256];

                        int bytes = stream.Read(data, 0, data.Length);
                        message.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        messageString = message.ToString();
                        Console.WriteLine(messageString);

                        if (messageString == "exit")
                        {
                            break;
                        }
                        else if (messageString == "other protocol")
                        {
                            break;
                        }
                        if (messageString != String.Empty)
                        {
                            string tiv1 = null;
                            string tiv2 = null;
                            string operator1 = null;

                            Drop(messageString, ref operator1, ref tiv1, ref tiv2);

                            ms.num1 = Convert.ToDouble(tiv1);
                            ms.num2 = Convert.ToDouble(tiv2);

                            double result = ms.PerformOperation(Convert.ToChar(operator1));
                            Console.WriteLine("Worked");

                            string send = Convert.ToString(result);

                            byte[] data2 = Encoding.UTF8.GetBytes(send);
                            stream.Write(data2, 0, data2.Length);
                        }
                    }
                    while (messageString != String.Empty);

                    stream.Close();
                    //closing
                    tcpClient.Close();
                    server.Stop();
                }
                catch (Exception)
                {
                    Console.WriteLine("Something goes wrong...disconnected");
                    return;
                }
            }
        }

        /// <summary>
        /// Getting numbers and the operator
        /// </summary>
        /// <param name="message"></param>
        /// <param name="operator1"></param>
        /// <param name="tiv1"></param>
        /// <param name="tiv2"></param>
        private void Drop(string message, ref string operator1, ref string tiv1, ref string tiv2)
        {
            if (message != String.Empty)
            {
                string[] result = message.Split(' ');
                tiv1 = result[0];
                tiv2 = result[2];
                operator1 = result[1];
            }
        }
    }
}