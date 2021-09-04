using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _019.SocketTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建Socket
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2.绑定IP跟端口号
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 1, 100 });
            EndPoint point = new IPEndPoint(ipAddress, 6688);
            tcpServer.Bind(point);

            //3.监听(等待客户端连接)
            tcpServer.Listen(100);

            //4.阻塞当前线程，直到有一个客户端连接过来在唤醒执行下面代码
            Socket clientSocket = tcpServer.Accept();

            //5.发送消息给客户端
            string message = "Hello World!";
            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);
            Console.WriteLine("向客户端发送了一条数据");

            //6.接收客户端消息
            byte[] data2 = new byte[1024];
            int length = clientSocket.Receive(data2);
            string message2 = Encoding.UTF8.GetString(data2, 0, length);
            Console.WriteLine(message2);


            Console.ReadKey();

        }
    }
}
