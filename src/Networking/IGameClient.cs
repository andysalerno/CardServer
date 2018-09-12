using System.Runtime.Serialization;

namespace CardServer.Networking
{
    public interface IGameClient
    {
        /// Send a message to the server..
        void Send(GameMessage message);

        /// Attempt to retrieve the next message, immediately returning false if none is available
        bool TryReceive(out GameMessage message);

        /// Block until the next message is available, then return it
        GameMessage WaitReceive();
    }
}