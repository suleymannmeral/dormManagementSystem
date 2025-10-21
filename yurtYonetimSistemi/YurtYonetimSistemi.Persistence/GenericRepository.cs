

using System.Linq.Expressions;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities.Common;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence;

public class GenericRepository<T, TId>(AppDbContext context) : IGenericRepository<T, TId> where T : BaseEntity<TId> where TId : struct
{
    public ValueTask AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public ValueTask<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
