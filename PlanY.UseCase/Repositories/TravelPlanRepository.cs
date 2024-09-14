using Microsoft.EntityFrameworkCore;
using PlanY.Domain.Entities;
using PlanY.Infrastructure;
using PlanY.Infrastructure.UnitOfWork;

namespace PlanY.UseCase.Repositories;

public class TravelPlanRepository : ITravelPlanRepository
{
    private readonly PlanYDbContext _dbContext;
    public IUnitOfWork UnitOfWork => _dbContext;

    public TravelPlanRepository(PlanYDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TravelPlan> AddAsync(TravelPlan item)
    {
        var itemAdded = await _dbContext.TravelPlans.AddAsync(item);
        return itemAdded.Entity;
    }

    public TravelPlan Update(TravelPlan item)
    {
        return _dbContext.TravelPlans.Update(item).Entity;
    }

    public TravelPlan Delete(TravelPlan item)
    {
        return _dbContext.TravelPlans.Remove(item).Entity;
    }

    public async Task<TravelPlan?> FindByIdAsync(long id)
    {
        return await _dbContext.TravelPlans.FindAsync(id);
    }

    public async Task<List<TravelPlan>> FindListAsync()
    {
        return await _dbContext.TravelPlans.ToListAsync();
    }
}