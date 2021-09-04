using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _023.SocketUDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 6688);
            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.SendTo(data, endPoint);
            }

            udpClient.Close();
            Console.ReadKey();
        }
    }
}
