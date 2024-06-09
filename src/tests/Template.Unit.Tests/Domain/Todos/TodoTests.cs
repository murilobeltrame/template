using FluentAssertions;

using Template.Domain.Todos;

namespace Template.Unit.Tests.Domain.Todos;

public class TodoTests
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        var title = "Some title";
        var description = "A little longer description than the title";

        var instance = new Todo(title, description);

        instance.Title.Should().Be(title);
        instance.Description.Should().Be(description);
        instance.DueDate.Should().BeNull();
        instance.FinishedAt.Should().BeNull();
    }
}
