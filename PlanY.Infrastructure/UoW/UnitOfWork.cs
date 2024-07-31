using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace PlanY.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly PlanYDbContext _context;
    private IDbContextTransaction? _currentTransaction;
    public bool HasActiveTransaction => _currentTransaction != null;

    public UnitOfWork(PlanYDbContext context)
    {
        _context = context;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            await DisposeTransactionAsync();
            throw new Exception("Transaction is started");
        }

        return _currentTransaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public IDbContextTransaction GetCurrentTransaction()
    {
        if (!HasActiveTransaction) throw new Exception("Null Transaction");
        return _currentTransaction;
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

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        if (HasActiveTransaction) await _currentTransaction.RollbackAsync();
    }

    public async Task DisposeTransactionAsync()
    {
        await _currentTransaction.DisposeAsync();
    }
}