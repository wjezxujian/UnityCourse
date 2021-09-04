using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace _025.TcpClientEx
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("192.168.1.100", 6688);

            NetworkStream stream = client.GetStream();

            while (stream.CanWrite)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }

            stream.Close();
            client.Close();

            Console.ReadKey();
        }
    }
}
