using FluentValidation.Results;

namespace Financial.Services.Core.Communication.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T TEvent) where T : Event;
    Task<ValidationResult> SendCommand<T>(T TCommand) where T : Command;
}
