namespace CardServer.CardGameEngine.Events
{
    public class HandshakeEvent : AEvent
    {
        public override string Description => "Handshake event";

        public string HandshakeMessage { get; set; }

        public HandshakeEvent(string message)
        {
            this.HandshakeMessage = message ?? throw new System.ArgumentNullException(nameof(message));
        }

        public HandshakeEvent()
        {
            // empty constructor needed for deserialization
        }

        public override void Run(GameState gameState)
        {
            // Nothing to do here
        }
    }
}