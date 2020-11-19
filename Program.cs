using System;
using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            String IpAddressString = IPAddress.Loopback.ToString();
            Int32 port = 14333;
            String message = "Привет!";

            Console.WriteLine("Connecting to server...");

            try
            {

                TcpClient client = new TcpClient(IpAddressString, port);
                NetworkStream stream = client.GetStream();
                int count = 0;
                String response = "";

                while (!response.Equals("пока"))
                {
                    // Translate the Message into ASCII.
                    Byte[] data = System.Text.Encoding.Unicode.GetBytes(message);
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Я: {0}", message);
                    // Bytes Array to receive Server Response.
                    data = new Byte[256];
                    response = String.Empty;
                    // Read the Tcp Server Response Bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    response = System.Text.Encoding.Unicode.GetString(data, 0, bytes);
                    Console.WriteLine("Сервер: {0}", response);
                    if (!response.Equals("пока")) message = Console.ReadLine();
                }
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }


        }


    }
}
