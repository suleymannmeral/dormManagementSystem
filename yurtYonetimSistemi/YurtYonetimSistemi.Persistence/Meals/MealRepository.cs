using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.Meals;

public class MealRepository(AppDbContext context): GenericRepository<Meal, int>(context), IMealRepository
{
}
