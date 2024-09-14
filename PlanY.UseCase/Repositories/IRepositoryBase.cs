using PlanY.Infrastructure.UnitOfWork;

namespace PlanY.UseCase.Repositories;

public interface IRepositoryBase<T>
{
    IUnitOfWork UnitOfWork { get; }

    Task<T?> AddAsync(T item);
    T Update(T item);
    T Delete(T item);
}