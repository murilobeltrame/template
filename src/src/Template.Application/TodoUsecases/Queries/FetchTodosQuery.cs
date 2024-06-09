using MediatR;

using Template.Domain.Todos;
using Template.Domain.Todos.Specifications;

namespace Template.Application.TodoUsecases.Queries;

public class FetchTodosQuery(uint page, ushort size) : IRequest<IEnumerable<Todo>>
{
    public ushort Size { get; set; } = size;
    public uint Page { get; set; } = page;

    public FetchTodosSpecification ToSpecification() => new(Page, Size);
}