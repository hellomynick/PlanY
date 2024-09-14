using PlanY.Domain.Entities;

namespace PlanY.UseCase.Repositories;

public interface ITravelPlanRepository : IRepositoryBase<TravelPlan>
{
    Task<TravelPlan?> FindByIdAsync(long id);
    Task<List<TravelPlan>> FindListAsync();
}