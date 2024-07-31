using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanY.Infrastructure.Idempotency;

namespace PlanY.Infrastructure.EntityTypeConfigurations;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<ClientRequest>
{
    public void Configure(EntityTypeBuilder<ClientRequest> builder)
    {
        builder.ToTable("requests");
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Time).IsRequired();
    }
}