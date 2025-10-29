namespace YurtYonetimSistemi.Application.Features.Meals;

public  interface IMealService
{
    Task<ServiceResult<MealDto>> GetMealByIdAsync(int id);
}
