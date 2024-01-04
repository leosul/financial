using Financial.Services.Api.Controllers;
using Financial.Services.Core.Communication.Mediator;
using Financial.Services.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Services.Api.V1.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/categories")]
public class CategoryController(IMediatorHandler _mediatrHandler, INotificator _notificator) : MainController(_notificator)
{
    //private readonly IMediatorHandler _mediatrHandler = mediatrHandler;

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok();
    }
}
