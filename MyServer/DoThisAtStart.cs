using System;
using NServiceBus;

namespace MyServer
{
    public class DoThisAtStart : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }
        public void Run()
        {
            Console.Title = "V2";
            Console.WriteLine("Run");
            var cmd = new MyCommand { Key = 1 };
            Bus.SendLocal(cmd, cmd, cmd, cmd);
            Console.WriteLine("Run is done");
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }
}