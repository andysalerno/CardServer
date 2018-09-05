using System;
using System.Threading;
using CardServer.Networking;
using CardServer.Util;

namespace GameServer
{
    class Program
    {
        private const int PORT = 7777;
        static void Main(string[] args)
        {
            var server = new Server();
            server.AcceptClient();

            Handshake(server);

            Console.ReadKey();

            CloseConnection(server);
        }

        private static void Handshake(Server server)
        {
            server.ExpectFromClient("Hello!");
            server.ExpectFromClient("World!");
            server.SendToClient("Hello right back at you!");
            Debug.Log("Handshake complete.");
        }

        private static void CloseConnection(Server server)
        {
            server.SendToClient("Closing connection");
            server.Flush();
        }
    }
}
