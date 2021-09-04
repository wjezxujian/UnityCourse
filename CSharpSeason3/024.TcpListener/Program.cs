using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace _024.TcpListenerEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.TcpListener对Socket进行了封装
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.1.100"), 6688);

            //2.开始进行监听
            listener.Start();

            //3.等待客户端连接
            TcpClient client = listener.AcceptTcpClient();

            //4.取得客户端发送过来的数据
            NetworkStream stream =  client.GetStream();

            byte[] date = new byte[1024];
            while (client.Connected && stream.CanRead)
            {                
                int length = stream.Read(date, 0, 1024);
                string message = Encoding.UTF8.GetString(date, 0, length);

                Console.WriteLine("收到了消息：" + message);
            }

            Console.ReadKey();

            stream.Close();
            client.Close();
            listener.Stop();
        }
    }
}
