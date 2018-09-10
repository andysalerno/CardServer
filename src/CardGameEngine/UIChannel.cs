namespace CardServer.CardGameEngine
{
    public class UIChannel
    {
        private static IUIChannelProvider provider;
        public static IUIChannelProvider Provider
        {
            get
            {
                if (provider == null)
                {
                    throw new System.Exception("Provider cannot be accessed before it is registered.");
                }

                return provider;
            }
            private set
            {
                provider = value;
            }
        }

        public static void RegisterIUIChannelProvider(IUIChannelProvider provider)
        {
            UIChannel.Provider = provider;
        }
    }
}