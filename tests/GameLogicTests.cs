using System.Collections.Generic;
using System.Linq;
using CardServer.CardGameEngine;
using CardServer.Networking.Events;
using CardServer.Tests.Helpers;
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

        [Fact]
        public void StartGameBehavior()
        {
            var deck1 = new Deck();
            deck1.AddCard(TestCards.SleepyPanda, count: 10);
            deck1.AddCard(TestCards.BigDragon, count: 2);

            var deck2 = new Deck();
            deck2.AddCard(TestCards.RabidDog, count: 10);
            deck2.AddCard(TestCards.BigDragon, count: 2);

            var eventQueue = new List<AEvent>
            {
                new PlayerActionPlayCardEvent(Player.Player1, deck1.Cards.First(), new Id<CardMount>(new CardMount(1))),
                new PlayerActionEndTurnEvent(),
                new PlayerDrawCardEvent(Player.Player2),
                new PlayerActionPlayCardEvent(Player.Player2, deck1.Cards.First(), new Id<CardMount>(new CardMount(1))),
                new PlayerActionEndTurnEvent(),
                new PlayerActionForfeitGame(Player.Player1),
            };

            var eventProvider = new TestEventProvider(eventQueue);

            var gameLoop = new GameLoop(eventProvider, deck1, deck2);

            // PlayGame() will trigger the beginning of game card draw events
            gameLoop.PlayGame();
        }
    }
}