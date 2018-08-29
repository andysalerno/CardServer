using CardServer.CardGameEngine;

namespace CardServer.Tests.Helpers
{
    public class TestCards
    {
        public static Id<CardInfo> BigDragon => new Id<CardInfo>(new CardInfoBuilder
        {
            Title = "Big Dragon!",
            Attack = 8,
            Health = 9,
            Cost = 9,
            CardType = CardType.Creature,
            Text = "it's a really big dragon!",
            Range = 8,
            Tribe = Tribe.Normal,
        }.Build());

        public static Id<CardInfo> RabidDog => new Id<CardInfo>(new CardInfoBuilder
        {
            Title = "Rabid Dog",
            Attack = 4,
            Health = 1,
            Cost = 3,
            CardType = CardType.Creature,
            Text = "At the start of your turn, deals 1 damage to adjacent creatures.",
            Range = 1,
            Tribe = Tribe.Normal,
        }.Build());

        public static Id<CardInfo> SleepyPanda => new Id<CardInfo>(new CardInfoBuilder
        {
            Title = "Sleepy Panda",
            Attack = 2,
            Health = 3,
            Cost = 3,
            CardType = CardType.Creature,
            Text = "Pick an enemy creature within range to sleep next turn.",
            Range = 3,
            Tribe = Tribe.Normal,
        }.Build());
    }
}