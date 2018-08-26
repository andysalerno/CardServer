using System.Collections.Generic;

namespace CardServer.CardGameEngine
{
    public class BoardSide
    {
        private List<Id<CardMount>> mounts;

        /// Create a board with boardSize mounts on each side.
        public BoardSide(int boardSize)
        {
            this.mounts = new List<Id<CardMount>>(boardSize);

            for (int i = 0; i < boardSize; i++)
            {
                var mount = new CardMount(i);
                this.mounts.Add(new Id<CardMount>(mount));
            }
        }
    }
}