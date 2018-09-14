namespace CardServer.Networking
{
    /// <summary>
    /// A <see cref="IGameClient"/> implementation using TCP networking under the hood.
    /// </summary>
    public class NetworkGameClient : IGameClient
    {
        private NetworkClient client;

        public NetworkGameClient()
        {
            this.client = new NetworkClient();
        }

        private GameMessage Receive()
        {
            string json = this.client.ReceiveFromServer();

            if (json == null)
            {
                return null;
            }

            GameMessage gameMessage = Util.Json.Deserialize<GameMessage>(json);

            return gameMessage;
        }

        public bool TryReceive(out GameMessage received)
        {
            GameMessage result = this.Receive();

            if (result == null)
            {
                received = null;
                return false;
            }

            received = result;
            return true;
        }

        public GameMessage WaitReceive()
        {
            string json = this.client.WaitUntilReceiveFromServer();

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