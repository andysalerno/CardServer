using CardServer.CardGameEngine;
using CardServer.Networking;
using CardServer.Networking.Events;
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
    }
}
