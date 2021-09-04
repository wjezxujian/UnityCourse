using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _020.SocketTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建Socket
            Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            //2.连接服务器
            IPAddress iPAddress = IPAddress.Parse("192.168.1.100");
            EndPoint endPoint = new IPEndPoint(iPAddress, 6688);
            tcpClient.Connect(endPoint);


            //3.接收服务端消息
            byte[] date = new byte[1024];
            int length = tcpClient.Receive(date);

            string message = Encoding.UTF8.GetString(date, 0, length);

            Console.WriteLine(message);


            //4.向服务端发送消息
            string message2 = Console.ReadLine();
            tcpClient.Send(Encoding.UTF8.GetBytes(message2));


            Console.ReadKey();


        }
    }
}
