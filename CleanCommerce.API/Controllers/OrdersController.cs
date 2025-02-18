using CleanCommerce.Application.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : Controller
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _mediator.Send(command);
        return orderId;
    }
}