using YurtYonetimSistemi.Application.Features.Meals;

namespace YurtYonetimSistemi.Application.Features.Menus;

public record MenuDto(
    int Id,
    DateTime Date,
    string MealTime,
    List<MealDto> Meals
);

