using System;
using CardServer.Networking;
using CardServer.Util;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new Client();

            Handshake(client);

            Console.ReadKey();
        }

        private static string ReceiveFromServer(Client client)
        {
            string message = client.ReceiveFromServer();

            if (message == "Closing connection")
            {
                Environment.Exit(0);
            }

            return message;
        }

        private static void Handshake(Client client)
        {
            client.SendToServer("Hello!");
            client.SendToServer("World!");
            client.ExpectFromServer("Hello right back at you!");

            Debug.Log("Handshake complete.");
        }
    }
}
