using System.Collections.Generic;
using CardServer.CardGameEngine.Events;
using CardServer.CardGameEngine;
using CardServer.Networking;

namespace CardServer.Tests
{
    internal class TestEventProvider : IEventProvider
    {
        public IEnumerable<AEvent> EventQueue { get; }
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
            this.EventQueue = eventQueue ?? throw new System.ArgumentNullException(nameof(eventQueue));
            this.enumerator = this.EventQueue.GetEnumerator();
        }

        public TestEventProvider() { }
    }
}