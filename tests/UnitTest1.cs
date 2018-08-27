using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CardServer.CardGameEngine;
using CardServer.Networking.Events;
using Xunit;

namespace CardServer.Tests
{
    public class GameEngineTests
    {
        // [Fact]
        // public void DrawCard()
        // {
        //     var gameLoop = new GameLoop(new TestServer());
        // }

        [Fact]
        public void EventIsSerializable()
        {
            var serialized = new PlayerDrawCardEvent(Player.Player1);

            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, serialized);

            stream.Seek(0, SeekOrigin.Begin);
            PlayerDrawCardEvent deserialized = formatter.Deserialize(stream) as PlayerDrawCardEvent;

            Assert.True(deserialized != null);
            Assert.Equal(serialized, deserialized);
        }
    }
}
