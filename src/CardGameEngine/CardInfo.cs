using System;

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

    [Serializable()]
    public class CardInfo
    {
        public string Title { get; set; }
        public int Cost { get; set; }
        public string Text { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Range { get; set; }
        public CardType CardType { get; set; }
        public Tribe Tribe { get; set; }

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