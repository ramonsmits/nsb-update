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
        // ISpecifyMessageHandlerOrdering,
        //, IWantCustomInitialization
    {
        public MyEndpoint()
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
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

        //public void Init()
        //{
        //    //var e = NServiceBus.ObjectBuilder.ComponentCallModelEnum.Singleton;


        //    Configure.Instance.Configurer.ConfigureComponent<object>(NServiceBus.ObjectBuilder.ComponentCallModelEnum.Singleton);

        //    var bus = NServiceBus.Configure
        //        .With()
        //        .DefaultBuilder()
        //        .CreateBus()
        //        .Start();



        //    //NServiceBus.ObjectBuilder.Spring.
        //    //NServiceBus.ObjectBuilder.IConfigureComponents.ConfigureComponent<T>(NServiceBus.ObjectBuilder.ComponentCallModelEnum)' is obsolete”?
        //}



        public void Init()
        {
            //Configure.With()
            //    .DefaultBuilder()
            //    .Sagas()
            //        .NHibernateSagaPersister()
            //        .DBSubcriptionStorage()
            //    .XmlSerializer();

            //Configure.With()
            //    .DefaultBuilder()
            //    .Sagas()
            //        .NHibernateSagaPersister()
            //    .XmlSerializer()
            //    .MsmqTransport()
            //      .IsTransactional(true)
            //      .PurgeOnStartup(false)
            //    .UnicastBus()
            //    .CreateBus()
            //    .Start();
        }
    }

    public class ConfigureEndpoint : IWantCustomInitialization
    {

        public void Init()
        {
            //Configure.Instance
            //    .NHibernateSagaPersister()
                //.DBSubcriptionStorage()
                ;
        }
    }
}
