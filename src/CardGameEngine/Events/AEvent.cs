using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;

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