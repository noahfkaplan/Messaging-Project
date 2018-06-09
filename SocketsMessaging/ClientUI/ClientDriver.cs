using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace ClientUI
{
    public class ClientDriver
    {
        private ClientObject client;
        public string myUsername;
        public ClientDriver(string username)
        {
            myUsername = username;
            client = new ClientObject();
            client.Connect("127.0.0.1", 6556);
            client.Send(myUsername);
        }
        public void SendMessage(string message)
        {
            client.Send(message);
        }
        public List<string> Refresh()
        {
            if(client.messageBacklog.Count > 0)
            {
                return client.messageBacklog;
            }
            else
            {
                return null;
            }
        }
    }
}
