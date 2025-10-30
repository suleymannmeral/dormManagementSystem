using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Faults.Create;
using YurtYonetimSistemi.Application.Features.Meals.Create;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features.Meals;

public  class MealService(IMealRepository mealRepository,
    IUnitOfWork unitOfWork):IMealService
{

    public async Task<ServiceResult<MealDto>> GetByIdAsync(int id)
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
    public async Task<ServiceResult<CreateMealResponse>> CreateAsync(CreateMealRequest request)
    {
        // Create new Meal entity manually
        var meal = new Meal()
        {
           Name = request.Name,
           Type = request.Type,
           MenuId = request.MenuId
        };

        await mealRepository.AddAsync(meal);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateMealResponse>.Success(new CreateMealResponse(meal.Id));
    }



}
