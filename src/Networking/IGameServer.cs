using System.Runtime.Serialization;

namespace CardServer.Networking
{
    public interface IGameServer
    {
        /// Send a message to a client.
        void Send(GameMessage message);

        /// Receive the next queued message from a client.
        GameMessage Receive();
    }
}