using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class GameState
    {
        private Deck player1Deck;
        private Deck player2Deck;

        private Hand player1Hand;
        private Hand player2Hand;

        private const int START_HEALTH = 60;
        private int HealthPlayer1 { get; } = START_HEALTH;
        private int HealthPlayer2 { get; } = START_HEALTH;

        private List<Id<CardInfo>> discardPilePlayer1 = new List<Id<CardInfo>>();
        private List<Id<CardInfo>> discardPilePlayer2 = new List<Id<CardInfo>>();

        // Defines how many slots exist on each board (not really used right now)
        private const int BOARD_SIZE = 7;
        private BoardSide boardPlayer1 = new BoardSide(BOARD_SIZE);
        private BoardSide boardPlayer2 = new BoardSide(BOARD_SIZE);

        public int ManaPlayer1 { get; private set; }
        public int ManaPlayer2 { get; private set; }

        public Player CurrentPlayerTurn { get; set; }

        public GameState(Deck player1Deck, Deck player2Deck)
        {
            this.player1Deck = player1Deck;
            this.player2Deck = player2Deck;

            this.player1Hand = new Hand();
            this.player2Hand = new Hand();
        }

        public Deck GetDeck(Player player)
        {
            if (player == Player.Player1)
            {
                return this.player1Deck;
            }

            return this.player2Deck;
        }

        public Hand GetHand(Player player)
        {
            if (player == Player.Player1)
            {
                return this.player1Hand;
            }

            return this.player2Hand;
        }

        public int GetHealth(Player player)
        {
            if (player == Player.Player1)
            {
                return this.HealthPlayer1;
            }

            return this.HealthPlayer2;
        }
    }
}