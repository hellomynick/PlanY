using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlanY.Infrastructure.Idempotency;

namespace PlanY.Infrastructure.Extensions;

public static class InfrastructureExtension
{
    public static void AddInfrastructureLayer(this IServiceCollection services, string? connectionString)
    {
        services.AddTransient<IRequestManager, RequestManager>();

        if (string.IsNullOrEmpty(connectionString)) throw new Exception("Connection string cannot null");
        services.AddDbContext<PlanYDbContext>(options =>
            options.UseNpgsql(connectionString, action => { action.MigrationsAssembly("PlanY.Infrastructure"); }));
    }
}