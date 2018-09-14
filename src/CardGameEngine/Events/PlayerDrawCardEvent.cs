using CardServer.Util;

namespace CardServer.CardGameEngine.Events
{
    public class PlayerDrawCardEvent : AEvent
    {
        public Player Player { get; }

        public Id<CardInfo> CardDrawn { get; private set; }

        public override string Description => $"{this.Player} draws a card";

        public PlayerDrawCardEvent(Player player)
        {
            this.Player = player;
        }

        public override void Run(GameState gameState)
        {
            Deck deck = gameState.GetDeck(this.Player);
            Id<CardInfo> card = deck.DrawFromTop();
            this.CardDrawn = card;

            Hand hand = gameState.GetHand(this.Player);
            hand.AddCard(card);

            Debug.Log($"Player {this.Player} draw card: {card.Value.Title}");
        }
    }
}