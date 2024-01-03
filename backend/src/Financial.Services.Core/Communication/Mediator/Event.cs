using Financial.Services.Core.Messages;
using MediatR;

namespace Financial.Services.Core.Communication.Mediator
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}