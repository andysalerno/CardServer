using CardServer.CardGameEngine;

namespace CardServer.Networking.Events
{
    public class PlayerActionForfeitGame : AEvent
    {
        public override string Description => "Player forfeits the game.";
        private Player Player { get; }

        public PlayerActionForfeitGame(Player player)
        {
            this.Player = player;
        }

        public override void Run(GameState gameState)
        {
            if (this.Player == Player.Player1)
            {
                gameState.ForfeitPlayer1 = true;
            }
            else if (this.Player == Player.Player2)
            {
                gameState.ForfeitPlayer2 = true;
            }
        }
    }
}