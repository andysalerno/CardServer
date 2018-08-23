namespace CardServer.CardGameEngine
{
    public enum CardType
    {
        Creature,
        Spell,
    }

    public enum Tribe
    {
        // ...
        Normal,
    }

    public class CardInfo
    {
        public string Title { get; private set; }
        public int Cost { get; private set; }
        public string Text { get; private set; }
        public int Attack { get; private set; }
        public int Health { get; private set; }
        public int Range { get; private set; }
        public CardType CardType { get; private set; }
        public Tribe Tribe { get; private set; }
    }
}