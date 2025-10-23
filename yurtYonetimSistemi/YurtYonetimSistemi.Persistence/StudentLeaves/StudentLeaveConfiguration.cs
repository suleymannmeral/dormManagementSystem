using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Persistence;

public class StudentLeaveConfiguration : IEntityTypeConfiguration<StudentLeave>
{
    public void Configure(EntityTypeBuilder<StudentLeave> builder)
    {
        builder.HasKey(sl => sl.Id);
        builder.Property(sl => sl.Reason)
               .IsRequired()
               .HasMaxLength(500);
        builder.Property(sl => sl.Status).IsRequired();
        builder.Property(sl => sl.RequestDate)
               .IsRequired();
        builder.Property(sl => sl.StartDate)
               .IsRequired();
        builder.Property(sl => sl.EndDate)
               .IsRequired();

        builder.HasOne(sl => sl.Student)
                .WithMany(s => s.StudentLeaves)
                .HasForeignKey(sl => sl.StudentId)
                .OnDelete(DeleteBehavior.Cascade); // When a Student is deleted, their leaves are also deleted
    }
}
