using CardServer.CardGameEngine;
using CardServer.Networking.Events;
using CardServer.Tests.TestExtensions;
using Moq;
using Xunit;

namespace CardServer.Tests
{
    public class GameLogicTests
    {

        [Fact]
        public void DrawCard()
        {
            const int StartingDeckSize = 10;
            const Player playerToDraw = Player.Player2;

            var deck1 = new Deck().WithCardCount(StartingDeckSize);
            var deck2 = new Deck().WithCardCount(StartingDeckSize);

            var gameState = new GameState(deck1, deck2);

            int startingHandSize = gameState.GetHand(playerToDraw).Size;

            var drawEvent = new PlayerDrawCardEvent(playerToDraw);
            EventRunner.RunEvent(drawEvent, gameState);

            Assert.Equal(StartingDeckSize - 1, deck2.Size);
            Assert.Equal(startingHandSize + 1, gameState.GetHand(playerToDraw).Size);
        }
    }
}