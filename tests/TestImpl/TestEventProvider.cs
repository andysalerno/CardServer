using System.Collections.Generic;
using CardServer.CardGameEngine;
using CardServer.Networking;

namespace CardServer.Tests
{
    internal class TestEventProvider : IEventProvider
    {
        private IEnumerable<AEvent> eventQueue;
        private IEnumerator<AEvent> enumerator;

        public AEvent WaitForEvent()
        {
            if (this.enumerator.MoveNext())
            {
                return this.enumerator.Current;
            }

            return null;
        }

        public TestEventProvider(IEnumerable<AEvent> eventQueue)
        {
            this.eventQueue = eventQueue ?? throw new System.ArgumentNullException(nameof(eventQueue));
            this.enumerator = eventQueue.GetEnumerator();
        }

        public TestEventProvider() { }
    }
}