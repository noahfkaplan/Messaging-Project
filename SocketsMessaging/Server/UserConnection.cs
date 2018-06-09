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
        public UserConnection(int identifier, byte[] buf)
        {
            buffer = buf;
            id = identifier;
        }
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer;
        // Client  socket.  
        public Socket userSocket;
        // Client Username
        public string username;
        //Client ID
        public int id;
    }
}
