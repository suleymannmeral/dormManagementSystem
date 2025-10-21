using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

public class FaultConfiguration : IEntityTypeConfiguration<Fault>
{
    public void Configure(EntityTypeBuilder<Fault> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(f => f.Student)         
            .WithMany(s => s.Faults)
            .HasForeignKey(f => f.StudentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Room)
            .WithMany(r => r.Faults)
            .HasForeignKey(f => f.RoomId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

       
    }
}
