using Ardalis.Specification;

namespace Template.Domain.Todos.Specifications;

public class GetTodoByIdSpecification : Specification<Todo> { 
    public GetTodoByIdSpecification(int id)
    {
        Query.Where(w => w.Id == id);
    }
}