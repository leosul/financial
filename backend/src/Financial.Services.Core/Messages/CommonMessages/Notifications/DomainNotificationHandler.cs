using MediatR;

namespace Financial.Services.Core.Messages.CommonMessages.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = [];
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotification()
        {
            return _notifications;
        }

        public virtual bool TemNotificacao()
        {
            return GetNotification().Count != 0;
        }

        public void Dispose()
        {
            _notifications = [];
        }
    }
}