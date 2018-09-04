using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class SummonedCard
    {
        /// the information on the card at the time it was summoned
        private Id<CardInfo> cardInfoWhenSummoned;

        /// the information on the card as it exists now (i.e., its health might be lowered via damage)
        private Id<CardInfo> currentCardInfo;
        private Id<CardMount> mount;

        public bool IsAlive => this.currentCardInfo.Value.Health > 0;

        public SummonedCard(Id<CardInfo> cardInfo, Id<CardMount> mount)
        {
            this.cardInfoWhenSummoned = cardInfo ?? throw new System.ArgumentNullException(nameof(cardInfo));
            this.mount = mount ?? throw new System.ArgumentNullException(nameof(mount));

            var clonedInfo = new CardInfo(cardInfo.Value);
            this.currentCardInfo = new Id<CardInfo>(clonedInfo);
        }
    }
}