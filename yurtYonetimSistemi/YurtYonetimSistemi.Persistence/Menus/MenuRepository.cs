using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.Menus;

public class MenuRepository(AppDbContext context): GenericRepository<Menu, int>(context), IMenuRepository
{
}
