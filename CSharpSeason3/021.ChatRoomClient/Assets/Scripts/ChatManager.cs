using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    private string ipAddress = "192.168.1.100";
    private int port = 6688;
    private Socket clientSocket;
    public UIInput textInput;
    public UILabel chatLabel;
    private Thread thread;
    private byte[] data = new byte[1024];
    private string message = "";

    // Start is called before the first frame update
    void Start()
    {
        ConnectedToServer();
    }

    // Update is called once per frame
    void Update()
    {
        if(message != null && message != "")
        {
            chatLabel.text += "\n" + message;
            message = "";
        }
    }

    private void ConnectedToServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //与服务器端建立连接
        //clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
        IPAddress iPAddress = IPAddress.Parse("192.168.1.100");
        EndPoint endPoint = new IPEndPoint(iPAddress, 6688);
        clientSocket.Connect(endPoint);

        thread = new Thread(ReceiveMessage);
        thread.Start();

        Debug.Log("123");
    }

    private void SendMessage(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(data);
    }

    private void ReceiveMessage()
    {
        while (true)
        {
            if (clientSocket.Connected == false)
                break;

            int length = clientSocket.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);

        }
    }


    public void OnSendButtonClick()
    {
        string message = textInput.value;
        
        SendMessage(message);

        textInput.value = "";
    }

    private void OnDestroy()
    {
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}
