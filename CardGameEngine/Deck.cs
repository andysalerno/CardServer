using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class Deck
    {
        public IList<Id<CardInfo>> Cards { get; private set; }
        public int Size => Cards.Count;
    }
}