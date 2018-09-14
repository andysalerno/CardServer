using System;
using System.Collections.Generic;
using System.Linq;

namespace CardServer.CardGameEngine
{
    public class Deck
    {
        private List<Id<CardInfo>> cards = new List<Id<CardInfo>>();

        public IReadOnlyCollection<Id<CardInfo>> Cards => this.cards;

        public bool Any => this.cards.Any();

        public int Size => Cards.Count;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Id<CardInfo> DrawFromTop()
        {
            if (this.cards.Any())
            {
                Id<CardInfo> card = this.cards[0];
                this.cards.RemoveAt(0);

                return card;
            }

            throw new Exception("Cannot draw from an empty deck.");
        }

        public void AddCard(Id<CardInfo> card)
        {
            this.cards.Add(card);
        }
    }
}