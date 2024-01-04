using Financial.Services.Core.Notifications;
using FluentValidation;

namespace Financial.Services.Core.Communication.Mediator;

public abstract class ErrorHandler
{
    private readonly INotificator _notificator;
    protected ErrorHandler(INotificator notificator) => _notificator = notificator;

    protected void Notify(FluentValidation.Results.ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
            Notify(error.ErrorMessage);
    }

    protected void Notify(string message) => _notificator.Handle(new Notification(message));

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE>
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}
