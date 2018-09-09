namespace CardServer.Networking
{
    public class GameServer : IGameServer
    {
        private Server server;

        public GameServer()
        {
            this.server = new Server();
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