namespace Financial.Services.Core.Notifications;

public class Notificator : INotificator
{
    private readonly List<Notification> _notifications;

    public Notificator()
    {
        _notifications = [];
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public void Handle(Notification notificacao)
    {
        _notifications.Add(notificacao);
    }

    public bool HasNotification()
    {
        return _notifications.Count is not 0;
    }
}
