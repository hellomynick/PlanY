using PlanY.Domain.Entities;

namespace PlanY.UseCase.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> GetUserByIdAsync(Guid id);
    Task<List<User>?> GetListUserAsync();
}