using CardServer.CardGameEngine;
using CardServer.CardGameEngine.Events;
using CardServer.CardGameEngine.Helpers;
using CardServer.Networking;
using CardServer.Tests.Helpers;
using Xunit;

namespace CardServer.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void GameMessageIsSerializable()
        {
            AEvent source = new PlayerDrawCardEvent(Player.Player2);

            GameMessage gameMessage = new GameMessage(source);

            // even though our reference is the abstract type, we should still know the derived
            Assert.Equal(typeof(PlayerDrawCardEvent), gameMessage.ContentType);

            string serializedMessage = Util.Json.Serialize(gameMessage);

            GameMessage deserializedMessage = Util.Json.Deserialize<GameMessage>(serializedMessage);

            // upon deserialization, the content type should still be known
            Assert.Equal(typeof(PlayerDrawCardEvent), deserializedMessage.ContentType);

            PlayerDrawCardEvent sourceCast = source as PlayerDrawCardEvent;
            PlayerDrawCardEvent deserialized = deserializedMessage.DeserializeContent<PlayerDrawCardEvent>();
            Assert.Equal(sourceCast.Player, deserialized.Player);
        }

        [Fact]
        public void CardInfoIsSerializable()
        {
            AEvent source = new PlayerDrawCardEvent(Player.Player2);

            var deckP1 = new Deck().WithCardCount(1);
            var deckP2 = new Deck().WithCardCount(1);

            var gameState = new GameState(deckP1, deckP2);

            source.Run(gameState);

            GameMessage gameMessage = new GameMessage(source);

            string serialized = Util.Json.Serialize(gameMessage);

            GameMessage deserialized = Util.Json.Deserialize<GameMessage>(serialized);

            AEvent receivedEvent = deserialized.ToEvent();

            PlayerDrawCardEvent deserializedEvent = receivedEvent as PlayerDrawCardEvent;

            Assert.Equal(TestCards.SleepyPanda.Value.Title, deserializedEvent.CardDrawn.Value.Title);
            Assert.Equal(TestCards.SleepyPanda.Value.Text, deserializedEvent.CardDrawn.Value.Text);
            Assert.Equal(TestCards.SleepyPanda.Value.Cost, deserializedEvent.CardDrawn.Value.Cost);
            // ...
        }
    }
}
