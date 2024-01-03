﻿using Financial.Services.Core.Messages;
using FluentValidation.Results;
using MediatR;

namespace Financial.Services.Core.Communication.Mediator
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}