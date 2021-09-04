using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _022.SocketUDPServer
{
    class Program
    {
        static private Socket udpServer;

        static void Main(string[] args)
        {
            //1.创建socket
            udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            
            //2.绑定IP和端口号
            udpServer.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 6688));

            //3.接收数据线程
            new Thread(ReceiveMessage) { IsBackground = true}.Start();


            Console.ReadKey();
        }

        static void ReceiveMessage()
        {
            //3.接收数据
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[1024];

            while (true)
            {
                int length = udpServer.ReceiveFrom(data, ref remote);

                string message = Encoding.UTF8.GetString(data, 0, length);

                IPEndPoint remoteEndPoint = remote as IPEndPoint;
                Console.WriteLine("从ip: " + remoteEndPoint.Address.ToString() + ":" + remoteEndPoint.Port.ToString() + " " + message);   
            }
            
        }
    }
}
