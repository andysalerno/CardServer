namespace CardServer.Networking
{
    public interface IGameServer
    {
        void Send(GameMessage message);
        GameMessage Receive();
    }
}