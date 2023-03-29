using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YAB.App.Service.Features.CQRS.Commands;
using YAB.App.Service.Features.CQRS.Queries;

namespace YAB.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetProductsQueryRequest());
            return Ok(result);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }


        [HttpPut]

        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveProductCommandRequest(id));
            return Ok();
        }
    }
}
