using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Meals.Create;
using YurtYonetimSistemi.Application.Features.Meals.Update;
using YurtYonetimSistemi.Domain.Entities;

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

    public async Task<ServiceResult> UpdateAsync(int id, UpdateMealRequest request)
    {
        var meal = await mealRepository.GetByIdAsync(id);

        if (meal is null)
        {
            return ServiceResult.Fail("Meal not found", HttpStatusCode.NotFound);
        }
        meal.Name = request.Name;
        meal.Type = request.Type;
        meal.MenuId = request.MenuId;

        mealRepository.Update(meal);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();

    }

    }
