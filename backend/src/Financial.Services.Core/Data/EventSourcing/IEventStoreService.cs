using EventStore.ClientAPI;

namespace Financial.Services.Core.Data.EventSourcing
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConnection();
    }
}