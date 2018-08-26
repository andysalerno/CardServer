namespace CardServer.CardGameEngine
{
    /// An object on the board on which a card can be played.
    public class CardMount
    {
        public Id<SummonedCard> MountedCard { get; set; }
        public int Position { get; }
        public bool IsOccupied => this.MountedCard != null;

        public CardMount(Id<SummonedCard> mountedCard, int position)
        : this(position)
        {
            MountedCard = mountedCard ?? throw new System.ArgumentNullException(nameof(mountedCard));
        }

        public CardMount(int position)
        {
            this.Position = position;
        }
    }
}