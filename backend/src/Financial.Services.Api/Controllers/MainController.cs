using Financial.Services.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Financial.Services.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificator _notificator;

    protected MainController(INotificator notificator)
    {
        _notificator = notificator;
    }

    protected bool ValidOperation()
    {
        return !_notificator.HasNotification();
    }

    protected ActionResult CustomResponse(object? result = null)
    {
        if (ValidOperation())
        {
            return Ok(new
            {
                success = true,
                data = result,
            });
        }

        return BadRequest(new
        {
            success = false,
            data = _notificator.GetNotifications().Select(n => n.Mensagem),
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotifyErrorInvalidModel(modelState);
        return CustomResponse();
    }

    protected void NotifyErrorInvalidModel(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotifyError(errorMsg);
        }
    }
    protected void NotifyError(string mensagem)
    {
        _notificator.Handle(new Notification(mensagem));
    }
}
