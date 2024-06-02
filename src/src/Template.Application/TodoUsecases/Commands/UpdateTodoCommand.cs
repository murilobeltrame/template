namespace Template.Application.TodoUsecases.Commands;

public class UpdateTodoCommand(int id, string title, string description, DateTime? dueDate)
{
    public int Id { get; } = id;
    public string Title { get; } = title;
    public string Description { get; } = description;
    public DateTime? DueDate { get; } = dueDate;
}