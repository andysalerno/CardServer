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
        public string Title { get; }
        public int Cost { get; }
        public string Text { get; }
        public int Attack { get; }
        public int Health { get; }
        public int Range { get; }
        public CardType CardType { get; }
        public Tribe Tribe { get; }

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

        public CardInfo(
            string title,
            int cost,
            string text,
            int attack,
            int health,
            int range,
            CardType cardType,
            Tribe tribe
        )
        {
            Title = title;
            Cost = cost;
            Text = text;
            Attack = attack;
            Health = health;
            Range = range;
            CardType = cardType;
            Tribe = tribe;
        }

        public CardInfo() { }
    }

    // public List<Trigger> Triggers {get; private set;}
    // enum Trigger { OnAttack, OnAttacked, OnDraw, OnConjure, ... }
}