namespace CardServer.CardGameEngine
{
    public class PlayerActionAttackEvent : AEvent
    {
        private Id<SummonedCard> Attacker { get; set; }
        private Id<SummonedCard> Target { get; set; }
        public override string Description => $"{Attacker} attacks target {Target}";

        public override void Run(GameState gameState)
        {

        }
    }
}