using System;
using System.Runtime.Serialization;
using CardServer.CardGameEngine;

namespace CardServer.Networking.Events
{
    [Serializable()]
    public class PlayerDrawCardEvent : AEvent
    {
        public Player Player { get; private set; }

        public PlayerDrawCardEvent(Player player)
        {
            this.Player = player;
        }

        public PlayerDrawCardEvent()
        {
            // for deserialization
        }

        public override void Run(GameState gameState)
        {
            Deck deck = gameState.GetDeck(this.Player);
            Id<CardInfo> card = deck.DrawFromTop();

            Hand hand = gameState.GetHand(this.Player);
            hand.AddCard(card);
        }
    }
}