using CardServer.CardGameEngine;
using Moq;

namespace CardServer.Tests.TestExtensions
{
    public static class CardExtensions
    {
        public static Id<CardInfo> SimpleCard => new Id<CardInfo>(new CardInfo());
    }
}