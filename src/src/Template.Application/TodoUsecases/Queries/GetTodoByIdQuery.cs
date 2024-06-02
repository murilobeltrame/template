namespace Template.Application.TodoUsecases.Queries;

public class GetTodoByIdQuery(int id)
{
    public int Id { get; } = id;
}