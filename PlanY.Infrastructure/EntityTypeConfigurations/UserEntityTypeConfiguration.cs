using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanY.Domain.Entities;

namespace PlanY.Infrastructure.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User, Guid>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");
        builder.Property(u => u.IdentityGuid).IsRequired();
        builder.Property(u => u.Name).IsRequired();
        builder.HasMany(u => u.DailyPlans).WithOne(dp => dp.User).HasForeignKey(dp => dp.UserId);
        builder.HasMany(u => u.TravelPlans).WithOne(tp => tp.User).HasForeignKey(tp => tp.UserId);
    }
}