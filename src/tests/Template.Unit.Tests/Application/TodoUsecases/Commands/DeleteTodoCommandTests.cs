using FluentAssertions;

using Template.Application.TodoUsecases.Commands;

namespace Template.Unit.Tests.Application.TodoUsecases.Commands;

public class DeleteTodoCommandTests
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        var id = 1;

        var command = new DeleteTodoCommand(id);

        command.Id.Should().Be(id);
    }
}