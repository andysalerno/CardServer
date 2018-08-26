using System.Collections.Generic;
using System.Linq;

namespace CardServer.CardGameEngine
{
    public class Deck
    {
        public IList<Id<CardInfo>> Cards { get; private set; }
        public int Size => Cards.Count;

        public Id<CardInfo> DrawFromTop()
        {
            if (this.Cards.Any())
            {
                Id<CardInfo> card = this.Cards[0];
                this.Cards.RemoveAt(0);

                return card;
            }

            return null;
        }
    }
}