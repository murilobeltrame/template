using Ardalis.Specification;

using Template.Domain.Shared.Abstractions;

namespace Template.Domain.Shared.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> FetchAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

        Task<T> GetAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

        Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
