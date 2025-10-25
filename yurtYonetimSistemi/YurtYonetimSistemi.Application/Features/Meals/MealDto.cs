using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features;

public record MealDto(
    int Id,
    string Name,
    MealType Type,
    int MenuId
);





