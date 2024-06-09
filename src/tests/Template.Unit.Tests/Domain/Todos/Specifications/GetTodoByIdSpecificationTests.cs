using FluentAssertions;

using Template.Domain.Todos.Specifications;

namespace Template.Unit.Tests.Domain.Todos.Specification;

public class GetTodoByIdSpecificationTests
{
    [Fact]
    public void When_Instantiating_With_Valid_Args_Then_Should_Be_Instantiated()
    {
        var specification = new GetTodoByIdSpecification(1);
        specification.WhereExpressions.Should().ContainSingle();
    }
}