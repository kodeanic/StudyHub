using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(t => t.User)
            .WithOne(u => u.Teacher)
            .HasForeignKey<User>(u => u.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.University)
            .WithMany(u => u.Teachers)
            .HasForeignKey(t => t.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Comments)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
