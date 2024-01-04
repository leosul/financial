using Financial.Services.Core.Notifications;

namespace Financial.Services.Core.Communication.Mediator;

public abstract class QueryHandler : ErrorHandler
{
    protected QueryHandler(INotificator notificator) : base(notificator)
    {
    }
}
