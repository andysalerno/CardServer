namespace CardServer.CardGameEngine
{
    public class CardTakeDamageEvent
    {
        private Id<SummonedCard> Target { get; set; }
        private Id<SummonedCard> Source { get; set; }

        public CardTakeDamageEvent(Id<SummonedCard> target, Id<SummonedCard> source)
        {
            Target = target ?? throw new System.ArgumentNullException(nameof(target));
            Source = source ?? throw new System.ArgumentNullException(nameof(source));

        }
    }
}