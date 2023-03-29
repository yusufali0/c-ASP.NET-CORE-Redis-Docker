using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
using StackExchange.Redis;
using System;
using YAB.App.Api.Redis;
using YAB.App.Domain.Entities;
using YAB.App.Service.Features.CQRS.Commands;
using YAB.App.Service.Features.CQRS.Queries;
using static ServiceStack.Diagnostics.Events;

namespace YAB.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDatabase _database;



        public CategoriesController(IMediator mediator, IDatabase database)
        {
            _mediator = mediator;
            _database = database;

            _database.StringSet("Category", "Elektronik");
        }


        [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _mediator.Send(new GetCategoriesQueryRequest());
                return Ok(result);
            }

            [HttpGet("{id}")]

            public async Task<IActionResult> GetById(int id)
            {
                var result = await _mediator.Send(new GetCategoryQueryRequest(id));
                return Ok(result);
            }

            [HttpPost]

            public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
            {
                var result = await _mediator.Send(request);
                return Created("", result);
            }


            [HttpPut]
            public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
            {

                await _mediator.Send(request);
                return NoContent();

            }


            [HttpDelete("{id}")]

            public async Task<IActionResult> Remove(int id)
            {
                await _mediator.Send(new RemoveCategoryCommandRequest(id));
                return Ok();
            }
        }
    }
