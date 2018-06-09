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
    public class ClientObject
    {
        // State object for reading client data asynchronously  
        
        private byte[] _buffer;
        private Socket _socket;
        public List<string> messageBacklog;

        public ClientObject()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            messageBacklog = new List<string>();
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
            _socket.EndConnect(result);
            connectDone.Set();
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            int packetSize = _socket.EndReceive(result);
            byte[] packet = _buffer.ToArray();

            //handle packet
            Regex rgx = new Regex(@"[\0]");
            string temp = rgx.Replace(System.Text.Encoding.UTF8.GetString(packet),"");
            //Console.WriteLine("Received Message: " + temp);
            messageBacklog.Add(temp);
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }

        public void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            _socket.BeginSend(data, 0, data.Length,0 , new AsyncCallback(SendCallback), null);
        }
        public void SendCallback(IAsyncResult result)
        {
            _socket.EndSend(result);
            sendDone.Set();
        }
    }
}
