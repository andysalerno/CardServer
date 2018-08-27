using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CardServer.CardGameEngine
{
    public class Hand
    {
        public Player Player { get; }
        private List<Id<CardInfo>> _Cards { get; } = new List<Id<CardInfo>>();
        public ReadOnlyCollection<Id<CardInfo>> Cards => this._Cards.AsReadOnly();
        public int Size => this._Cards.Count;

        public void AddCard(Id<CardInfo> card)
        {
            if (card == null)
            {
                // todo: must be a better way to achieve this
                throw new ArgumentNullException(nameof(card));
            }

            this._Cards.Add(card);
        }
    }
}