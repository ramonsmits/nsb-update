using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Saga;

namespace MyServer
{
    public class MyEndpoint :
        AsA_Server,
        IConfigureThisEndpoint//,
       // ISpecifyMessageHandlerOrdering
        ,IWantCustomInitialization
    {
        public MyEndpoint()
        {
            //AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled: {0}", ((Exception)e.ExceptionObject).Message);
        }

        void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine("FirstChance: {0}",e.Exception.Message);
        }

        public void SpecifyOrder(Order order)
        {
        }

        public void Init()
        {
            Console.WriteLine("Init endpoint");
            Configure.Instance
                //.With()
                .DefineEndpointName("MyEndpoint")
                //.DefaultBuilder()
                ;
        }
    }
}
