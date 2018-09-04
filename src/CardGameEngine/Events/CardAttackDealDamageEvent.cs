namespace CardServer.CardGameEngine.Events
{
    public class CardAttackDealDamageEvent : AEvent
    {
        private Id<SummonedCard> Target { get; set; }
        private Id<SummonedCard> Source { get; set; }
        public override string Description => $"Card {Target} takes damage from {Source}";

        public CardAttackDealDamageEvent(Id<SummonedCard> target, Id<SummonedCard> source)
        {
            Target = target ?? throw new System.ArgumentNullException(nameof(target));
            Source = source ?? throw new System.ArgumentNullException(nameof(source));

        }

        public override void Run(GameState gameState)
        {
            throw new System.NotImplementedException();
        }
    }
}