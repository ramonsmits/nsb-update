using System;
using System.Globalization;
using NServiceBus.Saga;

namespace MyServer
{
    public class MySaga : Saga<MyData>,
        IAmStartedByMessages<MyCommand>
    //,IHandleTimeouts<ResponseMarkingTimeout>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<MyCommand>(saga => saga.MessageKey, msg => msg.Key);
        }

        public void Handle(MyCommand msg)
        {
            Console.WriteLine("Processing command in saga");
            Data.MessageKey = msg.Key;

            var notificationTimestamp = DateTime.UtcNow.AddSeconds(15);
            Data.RecordVersion++;

            //RequestUtcTimeout<ResponseMarkingTimeout>(notificationTimestamp, m =>
            //{
            //    m.RecordVersion = Data.RecordVersion;
            //});

            //RequestTimeout<ResponseMarkingTimeout>(notificationTimestamp, m =>
            //{
            //    m.RecordVersion = Data.RecordVersion;
            //});

            Console.WriteLine("Timeout at: {0}", notificationTimestamp);
            RequestUtcTimeout(notificationTimestamp, Data.RecordVersion.ToString());

        }

        //[Obsolete]
        public override void Timeout(object state)
        {
            Console.WriteLine("Timeout: {0}", state.GetType());
            // if timeout occured on the correct record version
            if (state != null && state.ToString() == Data.RecordVersion.ToString(CultureInfo.InvariantCulture))
            {
                //Timeout is still appropriate for current saga instance version.
            }

            //if (state != null)
            //{
            //    Timeout(new ResponseMarkingTimeout
            //    {
            //        RecordVersion = int.Parse(state.ToString(), CultureInfo.InvariantCulture)
            //    });
            //}
        }

        //public void Timeout(ResponseMarkingTimeout state)
        //{
        //    var isTimeoutRelatedToCurrentState = state.RecordVersion == Data.RecordVersion;

        //    if (isTimeoutRelatedToCurrentState)
        //    {
        //        //doing something here
        //    }
        //}
    }
}