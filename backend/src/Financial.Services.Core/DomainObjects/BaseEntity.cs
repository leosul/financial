using Financial.Services.Core.Communication.Mediator;

namespace Financial.Services.Core.DomainObjects
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        private List<Event> _notifications;
        public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public void AddEvent(Event events)
        {
            _notifications ??= [];
            _notifications.Add(events);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _notifications?.Clear();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 822 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}