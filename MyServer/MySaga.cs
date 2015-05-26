using System;
using System.Globalization;
using NServiceBus.Saga;

namespace MyServer
{
    public class MySaga : Saga<MyData>,
        IAmStartedByMessages<MyCommand>
        //,IHandleSagaNotFound
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<MyCommand>(saga => saga.MessageKey, msg => msg.Key);
        }

        public void Handle(MyCommand msg)
        {
            Console.WriteLine("Processing command in saga: {0}", Data.Id);
            Data.MessageKey = msg.Key;

            var notificationTimestamp = DateTime.UtcNow.AddSeconds(15);
            Data.RecordVersion++;

            Console.WriteLine("Timeout at: {0}", notificationTimestamp);
            RequestUtcTimeout(notificationTimestamp, Data.RecordVersion.ToString(CultureInfo.InvariantCulture));
        }

        [Obsolete]
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
    
public void Handle(object message)
{
 	throw new NotImplementedException();
}
}
}
