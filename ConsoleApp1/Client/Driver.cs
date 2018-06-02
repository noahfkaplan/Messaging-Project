using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Driver
    {
        private static Client client = new Client();
        public static void Main()
        {
            Console.Write("Enter a user name:");
            Console.ReadLine();
            client.Connect("127.0.0.1",6556);
            while (true)
            {
                Console.Write("Type your message: ");
                string message = Console.ReadLine();
                client.Send(message);
            }
        }
    }
}
