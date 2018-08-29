using CardServer.CardGameEngine;

namespace CardServer.Tests.Helpers
{

    public class CardInfoBuilder
    {
        public string Title { get; set; }
        public int Cost { get; set; }
        public string Text { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Range { get; set; }
        public CardType CardType { get; set; }
        public Tribe Tribe { get; set; }

        public CardInfo Build()
        {
            return new CardInfo(Title, Cost, Text, Attack, Health, Range, CardType, Tribe);
        }
    }

}