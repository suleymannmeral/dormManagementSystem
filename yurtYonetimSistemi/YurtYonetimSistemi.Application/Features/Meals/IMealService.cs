namespace YurtYonetimSistemi.Application.Features.Meals;

public  interface IMealService
{
    Task<ServiceResult<MealDto>> GetByIdAsync(int id);
}
