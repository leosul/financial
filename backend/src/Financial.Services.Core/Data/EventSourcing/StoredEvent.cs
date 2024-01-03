namespace Financial.Services.Core.Data.EventSourcing
{
    public class StoredEvent(Guid id, string type, DateTime createdAt, string data)
    {
        public Guid Id { get; private set; } = id;

        public string Type { get; private set; } = type;

        public DateTime CreatedAt { get; set; } = createdAt;

        public string Data { get; private set; } = data;
    }
}