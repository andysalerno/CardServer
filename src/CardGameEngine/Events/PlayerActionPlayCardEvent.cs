using CardServer.CardGameEngine;

namespace CardServer.Networking.Events
{
    public class PlayerActionPlayCardEvent : AEvent
    {
        public Id<CardInfo> CardPlayed { get; }
        public Id<CardMount> CardMount { get; }
        public Player Player { get; }

        public override string Description => $"{this.Player} plays card {this.CardPlayed} on mount {this.CardMount}";

        public PlayerActionPlayCardEvent(Player player, Id<CardInfo> cardPlayed, Id<CardMount> cardMount)
        {
            Player = player;
            CardPlayed = cardPlayed ?? throw new System.ArgumentNullException(nameof(cardPlayed));
            CardMount = cardMount ?? throw new System.ArgumentNullException(nameof(cardMount));
        }

        public override void Run(GameState gameState)
        {
            if (gameState == null)
            {
                throw new System.ArgumentNullException(nameof(gameState));
            }

            var summoned = new Id<SummonedCard>(new SummonedCard(this.CardPlayed, this.CardMount));
            this.CardMount.Value.MountedCard = summoned;
        }
    }
}