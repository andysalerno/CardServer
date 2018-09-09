using System;
using CardServer.CardGameEngine.Events;
using CardServer.Networking;
using CardServer.Util;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new GameClient();

            Handshake(client);

            Debug.Log("Handshake complete.");

            while (true)
            {
                GameMessage received = client.Receive();
            }

            Console.ReadKey();
        }

        private static void Handshake(GameClient client)
        {
            GameMessage hello = client.Receive();
            if (hello.ContentType != typeof(HandshakeEvent))
            {
                throw new Exception("client expected handshake");
            }

            HandshakeEvent handshake = hello.DeserializeContent<HandshakeEvent>();
            string handshakeMessage = handshake.HandshakeMessage;

            // send it back to server to ack
            client.Send(new GameMessage(new HandshakeEvent(handshakeMessage)));
        }
    }
}
