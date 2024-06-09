using FluentAssertions;

using Template.Application.TodoUsecases.Commands;

namespace Template.Unit.Tests.Application.TodoUsecases.Commands;

public class CreateTodoCommandTests
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        var title = "title";
        var description = "description";
        
        var command = new CreateTodoCommand(title, description);

        command.Title.Should().Be(title);
        command.Description.Should().Be(description);
        command.DueDate.Should().BeNull();
    }
}