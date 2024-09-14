using Microsoft.EntityFrameworkCore;
using PlanY.Domain.Entities;
using PlanY.Infrastructure;
using PlanY.Infrastructure.UnitOfWork;

namespace PlanY.UseCase.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PlanYDbContext _dbContext;

    public UserRepository(PlanYDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IUnitOfWork UnitOfWork => _dbContext;

    public async Task<User?> AddAsync(User item)
    {
        var userAdded = await _dbContext.Users.AddAsync(item);
        return userAdded.Entity;
    }

    public User Update(User item)
    {
        throw new NotImplementedException();
    }

    public User Delete(User item)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<List<User>?> GetListUserAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }
}