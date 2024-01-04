namespace Financial.Services.Core.Notifications;

public interface INotificator
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notificacao);
}
