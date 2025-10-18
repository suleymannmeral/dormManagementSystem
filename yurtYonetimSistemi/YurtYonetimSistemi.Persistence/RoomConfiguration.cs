using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomNumber)
            .IsRequired() 
            .HasMaxLength(10); 

        builder.HasIndex(r => r.RoomNumber)
            .IsUnique();

        builder.Property(r => r.Capacity)
            .IsRequired();

        builder.Property(r => r.IsAvailable)
            .IsRequired();


    }
}