namespace CardServer.CardGameEngine.Events
{
    public class GameStartCardDrawEvent : AEvent
    {
        public override string Description => "The game has begun.";

        public int DrawCount { get; }

        public override void Run(GameState gameState)
        {
            for (int i = 0; i < this.DrawCount; i++)
            {
                var drawEventPlayer1 = new PlayerDrawCardEvent(Player.Player1);
                var drawEventPlayer2 = new PlayerDrawCardEvent(Player.Player2);

                EventRunner.RunEvent(drawEventPlayer1, gameState);
                EventRunner.RunEvent(drawEventPlayer2, gameState);
            }
        }

        public GameStartCardDrawEvent(int drawCount)
        {
            this.DrawCount = drawCount;
        }
    }
}