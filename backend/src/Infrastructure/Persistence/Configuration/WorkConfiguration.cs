using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(LengthConstant.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.HasOne(w => w.Student)
            .WithMany(s => s.Works)
            .HasForeignKey(w => w.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Subject)
            .WithMany(s => s.Works)
            .HasForeignKey(w => w.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
