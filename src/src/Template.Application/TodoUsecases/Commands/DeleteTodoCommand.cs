using MediatR;

namespace Template.Application.TodoUsecases.Commands;

public class DeleteTodoCommand(int id): IRequest
{
    public int Id { get; } = id;
}