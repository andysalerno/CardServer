using CardServer.CardGameEngine;

namespace CardServer.Tests.TestExtensions
{
    public static class DeckExtensions
    {
        public static Deck WithCardCount(this Deck deck, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var card = new CardInfo();
                var idCard = new Id<CardInfo>(card);

                deck.AddCard(idCard);
            }

            return deck;
        }
    }
}