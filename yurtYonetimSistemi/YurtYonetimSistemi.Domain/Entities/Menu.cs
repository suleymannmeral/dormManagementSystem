using YurtYonetimSistemi.Domain.Entities.Common;

namespace YurtYonetimSistemi.Domain.Entities;

public sealed class Menu:BaseEntity<int>
{
    public DateTime Date { get; set; }
    public string MealTime { get; set; } = null!; // Breakfast, Lunch, Dinner
    public ICollection<Meal> Meals { get; set; } = new List<Meal>();
}
