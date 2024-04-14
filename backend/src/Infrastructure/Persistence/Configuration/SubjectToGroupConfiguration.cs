using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class SubjectToGroupConfiguration : IEntityTypeConfiguration<SubjectToGroup>
{
    public void Configure(EntityTypeBuilder<SubjectToGroup> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(s => new { s.SubjectId, s.GroupId }).IsUnique();

        builder.HasOne(s => s.Subject)
            .WithMany(u => u.SubjectToGroups)
            .HasForeignKey(g => g.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Group)
            .WithMany(u => u.SubjectToGroups)
            .HasForeignKey(g => g.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
