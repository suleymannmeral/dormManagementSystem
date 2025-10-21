

using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence;

public class StaffRepository(AppDbContext context): GenericRepository<Staff, int>(context), IStaffRepository
{
}
