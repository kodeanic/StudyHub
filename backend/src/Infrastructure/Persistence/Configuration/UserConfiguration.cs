using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Login).HasMaxLength(LengthConstant.Name).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(LengthConstant.Name).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(LengthConstant.Name).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(LengthConstant.Name).IsRequired();
        builder.Property(x => x.Patronymic).HasMaxLength(LengthConstant.Name).IsRequired();

        builder.HasIndex(x => x.Login).IsUnique();
    }
}
