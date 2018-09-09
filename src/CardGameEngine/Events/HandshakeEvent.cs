namespace CardServer.CardGameEngine.Events
{
    public class HandshakeEvent : AEvent
    {
        public override string Description => "Handshake event";

        public string HandshakeMessage { get; }

        public HandshakeEvent(string message)
        {
            this.HandshakeMessage = message ?? throw new System.ArgumentNullException(nameof(message));
        }

        public override void Run(GameState gameState)
        {
            // Nothing to do here
        }
    }
}