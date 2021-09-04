using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _026.UdpClientS
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 6688));

            IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] data = udpClient.Receive(ref point);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("UDP收到了消息：" + message);
            }
            

            udpClient.Close();
        }
    }
}
