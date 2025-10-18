using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Persistence;

public class FaultConfiguration : IEntityTypeConfiguration<Fault>
{
    public void Configure(EntityTypeBuilder<Fault> builder)
    {
       builder.HasKey(f => f.Id);
       builder.Property(f => f.Title).IsRequired().HasMaxLength(60);
       builder.Property(f => f.Description).IsRequired().HasMaxLength(500);

        builder.HasOne(f => f.Student)
            .WithMany()          
            .HasForeignKey(f => f.StudentId)
            .IsRequired() 
            .OnDelete(DeleteBehavior.Restrict); // İlişkili öğrenci silindiğinde Fault kaydının silinmesini engeller

        builder.HasOne(f => f.Room) 
            .WithMany() 
            .HasForeignKey(f => f.RoomId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
