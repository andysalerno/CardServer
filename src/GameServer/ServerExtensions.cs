using System;
using CardServer.Networking;

namespace GameServer
{
    public static class ServerExtensions
    {
        public static void ExpectFromClient(this Server server, string message)
        {
            string received = server.ReceiveFromClient();

            if (message != received)
            {
                throw new Exception($"Expected to receive: {message}\nActually received:{received}");
            }
        }
    }
}