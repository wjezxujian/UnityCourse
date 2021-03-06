using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _021.ChatRoomServer
{
    class Client
    {
        private Socket clientSocket;
        private Thread thread;
        private byte[] data = new byte[1024];

        public Client(Socket socket)
        {
            clientSocket = socket;

            //启动一个线程处理客户端的数据接收
            thread = new Thread(ReceiveMessage);
            thread.Start();
        }

        private void ReceiveMessage()
        {

            while (true)
            {
                //在接收数据之前判断Socket连接是否断开
                if (clientSocket.Poll(10, SelectMode.SelectRead))
                {
                    Console.WriteLine("连接断开了");
                    break;
                }

                int length = clientSocket.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine("收到了消息：" + message);

                // Todo: 接收到数据的时候 要把这个数据分发到客户端
                Program.BroadcastMessage(message);
                
            }
        }

        public void SendMessage(string message)
        {

            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);
        }

        public bool Connected
        {
            get
            {
                return clientSocket.Connected;
            }
        }
    }
}
