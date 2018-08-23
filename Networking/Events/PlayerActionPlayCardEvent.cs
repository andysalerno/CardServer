using CardServer.CardGameEngine;

namespace CardServer.Networking.Events
{
    public class PlayerActionPlayCardEvent : AEvent
    {
        public CardInfo CardPlayed { get; private set; }
    }
}