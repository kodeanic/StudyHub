using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class SubworkConfiguration : IEntityTypeConfiguration<Subwork>
{
    public void Configure(EntityTypeBuilder<Subwork> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(LengthConstant.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Status).HasMaxLength(LengthConstant.Name).IsRequired();

        builder.HasOne(s => s.Work)
            .WithMany(w => w.Subworks)
            .HasForeignKey(s => s.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
