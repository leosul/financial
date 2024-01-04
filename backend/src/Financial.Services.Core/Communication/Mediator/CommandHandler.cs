using Financial.Services.Core.Data;
using Financial.Services.Core.Notifications;
using FluentValidation.Results;

namespace Financial.Services.Core.Communication.Mediator;

public abstract class CommandHandler : ErrorHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler(INotificator notificator) : base(notificator)
    {
        ValidationResult = new ValidationResult();
    }

    protected async Task<ValidationResult> PersistDataAsync(IUnitOfWork unitOfWork)
    {
        if (await unitOfWork.Commit() is false) Notify("Error persisting data");

        return ValidationResult;
    }
}
