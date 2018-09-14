using System;
using System.Runtime.Serialization;

namespace CardServer.CardGameEngine.Events
{
    [Serializable()]
    public abstract class AEvent
    {
        public int SequenceNum { get; private set; }

        public abstract void Run(GameState gameState);

        public abstract string Description { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var allProperties = this.GetType().GetProperties();

            foreach (var property in allProperties)
            {
                info.AddValue(property.Name, property.GetValue(this));
            }
        }
    }
}