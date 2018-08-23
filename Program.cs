using System;
using System.Linq;
using System.Threading;
using CardServer.Networking;

namespace CardServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("Client", StringComparer.OrdinalIgnoreCase))
            {
                var client = new Client();
                Thread.Sleep(3000);

                while (true)
                {
                    client.ReceiveFromServer();
                }
            }
            else
            {
                var server = new Server();
                Thread.Sleep(3000);
                server.AcceptClient();
                Thread.Sleep(3000);

                for (int i = 0; i < 20; i++)
                {
                    server.SendToClient($"Here's message number: {i}");
                }
            }
        }
    }
}
