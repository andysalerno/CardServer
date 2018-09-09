using System.Runtime.Serialization;

namespace CardServer.Networking
{
    public interface IGameClient
    {
        /// Send a message to the server..
        void Send(GameMessage message);

        /// Receive the next message from the server.
        GameMessage Receive();
    }
}