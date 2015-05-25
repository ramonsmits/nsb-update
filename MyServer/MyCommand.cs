using NServiceBus;

namespace MyServer
{
    public class MyCommand : IMessage
    {
        public int Key { get; set; }
    }
}