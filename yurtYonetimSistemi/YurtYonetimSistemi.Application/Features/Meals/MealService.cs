using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Meals;

public  class MealService(IMealRepository mealRepository,
    IUnitOfWork unitOfWork):IMealService
{

    public async Task<ServiceResult<MealDto>> GetMealByIdAsync(int id)
    {
        var meal = await mealRepository.GetByIdAsync(id);

        // Check if meal exists

        if (meal is null)
        {
            return ServiceResult<MealDto>.Fail("Meal not found",HttpStatusCode.NotFound);
        }

        // Map Meal to MealDto (Manual mapping)

        var mealDto = new MealDto(
            meal.Id,
            meal.Name,
            meal.Type,
            meal.MenuId
        );
        return ServiceResult<MealDto>.Success(mealDto);
    }
}
