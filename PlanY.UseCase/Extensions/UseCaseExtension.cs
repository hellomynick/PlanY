using Microsoft.Extensions.DependencyInjection;
using PlanY.UseCase.Repositories;

namespace PlanY.UseCase.Extensions;

public static class UseCaseExtension
{
    public static void AddUseCaseLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDailyPlanRepository, DailyPlanRepository>();
        serviceCollection.AddScoped<ITravelPlanRepository, TravelPlanRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
    }
}