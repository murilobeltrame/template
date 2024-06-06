using MediatR;

using Template.Domain.Todos;
using Template.Domain.Todos.Specifications;

namespace Template.Application.TodoUsecases.Queries;

public class GetTodoByIdQuery(int id): IRequest<Todo>
{
    public int Id { get; } = id;

    internal GetTodoByIdSpecification ToSpecification() => new(Id);
}