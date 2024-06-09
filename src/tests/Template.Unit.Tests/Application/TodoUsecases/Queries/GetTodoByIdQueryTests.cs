using FluentAssertions;

using Template.Application.TodoUsecases.Queries;
using Template.Domain.Todos.Specifications;

namespace Template.Unit.Tests.Application.TodoUsecases.Query;

public class GetTodoByIdQueryTests
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        var id = 1;

        var query = new GetTodoByIdQuery(id);

        query.Id.Should().Be(id);
    }

    [Fact]
    public void Given_Query_When_ToSpecificationCalled_Then_SpecificationShouldBeReturned() {
        var query = new GetTodoByIdQuery(1);

        var specification = query.ToSpecification();

        specification.Should().BeOfType<GetTodoByIdSpecification>();
    }
}