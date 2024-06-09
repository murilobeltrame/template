using Ardalis.Specification;

namespace Template.Domain.Todos.Specifications;

public class FetchTodosSpecification : Specification<Todo> { 
    public FetchTodosSpecification(uint page, ushort size)
    {
        Query.Skip((int)page * size).Take(size);
    }
}