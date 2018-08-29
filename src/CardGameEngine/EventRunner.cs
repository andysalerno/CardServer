using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class EventRunner
    {
        // private Stack<AEvent> eventStack = new Stack<AEvent>();
        // private List<AEvent> eventLog ...

        public static void RunEvent(AEvent _event, GameState gameState)
        {
            _event.Run(gameState);
        }
    }
}