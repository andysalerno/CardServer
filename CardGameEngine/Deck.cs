using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class Deck
    {
        public IList<CardInfo> Cards { get; private set; }
        public int Size => Cards.Count;
    }
}