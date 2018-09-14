using CardServer.CardGameEngine;
using CardServer.CardGameEngine.Events;
using CardServer.Networking;
using CardServer.Util;
using System;
using System.Linq;

namespace CardGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new NetworkGameServer();

            EventRunner.RegisterGameServer(server);

            Handshake(server);

            var gameLoop = new GameLoop(new NetworkEventProvider(server), MakePlayerDeck(), MakePlayerDeck());
            gameLoop.PlayGame();

            Console.ReadKey();
        }

        private static void Handshake(NetworkGameServer server)
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

        private static Deck MakePlayerDeck()
        {
            var deck = new Deck();

            var adjectives = new[]
            {
                "Spooky", "Angry", "Happy", "Sleepy", "Floppy", "Enormous", "Savage", "Terrified", "Lazy", "Hungry", "Unmotivated",
            };

            var nouns = new[]
            {
                "Lizard", "Cat", "Monkey", "Robot", "Statue", "Hunter", "Dragon", "Turtle", "Insect", "Rock", "Hurricane", "Machine"
            };

            var rand = new Random();

            for (int i = 0; i < 30; i++)
            {
                string title = $"{adjectives[rand.Next(adjectives.Count())]} {nouns[rand.Next(nouns.Count())]}";
                int strength = rand.Next(10) + 1;
                int health = rand.Next(10) + 1;
                int cost = strength + health / 2;
                var card = new CardInfo(
                   title, cost, "testing", strength, health, 3, CardType.Creature, Tribe.Normal
                );

                deck.AddCard(new Id<CardInfo>(card));
            }

            return deck;
        }
    }
}
