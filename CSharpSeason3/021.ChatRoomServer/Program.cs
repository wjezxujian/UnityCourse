using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _021.ChatRoomServer
{
    class Program
    {
        static List<Client> clientList = new List<Client>();

        static public void BroadcastMessage(string message)
        {
            var notConnectedList = new List<Client>();

            foreach(Client client in clientList)
            {
                if (client.Connected)
                {
                    client.SendMessage(message);
                }
                else
                {
                    notConnectedList.Add(client);
                }         
            }

            foreach(Client client in notConnectedList)
            {
                clientList.Remove(client);
            }
        }

        static void Main(string[] args)
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 6688));

            tcpServer.Listen(100);

            Console.WriteLine("服务器启动成功……");

            while (true)
            {
                Socket clientSocket = tcpServer.Accept();
                Console.WriteLine("一个客户端连接成功……");
                Client client = new Client(clientSocket);
                clientList.Add(client);
            }
        }
    }
}
