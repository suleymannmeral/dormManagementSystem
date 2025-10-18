using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Type)
            .IsRequired();

        builder.HasOne(m => m.Menu)
            .WithMany(mn => mn.Meals)
            .HasForeignKey(m => m.MenuId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
