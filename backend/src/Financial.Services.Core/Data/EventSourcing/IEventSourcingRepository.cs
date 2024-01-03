using Financial.Services.Core.Communication.Mediator;

namespace Financial.Services.Core.Data.EventSourcing
{
    public interface IEventSourcingRepository
    {
        Task SaveEvent<TEvent>(TEvent events) where TEvent : Event;
        Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId);
    }
}