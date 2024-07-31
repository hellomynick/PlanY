using Microsoft.EntityFrameworkCore;
using PlanY.Domain.Entities;
using PlanY.Infrastructure.EntityTypeConfigurations;
using PlanY.Infrastructure.Idempotency;

namespace PlanY.Infrastructure;

public class PlanYDbContext : DbContext
{
    public DbSet<DailyPlan> DailyPlans { get; set; }
    public DbSet<TravelPlan> TravelPlans { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ClientRequest> ClientRequests { get; set; }

    public PlanYDbContext(DbContextOptions<PlanYDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("planY");
        modelBuilder.ApplyConfiguration(new DailyPlanBaseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TravelPlanBaseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }
}