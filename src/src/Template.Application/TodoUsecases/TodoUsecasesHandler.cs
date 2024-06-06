using MediatR;

using Template.Application.TodoUsecases.Commands;
using Template.Application.TodoUsecases.Queries;
using Template.Domain.Shared.Interfaces;
using Template.Domain.Todos;

namespace Template.Application.TodoUsecases;

public class TodoUsecasesHandler(IRepository<Todo> repository) :
    IRequestHandler<FetchTodosQuery, IEnumerable<Todo>>,
    IRequestHandler<GetTodoByIdQuery, Todo>,
    IRequestHandler<CreateTodoCommand, Todo>,
    IRequestHandler<UpdateTodoCommand>,
    IRequestHandler<DeleteTodoCommand>
{
    private readonly IRepository<Todo> _repository = repository;

    public async Task<IEnumerable<Todo>> Handle(FetchTodosQuery request, CancellationToken cancellationToken)
    {
        return await _repository.FetchAsync(request.ToSpecification(), cancellationToken);
    }

    public async Task<Todo> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAsync(request.ToSpecification(), cancellationToken);
    }

    public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(request.ToEntity(), cancellationToken);
    }

    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.ToEntity(), cancellationToken);
    }

    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
    }
}
