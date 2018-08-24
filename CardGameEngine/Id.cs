using System;

namespace CardServer.CardGameEngine
{
    /// A wrapper for any type that will always provide a unique ID for the wrapped object.
    /// Useful in a card game because you may have both an abstract concept of a card
    /// (i.e. card metadata like CardInfo class) but you want to use the same representation
    /// to denote a specific, unique "card" as it exists in a deck.
    /// Using this class, callers can specify that they require a unique version.
    public class Id<T>
    {
        public Guid Guid { get; private set; }

        public T Value { get; private set; }

        public Id(T value)
        {
            this.Value = value;
            this.Guid = Guid.NewGuid();
        }

        public Id(T value, Guid guid)
        {
            this.Value = value;
            this.Guid = guid;
        }
    }
}