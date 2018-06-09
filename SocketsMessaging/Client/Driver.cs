using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Driver
    {
        private static ClientObject client = new ClientObject();
        public static void Main()
        {
        //    client.Connect("127.0.0.1",6556);
        //    Console.Write("Enter a user name:");
        //    client.Send(Console.ReadLine());
            while (true)
            {
                //string message = Console.ReadLine();
                //client.Send(message);
                Console.ReadLine();
            }
        }
    }
}
