using PlanY.Domain.Entities;

namespace PlanY.UseCase.Repositories;

public interface IRepositoryBase<T>
    where T : BaseEntity
{
    Task AddAsync(T item);
    Task UpdateAsync(T item);
    Task<T> DeleteAsync(long id);
}