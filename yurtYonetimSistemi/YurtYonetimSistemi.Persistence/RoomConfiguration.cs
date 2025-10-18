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

        builder.HasMany(r => r.Students) 
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId) 
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasMany(r => r.Faults) 
            .WithOne(f => f.Room) 
            .HasForeignKey(f => f.RoomId) 
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); 
    }
}