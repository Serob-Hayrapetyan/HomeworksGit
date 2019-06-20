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
                    string operator1 = null;

                    Drop(message, ref operator1, ref tiv1, ref tiv2);

                    ms.num1 = Convert.ToDouble(tiv1);
                    ms.num2 = Convert.ToDouble(tiv2);

                    string result = Convert.ToString(ms.PerformOperation(Convert.ToChar(operator1)));                 

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