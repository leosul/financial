using EventStore.ClientAPI;
using Financial.Services.Core.Communication.Mediator;
using System.Text;
using System.Text.Json;

namespace Financial.Services.Core.Data.EventSourcing
{
    public class EventSourcingRepository(IEventStoreService eventStoreService) : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService = eventStoreService;

        public async Task SaveEvent<TEvent>(TEvent events) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                events.AggregateId.ToString(),
                ExpectedVersion.Any,
                FormatEvent(events));
        }

        public async Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId)
        {
            var events = await _eventStoreService.GetConnection()
                .ReadStreamEventsForwardAsync(aggregateId.ToString(), 0, 500, false);

            var listEvents = new List<StoredEvent>();

            foreach (var resolvedEvent in events.Events)
            {
                var dataEncoded = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var jsonData = JsonSerializer.Deserialize<BaseEvent>(dataEncoded);

                var eventData = new StoredEvent(
                    resolvedEvent.Event.EventId,
                    resolvedEvent.Event.EventType,
                    jsonData.Timestamp,
                    dataEncoded);

                listEvents.Add(eventData);
            }

            return listEvents.OrderBy(e => e.CreatedAt);
        }

        private static IEnumerable<EventData> FormatEvent<TEvent>(TEvent events) where TEvent : Event
        {
            yield return new EventData(
                Guid.NewGuid(),
                events.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(events)),
                null);
        }
    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}