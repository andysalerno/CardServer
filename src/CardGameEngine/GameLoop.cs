using System;
using CardServer.Networking;
using CardServer.Networking.Events;

namespace CardServer.CardGameEngine
{
    public enum Player
    {
        Player1,
        Player2,
    }

    public class GameLoop
    {
        // game start
        private IEventProvider eventProvider;

        public Deck DeckPlayer1 { get; }
        public Deck DeckPlayer2 { get; }

        public GameLoop(IEventProvider eventProvider, Deck deckPlayer1, Deck deckPlayer2)
        {
            this.eventProvider = eventProvider ?? throw new ArgumentNullException(nameof(eventProvider));
            DeckPlayer1 = deckPlayer1 ?? throw new System.ArgumentNullException(nameof(deckPlayer1));
            DeckPlayer2 = deckPlayer2 ?? throw new System.ArgumentNullException(nameof(deckPlayer2));
        }

        public void PlayGame()
        {
            GameState gameState = StartingGameState(this.DeckPlayer1, this.DeckPlayer2);

            // at the beginning, each player will draw 5 cards
            const int FIRST_DRAW_COUNT = 5;
            for (int i = 0; i < FIRST_DRAW_COUNT; i++)
            {
                var drawEventPlayer1 = new PlayerDrawCardEvent(Player.Player1);
                var drawEventPlayer2 = new PlayerDrawCardEvent(Player.Player2);

                EventRunner.RunEvent(drawEventPlayer1, gameState);
                EventRunner.RunEvent(drawEventPlayer2, gameState);
            }

            Player playerTurn = FirstPlayerCoinToss();

            while (!IsGameOver(gameState))
            {
                PlayerTakeTurn(playerTurn, gameState);

                playerTurn = NextPlayer(playerTurn);
            }

            EventRunner.RunEvent(new GameOverEvent(), gameState);
        }

        private void PlayerTakeTurn(Player player, GameState gameState)
        {
            while (gameState.CurrentPlayerTurn == player && !IsGameOver(gameState))
            {
                AEvent playerEvent = this.eventProvider.WaitForEvent();
                EventRunner.RunEvent(playerEvent, gameState);
            }
        }

        private static Player FirstPlayerCoinToss()
        {
            return Player.Player1;
        }

        private static bool IsGameOver(GameState gameState)
        {
            return gameState.GetHealth(Player.Player1) <= 0 || gameState.GetHealth(Player.Player2) <= 0
                || gameState.ForfeitPlayer1 || gameState.ForfeitPlayer2;
        }

        private static Player NextPlayer(Player currentPlayer)
        {
            return currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
        }

        private static GameState StartingGameState(Deck player1Deck, Deck player2Deck)
        {
            return new GameState(player1Deck, player2Deck);
        }

        private Deck LoadDeck(Player player)
        {
            return null;
        }
    }

}