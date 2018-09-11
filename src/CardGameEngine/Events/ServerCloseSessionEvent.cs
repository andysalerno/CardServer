namespace CardServer.CardGameEngine.Events
{
    public class ServerCloseSessionEvent : AEvent
    {
        public override string Description => "The server has closed the session.";

        public override void Run(GameState gameState)
        {
        }
    }
}