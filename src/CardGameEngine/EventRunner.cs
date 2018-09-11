using System;
using System.Collections.Generic;
using CardServer.Networking;
using CardServer.Util;
using CardServer.CardGameEngine.Events;

namespace CardServer.CardGameEngine
{
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