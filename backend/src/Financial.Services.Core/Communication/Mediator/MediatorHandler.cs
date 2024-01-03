using Financial.Services.Core.Data.EventSourcing;
using Financial.Services.Core.Messages.CommonMessages.DomainEvents;
using Financial.Services.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace Financial.Services.Core.Communication.Mediator
{
    public class MediatorHandler(IMediator mediator,
                                 IEventSourcingRepository eventSourcingRepository) : IMediatorHandler
    {
        private readonly IMediator _mediator = mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository = eventSourcingRepository;

        public async Task<bool> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
            await _eventSourcingRepository.SaveEvent(evento);

        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task PublishDomainEvent<T>(T notification) where T : DomainEvent
        {
            await _mediator.Publish(notification);
        }
    }
}