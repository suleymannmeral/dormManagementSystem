using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Persistence.Dorms;

public class DormConfiguration : IEntityTypeConfiguration<Dorm>
{
    public void Configure(EntityTypeBuilder<Dorm> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.PhoneNumber).HasMaxLength(11).HasColumnType("varchar(11)");
        builder.Property(d => d.Address).IsRequired().HasMaxLength(300);
        builder.Property(d => d.Email).IsRequired().HasMaxLength(100);
    }
}
