using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.HasOne(l => l.SubjectToGroup)
            .WithMany(s => s.Links)
            .HasForeignKey(l => l.SubjectToGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
