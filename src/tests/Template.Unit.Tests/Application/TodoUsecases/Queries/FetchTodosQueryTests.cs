using FluentAssertions;

using Template.Application.TodoUsecases.Queries;
using Template.Domain.Todos.Specifications;

namespace Template.Unit.Tests.Application.TodoUsecases.Query;

public class FetchTodoQueryTest
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        uint page = 0;
        ushort size = 10;

        var query = new FetchTodosQuery(page, size);

        query.Page.Should().Be(page);
        query.Size.Should().Be(size);
    }

    [Fact]
    public void Given_Query_When_ToSpecificationCalled_Then_SpecificationShouldBeReturned() {
        var query = new FetchTodosQuery(1,20);

        var specification = query.ToSpecification();

        specification.Should().BeOfType<FetchTodosSpecification>();
    }
}