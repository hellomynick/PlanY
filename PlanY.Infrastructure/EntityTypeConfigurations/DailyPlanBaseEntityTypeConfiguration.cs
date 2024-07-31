using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanY.Domain.Entities;

namespace PlanY.Infrastructure.EntityTypeConfigurations;

public class DailyPlanBaseEntityTypeConfiguration : BaseEntityTypeConfiguration<DailyPlan>
{
    public override void Configure(EntityTypeBuilder<DailyPlan> builder)
    {
        base.Configure(builder);

        builder.ToTable("dailyPlans");
        builder.Property(dP => dP.NamePlan).IsRequired();
        builder.Property(dP => dP.Price).IsRequired();
        builder.Property(dP => dP.Date).IsRequired();
        builder.Property(dP => dP.Detail);
    }
}