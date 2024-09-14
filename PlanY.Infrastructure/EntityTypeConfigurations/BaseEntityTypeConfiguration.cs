using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanY.Domain.Concreted;

namespace PlanY.Infrastructure.EntityTypeConfigurations;

public abstract class BaseEntityTypeConfiguration<T, TId> : IEntityTypeConfiguration<T>
    where T : BaseEntity<TId>
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.DateCreated);
        builder.Property(b => b.DateUpdated);
    }
}