using FluentValidation.Results;
using MediatR;

namespace Financial.Services.Core.Communication.Mediator;

public class MediatorHandler(IMediator mediator) : IMediatorHandler
{
    private readonly IMediator _mediator = mediator;

    public async Task PublishEvent<T>(T TEvent) where T : Event
    {
        await _mediator.Publish(TEvent);
    }

    public async Task<ValidationResult> SendCommand<T>(T TCommand) where T : Command
    {
        return await _mediator.Send(TCommand);
    }
}
