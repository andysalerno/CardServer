using CardServer.CardGameEngine.Events;
using CardServer.CardGameEngine.Helpers;
using CardServer.Networking;
using CardServer.Util;
using System;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new NetworkGameClient();

            Handshake(client);

            while (true)
            {
                GameMessage received = client.WaitReceive();

                if (received.ContentType == typeof(ServerCloseSessionEvent))
                {
                    Debug.Log("The server has ended the session.");
                    return;
                }
                else
                {
                    AEvent _event = received.ToEvent();
                    Debug.Log(_event.Description);
                }
            }
        }

        private static void Handshake(NetworkGameClient client)
        {
            GameMessage hello = client.WaitReceive();

            if (hello.ContentType != typeof(HandshakeEvent))
            {
                throw new Exception("client expected handshake");
            }

            HandshakeEvent handshake = hello.DeserializeContent<HandshakeEvent>();
            string handshakeMessage = handshake.HandshakeMessage;

            // send it back to server to ack
            client.Send(new GameMessage(new HandshakeEvent(handshakeMessage)));
            Debug.Log("Handshake complete.");
        }
    }
}
