using CardServer.CardGameEngine;
using CardServer.Networking;

namespace CardServer.Tests
{
    internal class TestUIChannelProvider : IUIChannelProvider
    {
        public void SendToUI(GameMessage gameMessage)
        {
            // do nothing
        }
    }
}