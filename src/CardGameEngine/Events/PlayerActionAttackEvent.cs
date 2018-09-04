namespace CardServer.CardGameEngine.Events
{
    public class PlayerActionAttackEvent : AEvent
    {
        private Id<SummonedCard> Attacker { get; set; }
        private Id<SummonedCard> Target { get; set; }
        public override string Description => $"{Attacker} attacks target {Target}";

        public override void Run(GameState gameState)
        {
            if (gameState == null)
            {
                throw new System.ArgumentNullException(nameof(gameState));
            }

            var dealDamageEvent = new CardAttackDealDamageEvent(this.Target, this.Attacker);
            EventRunner.RunEvent(dealDamageEvent, gameState);

            // the deal damage event may have triggered other actions that killed the target.
            if (this.Target.Value.IsAlive)
            {
                var takeDamageEvent = new CardAttackTakeDamageEvent(this.Target, this.Attacker);
                EventRunner.RunEvent(takeDamageEvent, gameState);
            }
        }
    }
}