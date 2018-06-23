using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client;

namespace ClientUI
{
    public class ClientDriver
    {
        private ClientObject client;
        public string myUsername;
        private const string errorMessage = "Connection lost with server";
        public bool serverConnected = true;
        public ClientDriver(string username)
        {
            myUsername = username;
            client = new ClientObject();
            client.Connect();
            client.Send(myUsername);

        }
        public void SendMessage(string message)
        {
            if (client.serverOnline)
            {
                client.Send(message);
            }
            else
            {
                serverConnected = false;
                Disconnect();

            }
        }
        public List<string> Refresh()
        {
            if (!client.serverOnline)
            {
                serverConnected = false;
                Disconnect();
            }
            if (client.messageBacklog.Count > 0)
            {
                return client.messageBacklog;
            }
            else
            {
                return null;
            }
        }
        public void Disconnect()
        {
            
            //Environment.Exit(0);

        }
    }
}
