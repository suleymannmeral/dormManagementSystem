using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features.Meals.Update;

public record UpdateMealRequest(string Name,MealType Type,int MenuId);

