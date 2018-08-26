using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CardServer.CardGameEngine
{
    public class Hand
    {
        public Player Player { get; private set; }
        private List<Id<CardInfo>> cards;
        public ReadOnlyCollection<Id<CardInfo>> Cards => this.cards.AsReadOnly();
        public int Size => this.cards.Count;

        public void AddCard(Id<CardInfo> card)
        {
            if (card == null)
            {
                // todo: must be a better way to achieve this
                throw new ArgumentNullException(nameof(card));
            }

            this.cards.Add(card);
        }
    }
}