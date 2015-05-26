using NServiceBus;

namespace MyServer
{
    public class MyCommand : ICommand
    {
        public int Key { get; set; }
    }
}