using CardServer.Networking;

namespace CardServer.CardGameEngine
{
    public interface IUIChannelProvider
    {
        void SendToUI(GameMessage gameMessage);
    }
}