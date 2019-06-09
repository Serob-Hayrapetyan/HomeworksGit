using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)

        {

            Console.WriteLine("MATH SERVER");



            //I divided the process into 2 threads

            Thread tr1 = new Thread(TcpProt);

            Thread tr2 = new Thread(UdpProt);

            tr1.Start();

            tr2.Start();

        }



        /// <summary>

        /// This method uses TPS protocol

        /// </summary>

        public static void TcpProt()

        {

            try

            {

                TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8001);

                server.Start();



                Console.WriteLine("Waiting for connection... ");



                //Getting coming connection

                TcpClient tcpClient = server.AcceptTcpClient();

                Console.WriteLine("Client is connected,doing queary...");



                //getting network stream for reading and writing

                NetworkStream stream = tcpClient.GetStream();



                //COnfirming message

                string response = "CONNECTED";

                byte[] data1 = Encoding.UTF8.GetBytes(response);



                //sending message

                stream.Write(data1, 0, data1.Length);



                do

                {

                    StringBuilder message = new StringBuilder();

                    byte[] data = new byte[256];



                    int bytes = stream.Read(data, 0, data.Length);

                    message.Append(Encoding.UTF8.GetString(data, 0, bytes));

                    string messageString = message.ToString();

                    Console.WriteLine(messageString);



                    if (messageString == "exit")

                    {

                        break;

                    }



                    string send;



                    string tiv1 = null;

                    string tiv2 = null;

                    int indexOfOperator = 0;



                    if (messageString != String.Empty)

                    {

                        for (int i = 0; i < message.Length; i++)

                        {

                            if (message[i] == ' ')

                            {

                                indexOfOperator = i + 1;

                                for (int k = 0; k < i; k++)

                                {

                                    tiv1 = tiv1 + message[k];

                                }

                                for (int k = i + 3; k < message.Length; k++)

                                {

                                    tiv2 = tiv2 + message[k];

                                }

                                break;

                            }

                        }

                    }



                    double result = 0;



                    switch (message[indexOfOperator])

                    {

                        case '+':

                            result = Convert.ToInt32(tiv1) + Convert.ToInt32(tiv2);

                            break;

                        case '-':

                            result = Convert.ToInt32(tiv1) - Convert.ToInt32(tiv2);

                            break;

                        case '*':

                            result = Convert.ToInt32(tiv1) * Convert.ToInt32(tiv2);

                            break;

                        case '/':

                            result = Convert.ToInt32(tiv1) / Convert.ToInt32(tiv2);

                            break;

                    }

                    Console.WriteLine("Worked");



                    send = Convert.ToString(result);



                    byte[] data2 = Encoding.UTF8.GetBytes(send);

                    stream.Write(data2, 0, data2.Length);

                }

                while (stream.CanRead);



                stream.Close();

                // закрываем подключение

                tcpClient.Close();

            }

            catch (Exception e)

            {

                Console.WriteLine("Something goes wrong...disconnected");

                return;

            }

        }



        /// <summary>

        /// This method uses UDP protocol

        /// </summary>

        public static void UdpProt()

        {

            //for getting

            UdpClient udpClient = new UdpClient();

            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 8001));



            //for sending

            UdpClient client = new UdpClient();

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            client.Connect("localhost", 1000);

            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 1);

                string message = String.Empty;

                do
                {
                    var receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    message = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(message);
                    string tiv1 = null;
                    string tiv2 = null;

                    int indexOfOperator = 0;
                    if (message != String.Empty)
                    {
                        for (int i = 0; i < message.Length; i++)
                        {
                            if (message[i] == ' ')
                            {
                                indexOfOperator = i + 1;
                                for (int k = 0; k < i; k++)
                                {
                                    tiv1 = tiv1 + message[k];
                                }                         
                                for (int k = i + 3; k < message.Length; k++)
                                {
                                    tiv2 = tiv2 + message[k];
                                }
                                break;
                            }
                        }
                    }
                    double result = 0;



                    switch (message[indexOfOperator])

                    {

                        case '+':

                            result = Convert.ToInt32(tiv1) + Convert.ToInt32(tiv2);

                            break;

                        case '-':

                            result = Convert.ToInt32(tiv1) - Convert.ToInt32(tiv2);

                            break;

                        case '*':

                            result = Convert.ToInt32(tiv1) * Convert.ToInt32(tiv2);

                            break;

                        case '/':

                            result = Convert.ToInt32(tiv1) / Convert.ToInt32(tiv2);

                            break;

                    }
                    Console.WriteLine("Result = " + result);

                    var sendBytes = Encoding.ASCII.GetBytes(Convert.ToString(result));
                    client.Send(sendBytes, sendBytes.Length);
                }

                while (message != "exit");
                udpClient.Close();

            }

            catch (Exception e)

            {

                Console.WriteLine("Something goes wrong...disconnected");

                return;

            }

        }
    }
}
