using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _027.UdpClientC
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length, "192.168.1.100", 6688);
            }
            
            client.Close();

            Console.ReadKey();
        }
    }
}
