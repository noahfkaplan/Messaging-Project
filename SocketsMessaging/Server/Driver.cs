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
            Server server = new Server();
            server.Bind();
            server.Listen(50);
            server.Accept();

            while (true)
            {
                Console.ReadLine();
            }
        }

    }
}
