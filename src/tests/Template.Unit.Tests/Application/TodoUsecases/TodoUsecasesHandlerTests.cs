using Moq;

using Template.Application.TodoUsecases;
using Template.Application.TodoUsecases.Commands;
using Template.Application.TodoUsecases.Queries;
using Template.Domain.Shared.Interfaces;
using Template.Domain.Todos;
using Template.Domain.Todos.Specifications;

namespace Template.Unit.Tests.Application.TodoUsecases;

public class TodoUsecasesHandlerTests
{
    [Fact]
    public void Given_CallingWithFetchQuery_Then_RepositoryFetchShouldBeCalledWithFetchSpecification()
    {
        var repository = new Mock<IRepository<Todo>>();
        var handler = new TodoUsecasesHandler(repository.Object);
        var query = new FetchTodosQuery(1, 20);
        var cancellationToken = new CancellationToken();

        _ = handler.Handle(query, cancellationToken);

        repository.Verify(x => x.FetchAsync(It.IsAny<FetchTodosSpecification>(), cancellationToken), Times.Once());
    }

    [Fact]
    public void Given_CallingWithGetByIdQuery_Then_RepositoryGetShouldBeCalledWithGetByIdSpecification()
    {
        var repository = new Mock<IRepository<Todo>>();
        var handler = new TodoUsecasesHandler(repository.Object);
        var query = new GetTodoByIdQuery(99);
        var cancellationToken = new CancellationToken();

        _ = handler.Handle(query, cancellationToken);

        repository.Verify(x => x.GetAsync(It.IsAny<GetTodoByIdSpecification>(), cancellationToken), Times.Once());
    }

    [Fact]
    public void Given_CallingWithCreateCommand_Then_RepositoryCreateShouldBeCalledWithEntity()
    {
        var repository = new Mock<IRepository<Todo>>();
        var handler = new TodoUsecasesHandler(repository.Object);
        var command = new CreateTodoCommand("title", "description");
        var cancellationToken = new CancellationToken();

        _ = handler.Handle(command, cancellationToken);

        repository.Verify(x => x.CreateAsync(It.IsAny<Todo>(), cancellationToken), Times.Once());
    }

    [Fact]
    public void Given_CallingWithUpdateCommand_Then_RepositoryUpdateShouldBeCalledWithEntity()
    {
        var repository = new Mock<IRepository<Todo>>();
        var handler = new TodoUsecasesHandler(repository.Object);
        var command = new UpdateTodoCommand(99, "title", "description");
        var cancellationToken = new CancellationToken();

        _ = handler.Handle(command, cancellationToken);

        repository.Verify(x => x.UpdateAsync(It.IsAny<Todo>(), cancellationToken), Times.Once());
    }

    [Fact]
    public void Given_CallingWithDeleteCommand_Then_RepositoryDeleteShouldBeCalledWithId()
    {
        var repository = new Mock<IRepository<Todo>>();
        var handler = new TodoUsecasesHandler(repository.Object);
        var id = 7;
        var command = new DeleteTodoCommand(id);
        var cancellationToken = new CancellationToken();

        _ = handler.Handle(command, cancellationToken);

        repository.Verify(x => x.DeleteAsync(id, cancellationToken), Times.Once());
    }
}