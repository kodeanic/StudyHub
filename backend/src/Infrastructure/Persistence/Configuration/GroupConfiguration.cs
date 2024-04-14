using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(LengthConstant.Name).IsRequired();

        builder.HasOne(g => g.University)
            .WithMany(u => u.Groups)
            .HasForeignKey(g => g.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
