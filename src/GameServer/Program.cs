using System;
using System.Threading;
using CardServer.CardGameEngine.Events;
using CardServer.Networking;
using CardServer.Util;

namespace CardGameServer
{
    class Program
    {
        private const int PORT = 7777;
        static void Main(string[] args)
        {
            var server = new GameServer();

            Handshake(server);

            Console.ReadKey();
        }

        private static void Handshake(GameServer server)
        {
            string guid = Guid.NewGuid().ToString();
            var handshake = new HandshakeEvent(guid);

            server.Send(new GameMessage(handshake));

            GameMessage received = server.Receive();
            if (received.ContentType != typeof(HandshakeEvent))
            {
                throw new Exception("server expected handshake.");
            }

            HandshakeEvent internalEvent = received.DeserializeContent<HandshakeEvent>();
            if (internalEvent.HandshakeMessage != guid)
            {
                throw new Exception($"The client did not respond with the expected handshake message. Expected: {guid}\nSaw: {internalEvent.HandshakeMessage}");
            }

            Debug.Log("Handshake succeeded.");
        }
    }
}
