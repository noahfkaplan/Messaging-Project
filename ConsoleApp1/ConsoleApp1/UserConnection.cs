using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server
{
    public class UserConnection
    {

        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Client  socket.  
        public Socket userSocket;
        // Client Username
        public string username;
        //Client ID
        public int id;
    }
}
