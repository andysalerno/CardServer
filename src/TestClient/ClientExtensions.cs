using System;
using CardServer.Networking;

namespace TestClient
{
    public static class ClientExtensions
    {
        public static void ExpectFromServer(this Client client, string message)
        {
            string received = client.ReceiveFromServer();

            if (message != received)
            {
                throw new Exception($"Expected to receive: {message}\nActually received:{received}");
            }
        }
    }
}