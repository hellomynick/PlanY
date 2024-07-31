using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanY.Domain.Entities;

namespace PlanY.Infrastructure.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");
        builder.Property(u => u.IdentityGuid).IsRequired();
        builder.Property(u => u.Name).IsRequired();
    }
}