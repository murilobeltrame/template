namespace Template.Application.TodoUsecases.Commands;

public class CreateTodoCommand(string title, string description, DateTime? dueDate)
{
    public string Title { get; } = title;
    public string Description { get; } = description;
    public DateTime? DueDate { get; } = dueDate;
}