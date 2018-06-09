using System;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Configuration;

namespace Server
{
    public class Server
    {
        //User connection has the socket that is connected to each user and information about the user
        private UserConnection _user1;
        private UserConnection _user2;
        private Socket _socket; //main server socket, used to listen 
        public Server()
        {
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            _user1 = new UserConnection(1, new byte[UserConnection.BufferSize]);
            _user2 = new UserConnection(2, new byte[UserConnection.BufferSize]);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Bind()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse(ConfigurationManager.AppSettings["IPAddress"]);//ipHostInfo.AddressList[0];
            int portNumber = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
            _socket.Bind(localEndPoint);
        }
        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }
        public void Accept()
        {
            if (_user1.userSocket == null)
                _socket.BeginAccept(AcceptCallback, new State(1));
            else if (_user2.userSocket == null)
                _socket.BeginAccept(AcceptCallback, new State(2));
            else
                Console.WriteLine("Accepting more than 2 users is currently not possible");
            
        }
        public void AcceptCallback(IAsyncResult result)
        {
            Console.WriteLine("Connected with a client");
            State temp = result.AsyncState as State;
            if (temp.clientID == 1)
            {
                //_user1.userSocket now represents the connection between the server and client 1
                _user1.userSocket = _socket.EndAccept(result);
                _user1.userSocket.BeginReceive(_user1.buffer, 0, UserConnection.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), new State(1));
                //accept new connections
                Accept();
            }
            if( temp.clientID == 2)
            {
                //_user2.userSocket now represents the connection between the server and client 2
                _user2.userSocket = _socket.EndAccept(result);
                _user2.userSocket.BeginReceive(_user2.buffer, 0, UserConnection.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), new State(2));

                //sending both users the other user's username
                while (_user2.username == null || _user1.username == null) { } //bad code
                byte[] packet = Encoding.ASCII.GetBytes(_user1.username);
                _user2.userSocket.BeginSend(packet, 0, packet.Length, 0, new AsyncCallback(SendCallback), new State(2));
                packet = Encoding.ASCII.GetBytes(_user2.username);
                _user1.userSocket.BeginSend(packet, 0, packet.Length, 0, new AsyncCallback(SendCallback), new State(1));
            }
            
        }
        public void ReceiveCallback(IAsyncResult result)
        {
            State temp = result.AsyncState as State;
            if (temp.clientID == 1)
            {
                _user1.userSocket.EndReceive(result);
                byte[] packet = _user1.buffer.ToArray();
                _user1.buffer = new byte[UserConnection.BufferSize];
                if(_user1.username == null)
                {
                    //handle packet
                    Regex rgx = new Regex(@"[\0]");
                    _user1.username = rgx.Replace(System.Text.Encoding.UTF8.GetString(packet), "");
                }
                //send the values that were in _user1.buffer to user 2 via the _user2.userSocket if user2 is connected
                else if (_user2.userSocket != null)
                {
                    Console.WriteLine("Sending message from {0} to {1}",_user1.username,_user2.username);
                    _user2.userSocket.BeginSend(packet, 0, packet.Length, 0, new AsyncCallback(SendCallback), new State(2));
                }
                _user1.userSocket.BeginReceive(_user1.buffer, 0, _user1.buffer.Length, SocketFlags.None, ReceiveCallback, new State(1));
            }
            if (temp.clientID == 2)
            {
                _user2.userSocket.EndReceive(result);
                byte[] packet = _user2.buffer.ToArray();
                _user2.buffer = new byte[UserConnection.BufferSize];
                if (_user2.username == null)
                {
                    //handle packet
                    Regex rgx = new Regex(@"[\0]");
                    _user2.username = rgx.Replace(System.Text.Encoding.UTF8.GetString(packet), "");
                }
                else
                {
                    //send the values that were in _user1.buffer to user 2 via the _user2.userSocket
                    Console.WriteLine("Sending message from {0} to {1}",_user2.username, _user1.username);
                    _user1.userSocket.BeginSend(packet, 0, packet.Length, 0, new AsyncCallback(SendCallback), new State(1));
                }
                _user2.userSocket.BeginReceive(_user2.buffer, 0, _user2.buffer.Length, SocketFlags.None, ReceiveCallback, new State(2));
            }

        }
        public void SendCallback(IAsyncResult result)
        {
            State temp = result.AsyncState as State;
            if(temp.clientID == 1)
            {
                _user1.userSocket.EndSend(result);
            }
            if (temp.clientID == 2)
            {
                _user2.userSocket.EndSend(result);
            }
        }
    }
}