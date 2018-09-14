using CardServer.CardGameEngine.Events;
using CardServer.Networking;
using CardServer.Util;
using System;

namespace CardServer.CardGameEngine
{
    /// <summary>
    /// Acts as a service for executing <see cref="AEvent"/>s.
    /// 
    /// A <see cref="IGameServer"/> must be registered ahead of time.
    /// 
    /// Once registered, <see cref="EventRunner"/> will notify the server every time an event is run.
    /// </summary>
    public class EventRunner
    {
        // private Stack<AEvent> eventStack = new Stack<AEvent>();
        // private List<AEvent> eventLog ...
        private static IGameServer gameServer;

        public static IGameServer GameServer
        {
            get
            {
                if (EventRunner.gameServer == null)
                {
                    throw new Exception("Cannot access game server before it is registered");
                }
                return EventRunner.gameServer;
            }
            private set
            {
                EventRunner.gameServer = value;
            }
        }

        public static void RegisterGameServer(IGameServer gameServer)
        {
            Debug.Log($"Registered event runner server: {gameServer.GetType().Name}");
            EventRunner.gameServer = gameServer;
        }

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

            EventRunner.GameServer.Send(new GameMessage(_event));
            _event.Run(gameState);
        }
    }
}