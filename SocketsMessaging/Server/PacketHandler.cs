using System;
using System.Net.Sockets;

namespace Server
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
