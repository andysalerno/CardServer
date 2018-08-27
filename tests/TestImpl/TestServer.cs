using CardServer.Networking;

namespace CardServer.Tests
{
    internal class TestServer : IGameServer
    {
        public GameMessage Receive()
        {
            return null;
        }

        public void Send(GameMessage message)
        {
        }
    }
}