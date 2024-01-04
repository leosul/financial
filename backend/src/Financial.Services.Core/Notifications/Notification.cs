namespace Financial.Services.Core.Notifications;

public class Notification(string mensagem)
{
    public string Mensagem { get; } = mensagem;
}
