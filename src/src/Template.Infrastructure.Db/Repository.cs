using System.Collections.Immutable;

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using Template.Domain.Shared.Abstractions;
using Template.Domain.Shared.Exceptions;
using Template.Domain.Shared.Interfaces;

namespace Template.Infrastructure.Db;

public class Repository<T>(ApplicationContext context) : IRepository<T> where T : Entity
{
    private readonly ApplicationContext _context = context;

    public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().WithSpecification(specification).AsNoTracking().CountAsync(cancellationToken);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var result = await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(w => w.Id == id, cancellationToken) ?? throw new EntityNotFoundException(typeof(T), id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FetchAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().WithSpecification(specification).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T> GetAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().WithSpecification(specification).AsNoTracking().FirstOrDefaultAsync(cancellationToken) ?? throw new EntityNotFoundException(typeof(T));
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
