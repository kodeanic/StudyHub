using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class SubjectToTeacherConfiguration : IEntityTypeConfiguration<SubjectToTeacher>
{
    public void Configure(EntityTypeBuilder<SubjectToTeacher> builder)
    {
        builder.HasKey(s => new { s.SubjectId, s.TeacherId });

        builder.HasOne(s => s.Subject)
            .WithMany(u => u.SubjectToTeachers)
            .HasForeignKey(g => g.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Teacher)
            .WithMany(u => u.SubjectToTeachers)
            .HasForeignKey(g => g.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
