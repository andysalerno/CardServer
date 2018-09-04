using System;
using CardServer.Networking;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.SendToServer("Hello!");
            client.SendToServer("World!");
            Console.ReadKey();
        }
    }
}
