using MediatR;
using Microsoft.AspNetCore.Mvc;
using QBSync.Application.QB.Features.QBItemCustomColumns.Queries;

namespace QBSync.API.Controllers;

// Was used for testing purposes.
[ApiController]
public class QbItemCustomColumnsController : Controller
{
    private readonly IMediator _mediator;

    public QbItemCustomColumnsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiEndpoints.QbItems.CustomColumns.GetAll)]
    public async Task<IActionResult> GetAllAsync()
    {
        var getAllCommand = new FetchTableCustomColumnsCommand(Application.QB.Common.Constants.Tables.Items);
        var result = await _mediator.Send(getAllCommand);
        return Ok(result);
    }
}