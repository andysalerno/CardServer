using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class SummonedCard
    {
        private CardInfo cardInfo;
        private int mountId;

        public SummonedCard(CardInfo cardInfo, int mountId)
        {
            this.cardInfo = cardInfo;
            this.mountId = mountId;
        }
    }
}