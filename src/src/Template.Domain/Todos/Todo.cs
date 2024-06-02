namespace Template.Domain.Todos;

public class Todo
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime? DueDate { get; private set; }
    public DateTime? FinishedAt { get; private set; }

    public Todo(string title, string description, DateTime? dueDate)
    {
        Title = title; 
        Description = description; 
        DueDate = dueDate;
    }

    private Todo() {}
}