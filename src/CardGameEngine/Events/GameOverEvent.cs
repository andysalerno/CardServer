
using CardServer.CardGameEngine;

namespace CardServer.CardGameEngine.Events
{
    public class GameOverEvent : AEvent
    {
        public override string Description => "Game over.";

        public override void Run(GameState gameState)
        {
            // nothing to do
        }
    }
}