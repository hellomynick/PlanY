using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanY.Domain.Entities;

namespace PlanY.Infrastructure.EntityTypeConfigurations;

public class TravelPlanBaseEntityTypeConfiguration : BaseEntityTypeConfiguration<TravelPlan, long>
{
    public override void Configure(EntityTypeBuilder<TravelPlan> builder)
    {
        base.Configure(builder);

        builder.ToTable("travelPlans");
        builder.Property(tP => tP.UserId).IsRequired();
        builder.Property(tP => tP.Detail);
        builder.Property(tP => tP.Location);
        builder.Property(tP => tP.NamePlan).IsRequired();
        builder.Property(tP => tP.Expense).IsRequired();
        builder.Property(tP => tP.DateFrom).IsRequired();
        builder.Property(tP => tP.DateTo).IsRequired();
    }
}