using MediatR;

using Template.Domain.Todos;

namespace Template.Application.TodoUsecases.Commands;

public class CreateTodoCommand(string title, string description, DateTime? dueDate = null) : IRequest<Todo>
{
    public string Title { get; } = title;
    public string Description { get; } = description;
    public DateTime? DueDate { get; } = dueDate;

    public Todo ToEntity() => new(Title, Description, DueDate);
}