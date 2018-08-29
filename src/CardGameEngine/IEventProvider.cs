namespace CardServer.CardGameEngine
{
    public interface IEventProvider
    {
        AEvent WaitForEvent();
    }
}