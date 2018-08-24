namespace CardServer.CardGameEngine
{
    public abstract class AEvent
    {
        public int SequenceNum { get; private set; }
        public abstract void Run(GameState gameState);
    }
}