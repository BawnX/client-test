using Application.Clients.GetByLinq;
using Application.Clients.GetByStore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("Client")]
public class Customers : ApiController
{
  private readonly ISender _mediator;

  public Customers(ISender mediator)
  {
    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
  }

  [HttpGet("linq")]
  public async Task<IActionResult> getByLinq([FromQuery] GetByLinqClientCommand command)
  {
    var result = await _mediator.Send(command);

    return result.Match(
        clients => Ok(clients),
        errors => Problem(errors)
    );
  }

  [HttpGet("store")]
  public async Task<IActionResult> getByStore([FromQuery] GetByStoreProdecureClientCommand command)
  {
    var result = await _mediator.Send(command);

    return result.Match(
        clients => Ok(clients),
        errors => Problem(errors)
    );
  }
}
