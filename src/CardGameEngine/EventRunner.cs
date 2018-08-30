using System.Collections.Generic;
using CardServer.Util;

namespace CardServer.CardGameEngine
{
    public class EventRunner
    {
        // private Stack<AEvent> eventStack = new Stack<AEvent>();
        // private List<AEvent> eventLog ...

        public static void RunEvent(AEvent _event, GameState gameState)
        {
            if (_event == null)
            {
                throw new System.ArgumentNullException(nameof(_event));
            }

            if (gameState == null)
            {
                throw new System.ArgumentNullException(nameof(gameState));
            }

            Debug.Log($"Event executing: {_event.GetType().Name}");
            Debug.Log($"\t{_event.Description}");
            _event.Run(gameState);
        }
    }
}