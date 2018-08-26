namespace CardServer.CardGameEngine
{
    public enum CardType
    {
        Creature,
        Spell,
        Persistent,
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

        public CardInfo(CardInfo other)
        {
            this.Title = other.Title;
            this.Cost = other.Cost;
            this.Text = other.Text;
            this.Attack = other.Attack;
            this.Health = other.Health;
            this.Range = other.Range;
            this.CardType = other.CardType;
            this.Tribe = other.Tribe;
        }
    }

    // public List<Trigger> Triggers {get; private set;}
    // enum Trigger { OnAttack, OnAttacked, OnDraw, OnConjure, ... }
}