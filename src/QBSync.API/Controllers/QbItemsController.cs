using MediatR;
using Microsoft.AspNetCore.Mvc;
using QBSync.Application.QB.Features.QBItems.Queries;

namespace QBSync.API.Controllers;

[ApiController]
public class QbItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QbItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet(ApiEndpoints.QbItems.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new FetchQbItemsCommand());
        
        return Ok(result);
    }
}