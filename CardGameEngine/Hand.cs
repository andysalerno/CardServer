using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class Hand
    {
        public Player Player { get; private set; }
        public IList<Id<CardInfo>> Cards { get; private set; }
        public int Size => Cards.Count;
    }
}