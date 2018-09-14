using CardServer.CardGameEngine.Events;
using System;

namespace CardServer.CardGameEngine
{
    public enum Player
    {
        Player1,
        Player2,
    }

    /// <summary>
    /// The central game-running logic.
    /// Create a <see cref="GameLoop"/> by passing it an event provider and two decks.
    /// 
    /// From there, you can invoke <see cref="PlayGame"/> and this class will
    /// begin requesting actions from each player in turn, running them with the <see cref="EventRunner"/>.
    /// </summary>
    public class GameLoop
    {
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

            const int START_HAND_SIZE = 5;
            EventRunner.RunEvent(new GameStartCardDrawEvent(START_HAND_SIZE), gameState);

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