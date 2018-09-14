namespace CardServer.Networking
{
    /// <summary>
    /// An interface that provides send/receive capabilities for <see cref="GameMessage"/>s.
    /// </summary>
    public interface IGameClient
    {
        /// <summary>
        /// Send a message to the server..
        /// </summary>
        /// <param name="message">The message to send.</param>
        void Send(GameMessage message);

        /// <summary>
        /// Attempt to retrieve the next message, immediately returning false if none is available
        /// </summary>
        /// <param name="message">The out-param message to be set if receiving succeeds.</param>
        /// <returns>True if there was a message to receive.</returns>
        bool TryReceive(out GameMessage message);

        /// <summary>
        /// Block until the next message is available, then return it
        /// </summary>
        /// <returns>The received <see cref="GameMessage"/>.</returns>
        GameMessage WaitReceive();
    }
}