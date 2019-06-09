using System;
using System.Net.Sockets;
using System.Text;

namespace MathClient
{
    public class TCP : INetworkService
    {
        Int32 port = 8001;
        string localAddr = "127.0.0.1";

        /// <summary>
        /// Sending messages using TCp protocol clients
        /// </summary>
        public void SendMessage()
        {
            // 1. Create a TcpClient ( need to have TcpServer connected to the same ip address and port
            try
            {
                TcpClient client = new TcpClient();
                client.SendTimeout = 1000;
                client.Connect(localAddr,port);

                byte[] data = new byte[256];
                StringBuilder response = new StringBuilder();

                // 2. Get client stream for reading and writing
                NetworkStream stream = client.GetStream();

                //Connection confirming
                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                //design 
                Console.WriteLine(response.ToString());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("WELCOM to TCP PROTOCOL. Enter operations in this format : NUMBER space OPERATOR space NUMBER");
                Console.ResetColor();
                //end disign

                string message = String.Empty;

                do
                {
                    //reading user's message
                    Console.Write("Enter expression: ");
                    message = Console.ReadLine();

                    //checking protocol choice
                    if (message == "other protocol")
                    {
                        stream.Close();
                        client.Close();
                        return;
                    }

                    byte[] data1 = Encoding.UTF8.GetBytes(message);

                    // 3. Send message to the connected server
                    stream.Write(data1, 0, data1.Length);

                    // 4. Receive the server response - read the response into buffer
                    StringBuilder result = new StringBuilder();
                    var data2 = new byte[256];
                    int bytes = stream.Read(data2, 0, data2.Length);

                    result.Append(Encoding.UTF8.GetString(data2, 0, bytes));
                    Console.WriteLine("Result = " + result);
                }
                while (message != String.Empty);

                // 5. Close stream
                stream.Close();
                // 6. Close client
                client.Close();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something goes wrong...disconnected");
                Console.ResetColor();
            }
        }
    }
}
