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

            Debug.Log("Waiting for opening handshake...");
            Thread.Sleep(5000);
            string message = server.ReceiveFromClient();
            Debug.Log($"Received: {message}");
            if (message != "Hello!")
            {
                Debug.Log("Handshake protocol violated! Quitting.");
                Console.ReadKey();
                return;
            }

            string nextMessage = server.ReceiveFromClient();
            Debug.Log($"Received: {nextMessage}");
            if (nextMessage != "World!")
            {
                Debug.Log("Handshake protocol violated! Quitting.");
                Console.ReadKey();
                return;
            }

            Debug.Log("All happy! Press any key to quit.");
            Console.ReadKey();
        }
    }
}
