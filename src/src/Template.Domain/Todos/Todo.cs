using Ardalis.GuardClauses;

namespace Template.Domain.Todos;

public class Todo
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime? DueDate { get; private set; }
    public DateTime? FinishedAt { get; private set; }

    public Todo(string title, string description, DateTime? dueDate = null)
    {
        Title = Guard.Against.NullOrWhiteSpace(title); 
        Description = Guard.Against.NullOrWhiteSpace(description); 
        DueDate = dueDate;
    }

#pragma warning disable CS8618 // Required by EF.
    private Todo() { }
#pragma warning restore CS8618 // Required by EF.
}