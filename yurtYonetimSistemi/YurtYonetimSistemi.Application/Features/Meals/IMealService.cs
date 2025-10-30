using YurtYonetimSistemi.Application.Features.Meals.Create;

namespace YurtYonetimSistemi.Application.Features.Meals;

public  interface IMealService
{
    Task<ServiceResult<MealDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateMealResponse>> CreateAsync(CreateMealRequest request);
}
