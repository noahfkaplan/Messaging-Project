using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace Client
{
    public class Client
    {
        // State object for reading client data asynchronously  
        
        private byte[] _buffer;
        private Socket _socket;

        public Client()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        public void Connect(string ipAddress, int port)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            _socket.BeginConnect(endPoint,ConnectCallback,null);
        }

        private void ConnectCallback(IAsyncResult result)
        {
            Console.WriteLine("Connected to the Server");
            _socket.EndConnect(result);
            connectDone.Set();
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
            
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            int packetSize = _socket.EndReceive(result);
            byte[] packet = new byte[packetSize];
            packet = _buffer;

            //handle packet
            Console.WriteLine("Received Message: " + Regex.Replace(System.Text.Encoding.Default.GetString(packet), @"\s+", ""));
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }

        public void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            _buffer = data;
            _socket.BeginSend(_buffer, 0, _buffer.Length,0 , new AsyncCallback(SendCallback), null);
        }
        public void SendCallback(IAsyncResult result)
        {
            _socket.EndSend(result);
            _buffer = new byte[1024];
            sendDone.Set();
        }
    }
}
