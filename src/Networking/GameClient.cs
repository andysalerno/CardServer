namespace CardServer.Networking
{
    public class GameClient : IGameClient
    {
        private Client client;

        public GameClient()
        {
            this.client = new Client();
        }

        public GameMessage Receive()
        {
            string json = this.client.ReceiveFromServer();
            GameMessage gameMessage = Util.Json.Deserialize<GameMessage>(json);

            return gameMessage;
        }

        public void Send(GameMessage message)
        {
            string json = Util.Json.Serialize(message);
            this.client.SendToServer(json);
        }
    }
}