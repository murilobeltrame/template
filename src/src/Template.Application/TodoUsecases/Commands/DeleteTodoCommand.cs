namespace Template.Application.TodoUsecases.Commands;

public class DeleteTodoCommand(int id)
{
    public int Id { get; } = id;
}