using NServiceBus;
using NServiceBus.Hosting.Profiles;

namespace MyServer
{
    class NHibernatePersistenceBehavior : IHandleProfile<NHibernatePersistence>
    {
        public void ProfileActivated()
        {
            Configure.Instance
                .NHibernateSagaPersister()
                .UseNHibernateTimeoutPersister()
                .DBSubcriptionStorage()
                ;
        }
    }
}