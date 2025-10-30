using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features.Meals.Create;
public record CreateMealRequest(string Name,MealType Type,int MenuId);
