using CardServer.CardGameEngine.Events;

namespace CardServer.CardGameEngine
{
    public interface IEventProvider
    {
        AEvent WaitForEvent();
    }
}