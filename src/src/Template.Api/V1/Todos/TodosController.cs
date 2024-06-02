using MediatR;

using Microsoft.AspNetCore.Mvc;

using Template.Application.TodoUsecases.Commands;
using Template.Application.TodoUsecases.Queries;

namespace Template.Api.V1.Todos;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class TodosController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Fetch(FetchTodosQuery query) {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id) {
        var result = await _mediator.Send(new GetTodoByIdQuery(id));
        return result != null ? Ok() : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoCommand command) {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new {id = 1}, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoCommand command) {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
        await _mediator.Send(new DeleteTodoCommand(id));
        return NoContent();
    }
}