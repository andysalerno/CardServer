using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class EventRunner
    {
        // private Stack<AEvent> eventStack = new Stack<AEvent>();

        public static void RunEvent(AEvent _event, GameState gameState)
        {
            _event.Run(gameState);
        }
    }
}