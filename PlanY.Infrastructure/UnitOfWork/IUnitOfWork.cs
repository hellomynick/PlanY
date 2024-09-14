using Microsoft.EntityFrameworkCore.Storage;

namespace PlanY.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync();
    Task DisposeTransactionAsync();
}