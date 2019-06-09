using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MathServer
{
    public class UDP : INetworkService
    {
        int port = 8001;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        public void SendResult(MathService ms)
        {
            //for getting
            UdpClient clientget = new UdpClient();
            clientget.Client.Bind(new IPEndPoint(IPAddress.Any, port));

            //for sending
            UdpClient clientsend = new UdpClient();
            clientsend.Connect(localAddr,1000);

            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 1);

                string message = String.Empty;

                do
                {
                    var receiveBytes = clientget.Receive(ref RemoteIpEndPoint);
                    message = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(message);

                    string tiv1 = null;
                    string tiv2 = null;
                    int indexOfOperator = 0;

                    Drop(message, ref indexOfOperator, ref tiv1, ref tiv2);

                    ms.num1 = Convert.ToDouble(tiv1);
                    ms.num2 = Convert.ToDouble(tiv2);

                    string result = Convert.ToString(ms.PerformOperation(message[indexOfOperator]));                 

                    var sendBytes = Encoding.ASCII.GetBytes(result);
                    clientsend.Send(sendBytes, sendBytes.Length);
                    Console.WriteLine("worked");
                }
                while (message != "exit");

                //closing client
                clientget.Close();
                clientsend.Close();
            }
            catch(Exception)
            {
                Console.WriteLine("Something goes wrong...disconnected");
                return;
            }
        }

        /// <summary>
        /// Getting numbers and the operator
        /// </summary>
        /// <param name="message"></param>
        /// <param name="indexOfOperator"></param>
        /// <param name="tiv1"></param>
        /// <param name="tiv2"></param>
        private void Drop(string message,ref int indexOfOperator,ref string tiv1,ref string tiv2)
        {
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
                        return;
                    }
                }
            }
        }
    }
}