using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    public static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            Console.WriteLine("Received a packet");
            //clientSocket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
        }
    }
}
