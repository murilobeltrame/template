using FluentAssertions;

using Template.Application.TodoUsecases.Commands;

namespace Template.Unit.Tests.Application.TodoUsecases.Commands;

public class UpdateTodoCommandTests
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        var id = 1;
        var title = "title";
        var description = "description";
        
        var command = new UpdateTodoCommand(id, title, description);

        command.Id.Should().Be(id);
        command.Title.Should().Be(title);
        command.Description.Should().Be(description);
        command.DueDate.Should().BeNull();
    }

    [Fact]
    public void When_ToEntity_Should_Return_Todo()
    {
        var title = "title";
        var description = "description";

        var command = new CreateTodoCommand(title, description);

        var entity = command.ToEntity();

        entity.Title.Should().Be(title);
        entity.Description.Should().Be(description);
        entity.DueDate.Should().BeNull();
    }
}