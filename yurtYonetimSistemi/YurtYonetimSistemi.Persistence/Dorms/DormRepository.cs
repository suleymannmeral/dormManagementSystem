
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence;

public class DormRepository(AppDbContext context): GenericRepository<Dorm, int>(context), IDormRepository
{
}
