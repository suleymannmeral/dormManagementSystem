using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Persistence;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
       builder.HasKey(m => m.Id);
       builder.Property(m => m.Date).IsRequired();

        builder.HasMany(m=>m.Meals)
            .WithOne(meal=>meal.Menu)
            .HasForeignKey(meal=>meal.MenuId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
