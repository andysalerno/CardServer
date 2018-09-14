namespace CardServer.Networking
{
    /// <summary>
    /// An interface that provides send/receive capability of <see cref="GameMessage"/>s.
    /// </summary>
    public interface IGameServer
    {
        void Send(GameMessage message);
        GameMessage Receive();
    }
}