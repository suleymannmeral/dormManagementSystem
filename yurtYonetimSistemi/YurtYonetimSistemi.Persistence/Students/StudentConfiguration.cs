using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Department)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.University)
            .IsRequired() 
            .HasMaxLength(200);

        builder.HasOne(s => s.Room) 
            .WithMany(r => r.Students)
            .HasForeignKey(s => s.RoomId) 
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


    }
}