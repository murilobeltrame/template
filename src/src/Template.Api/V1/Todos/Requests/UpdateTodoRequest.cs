using Template.Application.TodoUsecases.Commands;

namespace Template.Api.V1.Todos.Requests;

public class UpdateTodoRequest(string title, string description, DateTime? dueDate)
{
    public string Title { get; } = title;
    public string Description { get; } = description;
    public DateTime? DueDate { get; } = dueDate;

    internal UpdateTodoCommand ToCommandWithId(int id) => new(id, Title, Description, DueDate);
}