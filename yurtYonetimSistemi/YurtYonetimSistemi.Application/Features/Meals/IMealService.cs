using YurtYonetimSistemi.Application.Features.Meals.Create;
using YurtYonetimSistemi.Application.Features.Meals.Update;

namespace YurtYonetimSistemi.Application.Features.Meals;

public  interface IMealService
{
    Task<ServiceResult<MealDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateMealResponse>> CreateAsync(CreateMealRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateMealRequest request);
}
