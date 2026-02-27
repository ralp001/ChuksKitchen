using Microsoft.AspNetCore.Mvc;
using MediatR;
using ChuksKitchen.Application.Orders.Commands;
using ChuksKitchen.Application.Orders.Queries;

namespace ChuksKitchen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(PlaceOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}/status")]
    public async Task<IActionResult> GetStatus(Guid id)
    {
        var result = await _mediator.Send(new GetOrderStatusQuery(id));
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}