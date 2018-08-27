using System.Runtime.Serialization;

namespace CardServer.Networking
{
    public interface IGameServer<T> where T : ISerializable
    {
        void Send(GameMessage<T> message);

        GameMessage<T> Receive();
    }
}