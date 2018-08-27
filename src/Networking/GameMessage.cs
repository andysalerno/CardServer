namespace CardServer.Networking
{
    public class GameMessage<T>
    {
        public int SequenceId { get; private set; }
        public T Content { get; }
    }
}