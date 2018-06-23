using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Driver
    {

        public static void Main()
        {
            try
            {
                Server server = new Server();
                server.Bind();
                server.Listen(50);
                server.Accept();
            }
            catch
            {
                Console.WriteLine("Connection Lost with clients");
            }
            while (true)
            {
                Console.ReadLine();
            }
        }

    }
}
