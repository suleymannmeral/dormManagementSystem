using YurtYonetimSistemi.Domain.Entities.Common;
using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Domain.Entities;

public sealed class Meal:BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public MealType Type { get; set; } // soup, main course, dessert, etc.
    public int MenuId { get; set; } // Foreign Key to Menu
    public Menu Menu { get; set; } = null!;
}
