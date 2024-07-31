using PlanY.Domain.Entities;

namespace PlanY.UseCase.Repositories;

public interface IDailyPlanRepository : IRepositoryBase<DailyPlan>
{
    Task<DailyPlan?> FindByIdAsync(long id);
    Task<List<DailyPlan?>> FindListAsync();
}