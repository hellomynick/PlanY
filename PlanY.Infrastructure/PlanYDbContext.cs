using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PlanY.Domain.Entities;
using PlanY.Infrastructure.EntityTypeConfigurations;
using PlanY.Infrastructure.Idempotency;
using PlanY.Infrastructure.UnitOfWork;

namespace PlanY.Infrastructure;

public class PlanYDbContext : DbContext, IUnitOfWork
{
    private IDbContextTransaction? _currentTransaction;

    public PlanYDbContext(DbContextOptions<PlanYDbContext> options) : base(options)
    {
    }

    public bool HasActiveTransaction => _currentTransaction != null;

    public DbSet<DailyPlan> DailyPlans { get; set; }
    public DbSet<TravelPlan> TravelPlans { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ClientRequest> ClientRequests { get; set; }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            await DisposeTransactionAsync();
            throw new Exception("Transaction is started");
        }

        return _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTransactionAsync()
    {
        if (HasActiveTransaction)
            try
            {
                await SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch (Exception e)
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (HasActiveTransaction) await DisposeTransactionAsync();
                _currentTransaction = null;
            }
    }

    public async Task RollbackTransactionAsync()
    {
        if (HasActiveTransaction) await _currentTransaction.RollbackAsync();
    }

    public async Task DisposeTransactionAsync()
    {
        await _currentTransaction.DisposeAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("planY");
        modelBuilder.ApplyConfiguration(new DailyPlanBaseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TravelPlanBaseEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }

    public IDbContextTransaction GetCurrentTransaction()
    {
        if (!HasActiveTransaction) throw new Exception("Null Transaction");
        return _currentTransaction;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
        return true;
    }
}