using System;
using CardServer.Networking;
using CardServer.Networking.Events;

namespace CardServer.CardGameEngine
{
    public class EventProvider : IEventProvider
    {
        private IGameServer Server { get; }

        public EventProvider(IGameServer server)
        {
            Server = server ?? throw new System.ArgumentNullException(nameof(server));
        }

        public AEvent WaitForEvent()
        {
            GameMessage gameMessage = this.Server.Receive();
            AEvent gameEvent = EventFromMessage(gameMessage);
            return gameEvent;
        }

        private static AEvent EventFromMessage(GameMessage gameMessage)
        {
            if (gameMessage.ContentType == typeof(PlayerDrawCardEvent))
            {
                return Util.Json.Deserialize<PlayerDrawCardEvent>(gameMessage.SerializedJson);
            }
            else if (gameMessage.ContentType == typeof(CardTakeDamageEvent))
            {
                return Util.Json.Deserialize<CardTakeDamageEvent>(gameMessage.SerializedJson);
            }
            else if (gameMessage.ContentType == typeof(PlayerActionAttackEvent))
            {
                return Util.Json.Deserialize<PlayerActionAttackEvent>(gameMessage.SerializedJson);
            }
            else if (gameMessage.ContentType == typeof(PlayerActionEndTurnEvent))
            {
                return Util.Json.Deserialize<PlayerActionEndTurnEvent>(gameMessage.SerializedJson);
            }
            else if (gameMessage.ContentType == typeof(PlayerActionPlayCardEvent))
            {
                return Util.Json.Deserialize<PlayerActionPlayCardEvent>(gameMessage.SerializedJson);
            }

            throw new Exception("Could not transform the game message into an event.");
        }
    }
}