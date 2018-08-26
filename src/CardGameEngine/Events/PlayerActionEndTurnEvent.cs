namespace CardServer.CardGameEngine
{
    public class PlayerActionEndTurnEvent : AEvent
    {
        public override void Run(GameState gameState)
        {
            gameState.CurrentPlayerTurn = OtherPlayer(gameState.CurrentPlayerTurn);
        }

        private static Player OtherPlayer(Player player)
        {
            return (player == Player.Player1) ? Player.Player2 : Player.Player1;
        }
    }
}