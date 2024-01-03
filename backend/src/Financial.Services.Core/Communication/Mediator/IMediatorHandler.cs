using Financial.Services.Core.Messages.CommonMessages.DomainEvents;
using Financial.Services.Core.Messages.CommonMessages.Notifications;

namespace Financial.Services.Core.Communication.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T events) where T : Event;
    Task<bool> SendCommand<T>(T command) where T : Command;
    Task PublishNotification<T>(T notification) where T : DomainNotification;
    Task PublishDomainEvent<T>(T notification) where T : DomainEvent;
}
