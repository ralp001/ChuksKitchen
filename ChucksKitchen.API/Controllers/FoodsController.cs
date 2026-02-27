using Microsoft.AspNetCore.Mvc;
using MediatR;
using ChuksKitchen.Application.Foods.Queries;

namespace ChuksKitchen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IMediator _mediator;
    public FoodsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetMenu()
    {
        var result = await _mediator.Send(new GetFoodItemsQuery());
        return Ok(result);
    }
}