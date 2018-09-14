namespace CardServer.Networking
{
    /// <summary>
    /// A <see cref="IGameServer"/> implementor using TCP networking under the hood.
    /// </summary>
    public class NetworkGameServer : IGameServer
    {
        private NetworkServer server;

        public NetworkGameServer()
        {
            this.server = new NetworkServer();
            this.server.AcceptClient();
        }

        public GameMessage Receive()
        {
            string json = this.server.ReceiveFromClient();
            GameMessage gameMessage = Util.Json.Deserialize<GameMessage>(json);

            return gameMessage;
        }

        public void Send(GameMessage message)
        {
            string json = Util.Json.Serialize(message);

            this.server.SendToClient(json);
        }
    }
}