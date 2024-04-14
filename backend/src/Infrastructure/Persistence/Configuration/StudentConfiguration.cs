using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<User>(u => u.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
