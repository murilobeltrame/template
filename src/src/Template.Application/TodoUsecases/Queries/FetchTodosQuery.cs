using MediatR;

using Template.Domain.Todos;
using Template.Domain.Todos.Specifications;

namespace Template.Application.TodoUsecases.Queries;

public class FetchTodosQuery : IRequest<IEnumerable<Todo>>
{
    internal FetchTodosSpecification ToSpecification() => new();
}