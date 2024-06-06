using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Template.Api.V1.Todos.Requests;
using Template.Application.TodoUsecases.Commands;
using Template.Application.TodoUsecases.Queries;
using Template.Domain.Todos;

namespace Template.Api.V1.Todos;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class TodosController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType<IEnumerable<Todo>>((int)HttpStatusCode.OK)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Fetch([FromQuery] FetchTodosQuery query) {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType<Todo>((int)HttpStatusCode.OK)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(int id) {
        return Ok(await _mediator.Send(new GetTodoByIdQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType<Todo>((int)HttpStatusCode.Created)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.Conflict)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.PreconditionRequired)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.PreconditionFailed)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create([FromBody] CreateTodoCommand command) {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new {id = 1}, result);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.Conflict)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.PreconditionRequired)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.PreconditionFailed)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoRequest request) {
        await _mediator.Send(request.ToCommandWithId(id));
        return NoContent();
    }

    /// <summary>
    /// Deletes a Todo item.
    /// </summary>
    /// <param name="id">The Todo identification</param>
    /// <returns>Nothing</returns>
    /// <response code="204">Returns nothing as success.</response>
    /// <response code="404">If Todo item couldn`t be found.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.Conflict)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.PreconditionRequired)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.PreconditionFailed)]
    [ProducesResponseType<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Delete(int id) {
        await _mediator.Send(new DeleteTodoCommand(id));
        return NoContent();
    }
}