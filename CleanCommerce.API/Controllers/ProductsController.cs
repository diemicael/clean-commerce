using CleanCommerce.Application.Products.Commands;
using CleanCommerce.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var query = new GetProductByIdQuery { Id = id };
        var product = await _mediator.Send(query);
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProduct), new { id = productId }, productId);
    }
}