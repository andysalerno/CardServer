using CardServer.CardGameEngine;

namespace CardServer.Networking.Events
{
    public class PlayerActionPlayCardEvent : AEvent
    {
        public CardInfo CardPlayed { get; private set; }

        public override void Run(GameState gameState)
        {
            throw new System.NotImplementedException();
        }
    }
}