using Microsoft.EntityFrameworkCore.Storage;

namespace PlanY.Infrastructure.UoW;

public interface IUnitOfWork
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task SaveChangesAsync();
    Task RollbackTransactionAsync();
    Task DisposeTransactionAsync();
}