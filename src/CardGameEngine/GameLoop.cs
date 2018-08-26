using CardServer.Networking;

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
        private IGameServer server;

        public GameLoop(IGameServer server) => this.server = server;

        public void PlayGame()
        {
            Deck player1Deck = this.LoadDeck(Player.Player1);
            Deck player2Deck = this.LoadDeck(Player.Player2);

            GameState gameState = StartingGameState(player1Deck, player2Deck);

            Player playerTurn = FirstPlayerCoinToss();

            while (!IsGameOver(gameState))
            {
                PlayerTakeTurn(playerTurn, gameState);

                playerTurn = NextPlayer(playerTurn);
            }
        }

        private void PlayerTakeTurn(Player player, GameState gameState)
        {
            while (gameState.CurrentPlayerTurn == player)
            {
                AEvent playerEvent = WaitForPlayerEvent();
                EventRunner.RunEvent(playerEvent, gameState);
            }
        }

        private static Player FirstPlayerCoinToss()
        {
            return Player.Player1;
        }

        private static bool IsGameOver(GameState gameState)
        {
            return false;
        }

        private static Player NextPlayer(Player currentPlayer)
        {
            return currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
        }

        private static GameState StartingGameState(Deck player1Deck, Deck player2Deck)
        {
            return null;
        }

        private Deck LoadDeck(Player player)
        {
            return null;
        }

        private AEvent WaitForPlayerEvent()
        {
            return null;
        }
    }

}