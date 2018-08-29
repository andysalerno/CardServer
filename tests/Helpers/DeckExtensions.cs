using CardServer.CardGameEngine;

namespace CardServer.Tests.Helpers
{
    public static class DeckExtensions
    {
        public static Deck WithCardCount(this Deck deck, int count)
        {
            for (int i = 0; i < count; i++)
            {
                deck.AddCard(TestCards.SleepyPanda);
            }

            return deck;
        }

        public static Deck AddCard(this Deck deck, Id<CardInfo> card, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Id<CardInfo> copy = new Id<CardInfo>(new CardInfo(card.Value));
                deck.AddCard(copy);
            }

            return deck;
        }
    }
}