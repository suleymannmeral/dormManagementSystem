using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

}
