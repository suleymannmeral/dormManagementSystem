using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Date)
            .IsRequired();

        builder.Property(m => m.MealTime)
            .IsRequired()
            .HasMaxLength(50);
    }
}
