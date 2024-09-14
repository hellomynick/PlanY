using Microsoft.EntityFrameworkCore;
using PlanY.Domain.Entities;
using PlanY.Infrastructure;
using PlanY.Infrastructure.UnitOfWork;

namespace PlanY.UseCase.Repositories;

public class DailyPlanRepository : IDailyPlanRepository
{
    private readonly PlanYDbContext _context;
    public IUnitOfWork UnitOfWork => _context;
    
    public DailyPlanRepository(PlanYDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<DailyPlan> AddAsync(DailyPlan item)
    {
        var itemAdded = await _context.DailyPlans.AddAsync(item);
        return itemAdded.Entity;
    }

    public DailyPlan Update(DailyPlan item)
    {
        return _context.DailyPlans.Update(item).Entity;
    }

    public DailyPlan Delete(DailyPlan item)
    {
        return _context.DailyPlans.Remove(item).Entity;
    }

    public async Task<DailyPlan?> FindByIdAsync(long id)
    {
       return await _context.DailyPlans.FindAsync(id);
    }

    public async Task<List<DailyPlan>> FindListAsync()
    {
        var listItem = await _context.DailyPlans.ToListAsync();
        return listItem;
    }
}