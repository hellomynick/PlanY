using FluentValidation;
using PlanY.Infrastructure.Extensions;
using PlanY.Presentation.CQRS.Commands.DailyPlanCommand;
using PlanY.Presentation.CQRS.Commands.TravelPlanCommand;
using PlanY.Presentation.CQRS.Queries;
using PlanY.Presentation.Validators;
using PlanY.UseCase.Extensions;

namespace PlanY.Presentation.Extensions;

public static class PresentationExtension
{
    public static void AddPresentationLayer(this IServiceCollection serviceCollection, ConfigurationManager builder)
    {
        serviceCollection.AddInfrastructureLayer(builder.GetConnectionString("PlanYDb"));
        serviceCollection.AddUseCaseLayer();

        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining(typeof(Program));
        });

        //service
        serviceCollection.AddTransient<IUserQuery, UserQuery>();

        //validator
        serviceCollection.AddSingleton<IValidator<CreateDailyPlanCommand>, CreateDailyPlanValidator>();
        serviceCollection.AddSingleton<IValidator<CreateTravelPlanCommand>, CreateTravelPlanValidator>();
    }
}